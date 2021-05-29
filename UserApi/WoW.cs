using UserApi.WoWObjects;
using Core = BotTemplate;

namespace UserApi
{
    public static class WoW
    {
        #region Fields

        private static LocalPlayer _localPlayer = new LocalPlayer();

        #endregion

        #region Props

        #region Api Specific

        public static LocalPlayer LocalPlayer
        {
            get
            {
                return _localPlayer;
            }
        }

        #endregion

        public static uint BgStatus
        {
            get
            {
                return Core.WoW.BgStatus;
            }
        }

        public static uint BattlefieldInstanceExpiration
        {
            get
            {
                return Core.WoW.BattlefieldInstanceExpiration;
            }
        }

        public static string LastError
        {
            get
            {
                return Core.WoW.LastError;
            }
        }

        public static string RealmName
        {
            get
            {
                return Core.WoW.RealmName;
            }
        }

        public static string LoginState
        {
            get
            {
                return Core.WoW.LoginState;
            }
        }

        public static int LoadingState
        {
            get
            {
                return Core.WoW.LoadingState;
            }
        }

        public static int CharCount
        {
            get
            {
                return Core.WoW.CharCount;
            }
        }

        public static int CharNo
        {
            get
            {
                return Core.WoW.CharNo;
            }
        }

        public static bool Online
        {
            get
            {
                return Core.WoW.Online;
            }
        }

        public static string WoWBuild
        {
            get
            {
                return Core.WoW.WoWBuild;
            }
        }

        #endregion

        #region Methods

        public static void LuaDoString(string command)
        {
            Core.WoW.LuaDoString(command);
        }

        public static string LuaGetLocalizedText(string LuaVar)
        {
            return Core.WoW.LuaGetLocalizedText(LuaVar);
        }

        public static float TraceLine(Vector3 end, Vector3 start, Enums.CGWorldFrameHitFlags flag, int heigtOffset = 0)
        {
            return Core.WoW.TraceLine(end, start, flag, heigtOffset);
        }

        #endregion
    }
}
