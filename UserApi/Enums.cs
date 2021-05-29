using System;

namespace UserApi
{
    public class Enums
    {
        #region Plugin Type

       /// <summary>
       /// Speicify what your plugin is made for.
       /// Please don´t use the 'All' type, it is only for sorting purposes.
       /// </summary>
        public enum PluginType
        {
            All,
            Utility,
            DeathKnigh,
            Druid,
            Hunter,
            Mage,
            Paladin,
            Priest,
            Rogue,
            Shaman,
            Warlock,
            Warrior
        }

        #endregion

        #region ClickToMoveType

        public enum ClickToMoveType : int
        {
            GoTo = 0x4,
            InteractWithNpc = 0x5,
            Loot = 0x6,
            InteractWithObj = 0x7,
            Fight = 0xA,
            FightEx = 0xB,
            None = 0xD,
        }

        #endregion

        #region CGWorldFrameHitFLags

        [Flags]
        public enum CGWorldFrameHitFlags : uint
        {
            HitTestNothing = 0x0,
            /// <summary>
            /// Models' bounding, ie. where you can't walk on a model. (Trees, smaller structures etc.)
            /// </summary>
            HitTestBoundingModels = 0x1,
            /// <summary>
            /// Structures like big buildings, Orgrimmar etc.
            /// </summary>
            HitTestWMO = 0x10,
            /// <summary>
            /// Used in ClickTerrain.
            /// </summary>
            HitTestUnknown = 0x40,
            /// <summary>
            /// The terrain.
            /// </summary>
            HitTestGround = 0x100,
            /// <summary>
            /// Tested on water - should work on lava and other liquid as well.
            /// </summary>
            HitTestLiquid = 0x10000,
            /// <summary>
            /// This flag works for liquid as well, but it also works for something else that I don't know (this hit while the liquid flag didn't hit) - called constantly by WoW.
            /// </summary>
            HitTestUnknown2 = 0x20000,
            /// <summary>
            /// Hits on movable objects - tested on UC elevator doors.
            /// </summary>
            HitTestMovableObjects = 0x100000,

            HitTestLOS = HitTestWMO | HitTestGround, //| HitTestMovableObjects | HitTestUnknown2,
            //HitTestLand = HitTestGround | HitTestWMO, //| HitTestMovableObjects | HitTestUnknown2,
            HitTestGroundAndStructures = HitTestLOS | HitTestGround
        }

       
            
       

        #endregion

        #region LogLevel

        public enum LogLevel
        {
            Off = 0,
            Error = 1,
            Warnings = 2,
            Information = 3,
            Debug = 5,
            Trace = 6
        }

        #endregion
    }
}
