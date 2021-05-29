//using Microsoft.CSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
////using System.Threading.Tasks;
//using System.Windows.Forms;
//using BotTemplate.Helper;
//using System.Diagnostics;
//using BotTemplate.Interface;
//using BotTemplate.Constants;

//namespace BotTemplate
//{
//    class ApiWrapper : IApiWrapper
//    {

//        #region Fields

//        private Hook _myHook;
//        private OManager.Memory _objectManager;

//        #endregion

//        #region Constructors

//        public ApiWrapper()
//        {
//            Init();
//        }

//        #endregion

//        #region Properties

//        OManager.Memory IApiWrapper.ObjectManager
//        {
//            get
//            {
//                return _objectManager;
//            }

//        }

//        #endregion

//        #region Public Methods

        

//        #endregion

//        #region Private Methods

//        private void Init()
//        {
//            Process[] first = Process.GetProcessesByName("WoW");
//            _myHook = new Hook(first[0]);
//            _objectManager = new OManager.Memory(_myHook);
//            _objectManager.Read();
//        }

//        #endregion

//        public struct Vector3
//        {
//            public float X;
//            public float Y;
//            public float Z;
//        }
       
//        #region endsczene

//        #region direct

//        /// <summary>
//        /// This method performs an click to move in the Client.
//        /// </summary>
//        /// <param name="x">X value of varget vector</param>
//        /// <param name="y">Y value of target vector</param>
//        /// <param name="z">Z value of target vector</param>
//        /// <param name="guid"></param>
//        /// <param name="action"></param>
//        /// <param name="precision"></param>
//        public void CGPlayer_C__ClickToMove(Single x, Single y, Single z, UInt64 guid, Int32 action, Single precision)
//        {
            
//            // Allocate Memory:
//            UInt32 Pos_Codecave = _myHook.Memory.AllocateMemory(0x4 * 3);
//            UInt32 GUID_Codecave = _myHook.Memory.AllocateMemory(0x8);
//            UInt32 Precision_Codecave = _myHook.Memory.AllocateMemory(0x4);

//            // Offset:
//            uint CGPlayer_C__ClickToMove = 0x727400;
//            uint ClntObjMgrGetActivePlayerObj = 0x4038F0;

//            // Write value:
//            _myHook.Memory.WriteUInt64(GUID_Codecave, guid);
//            _myHook.Memory.WriteFloat(Precision_Codecave, precision);

//            _myHook.Memory.WriteFloat(Pos_Codecave, x);
//            _myHook.Memory.WriteFloat(Pos_Codecave + 0x4, y);
//            _myHook.Memory.WriteFloat(Pos_Codecave + 0x8, z);

//            // BOOL __thiscall CGPlayer_C__ClickToMove(WoWActivePlayer *this, CLICKTOMOVETYPE clickType, WGUID *interactGuid, WOWPOS *clickPos, float precision)
//            string[] asm = new string[]
//            {
//                "mov edx, [" + Precision_Codecave + "]",
//                "push edx",

//                "call " + (uint)ClntObjMgrGetActivePlayerObj,
//                "mov ecx, eax",
                
//                "push " + Pos_Codecave,
//                "push " + GUID_Codecave,
//                "push " + action,

//                "call " + (uint)CGPlayer_C__ClickToMove,
//                "retn",
//            };
//            //string[] asmend = new string[]
//            //{
//            //    "retn",
//            //};

//            //asm = _myHook.addStrings(asm, asm);
//            //asm = _myHook.addStrings(asm, asm);
//            //asm = _myHook.addStrings(asm, asmend);
            
            

//            _myHook.InjectAndExecute(asm, 1);

//            _myHook.Memory.FreeMemory(Pos_Codecave);
//            _myHook.Memory.FreeMemory(GUID_Codecave);
//            _myHook.Memory.FreeMemory(Precision_Codecave);
//        }

//        public void LuaDoString(string command)
//        {
//            // Allocate memory
//            uint DoStringArg_Codecave = _myHook.Memory.AllocateMemory(Encoding.UTF8.GetBytes(command).Length + 1);
//            // offset:
//            uint FrameScript__Execute = 0x819210;


//            // Write value:
//            _myHook.Memory.WriteBytes(DoStringArg_Codecave, Encoding.UTF8.GetBytes(command));

//            // Write the asm stuff for Lua_DoStringam 
//            String[] asm = new String[] 
//            {
//                "mov eax, " + DoStringArg_Codecave,
//                "push 0",
//                "push eax",
//                "push eax",
//                "mov eax, " + (uint)FrameScript__Execute, // Lua_DoString
//                "call eax",
//                "add esp, 0xC",
//              //  "retn",
              
//            };
//            String[] end = new String[]{
//                "retn",
//            };

//          //  asm = MyHook.addStrings(asm, asm);
//            asm = _myHook.addStrings(asm, end);

//            // Inject
//            _myHook.InjectAndExecute(asm);
//            // Free memory allocated 
//            _myHook.Memory.FreeMemory(DoStringArg_Codecave);
//        }

//        public void lookFrameOn(){
//            _myHook.lockFrame();
//            Console.WriteLine(_myHook.Memory.ReadInt(_myHook.frameLockFlagAdress));
//        }
//        public void lookFrameOff()
//        {
//            _myHook.releaseFrame();
//            Console.WriteLine(_myHook.Memory.ReadInt(_myHook.frameLockFlagAdress));
//        }

//        public void testDummy(){
//            string[] asm = new string[]
//                {
//                    "retn",
//                };
//            _myHook.InjectAndExecute(asm);
//        }

