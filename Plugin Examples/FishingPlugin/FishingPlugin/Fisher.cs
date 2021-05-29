using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi;
using UserApi.Managers;

namespace FishingPlugin
{
    class Fisher
    {
        private List<uint> spells = new List<uint>();
        private List<ulong> _oldBobbers = new List<ulong>();
        private int _lastAction = 0;

        public Fisher()
        {
            spells.Add(7731);
            spells.Add(7732);
            spells.Add(18248);
        }

        public void Pulse()
        {
            ObjectManager.Update();
            Fish();
            Catch();
        }

        public void Fish()
        {
            if (ReadyForNextAction() && !IsFishing())
            {
                SpellManager.CastSpellByName("Fishing");
                _lastAction = Environment.TickCount;
            }
        }

        public void Catch()
        {
            ClearOldBobbers();

            var objects = ObjectManager.GetGameObjects();

            foreach (var o in objects)
            {
                if (ReadyForNextAction() && o.Name == "Fishing Bobber" && o.IsBobbing && !_oldBobbers.Contains(o.GUID))
                {
                    o.Interact();
                    _oldBobbers.Add(o.GUID);
                    _lastAction = Environment.TickCount;
                }
            }
        }

        private void ClearOldBobbers()
        {
            while (_oldBobbers.Count > 5)
            {
                _oldBobbers.RemoveAt(0);
                _oldBobbers.TrimExcess();
            }
        }

        private bool IsFishing()
        {
            var spell = WoW.LocalPlayer.ChannelId;
            Bot.WriteLogMessage(spell.ToString());
            return spells.Contains(spell);
        }

        private bool ReadyForNextAction()
        {
            return Environment.TickCount > _lastAction + 600;
        }

    }
}
