using BotTemplate.BO;
using Magic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BotTemplate.Extensions;
using BotTemplate.Constants;
using BotTemplate.GUI.Forms;

namespace BotTemplate.Managers
{
    internal static class MemoryManager
    {
        #region Fields

        // Memories
        private static List<AllocatedMemory> _vectors = new List<AllocatedMemory>();
        private static List<AllocatedMemory> _mem0x4 = new List<AllocatedMemory>();
        private static List<AllocatedMemory> _mem0x8 = new List<AllocatedMemory>();
        private static List<AllocatedMemory> _memRnd = new List<AllocatedMemory>();

        // Fields
        private static BlackMagic _wow = new BlackMagic();
        private static Process _process;

        #endregion

        #region Constructors

        static MemoryManager()
        {
            Process[] processes = Process.GetProcessesByName("WoW");

            if (processes.Length > 0)
                if (processes.Length > 1)
                {
                    ProcessSelectionForm frm = new ProcessSelectionForm(processes);
                    //frm.Show();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        _process = frm.SelectedProcess;
                    frm.Dispose();
                }
                else
                {
                    _process = processes[0];
                }
            else
                throw new Exception("No process found!");

            _wow.OpenProcessAndThread(_process.Id);
        }

        #endregion

        #region Properties

        public static BlackMagic BlackMagic
        {
            get
            {
                return _wow;
            }
        }

        #endregion

        #region Public Methods

        public static AllocatedMemory GetAllocatedMemory(int sizeOfMemory)
        {
            switch(sizeOfMemory)
            {
                case 4:
                    return _mem0x4.GetFreeMemory(sizeOfMemory);
                case 8:
                    return _mem0x8.GetFreeMemory(sizeOfMemory);
                case 12:
                    return _vectors.GetFreeMemory(sizeOfMemory);
                default:
                    _memRnd.Add(new AllocatedMemory(BlackMagic.AllocateMemory(sizeOfMemory)));
                    return _memRnd.Last();
            }
        }

        public static void DisposeMemory()
        {
            _vectors.DisposeMemory();
            _mem0x4.DisposeMemory();
            _mem0x8.DisposeMemory();
            _memRnd.DisposeMemory();
        }

        #endregion
    }
}
