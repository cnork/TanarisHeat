using BotTemplate.Helper;
using BotTemplate.Managers;
using System;

namespace BotTemplate.Constants
{
    internal partial class Offsets
    {
        internal static readonly byte[] EndSceneOriginal = new byte[5] { 0x8B, 0xFF, 0x55, 0x8B, 0xEC };
        
        internal static uint BaseAddress
        {
            get
            {
                return (uint)MemoryManager.BlackMagic.MainModule.BaseAddress;
            }
        }

        #region Lua

        public enum Lua
        {
            Lua_DoString = 0x008193B0,                  // 3.3.5
            Lua_GetLocalizedText = 0x007229C0,          // 3.3.5
        }

        #endregion

        #region Direct3D9

        public enum Direct3D9
        {
            pDevicePtr_1 = 0x00C5DF80,                  // 3.3.5
            pDevicePtr_2 = 0x397C,                      // 3.3.5
            oEndScene = 0xA8,                           // 3.3.5
        }

        #endregion

        #region ObjectManager

        public enum ObjectManager
        {
            CurMgrPointer = 0xC79CE0,                 
            CurMgrOffset = 0x2ED0,                    
            NextObject = 0x3C,                        
            FirstObject = 0xAC,                       
            LocalGUID = 0xC0                          
        }

        #endregion

        #region ObjectType

        public enum WoWObjectType
        {
            Object = 0,
            Item = 1,
            Container = 2,
            Unit = 3,
            Player = 4,
            GameObject = 5,
            DynamicObject = 6,
            Corpse = 7,
            AiGroup = 8,
            AreaTrigger = 9
        }

        #endregion

        #region Aura

        public enum Aura : uint
        {
            Count1 = 0xDD0,
            Count2 = 0xC54,
            Size = 0x18,
            SpellId = 0x8,
            Table1 = 0xC50,
            Table2 = 0xC58
        }

        #endregion

        #region Globals

        public enum Globals
        {
            // Player Infos
            PlayerGUID = 0x00CA1238,
            PlayerID = 0x00CA123C,
            PlayerName = 0x00C79D18,                     
            PlayerBase = 0x00CD87A8,                        // multipointer + 0x34 + 0x24
            ComboPoint = 0x00BD084D,
            Movement_Field = 0xD8,
            IsIndoors = 0x00B4AA94,

            // Spell Stuff
            SpellCooldown_Pointer = 0x00D3F5AC,
            Spell_C_CastSpell = 0x0080DB50,


            // Game Infos
            RealmName = 0x00C79B9E,
            IsLoadingOrConnecting = 0x00B6AA38,
            GameState = 0x00BD078A,                          // 1 = in game 0 = loadingscreen
            LastError = 0xBCFB90,
            LoginState = 0xB6A9E0,                           // 40 bytes lenght 
            LastHardwareAction = 0x00B4999C,
            MouseOver = 0x00BD07A0,
            LootWindow = 0x00BFA8D8,
            WoWBuild = 0x00A30BE6,

            // World Infos
            BattlefieldInstanceExpiration = 0xC55A24,
            LocationName = 0x00BD0780,
            BGStatus = 0x00BEA4D0,
            PlayerNameCache = 0xC5D938,

            // Target Stuff
            CGGameUI_Target = 0x005253F0,
            CurrentTarget = 0x00BD07B0,
            TargetGUID = 0x00BD07B0,
            LastTarget = 0x00BD07B8,

            // Account stuff
            CurrentAccount = 0x00B6AA40,
            CharCount = 0xB6B23C,
            CharNo = 0xAC436C,

            // I dont know section
            Timestamp = 0x00B1D618,
            ClntObjMgrObjectPtr = 0x004D5548,
            ClntObjMgrGetActivePlayerObj = 0x4038F8,
            HandleTerrainClick = 0x0080C458,
            CGUnit_C__GetCreatureType = 0x0071F6E0,
            CGUnit_C__GetCreatureRank = 0x00718DE0,
            nbItemsSellByMerchant = 0x00BFA3E8,
            CInputControl = 0x00C2494C,
        }

        #endregion

        #region ClickToMove

        public enum ClickToMove
        {
            CGPlayer_C__ClickToMove = 0x007278B8,       // 3.3.5 +

            CTM_Activate_Pointer = 0xBD08F4,            // 3.3.5 +
            CTM_Activate_Offset = 0x30,                 // 3.3.5 +

