using BotTemplate.BO;
using BotTemplate.Constants;
using BotTemplate.Helper;
using BotTemplate.Hooks;
using BotTemplate.Managers;
using Magic;
using System;
using UserApi;

namespace BotTemplate.WoWObjects
{
    internal class GameObject : BaseObject
    {
        #region Fields

        private BlackMagic _wow = MemoryManager.BlackMagic;
        private object _lock = new object();

        #endregion

        #region Contructors

        public GameObject(uint baseAddress)
            : base (baseAddress)
        {

        }
        
        #endregion

        #region Properties

        public override string Name
        {
            get
            {
                return StringHelper.ConvertBytesToString(_wow.ReadBytes(_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x1A4) + 0x90), 60));
            }
        }

        public virtual Vector3 Location
        {
            get
            {
                var x = _wow.ReadFloat(BaseAdress + 0xE8);
                var y = _wow.ReadFloat(BaseAdress + 0xEC);
                var z = _wow.ReadFloat(BaseAdress + 0xF0);
                return new Vector3(x, y, z);
            }
        }
   
        public float Orientation
        {
            get
            {
                return _wow.ReadFloat(BaseAdress + 0x7A8);
            }
        }

        public virtual bool IsLootable
        {
            get
            {
                return (_wow.ReadUInt(_wow.ReadUInt(BaseAdress + 0x8) + (0x4F * 4)) == 1);
            }
        }

        public virtual bool IsBobbing
        {
            get
            {
                return (_wow.ReadByte(BaseAdress + 0xBC) == 1);
            }
        }

        #endregion

        #region Methods

        public void Target()
        {
            UInt64 oldGUID;
            lock (_lock)
            {
                oldGUID = MemoryManager.BlackMagic.ReadUInt64(0x00BD07A0); // 0x00BD07B0
            }
            lock (_lock)
            {
                MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, GUID);
            }
            lock (_lock)
            {
                WoW.LuaDoString("TargetUnit(\"mouseover\")");
            }
            lock (_lock)
            {
                MemoryManager.BlackMagic.WriteUInt64(0x00BD07A0, oldGUID);
            }

        }

        public virtual void Interact()
        {
            uint InteractVMT = 44;
            if (BaseAdress > 0)
            {
                uint VMT44 = MemoryManager.BlackMagic.ReadUInt(MemoryManager.BlackMagic.ReadUInt(BaseAdress) + ((uint)InteractVMT * 4));
                var objectManagerBase = 0x2ED0;

                string[] asm = new string[]
                {
                    "fs mov eax, [0x2C]",
                    "mov eax, [eax]",
                    "add eax, 0x10",
                    "mov dword [eax], " + objectManagerBase,
                    "mov ecx, " + BaseAdress,
                    "call " + VMT44,
                    "retn",
                 };

                D3DHook.InjectAndExecuteAsm(asm);
            }
        }

        public virtual void Face()
        {
            WoW.LocalPlayer.FacePos(this.Location);
        }
      
        #endregion
    }
}
