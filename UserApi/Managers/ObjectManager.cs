using System.Collections.Generic;
using UserApi.WoWObjects;
using CoreManagers = BotTemplate.Managers;

namespace UserApi.Managers
{
    public static class ObjectManager
    {
        #region Methods

        public static void Update()
        {
            CoreManagers.ObjectManager.Update();
        }

        public static List<GameObject> GetGameObjects()
        {
            return CoreManagers.ObjectManager.GetGameObjects();
        }

        public static List<Unit> GetUnits()
        {
            return CoreManagers.ObjectManager.GetUnits();
        }

        public static List<Player> GetPlayers()
        {
            return CoreManagers.ObjectManager.GetPlayers();
        }

        public static Unit GetUnitByGUID(ulong guid)
        {
            return CoreManagers.ObjectManager.GetUnitByGUID(guid);
        }

        #endregion
    }
}
