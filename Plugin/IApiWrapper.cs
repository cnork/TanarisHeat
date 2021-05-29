//using System;
//using System.Collections.Generic;
//using BotTemplate.Helper;
////using System.Threading.Tasks;
//using BotTemplate.Constants;



//namespace BotTemplate.Interface
//{
//    public interface IApiWrapper
//    {
//        void testDummy();
//        #region Enums


//        #endregion

//        #region Properties

//        OManager.Memory ObjectManager { get; }

//        #endregion

//        #region Usorted Methods
        
//        void CGPlayer_C__ClickToMove(Single x, Single y, Single z, UInt64 guid, Int32 action, Single precision);

//        void targetGUID(UInt64 guid);

//        void LuaDoString(string command);

//        void InteractGameObject(uint baseAddress);

//        string GetLocalizedText(string LuaVar);

//        void WriteToConsole(string message);

//        void lookFrameOn();

//        void lookFrameOff();
       

//        #endregion
//    }


//    public interface IPlugin
//    {
//        string Name { get; }
//        string Description { get; }
//        void Initialize(IApiWrapper apiWrapper);
//        void Pulse();
//        void Close();
//    }
//}
