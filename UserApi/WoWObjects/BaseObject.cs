using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreObjects = BotTemplate.WoWObjects;

namespace UserApi.WoWObjects
{
    public class BaseObject
    {
        #region Fields

        private CoreObjects.BaseObject _object;

        #endregion

        #region Constructor

        public BaseObject(uint baseAddress)
        {
            _object = new CoreObjects.BaseObject(baseAddress);
        }

        #endregion

        #region Properties

        public virtual uint BaseAdress
        {
            get
            {
                return _object.BaseAdress;
            }
        }

        public virtual UInt64 GUID
        {
            get
            {
                return _object.GUID;
            }
        }

        public virtual string Name
        {
            get
            {
                return _object.Name;
            }
        }

        #endregion

        #region Methods

        public bool Validate()
        {
            return _object.Validate();
        }

        public bool Equals(BaseObject wowObject)
        {
            return _object.Equals(wowObject);
        }

        #endregion
    }
}
