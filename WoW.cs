using BotTemplate.BO;
using BotTemplate.Constants;
using BotTemplate.Helper;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using BotTemplate.WoWObjects;
using Magic;
using System;
using System.Text;
using UserApi;

namespace BotTemplate
{
    internal static class WoW
    {
        #region Fields

        private static BlackMagic _wow = MemoryManager.BlackMagic;
        private static LocalPlayer _localPlayer;

        #endregion

        #region Constructors

        static WoW()
        {

        }

	    #endregion

        #region Properties

        #region Core Specific

        internal static uint Playerbase
        {
            get
            {
                try
                {
                    return MemoryManager.BlackMagic.ReadUInt(_wow.ReadUInt(_wow.ReadUInt((uint)Offsets.Globals.PlayerBase) + 0x34) + 0x24);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        internal static LocalPlayer LocalPlayer
        {
            get
            {
                if (_localPlayer == null && Online)
                    _localPlayer = new LocalPlayer();

                return _localPlayer;
            }
        }

        #endregion

        internal static uint BgStatus
        {
            get
            {
                return _wow.ReadUInt((uint)Offsets.Globals.BGStatus);
            }
        }

        internal static uint BattlefieldInstanceExpiration
        {
            get
            {
                return _wow.ReadUInt((uint)(Offsets.Globals.BattlefieldInstanceExpiration));
            }
        }

        internal static string LastError
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes((uint)Offsets.Globals.LastError, 120));
            }
        }

