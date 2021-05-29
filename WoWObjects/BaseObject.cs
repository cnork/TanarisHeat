using BotTemplate.Helper;
using BotTemplate.Managers;
using Magic;
using System;

namespace BotTemplate.WoWObjects
{
    internal class BaseObject
    {
        #region Fields

        private BlackMagic _wow = MemoryManager.BlackMagic;

        private uint _baseAddress;
        private UInt64 _GUID = 0;

        #endregion

        #region Contructors

        public BaseObject(uint baseAddress)
        {
            _baseAddress = baseAddress;
            _GUID = _wow.ReadUInt64(BaseAdress + 0x30);
        }

        #endregion

        #region Properties

        public virtual uint BaseAdress
        {
            get
            {
                return _baseAddress;
            }
        }

        public virtual UInt64 GUID
        {
            get
            {
                return _GUID;
            }
        }

        public virtual string Name
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes(_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x964) + 0x5c), 60));
            }
        }

        #endregion

        #region Methods

        public bool Validate()
        {
            try
            {
                return (_wow.ReadUInt(BaseAdress) != 0 && _GUID == _wow.ReadUInt64(BaseAdress + 0x30));
            }
            catch
            {
                return false;
            }
            
        }

        public bool Equals(BaseObject wowObject)
        {
            return (BaseAdress == wowObject.BaseAdress && GUID == wowObject.GUID);
        }
		 
	    #endregion
    }
}
