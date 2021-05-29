using BotTemplate.Constants;
using BotTemplate.Managers;
using Magic;
using System;

namespace BotTemplate.WoWObjects
{
    internal class Aura
    {
        #region Fields

        private BlackMagic _wow = MemoryManager.BlackMagic;
        private ulong _endTime;
        private uint _baseAddress;
        private UInt64 _cretorGUID;
        private uint _Id;

        #endregion

        #region Contructors

        public Aura(uint baseAddress)
        {
            _baseAddress = baseAddress;
            _endTime = _wow.ReadUInt(_baseAddress + 0x14);
            _cretorGUID = _wow.ReadUInt64(_baseAddress);
            _Id = _wow.ReadUInt(baseAddress + (uint)Offsets.Aura.SpellId);
        }

        #endregion

        #region Properties

        public uint Id
        {
            get
            {
                return _Id;
            }
        }

        public UInt64 CreatorGUID
        {
            get
            {
                return _cretorGUID;
            }
        }

        public TimeSpan TimeLeft
        {
            get
            {
                var timeLeft = (int)_endTime - _wow.ReadInt(0x00B1D618);
                if (timeLeft < 0)
                    return TimeSpan.FromMilliseconds(0);
                else
                    return TimeSpan.FromMilliseconds(timeLeft);
            }
        }

        #endregion
    }
}