//        public void InteractGameObject(uint baseAddress)
//        {
//            uint InteractVMT = 44;
//            if (baseAddress > 0)
//            {
//                uint VMT44 = _myHook.Memory.ReadUInt(_myHook.Memory.ReadUInt(baseAddress) + ((uint)InteractVMT * 4));
//                var objectManagerBase = 0x2ED0;

//                string[] asm = new string[]
//                {
//            "fs mov eax, [0x2C]",
//            "mov eax, [eax]",
//            "add eax, 0x10",
//            "mov dword [eax], " + objectManagerBase,
//            "mov ecx, " + baseAddress,
//            "call " + VMT44,
//            "retn",
//                 };


//                _myHook.InjectAndExecute(asm);
//            }
//        }

//        public string GetLocalizedText(string LuaVar)
//        {
//            // Command to send using LUA
//            String Command = LuaVar;

//            // Allocate memory for command
//            uint Lua_GetLocalizedText_Space = _myHook.Memory.AllocateMemory(Encoding.UTF8.GetBytes(Command).Length + 1);

//            // offset:
//            uint ClntObjMgrGetActivePlayerObj = 0x4038F0;
//            uint FrameScript__GetLocalizedText = 0x7225E0;

//            // Write command in the allocated memory
//            _myHook.Memory.WriteBytes(Lua_GetLocalizedText_Space, Encoding.UTF8.GetBytes(Command));

//            String[] asm = new String[] 
//            {
//            "call " + (uint)ClntObjMgrGetActivePlayerObj,
//            "mov ecx, eax",
//            "push -1",
//            "mov edx, " + Lua_GetLocalizedText_Space + "",
//            "push edx",
//            "call " + (uint)FrameScript__GetLocalizedText,
//            "retn",
//            };
//            // Inject the shit
//            string sResult = Encoding.ASCII.GetString(_myHook.InjectAndExecute(asm));

//            // Free memory allocated for command
//            _myHook.Memory.FreeMemory(Lua_GetLocalizedText_Space);

//            // Uninstall the hook
//            return sResult;
//        }

//        public int traceLine(Vector3 end, Vector3 start, uint flag)
//        {
//            float distance = 1.0f;
//            // uint traceOFF = 0x7a4060;
//            int zero = 0;
//            //uint TRACELINE = 0x7a4060;
//            uint TRACELINE = 0x007A3B70;
//            // Allocate memory
//            UInt32 endCodeCave = _myHook.Memory.AllocateMemory(0x4 * 3);
//            UInt32 startCodeCave = _myHook.Memory.AllocateMemory(0x4 * 3);
//            UInt32 resultCodeCave = _myHook.Memory.AllocateMemory(0x4 * 3);
//            UInt32 distCodeCave = _myHook.Memory.AllocateMemory(0x4);
//            UInt32 resultRet = _myHook.Memory.AllocateMemory(0x4);

//            // Write Values

//            _myHook.Memory.WriteFloat(endCodeCave, end.X);
//            _myHook.Memory.WriteFloat(endCodeCave + 0x4, end.Y);
//            _myHook.Memory.WriteFloat(endCodeCave + 0x8, end.Z);

//            _myHook.Memory.WriteFloat(startCodeCave, start.X);
//            _myHook.Memory.WriteFloat(startCodeCave + 0x4, start.Y);
//            _myHook.Memory.WriteFloat(startCodeCave + 0x8, start.Z);

//            _myHook.Memory.WriteFloat(resultCodeCave, 1.0F);
//            _myHook.Memory.WriteFloat(resultCodeCave + 0x4, 1.0F);
//            _myHook.Memory.WriteFloat(resultCodeCave + 0x8, 1.0F);

//            _myHook.Memory.WriteFloat(distCodeCave, distance);

//            String[] asm = new String[]
//            {
//                "mov eax, " + (int)zero,
//                "push eax",
//                "mov eax, " + (uint)flag,
//                "push eax",
//                "push " + (uint)distCodeCave, 
//                "push " + (uint)resultCodeCave,
//                "push " + (uint)startCodeCave,
//                "push " + (uint)endCodeCave,
//                "call " + (uint)(TRACELINE) ,
//                "mov [" + (uint)resultRet + "], eax",  
//                "add esp, " + (uint)0x18, 
//                "retn",
//            };

//            //bool ret =true;
//            _myHook.InjectAndExecute(asm);
//            int ret;
//            ret = _myHook.Memory.ReadInt(resultRet); // > 0;
//            //  ret = MyHook.Memory.ReadFloat(distCodeCave);

//            _myHook.Memory.FreeMemory(endCodeCave);
//            _myHook.Memory.FreeMemory(endCodeCave + 0x4);
//            _myHook.Memory.FreeMemory(endCodeCave + 0x8);

//            _myHook.Memory.FreeMemory(startCodeCave);
//            _myHook.Memory.FreeMemory(startCodeCave + 0x4);
//            _myHook.Memory.FreeMemory(startCodeCave + 0x8);

//            _myHook.Memory.FreeMemory(resultCodeCave);
//            _myHook.Memory.FreeMemory(resultCodeCave + 0x4);
//            _myHook.Memory.FreeMemory(resultCodeCave + 0x8);

//            _myHook.Memory.FreeMemory(distCodeCave);

//            return ret;
//        }

//        #endregion
//        #region queue
//        #endregion
//        #endregion

//        public void WriteToConsole(string message)
//        {
//            Console.WriteLine(message);
//        }

       
//        public OManager.Memory ObjectManager()
//        {
//            return _objectManager;
           
//        }

//        public void targetGUID(UInt64 guid)
//        {
//            _myHook.Memory.WriteUInt64(_objectManager.playerbase + 0x00BD07B0, guid);
//        }




        
//    }
//}
