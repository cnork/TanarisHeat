using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjects = BotTemplate.WoWObjects;

namespace UserApi.WoWObjects
{
    public class Player : Unit
    {
        #region Fields

        private CoreObjects.Player _player;

        #endregion

        #region Constructors

        public Player(uint baseAddress)
            : base(baseAddress)
        {
            _player = new CoreObjects.Player(baseAddress);
        }

        #endregion

        #region Properties

        // name override?

        #endregion

        #region Public Methods

        #endregion
    }
}
