using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core = BotTemplate.WoWObjects;

namespace UserApi.WoWObjects
{
    public class Aura
    {
        #region Fields

        private Core.Aura _aura;

        #endregion

        #region Constructor

        public Aura(uint baseAddress)
        {
            _aura = new Core.Aura(baseAddress);
        }

        #endregion

        #region Properties

        public uint Id
        {
            get
            {
                return _aura.Id;
            }
        }

        public UInt64 CreatorGUID
        {
            get
            {
                return _aura.CreatorGUID;
            }
        }

        public TimeSpan TimeLeft
        {
            get
            {
                return _aura.TimeLeft;
            }
        }

        #endregion
    }
}
