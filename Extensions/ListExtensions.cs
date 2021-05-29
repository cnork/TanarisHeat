using BotTemplate.BO;
using BotTemplate.Managers;
using System.Collections.Generic;
using System.Linq;

namespace BotTemplate.Extensions
{
    internal static class ListExtensions
    {
        #region AllocatedMemory Lists

        public static void DisposeMemory(this List<AllocatedMemory> memory)
        {
            foreach(AllocatedMemory m in memory)
            {
                MemoryManager.BlackMagic.FreeMemory(m.Address);
            }

            memory.Clear();
        }

        public static AllocatedMemory GetFreeMemory(this List<AllocatedMemory> memory, int sizeOfAllocation)
        {
            foreach (AllocatedMemory m in memory)
                if (!m.Locked)
                {
                    m.Locked = true;
                    return m;
                }

            memory.Add(new AllocatedMemory(MemoryManager.BlackMagic.AllocateMemory(sizeOfAllocation)));
            return memory.Last();
        }

        #endregion
    }
}
