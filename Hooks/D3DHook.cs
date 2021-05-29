using BotTemplate.Managers;
using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotTemplate.Hooks
{
    internal static class D3DHook
  {
        #region Fields

        // Offsets
        private static uint DX_DEVICE = 0xC5DF88;
        private static uint DX_DEVICE_IDX = 0x397C;
        private static uint ENDSCENE_IDX = 0xA8;

        private static uint ENDSCENE_WRITE_POS = 0x2;
        private static uint ENDSCENE_RETURN_POS = 0x7;
        private static uint ORIGINAL_INSTRUCTION_OFFSET = 0x1FA79;

        // Memory Adresses
        private static uint _deviceAdress;
        private static uint _endAdress;
        private static uint _sceneAdress;
        private static uint _endSceneAdress;
        private static uint _hookLoopCave = 0;
        private static uint _codeInjectionCave = 0;
        private static uint _returnValueCave;
        private static uint _frameLockFlag;
        private static uint _waitFlag;


        // Other stuff
        private static BlackMagic _memory = MemoryManager.BlackMagic;
        private static string[] _originalAsmInstructions;
        private static object _lock = new object();
        private static bool _hookActive = false;

        #endregion

        #region Constructor

        static D3DHook()
        {
            _memory = MemoryManager.BlackMagic;

            GetEndsceneAdress();
            InitializeFields();
        }

	    #endregion

        #region Properties

        public static bool HookActive
        {
            get
            {
                return _hookActive;
            }
        }

        #endregion

        #region Public Methods

        public static void HookEndscene()
        {
            lock (_lock)
            {
                // check if wow is already hooked
                if (!HookActive)
                {
                   // Console.WriteLine("D3D pEndScene adress: {0:X}", _endSceneAdress);

                    try
                    {
                        // Console.WriteLine("Writing hook to memory...");

                        AllocateAndPrepareMemory();

                        // Generate the STUB to be injected
                        _memory.Asm.Clear();

                        // save regs
                        _memory.Asm.AddLine("pushad");
                        _memory.Asm.AddLine("pushfd");

                        //While Loop Open
                        _memory.Asm.AddLine("@frameLoop:");

                        // save regs
                        _memory.Asm.AddLine("pushad");
                        _memory.Asm.AddLine("pushfd");

                        // IA-32 Wait // DEPRECATED
                        _memory.Asm.AddLine("mov eax, [" + _waitFlag + "]");
                        _memory.Asm.AddLine("test eax, eax");
                        _memory.Asm.AddLine("je @out");

                        // Check if an adress for injection is set
                        _memory.Asm.AddLine("mov eax, " + _codeInjectionCave);
                        _memory.Asm.AddLine("test eax, eax");

                        // if not jump to @out
                        _memory.Asm.AddLine("je @out");

                        // Launch Function:
                        _memory.Asm.AddLine("mov eax, " + _codeInjectionCave);
                        _memory.Asm.AddLine("call eax");

                        // Copie pointer return value
                        _memory.Asm.AddLine("mov [" + _returnValueCave + "], eax");

                        // Set wait flag to zero
                        _memory.Asm.AddLine("mov edx, " + _waitFlag);
                        _memory.Asm.AddLine("mov ecx, 0");
                        _memory.Asm.AddLine("mov [edx], ecx");

                        _memory.Asm.AddLine("@out:");

                        // restore regs
                        _memory.Asm.AddLine("popfd");
                        _memory.Asm.AddLine("popad");

                        _memory.Asm.AddLine("mov eax, [" + _frameLockFlag + "]");
                        _memory.Asm.AddLine("test eax, eax");
                        _memory.Asm.AddLine("je @frameLoop");

                        // restore regs
                        _memory.Asm.AddLine("popfd");
                        _memory.Asm.AddLine("popad");

                        // Execute original Endscene instructions
                        WriteOriginalInstructions();

                        // create jump back stub
                        _memory.Asm.AddLine("jmp " + (_endSceneAdress + ENDSCENE_RETURN_POS));

                        // inject hook loop into memory
                        _memory.Asm.Inject(_hookLoopCave);
                        _memory.Asm.Clear();
                     
                        // Create Jump to hook Loop
                        _memory.Asm.AddLine("jmp " + (_hookLoopCave));
                        _memory.Asm.Inject(_endSceneAdress + ENDSCENE_WRITE_POS);
                        _memory.Asm.Clear();

                        _hookActive = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Asembly: \n" + ex.Message + "\nStackTrace: \n" + ex.StackTrace);
                        return;
                    }
                }
            }
        }

        public static void DisposeEndsceneHook()
        {
            lock (_lock)
            {
                // check if wow is already hooked and dispose Hook
                if (HookActive)
                {
                    DisableFramelock();

                    // Restore original endscene:
                    _memory.Asm.Clear();
                    WriteOriginalInstructions();
                    _memory.Asm.Inject(_endSceneAdress + ENDSCENE_WRITE_POS);

                    // make sure we are in original code
                    Thread.Sleep(10);

                    FreeMemory();

                    _hookActive = false;
                }
            }
        }

        public static void EnableFramelock()
        {
            lock (_lock)
            {
                //Console.WriteLine("Framelock enabled, flag adress: {0:X}", _frameLockFlag);
                if (!HookActive)
                    HookEndscene();

                _memory.WriteInt(_frameLockFlag, 0);
            }
        }

        public static void DisableFramelock()
        {
            lock (_lock)
            {
                //Console.WriteLine("Framelock disabled, flag adress: {0:X}", _frameLockFlag);
                if (!HookActive)
                    HookEndscene();

                _memory.WriteInt(_frameLockFlag, 1);
            }
        }

        public static byte[] InjectAndExecuteAsm(string[] asm, int returnLength = 0, bool requestRetValue = false)
        {
            lock (_lock)
            {
                if (!HookActive)
                    HookEndscene();

                //Console.WriteLine("Injection start...");
                byte[] retVal = new byte[0];

                _memory.Asm.Clear();
                foreach (string tempLineAsm in asm)
                {
                    _memory.Asm.AddLine(tempLineAsm);
                }

                try
                {
                    // Inject
                    _memory.WriteUInt(_returnValueCave, 0);
                    _memory.Asm.Inject(_codeInjectionCave);
                    _memory.WriteInt(_waitFlag, 1);

                    // prevent further execution in case the wait flag
                    // in the hook loop is set
                    while (_memory.ReadInt(_waitFlag) == 1)
                    {
                        // wait
                    }

                    if (requestRetValue)
                    {
                        if (returnLength > 0)
                        {
                            retVal = _memory.ReadBytes(_memory.ReadUInt(_returnValueCave), returnLength);
                        }
                        else
                        {
                            byte Buf = new Byte();
                            List<byte> retnByte = new List<byte>();
                            uint dwAddress = _memory.ReadUInt(_returnValueCave);
                            if (dwAddress != 0)
                            {
                                Buf = _memory.ReadByte(dwAddress);
                                while (Buf != 0)
                                {
                                    retnByte.Add(Buf);
                                    dwAddress = dwAddress + 1;
                                    Buf = _memory.ReadByte(dwAddress);
                                }

                                retVal = retnByte.ToArray();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR1 !! : " + ex.Message + "stack :" + ex.StackTrace); return null;
                }

                //Console.WriteLine("Execution finished");
                //Console.WriteLine("Elapsed milliseconds: " + _stopWatch.Elapsed.TotalMilliseconds + ", elapsed ticks: " + _stopWatch.ElapsedTicks);

                return retVal;
            }
        }

        #endregion

        #region Private

        private static void AllocateAndPrepareMemory()
        {
            // allocate memory to store the hook loop asm code:
            _hookLoopCave = _memory.AllocateMemory(2048);

            // allocate memory for ad hoc code injection:
            _codeInjectionCave = _memory.AllocateMemory(2048);
            _memory.Asm.Clear();
            _memory.Asm.AddLine("retn");
            _memory.Asm.Inject(_codeInjectionCave);

            // allocate memory for return values
            _returnValueCave = _memory.AllocateMemory(0x4);
            _memory.WriteInt(_returnValueCave, 0);

            // allocate memory for framelock flags
            _frameLockFlag = _memory.AllocateMemory(4);
            _waitFlag = _memory.AllocateMemory(4);
            _memory.WriteInt(_frameLockFlag, 1);
            _memory.WriteInt(_waitFlag, 0);
        }

        private static void FreeMemory()
        {
            _memory.FreeMemory(_hookLoopCave);
            _memory.FreeMemory(_codeInjectionCave);
            _memory.FreeMemory(_returnValueCave);
            _memory.FreeMemory(_frameLockFlag);
            _memory.FreeMemory(_waitFlag);
        }

        private static void GetEndsceneAdress()
        {
            _deviceAdress = _memory.ReadUInt(DX_DEVICE);
            _endAdress = _memory.ReadUInt(_deviceAdress + DX_DEVICE_IDX);
            _sceneAdress = _memory.ReadUInt(_endAdress);
            _endSceneAdress = _memory.ReadUInt(_sceneAdress + ENDSCENE_IDX);
        }

        private static void InitializeFields()
        {
            switch (GetWindowsVersion())
            {
                case "6.1":
                    InitializeFieldsForWin7();
                    break;
                case "6.2":
                    InitializeFieldsForWin8Plus();
                    break;
                default:
                    throw new Exception("Your OS is not supported! (" + GetWindowsVersion() + ")");
            }
        }

        private static void InitializeFieldsForWin8Plus()
        {
            ENDSCENE_WRITE_POS = 0x2;
            ENDSCENE_RETURN_POS = 0x7;
            ORIGINAL_INSTRUCTION_OFFSET = 0x1FA79;

            _originalAsmInstructions = new string[1]
            {
                "mov eax, " + (_endSceneAdress + ORIGINAL_INSTRUCTION_OFFSET)
            };
        }

        private static void InitializeFieldsForWin7()
        {
            ENDSCENE_WRITE_POS = 0x0;
            ENDSCENE_RETURN_POS = 0x5;

            _originalAsmInstructions = new string[3]
            {
                "mov edi, edi",
                "push ebp",
                "mov ebp, esp"
            };
        }

        private static void WriteOriginalInstructions()
        {
            foreach (string s in _originalAsmInstructions)
            {
                _memory.Asm.AddLine(s);
            }
        }

        private static String[] CombineStringArrays(String[] array1, String[] array2)
        {
            int array1OriginalLength = array1.Length;
            Array.Resize<String>(ref array1, array1OriginalLength + array2.Length);
            Array.Copy(array2, 0, array1, array1OriginalLength, array2.Length);
            return array1;
        }

        private static string GetWindowsVersion()
        {
            return string.Format("{0}.{1}", Environment.OSVersion.Version.Major,
                Environment.OSVersion.Version.Minor);
        }

        #endregion
    }
}