        internal static string RealmName
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes((uint)Offsets.Globals.RealmName, 120));
            }
        }

        internal static string LoginState
        {
            get
            {
                return _wow.ReadASCIIString((uint)Offsets.Globals.LoginState, 40);
            }
        }

        internal static int LoadingState
        {
            get
            {
                return (int)_wow.ReadUInt((uint)Offsets.Globals.IsLoadingOrConnecting);
            }
        }

        internal static int CharCount
        {
            get
            {
                return Convert.ToInt16(_wow.ReadByte((uint)Offsets.Globals.CharCount));
            }
        }

        internal static int CharNo
        {
            get
            { 
                return Convert.ToInt16(_wow.ReadByte((uint)Offsets.Globals.CharNo));
            }
        }

        internal static bool Online
        {
            get
            {
                try
                {
                    return (Playerbase != 0);
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        internal static string WoWBuild
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes((uint)Offsets.Globals.WoWBuild, 10));
            }
        }

        #endregion

        #region public Methods

        internal static void LuaDoString(string command)
        {
            // Allocate memory
            uint DoStringArg_Codecave = MemoryManager.BlackMagic.AllocateMemory(Encoding.UTF8.GetBytes(command).Length + 1);
            // offset:
            uint FrameScript__Execute = 0x819210;


            // Write value:
            MemoryManager.BlackMagic.WriteBytes(DoStringArg_Codecave, Encoding.UTF8.GetBytes(command));

            // Write the asm stuff for Lua_DoStringam 
            String[] asm = new String[] 
            {
                "mov eax, " + DoStringArg_Codecave,
                "push 0",
                "push eax",
                "push eax",
                "mov eax, " + (uint)FrameScript__Execute, // Lua_DoString
                "call eax",
                "add esp, 0xC",
                "retn",
            };

            // Inject
            D3DHook.InjectAndExecuteAsm(asm);

            // Free memory allocated 
            MemoryManager.BlackMagic.FreeMemory(DoStringArg_Codecave);
        }

        internal static string LuaGetLocalizedText(string LuaVar)
        {
            // Command to send using LUA
            String Command = LuaVar;

            // Allocate memory for command
            uint Lua_GetLocalizedText_Space = MemoryManager.BlackMagic.AllocateMemory(Encoding.UTF8.GetBytes(Command).Length + 1);

            // offset:
            uint ClntObjMgrGetActivePlayerObj = 0x4038F0;
            uint FrameScript__GetLocalizedText = 0x7225E0;

            // Write command in the allocated memory
            MemoryManager.BlackMagic.WriteBytes(Lua_GetLocalizedText_Space, Encoding.UTF8.GetBytes(Command));

            String[] asm = new String[] 
            {
            "call " + (uint)ClntObjMgrGetActivePlayerObj,
            "mov ecx, eax",
            "push -1",
            "mov edx, " + Lua_GetLocalizedText_Space + "",
            "push edx",
            "call " + (uint)FrameScript__GetLocalizedText,
            "retn",
            };
            // Inject the shit
            string sResult = Encoding.ASCII.GetString(D3DHook.InjectAndExecuteAsm(asm, 0, true));

            // Free memory allocated for command
            MemoryManager.BlackMagic.FreeMemory(Lua_GetLocalizedText_Space);

            // Uninstall the hook
            return sResult;
        }

        internal static float TraceLine(Vector3 end, Vector3 start, UserApi.Enums.CGWorldFrameHitFlags flag, int heigtOffset = 0)
        {
            float distance = 1.0f;
            // uint traceOFF = 0x7a4060;
            int zero = 0;
            //uint TRACELINE = 0x7a4060;
            uint TRACELINE = 0x007A3B70;

            // Allocate memory
            AllocatedMemory endCodeCave = MemoryManager.GetAllocatedMemory(0x4 * 3);
            AllocatedMemory startCodeCave = MemoryManager.GetAllocatedMemory(0x4 * 3);
            AllocatedMemory resultVectorCave = MemoryManager.GetAllocatedMemory(0x4 * 3);
            AllocatedMemory resultDistCodeCave = MemoryManager.GetAllocatedMemory(0x4);
            AllocatedMemory resultIntCave = MemoryManager.GetAllocatedMemory(0x4);

            // Write Values

            byte[] a1 = BitConverter.GetBytes(end.X);
            byte[] a2 = BitConverter.GetBytes(end.Y);
            byte[] a3 = BitConverter.GetBytes(end.Z + heigtOffset);
            byte[] writeArray = ConcatByteArrays(a1, a2, a3);
            MemoryManager.BlackMagic.WriteBytes(endCodeCave.Address, writeArray);

            a1 = BitConverter.GetBytes(start.X);
            a2 = BitConverter.GetBytes(start.Y);
            a3 = BitConverter.GetBytes(start.Z + heigtOffset);
            writeArray = ConcatByteArrays(a1, a2, a3);
            MemoryManager.BlackMagic.WriteBytes(startCodeCave.Address, writeArray);

            a1 = BitConverter.GetBytes(1.0F);
            a2 = BitConverter.GetBytes(1.0F);
            a3 = BitConverter.GetBytes(1.0F);
            writeArray = ConcatByteArrays(a1, a2, a3);
            MemoryManager.BlackMagic.WriteBytes(resultVectorCave.Address, writeArray);

            MemoryManager.BlackMagic.WriteFloat(resultDistCodeCave.Address, distance);

            String[] asm = new String[]
            {
                "mov eax, " + (int)zero,
                "push eax",
                "mov eax, " + (uint)flag,
                "push eax",
                "push " + (uint)resultDistCodeCave.Address, 
                "push " + (uint)resultVectorCave.Address,
                "push " + (uint)startCodeCave.Address,
                "push " + (uint)endCodeCave.Address,
                "call " + (uint)(TRACELINE) ,
                "mov [" + (uint)resultIntCave.Address + "], eax",  
                "add esp, " + (uint)0x18, 
                "retn",
            };

            // bool ret =true;
            // _hook.InjectAndExecuteAsm(asm);
            int ret = 1;
            D3DHook.InjectAndExecuteAsm(asm);
            ret = MemoryManager.BlackMagic.ReadInt(resultIntCave.Address);
            var ret2 = MemoryManager.BlackMagic.ReadFloat(resultDistCodeCave.Address);
            // Console.WriteLine("float: " + ret2);

            endCodeCave.Locked = false;
            startCodeCave.Locked = false;
            resultVectorCave.Locked = false;
            resultDistCodeCave.Locked = false;
            resultIntCave.Locked = false;

            return ret2;
        }
      
        #endregion

        #region private Methods

        private static byte[] ConcatByteArrays(byte[] a1, byte[] a2, byte[] a3)
        {
            byte[] rv = new byte[a1.Length + a2.Length + a3.Length];
            System.Buffer.BlockCopy(a1, 0, rv, 0, a1.Length);
            System.Buffer.BlockCopy(a2, 0, rv, a1.Length, a2.Length);
            System.Buffer.BlockCopy(a3, 0, rv, a1.Length + a2.Length, a3.Length);
            return rv;
        }

        #endregion
    }
}
