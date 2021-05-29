using BotTemplate.BO;
using BotTemplate.Constants;
using System;
using System.Collections.Generic;
using WrapperObjects = UserApi.WoWObjects;

namespace BotTemplate.Managers
{
    internal static class SpellManager
    {
        #region Fields

        // Offsets
        private static uint SPELLBOOK = 0x00BE5D88;

        // Fields
        private static List<uint> _spellIds = new List<uint>();
        private static object _lock = new object();

        #endregion
        
        #region Constructor

        static SpellManager()
        {
            UpdateSpellBook();
        }

        #endregion

        #region Public Methods

        #region CastSpell

        internal static void CastSpellByName(string spellName)
        {
            WoW.LuaDoString("CastSpellByName(\"" + spellName + "\")");
        }

        internal static void CastSpellByName(string spellName, ulong GUID)
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
                WoW.LuaDoString("CastSpellByName(\"" + spellName + "\",\"mouseover\")");
            }
            lock (_lock)
            {
                MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, oldGUID);
            }
                    
        }

        internal static void CastSpellByName(string spellName, WrapperObjects.Unit unit)
        {
            CastSpellByName(spellName, unit.GUID);
        }

        internal static void CastSpellByID(int spellID)
        {
            WoW.LuaDoString("CastSpellByID(" + spellID + ")");
        }

        internal static void CastSpellByID(int spellID, ulong GUID)
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
                WoW.LuaDoString("CastSpellByID(" + spellID + ",\"mouseover\")");
            }
            lock (_lock)
            {
                MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, oldGUID);
            }

        }

        internal static void CastSpellByID(int spellID, WrapperObjects.Unit unit)
        {
            CastSpellByID(spellID, unit.BaseAdress);
        }

        #endregion

        internal static void UpdateSpellBook()
        {
            _spellIds.Clear();
            for (int i = 0; i < MemoryManager.BlackMagic.ReadInt(0x00BE8D9C); i++)
            {
                uint id = MemoryManager.BlackMagic.ReadUInt((uint)(SPELLBOOK + (0x4 * i)));
                if (id != 0 && !_spellIds.Contains(id))
                    _spellIds.Add(id);
            }
        }

        internal static bool HasSpell(uint spellID)
        {

            if (_spellIds.Contains(spellID)) return true;
            else return false;
        }

        internal static TimeSpan SpellCooldown(uint spellid)
        {
            uint currentListObject = MemoryManager.BlackMagic.ReadUInt((0x00D3F5AC + 0x8));
            List<float> CDs = new List<float>();
            while ((currentListObject != 0) && ((currentListObject & 1) == 0))
            {
                uint currentSpellId = MemoryManager.BlackMagic.ReadUInt(currentListObject + 8);
                if (currentSpellId == spellid)
                {
                    int start = MemoryManager.BlackMagic.ReadInt((currentListObject + 0x10));

                    int cd1 = MemoryManager.BlackMagic.ReadInt((currentListObject + 0x14));
                    int cd2 = MemoryManager.BlackMagic.ReadInt((currentListObject + 0x20));

                    int length = cd1 + cd2;
                    int globalLength = MemoryManager.BlackMagic.ReadInt((currentListObject + 0x2C));

                    float cdleft = Math.Max(Math.Max(length, globalLength) - (Environment.TickCount - start), 0);

                    CDs.Add(cdleft);
                }


                //Get next list object
                currentListObject = MemoryManager.BlackMagic.ReadUInt(currentListObject + 4);
            }

            float biggestCD = 0;
            if (CDs.Count > 0)
            {
                foreach (float f in CDs)
                {
                    if (f > biggestCD)
                        biggestCD = f;
                }
            }

            return TimeSpan.FromMilliseconds(biggestCD);
        }

        #endregion
    }
}
