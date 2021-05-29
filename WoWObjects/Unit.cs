using BotTemplate.BO;
using BotTemplate.Constants;
using BotTemplate.Helper;
using BotTemplate.Managers;
using Magic;
using System;
using System.Collections.Generic;
using UserApi;
using WrapperObjects = UserApi.WoWObjects;

namespace BotTemplate.WoWObjects
{
    internal class Unit : GameObject
    {

        #region Fields

        private BlackMagic _wow = MemoryManager.BlackMagic;
        private List<int> _powerList = new List<int>();
        private static object _lock = new object();
        #endregion

        #region Contructors

        public Unit(uint baseAddress)
            : base (baseAddress)
        {
        }

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                if (IsPlayer) return GetPlayerNameByGuid(GUID);
                return StringHelper.ConvertBytesToString(_wow.ReadBytes(_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x964) + 0x5c), 60));
            }
        }


        public override Vector3 Location
        {
            get
            {
                var x = _wow.ReadFloat(BaseAdress + 0x7D4);
                var y = _wow.ReadFloat(BaseAdress + 0x7D8);
                var z = _wow.ReadFloat(BaseAdress + 0x7DC);
                return new Vector3(x, y, z);
            }
        }
       
        public List<WrapperObjects.Aura> Auras
        {
            get
            {
                return GetAuras(BaseAdress);
            }
        }

        public bool IsTarget
        {
            get
            {
                return (_wow.ReadUInt64((uint)Offsets.Globals.TargetGUID) == GUID);
            }
        }

        public bool IsPlayer
        {
            get
            {
                return (_wow.ReadUInt(BaseAdress + 0x14) == 4);
            }
        }

        public uint CurrentHealth
        {
            get
            {
                return _wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x8) + (0x18 * 4));
            }
        }

        public uint MaxHeath
        {
            get
            {
                return _wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x8) + (0x20 * 4));
            }
        }

        public float HealthPct
        {
            get
            {
                return (CurrentHealth / MaxHeath) * 100;
            }
        }

        public uint Level
        {
            get
            {
                return _wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x8) + (0x36 * 4));
            }
        }

        public bool IsInCombat
        {
            get
            {
                return (((_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 208) + 212) >> 19) & 1) == 1);
            }
        }

        public int FactionId
        {
            get
            {
                return Convert.ToInt32(_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x8) + (0x37 * 4)));
            }
        }

        public int CurrentPower
        {
            get
            {
                return GetUnitPower(BaseAdress);
            }
        }

        public List<int> PowerList
        {
            get
            {
                return _powerList;   
            }
        }
        public bool IsCasting
        {
            get
            {
                return _wow.ReadUInt(BaseAdress + 0xA6C) != 0;
            }
        }

        public uint CastId  
        {
            get
            {
                return _wow.ReadUInt(BaseAdress + 0xA6C);
            }
        }

        public TimeSpan CastTimeLeft
        {
            get{
                var _endTime = _wow.ReadUInt(BaseAdress + 0xA7C);
                var timeLeft = (int)_endTime - _wow.ReadInt(0x00B1D618); //_wow.ReadInt(0x00B1D618);
                if (timeLeft < 0)
                    return TimeSpan.FromMilliseconds(0);
                else
                    return TimeSpan.FromMilliseconds(timeLeft);
                
            }
        }

        public bool IsChanneling
        {
            get
            {
                return _wow.ReadUInt(BaseAdress + 0xA80) != 0;
            }
        }

        public uint ChannelId
        {
            get
            {
                return _wow.ReadUInt(BaseAdress + 0xA80);
            }
        }

        public TimeSpan ChannelimeLeft
        {
            get
            {
                var _endTime = _wow.ReadUInt(BaseAdress + 0xA88);
                var timeLeft = (int)_endTime - _wow.ReadInt(0x00B1D618);
                if (timeLeft < 0)
                    return TimeSpan.FromMilliseconds(0);
                else
                    return TimeSpan.FromMilliseconds(timeLeft);
            }
        }

        public bool IsAttackable {
            get
            {
                UInt64 oldGUID;
                lock (_lock)
                {
                    oldGUID = MemoryManager.BlackMagic.ReadUInt64(0x00BD07A0); // 0x00BD07B0
                }
                lock (_lock)
                {
                    MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, GUID);
                }
                lock (_lock)
                {
                    WoW.LuaDoString("canAttack = UnitCanAttack(\"player\", \"mouseover\");");                    
                }
                lock (_lock)
                {
                    MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, oldGUID);
                    if ("1" == WoW.LuaGetLocalizedText("canAttack")) return true;
                    return false;
                }
            }        
        }

        #endregion

        #region Methods

        public override void Interact()
        {
            base.Interact();
        }

        #endregion

        #region Private Functions

        private List<WrapperObjects.Aura> GetAuras(uint unit)
        {
            List<WrapperObjects.Aura> result = new List<WrapperObjects.Aura>();
            uint auraTable = unit + (uint)Offsets.Aura.Table1; //aura list & count has 2 possible locations
            uint auraCount = _wow.ReadUInt(unit + (uint)Offsets.Aura.Count1);

            if (auraCount > 80)
            {
                auraTable = _wow.ReadUInt(unit + (uint)Offsets.Aura.Table2); //and the second one
                auraCount = _wow.ReadUInt(unit + (uint)Offsets.Aura.Count2);
            }

            for (uint i = 0; i < auraCount; i++)
            {
                uint spellId = _wow.ReadUInt(auraTable + (uint)Offsets.Aura.Size * i + (uint)Offsets.Aura.SpellId);

                if (spellId > 0)
                {
                    WrapperObjects.Aura a = new WrapperObjects.Aura(auraTable + (uint)Offsets.Aura.Size * i);
                    result.Add(a);
                }
            }

            return result;
        }

        private int GetUnitPower(uint Object)
        {
            _powerList.Clear();

            uint Power;
            uint MaxPower;

            for (uint i = 0; i < 7; i++)
            {
                Power = _wow.ReadUInt(_wow.ReadUInt(WoW.Playerbase + 0x8) + ((i + 0x19) * 4)); // Reads players health
                MaxPower = _wow.ReadUInt(_wow.ReadUInt(WoW.Playerbase + 0x8) + ((i + 0x21) * 4)); // Reads players health

                if ((MaxPower > 10) & (MaxPower > 10))
                {
                    int P = Convert.ToInt32(Convert.ToDouble(Convert.ToDouble(Power) / Convert.ToDouble(MaxPower)) * 100);

                    if (P != 0)
                        _powerList.Add(P);
                }
            }

            if (_powerList.Count > 0)
                return _powerList[0];
            else
                return 0;
        }

        protected string GetPlayerNameByGuid(ulong guid)
        {
            const uint nameStorePtr = (uint)Offsets.Globals.PlayerNameCache + 0x8; // Player name cache
            const uint nameMaskOffset = 0x24;
            const uint nameBaseOffset = 0x1C;
            const uint nameStringOffset = 0x20;
            uint base_addr, offset, current, testGUID;
            uint mask = _wow.ReadUInt(nameStorePtr + nameMaskOffset);
            base_addr = _wow.ReadUInt(nameStorePtr + nameBaseOffset);
            uint shortGUID = (uint)guid & 0xffffffff;
            uint x = (mask & shortGUID);
            offset = 12 * x;
            current = _wow.ReadUInt((base_addr + offset + 8));
            offset = _wow.ReadUInt((base_addr + offset));
            if ((current == 0) || (current & 0x1) == 0x1)
                return "Unknown";
            testGUID = _wow.ReadUInt((current));
            string testName = StringHelper.ConvertBytesToString(_wow.ReadBytes((current + nameStringOffset), 40));
            while (testGUID != shortGUID)
            {
                current = _wow.ReadUInt((current + offset + 4));
                if ((current == 0) || (current & 0x1) == 0x1)
                    return "Unknown";
                testGUID = _wow.ReadUInt(current);
            }
            // Found the guid in the name list...
            string str = StringHelper.ConvertBytesToString(_wow.ReadBytes((current + nameStringOffset), 40));
            return str;
        }

        #endregion
    }
}