            CTM_Base = 0x00CA11D8,                      // 3.3.5 +
        }

        #endregion

        #region Party

        public enum Party
        {
            s_LeaderGUID = 0x00BD1960,                  // 3.3.5
            s_Member1GUID = 0x00BD1940,                 // 3.3.5
            s_Member2GUID = s_Member1GUID + 0x8,        // 3.3.5
            s_Member3GUID = s_Member2GUID + 0x8,        // 3.3.5
            s_Member4GUID = s_Member3GUID + 0x8,        // 3.3.5
        }

        #endregion

        #region Corpse

        public enum Corpse
        {
            X = 0x00BD0A58,                              // 3.3.5 +
            Y = X + 0x4,                                 // 3.3.5
            Z = X + 0x8,                                 // 3.3.5
        }

        #endregion

        #region ShapeShiftForms

        public enum ShapeshiftForm
        {
            CGUnit_C__GetShapeshiftFormId = 0x0071B358, // 3.3.5   +

            BaseAddress_Offset1 = 0xD0,                 // 3.3.5 
            BaseAddress_Offset2 = 0x1D3,                // 3.3.5 
        }

        #endregion

        #region UnitBaseGetUnitAura

        public enum UnitBaseGetUnitAura
        {
            CGUnit_Aura = 0x005576A8,                   // 3.3.5 +
            AURA_COUNT_1 = 0xDD0,                       // 3.3.5
            AURA_COUNT_2 = 0xC54,                       // 3.3.5
            AURA_TABLE_1 = 0xC50,                       // 3.3.5
            AURA_TABLE_2 = 0xC58,                       // 3.3.5
            AURA_SIZE = 0x18,                           // 3.3.5
            AURA_SPELL_ID = 0x8                         // 3.3.5
        }

        #endregion

        #region Movements

        public enum Movements
        {
            MoveForwardStart = 0x005FC5B0,              // 3.3.5
            MoveForwardStop = 0x005FC600,               // 3.3.5
            MoveBackwardStart = 0x005FC640,             // 3.3.5
            MoveBackwardStop = 0x005FC690,              // 3.3.5
            TurnLeftStart = 0x005FC6D0,                 // 3.3.5
            TurnLeftStop = 0x005FC710,                  // 3.3.5
            TurnRightStart = 0x005FC760,                // 3.3.5
            TurnRightStop = 0x005FC7A0,                 // 3.3.5
            JumpOrAscendStart = 0x005FC330,             // 3.3.5
            AscendStop = 0x005FC450,                    // 3.3.5
        }

        #endregion

        #region IsFlying

        public enum IsFlying
        {
            // Reversed from Lua_IsFlying

            IsFlyingOffset = 0x44,                      // 3.3.5
            IsFlying_Mask = 0x2000000,                  // 3.3.5
        }

        #endregion

        #region IsSwimming

        public enum IsSwimming
        {
            // Reversed from Lua_IsSwimming

            IsSwimmingOffset = 0xA30,                   // 3.3.5
            IsSwimming_Mask = 0x200000,                 // 3.3.5
        }

        #endregion

        #region AutoLoot

        public enum AutoLoot
        {
            AutoLoot_Activate_Pointer = 0x00D090C,      // 3.3.5
            AutoLoot_Activate_Offset = 0x30,            // 3.3.5
        }

        #endregion

        #region AutoSelfCast

        public enum AutoSelfCast
        {

            AutoSelfCast_Activate_Pointer = 0xBD0918,   // 3.3.5
            AutoSelfCast_Activate_Offset = 0x30,        // 3.3.5

        }

        #endregion

        #region WoWChat

        internal enum WoWChat
        {
            ChatBufferStart = 0x00B75A60,               // 3.3.5 +
            NextMessage = 0x17C0,                       // 3.3.5 +
            ChatBufferCount = 0x00BCEFF4,               // 3.3.5 +
        }

        #endregion

        #region Old Offsets

        internal enum player : uint
        {
            Class = 0x827E81,
            IsIngame = 0xB4B424,
            IsGhost = 0x435A48,
            Name = 0x827D88,
            TargetGuid = 0x74E2D8,
            IsChannelingDescriptor = 0x240,
            IsCasting = 0xCECA88,
            ComboPoints1 = 0xE68,
            ComboPoints2 = 0x1029,
            CharacterCount = 0x00B42140
        }

