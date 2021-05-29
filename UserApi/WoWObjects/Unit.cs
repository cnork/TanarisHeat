using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjects = BotTemplate.WoWObjects;

namespace UserApi.WoWObjects
{
    public class Unit : GameObject
    {
        #region Fields

        private CoreObjects.Unit _unit;
   
        #endregion

        #region Contructors

        public Unit(uint baseAddress)
            : base(baseAddress)
        {
            _unit = new CoreObjects.Unit(baseAddress);
        }

        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return _unit.Name;
            }
        }


        public override Vector3 Location
        {
            get
            {
                return _unit.Location;
            }
        }

        public List<Aura> Auras
        {
            get
            {
                return _unit.Auras;
            }
        }

        public bool IsTarget
        {
            get
            {
                return _unit.IsTarget;
            }
        }

        public bool IsPlayer
        {
            get
            {
                return _unit.IsPlayer;
            }
        }

        public uint CurrentHealth
        {
            get
            {
                return _unit.CurrentHealth;
            }
        }

        public uint MaxHeath
        {
            get
            {
                return _unit.MaxHeath;
            }
        }

        public float HealthPct
        {
            get
            {
                return _unit.HealthPct;
            }
        }

        public uint Level
        {
            get
            {
                return _unit.Level;
            }
        }

        public bool IsInCombat
        {
            get
            {
                return _unit.IsInCombat;
            }
        }

        public int FactionId
        {
            get
            {
                return _unit.FactionId;
            }
        }

        public int CurrentPower
        {
            get
            {
                return _unit.CurrentPower;
            }
        }

        public List<int> PowerList
        {
            get
            {
                return _unit.PowerList;
            }
        }

        public bool IsCasting
        {
            get
            {
                return _unit.IsCasting;
            }
        }

        public uint CastId
        {
            get
            {
                return _unit.CastId;
            }
        }

        public TimeSpan CastTimeLeft
        {
            get
            {
                return _unit.CastTimeLeft;
            }
        }

        public bool IsChanneling
        {
            get
            {
                return _unit.IsChanneling;
            }
        }

        public uint ChannelId
        {
            get
            {
                return _unit.ChannelId;
            }
        }

        public TimeSpan ChannelimeLeft
        {
            get
            {
                return _unit.ChannelimeLeft;
            }
        }

        public bool IsAttackable
        {
            get
            {
                return _unit.IsAttackable;
            }
        }
        #endregion

        #region Methods

        public override void Interact()
        {
            _unit.Interact();
        }

        #endregion
    }
}
