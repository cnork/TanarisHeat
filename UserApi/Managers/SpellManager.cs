using System;
using CoreManagers = BotTemplate.Managers;
using WrapperObjects = UserApi.WoWObjects;

namespace UserApi.Managers
{
    public static class SpellManager
    {
        #region Methods

        #region CastSpell

        public static void CastSpellByName(string spellName) 
        {
            CoreManagers.SpellManager.CastSpellByName(spellName);
        }

        public static void CastSpellByName(string spellName, ulong GUID)
        {
            CoreManagers.SpellManager.CastSpellByName(spellName, GUID);
        }

    //   public static void CastSpellByName(string spellName, Unit unit)
    //   {
    //       Core.SpellManager.CastSpellByName(spellName, unit);
    //   }
     
        public static void CastSpellByID(int spellID)
        {
            CoreManagers.SpellManager.CastSpellByID(spellID);
        }

        public static void CastSpellByID(int spellID, ulong GUID)
        {
            CoreManagers.SpellManager.CastSpellByID(spellID, GUID);
        }

        public static void CastSpellByID(int spellID, WrapperObjects.Unit unit)
        {
            CoreManagers.SpellManager.CastSpellByID(spellID, unit);
        }

        #endregion

        public static void UpdateSpellBook()
        {
            CoreManagers.SpellManager.UpdateSpellBook();
        }

        public static bool HasSpell(uint spellID)
        {
            return CoreManagers.SpellManager.HasSpell(spellID);
        }

        public static TimeSpan SpellCooldown(uint spellid, bool GCD = false)
        {
            return CoreManagers.SpellManager.SpellCooldown(spellid);
        }

        #endregion
    }
}
