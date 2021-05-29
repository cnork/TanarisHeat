using BotTemplate.Constants;
using Magic;
using System;
using System.Collections.Generic;
using WrapperObjects = UserApi.WoWObjects;

namespace BotTemplate.Managers
{
    internal static class ObjectManager
    {

        #region  Fields

        private static BlackMagic _wow = MemoryManager.BlackMagic;
        private static object _lock = new object();

        private static List<WrapperObjects.Unit> _units = new List<WrapperObjects.Unit>();
        private static List<WrapperObjects.Player> _players = new List<WrapperObjects.Player>();
        private static List<WrapperObjects.BaseObject> _objects = new List<WrapperObjects.BaseObject>();
        private static List<WrapperObjects.GameObject> _gameObjects = new List<WrapperObjects.GameObject>();

        #endregion

        #region Contructors

        static ObjectManager()
        {
            UpdateObjectsList();
        }
        
        #endregion

        #region internal Methods

        internal static void Update()
        {
            lock (_lock)
            {
                UpdateObjectsList();
                UpdateObjects();
            }
        }

        internal static List<WrapperObjects.GameObject> GetGameObjects()
        {
            lock (_lock)
            {
                var retVal = new List<WrapperObjects.GameObject>();
                retVal.AddRange(_gameObjects);
                return retVal;
            }
        }

        internal static List<WrapperObjects.Unit> GetUnits()
        {
            lock (_lock)
            {
                var retVal = new List<WrapperObjects.Unit>();
                retVal.AddRange(_units);
                return retVal;
            }
        }

        internal static List<WrapperObjects.Player> GetPlayers()
        {
            lock (_lock)
            {
                var retVal = new List<WrapperObjects.Player>();
                retVal.AddRange(_players);
                return retVal;
            }
        }

        internal static WrapperObjects.Unit GetUnitByGUID(ulong guid)
        {
            lock (_lock)
            {
                foreach (WrapperObjects.Unit u in _units)
                    if (u.GUID == guid)
                        return u;
            }

            return null;
        }
              
        #endregion

        #region Private Methods

        private static void UpdateObjectsList()
        {
            try
            {
                _objects.Clear();

                if (WoW.Online)
                {
                    uint s_curMgr = _wow.ReadUInt(_wow.ReadUInt((uint)Offsets.ObjectManager.CurMgrPointer) + (uint)Offsets.ObjectManager.CurMgrOffset);
                    uint curObj = _wow.ReadUInt(s_curMgr + 0xAC);
                    uint nextObj = curObj;

                    while (curObj != 0 && (curObj & 1) == 0)
                    {
                        _objects.Add(new WrapperObjects.BaseObject(curObj));

                        nextObj = _wow.ReadUInt(curObj + 0x3C);

                        if (nextObj == curObj)
                            break;
                        else
                            curObj = nextObj;
                    }
                }
            }
            catch (Exception E)
            {
                Console.WriteLine("Error.Object Manager " + E.Message);
            }
        }

        private static void UpdateObjects()
        {
            _units.Clear();
            _players.Clear();
            _gameObjects.Clear();

            if (WoW.Online)
            {
                foreach (WrapperObjects.BaseObject o in _objects)
                {
                    UInt64 type = _wow.ReadUInt(o.BaseAdress + 0x14);
                    switch (type)
                    {
                        case 3:     // Unit
                            _units.Add(new WrapperObjects.Unit(o.BaseAdress));
                            break;
                        case 4:     // Player
                            _players.Add(new WrapperObjects.Player(o.BaseAdress));
                            break;
                        case 5:     // GameObject
                            _gameObjects.Add(new WrapperObjects.GameObject(o.BaseAdress));
                            break;
                        default:    // everything else
                            break;
                    }
                }
            }
        }

        // replace by enum?
        //private static String GetFactionFromId(uint FactionIndex)
        //{
        //    switch (FactionIndex)
        //    {
        //        case 1:
        //            return "Alliance";
        //        case 2:
        //            return "Horde";
        //        case 3:
        //            return "Alliance";
        //        case 4:
        //            return "Alliance";
        //        case 5:
        //            return "Horde";
        //        case 6:
        //            return "Horde";
        //        case 115:
        //            return "Alliance";
        //        case 116:
        //            return "Horde";
        //        case 1610:
        //            return "Horde";
        //        case 1629:
        //            return "Alliance";
        //    }
        //    return "Unknown";
        //}
       
        //private static String GetTextFromChatString(String InptStr, String Pattern)
        //{
        //    int Start = 0;

        //    for (int i = 0; i < InptStr.Length; i++)
        //    {
        //        if (Start == 0)
        //            if (InptStr.Substring(i, Pattern.Length) == Pattern)
        //            {
        //                Start = i + Pattern.Length + 3;
        //            }

        //        String T = InptStr.Substring(i, 1);
        //        if ((Start != 0) & (InptStr.Substring(i, 1) == "]"))
        //            return InptStr.Substring(Start, i - Start);
        //    }

        //    return "";
        //}

        #endregion
    }
}