        internal enum partyStuff : uint
        {
            leaderGuid = 0x00BC75F8,
            party1Guid = 0x00BC6F48,
            party2Guid = 0x00BC6F50,
            party3Guid = 0x00BC6F58,
            party4Guid = 0x00BC6F60,
        }

        internal enum CTMAction : uint
        {
            FaceTarget = 0x1,
            Stop = 0x3,
            WalkTo = 0x4,
            InteractNpc = 0x5,
            Loot = 0x6,
            InteractObject = 0x7
        }


        internal enum misc : uint
        {
            GameVersion = 0x00837C04,
            MapId = 0x84C498,
            AntiDc = 0x00B41D98,
            LoginState = 0xB41478
        }

        internal enum functions : uint
        {
            LastHardwareAction = 0x00CF0BC8,
            AutoLoot = 0x4C1FA0,
            ClickToMove = 0x00611130,
            GetText = 0x703BF0,
            DoString = 0x00704CD0,
            //EndScene = 0x005A1B60,
            GetEndscene = 0x5A17B6,
            IsLooting = 0x006126B0,
            GetLootSlots = 0x004C2260,
            OnRightClickObject = 0x005F8660,
            OnRightClickUnit = 0x60BEA0,
            SetFacing = 0x004F42A0, // updated 3.3.5a //0x007C6F30,
            SendMovementPacket = 0x007413F0,  // updated 3.3.5a // 0x00600A30, old 1.0
            PerformDefaultAction = 0x00481F60,
            CGInputControl__GetActive = 0x005143E0,
            CGInputControl__SetControlBit = 0x00515090,

        }

        internal enum controlBits : uint
        {
            Front = 0x10,
            Right = 0x200,
            Left = 0x100,
            Back = 0x20
        }

        internal enum opCodes : uint
        {
            turnRight = 0xBD,
            turnLeft = 0xBC,
            moveBack = 0xB6,
            moveFront = 0xB5,
            stop = 0xB7,
        }

        internal enum movementFlags : uint
        {
            None = 0x00000000,
            Forward = 0x00000001,
            Back = 0x00000002,
            TurnLeft = 0x00000010,
            TurnRight = 0x00000020,
            Stunned = 0x00001000,
            Swimming = 0x00200000,
        }

        internal enum objectManager : uint
        {
            CurObjGuid = 0x30,
            ObjectManager = 0x00B41414,
            PlayerGuid = 0xc0,
            FirstObj = 0xac,
            NextObj = 0x3c,
            ObjType = 0x14,
            DescriptorOffset = 0x8,
            UnitPosX = 0x9B8,
            UnitPosY = 0x9BC,
            UnitPosZ = 0x9BC + 4
        }

        internal enum hacks : uint
        {
            ChangeX = 0x9C0,
            ChangeY = 0x9C4,
            ChangeZ = 0x9C8
        }

        internal enum descriptors : uint
        {
            GotLoot = 0xB4,
            SummonedByGuid = 0x30,
            DynamicFlags = 0x23C,
            IsChanneling = 0x240,
            CreatedByGuid = 0x38,
            GameObjectCreatedByGuid = 0x18,
            UnitPosX = 0x9B8,
            UnitPosY = 0x9BC,
            UnitPosZ = 0x9BC + 4,
            movementFlags = 0x9E8,
            Health = 0x58,
            MaxHealth = 0x70,
            FactionId = 0x8C,
            Mana = 0x5C,
            MaxMana = 0x74,
            Rage = 0x60,
            TargetGuid = 0x40,
            CorpseOwnedBy = 0x18,
            ItemId = 0xC,
            ItemStackCount = 0x38,
            ContainerTotalSlots = 0x6c8,
            CorpseX = 0x24,
            CorpseY = 0x28,
            CorpseZ = 0x2c
        }

        internal enum classIds : uint
        {
            Warrior = 1,
            Paladin = 2,
            Hunter = 3,
            Rogue = 4,
            Priest = 5,
            Shaman = 7,
            Mage = 8,
            Warlock = 9,
            Druid = 11
        }

        internal enum buffs : uint
        {
            FirstBuff = 0xBC,
            FirstDebuff = 0x13C,
            NextBuff = 0x4
        }
        #endregion

    }
}
