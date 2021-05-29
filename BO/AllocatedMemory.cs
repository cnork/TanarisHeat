using System;

namespace BotTemplate.BO
{
    internal class AllocatedMemory
    {

        public AllocatedMemory(UInt32 addresss)
        {
            Locked = false;
            Address = addresss;
        }

        public bool Locked
        {
            get;
            set;
        }

        public UInt32 Address
        {
            get;
            private set;
        }
    }
}
