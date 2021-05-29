using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjects = BotTemplate.WoWObjects;
using Core = BotTemplate;

namespace UserApi.WoWObjects
{
    public class LocalPlayer : Player
    {
        #region Fields

        private static CoreObjects.LocalPlayer _localPlayer;

        #endregion 

        #region Constructors

        public LocalPlayer()
            : base(Core.WoW.LocalPlayer.BaseAdress)
        {
            _localPlayer = Core.WoW.LocalPlayer;
        }

        #endregion

        #region Properties

        // Baseaddress override
        public override uint BaseAdress
        {
            get
            {
                return _localPlayer.BaseAdress;
            }
        }

        // Name override
        public override string Name
        {
            get
            {
                return _localPlayer.Name;
            }
        }

        // GUID override
        public override ulong GUID
        {
            get
            {
                return _localPlayer.GUID;
            }
        }

        // Location Override
        public override Vector3 Location
        {
            get
            {
                return _localPlayer.Location;
            }
        }

        public Vector3 CorpseLocation
        {
            get
            {
                return _localPlayer.CorpseLocation;
            }
        }

        public string LocationName
        {
            get
            {
                return _localPlayer.LocationName;
            }
        }

        //lootable override
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
                return _localPlayer.IsIndoors;
            }
        }

        public bool IsMounted
        {
            get
            {
                return _localPlayer.IsMounted;
            }
        }

        public int Combopoints
        {
            get
            {
                return _localPlayer.Combopoints;
            }
        }

        public int PlayerForm
        {
            get
            {
                return _localPlayer.PlayerForm;
            }
        }

        public bool Autoloot
        {
            get
            {
                return _localPlayer.Autoloot;
            }
            set
            {
                _localPlayer.Autoloot = value;
            }
        }

        public Unit Target
        {
            get
            {
                return _localPlayer.Target;
            }
        }

        public bool IsFalling
        {
            get
            {
                return _localPlayer.IsFalling;
            }
        }

        public bool IsMoving
        {
            get
            {
                return _localPlayer.IsMoving;
            }
        }
        #endregion

        #region Methods

        public void StopMovement()
        {
            _localPlayer.StopMovement();
        }

        public bool HasAuraWithId(int id)
        {
            return _localPlayer.HasAuraWithId(id);
        }

        public void FacePos(Vector3 location)
        {
            _localPlayer.FacePos(location);
        }

        public void CGPlayer_C__ClickToMove(Vector3 location, UInt64 guid, Enums.ClickToMoveType action, Single precision)
        {
            _localPlayer.CGPlayer_C__ClickToMove(location, guid, action, precision);
        }

        public void TargetUnit(Unit unit)
        {
            _localPlayer.TargetUnit(unit);
        }

        public void TeleportToCords(Vector3 location, float travelZ)
        {
            _localPlayer.TeleportToCords(location, travelZ);
        }

        #endregion

        #region Method Overrides

        public override void Face()
        {
            // Local Player cant face himself
        }
       
        #endregion
    }
}
