using BotTemplate.BO;
using BotTemplate.Constants;
using BotTemplate.Helper;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using Magic;
using System;
using UserApi;
using WrapperObjects = UserApi.WoWObjects;

namespace BotTemplate.WoWObjects
{
    internal class LocalPlayer : Player
    {
        #region Fields

        private BlackMagic _wow = MemoryManager.BlackMagic;

        #endregion

        #region Singleton Stuff

        public LocalPlayer()
            : base(WoW.Playerbase)
        {

        }

        #endregion

        #region Properties

        // Baseaddress Override
        public override uint BaseAdress
        {
            get
            {
                return WoW.Playerbase;
            }
        }

        // Name override
        public override string Name
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes((uint)Offsets.Globals.PlayerName, 120));
            }
        }
               
        // GUID override
        public override ulong GUID
        {
            get
            {
                return _wow.ReadUInt64((uint)Offsets.Globals.PlayerGUID);
            }
        }

        // Location Override
        public override Vector3 Location
        {
            get
            {
                var x = _wow.ReadFloat(BaseAdress + 0x798);
                var y = _wow.ReadFloat(BaseAdress + 0x79C);
                var z = _wow.ReadFloat(BaseAdress + 0x7A0);
                return new Vector3(x, y, z);
            }
        }

        public Vector3 CorpseLocation
        {
            get
            {
                var x = _wow.ReadFloat((uint)Offsets.Corpse.X);
                var y = _wow.ReadFloat((uint)Offsets.Corpse.Y);
                var z = _wow.ReadFloat((uint)Offsets.Corpse.Z);
                return new Vector3(x, y, z);
            }
        }

        public string LocationName
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes(_wow.ReadUInt((uint)Offsets.Globals.LocationName), 60));
            }
        }

        // lootable override
        public override bool IsLootable
        {
            get
            {
                return false;
            }
        }

        public bool IsIndoors
        {
            get
            {
                return (_wow.ReadUInt((uint)Offsets.Globals.IsIndoors) == 1);
            }
        }

        public bool IsMounted
        {
            get
            {
                return (_wow.ReadUInt(BaseAdress + 0x9C0) == 1);
            }
        }

        public int Combopoints
        {
            get
            {
                return Convert.ToInt16(_wow.ReadByte((uint)Offsets.Globals.ComboPoint));
            }
        }

        public int PlayerForm
        {
            get
            {
                byte[] UnitFields = _wow.ReadBytes(_wow.ReadUInt(BaseAdress + 0x8) + (0x17 * 4), 4);
                return Convert.ToInt32(UnitFields[3]);
            }
        }

        public bool Autoloot
        {
            get
            {
                return (_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0xD8) + 0x1020) == 1);
            }
            set
            {
                var lootFlag = 0;
                if (value)
                    lootFlag = 1;

                _wow.WriteInt(_wow.ReadUInt(BaseAdress + 0xD8) + 0x1020, lootFlag);
            }
        }
            
        public WrapperObjects.Unit Target
        {
            get
            {                
                return ObjectManager.GetUnitByGUID(_wow.ReadUInt64((uint)Offsets.Globals.TargetGUID));   
            }
        }

        public bool IsFalling 
        {
            get
            {
                return (_wow.ReadUInt(BaseAdress + 0x7cc) & 0x1000) != 0;
            }            
        }
            //0x1 = Moving Forward
            //0x2 = Moving Backward
            //0x4 = Strafing Left
            //0x8 = Strafing Right
            //0x10 = Turning Left
            //0x20 = Turning Right
        public bool IsMoving
        {
            get
            {
                var stat = _wow.ReadUInt(BaseAdress + 0x7cc);
                return ((stat & 0x1) != 0) || ((stat & 0x2) != 0) || ((stat & 0x4) != 0) || ((stat & 0x8) != 0) || ((stat & 0x10) != 0) || ((stat & 0x20) != 0);
            }
        }
              
        #endregion

        #region Public Methods

        public void StopMovement()
        {
            _wow.WriteUInt((BaseAdress + 0x7cc), 0x0);
        }
        
        public bool HasAuraWithId(int id)
        {
            foreach(WrapperObjects.Aura a in Auras)
                if (a.Id == id)
                    return true;

            return false;
        }

        public void FacePos(Vector3 location)
        {
            float f = (float)Math.Atan2(location.Y - WoW.LocalPlayer.Location.Y, location.X - WoW.LocalPlayer.Location.X);

            if (f < 0.0f)
            {
                f = f + (float)Math.PI * 2.0f;
            }
            else
            {
                if (f > (float)Math.PI * 2)
                {
                    f = f - (float)Math.PI * 2.0f;
                }
            }

            MemoryManager.BlackMagic.WriteFloat(WoW.Playerbase + 0x7A8, f);
        }

        public void CGPlayer_C__ClickToMove(Vector3 Location, UInt64 guid, UserApi.Enums.ClickToMoveType action, Single precision)
        {
            // Allocate Memory:
            AllocatedMemory Pos_Codecave = MemoryManager.GetAllocatedMemory(0x4 * 3);
            AllocatedMemory GUID_Codecave = MemoryManager.GetAllocatedMemory(0x8);
            AllocatedMemory Precision_Codecave = MemoryManager.GetAllocatedMemory(0x4);

            // Offset:
            uint CGPlayer_C__ClickToMove = 0x727400;
            uint ClntObjMgrGetActivePlayerObj = 0x4038F0;

            // Write value:
            MemoryManager.BlackMagic.WriteUInt64(GUID_Codecave.Address, guid);
            MemoryManager.BlackMagic.WriteFloat(Precision_Codecave.Address, precision);

            MemoryManager.BlackMagic.WriteFloat(Pos_Codecave.Address, Location.X);
            MemoryManager.BlackMagic.WriteFloat(Pos_Codecave.Address + 0x4, Location.Y);
            MemoryManager.BlackMagic.WriteFloat(Pos_Codecave.Address + 0x8, Location.Z);

            string[] asm = new string[]
            {
                "mov edx, [" + Precision_Codecave.Address + "]",
                "push edx",

                "call " + (uint)ClntObjMgrGetActivePlayerObj,
                "mov ecx, eax",
                
                "push " + Pos_Codecave.Address,
                "push " + GUID_Codecave.Address,
                "push " + (uint)action,

                "call " + (uint)CGPlayer_C__ClickToMove,
                "retn",
            };

            D3DHook.InjectAndExecuteAsm(asm, 1);

            Pos_Codecave.Locked = false;
            GUID_Codecave.Locked = false;
            Precision_Codecave.Locked = false;
        }

        public void TargetUnit(WrapperObjects.Unit unit)
        {
            _wow.WriteUInt64(0x00BD07B0, unit.GUID);
        }

        public void TeleportToCords(Vector3 location, float travelZ)
        {
            var treshold = 25;

            try
            {
                if (WoW.LocalPlayer.IsFalling) 
                    WoW.LocalPlayer.StopMovement();

                if (WoW.LocalPlayer.Location.X != 0)
                {
                    if ((CalcDistance(WoW.LocalPlayer.Location.X, location.X) > treshold)
                     || (CalcDistance(WoW.LocalPlayer.Location.Y, location.Y) > treshold)
                     || (CalcDistance(WoW.LocalPlayer.Location.Z, location.Z) > treshold))
                    {
                        float nx, ny, nz;
                        if ((CalcDistance(WoW.LocalPlayer.Location.X, location.X) > treshold))
                        {
                            if (location.X > WoW.LocalPlayer.Location.X)
                                nx = (WoW.LocalPlayer.Location.X + treshold);
                            else
                                nx = (WoW.LocalPlayer.Location.X - treshold);
                        }
                        else
                            nx = location.X;

                        if ((CalcDistance(WoW.LocalPlayer.Location.Y, location.Y) > treshold))
                        {
                            if (location.Y > WoW.LocalPlayer.Location.Y)
                                ny = (WoW.LocalPlayer.Location.Y + treshold);
                            else
                                ny = (WoW.LocalPlayer.Location.Y - treshold);
                        }
                        else
                            ny = location.Y;

                        if ((CalcDistance(WoW.LocalPlayer.Location.Z, location.Z) > treshold))
                        {
                            if (location.Z > WoW.LocalPlayer.Location.Z)
                                nz = (WoW.LocalPlayer.Location.Z + treshold);
                            else
                                nz = (WoW.LocalPlayer.Location.Z - treshold);
                        }
                        else
                            nz = location.Z;

                        _wow.WriteFloat(WoW.Playerbase + 0x798, nx);
                        _wow.WriteFloat(WoW.Playerbase + 0x79C, ny);
                        _wow.WriteFloat(WoW.Playerbase + 0x7A0, nz);
                        _wow.WriteFloat(WoW.Playerbase + 0x7A8, 4);

                        WoW.LuaDoString("TurnRightStart()");
                        WoW.LuaDoString("TurnRightStop()");
                    }
                    else
                    {
                        _wow.WriteFloat(WoW.Playerbase + 0x798, location.X);
                        _wow.WriteFloat(WoW.Playerbase + 0x79C, location.Y);
                        _wow.WriteFloat(WoW.Playerbase + 0x7A0, location.Z);
                        _wow.WriteFloat(WoW.Playerbase + 0x7A8, 4);

                        ObjectManager.Update();
                        WoW.LuaDoString("TurnRightStart()");
                        WoW.LuaDoString("TurnRightStop()");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        #endregion

        #region Method Overrides

        public override void Face()
        {
            // Local Player cant face himself
        }

        #endregion

        #region Private Methods

        private float CalcDistance(float a, float b)
        {
            if (a > b) return (a - b);
            else if (a < b) return (b - a);
            else return 0;
        }

        #endregion
    }
}
