using System;
using System.Threading;
using System.Diagnostics;

using UserApi.Interfaces;
using UserApi.Managers;
using UserApi;
using System.Linq;

namespace Plugin
{
    public class Plugin : IPlugin
    {
        Stopwatch sw_OM = new Stopwatch();
        Stopwatch tickTime = new Stopwatch();
        public string Description
        {
            get
            {
                return "A test plugin";
            }
        }

        public string Name
        {
            get
            {
                return "Traceline";
            }
        }

        public string Version
        {
            get
            {
                return "1";
            }
        }

        public Enums.PluginType PluginType
        {
            get
            {
                return Enums.PluginType.Utility;
            }
        }

        public void OpenForm()
        {
            // do nuthing
        }

        public void Pulse()
        {
            if (!sw_OM.IsRunning) sw_OM.Restart();

            if (sw_OM.Elapsed > TimeSpan.FromMilliseconds(20))
            {
                ObjectManager.Update();
                sw_OM.Restart();
            }

            var players = ObjectManager.GetPlayers();

            if (players.Count < 2)
                return;

            var me = WoW.LocalPlayer;
            var target = players[1];
                       
            Bot.EnableFramelock();
            float traceResult = WoW.TraceLine(target.Location, me.Location, Enums.CGWorldFrameHitFlags.HitTestLOS);
            tickTime.Restart();
            Bot.WriteToConsole("Trace Result: " + traceResult + " Trace Target Name: " + target.Name+ " Time: " +tickTime.ElapsedMilliseconds);
            Bot.DisableFramelock();
        }

        private void FollowPlayers()
        {
            ObjectManager.Update();

            var players = ObjectManager.GetPlayers();

            if (players.Count >= 2)
            {
                var me = WoW.LocalPlayer;
                var target = players[1];

                Bot.EnableFramelock();
                Bot.WriteToConsole(target.Name + " name  combat: " + target.IsInCombat);
                me.CGPlayer_C__ClickToMove(target.Location, target.GUID, Enums.ClickToMoveType.GoTo, 0);
                Bot.DisableFramelock();
            }
            else
            {
                Bot.WriteToConsole("no target :(");
            }
        }

        private void FrameLockCTM()
        {
            ObjectManager.Update();

            Bot.EnableFramelock();

            for (int i = 0; i < 100; i++)
                WoW.LocalPlayer.CGPlayer_C__ClickToMove(WoW.LocalPlayer.Target.Location, WoW.LocalPlayer.Target.GUID, Enums.ClickToMoveType.GoTo, 0);

            Bot.DisableFramelock();
        }

       
        private void ObjectmanagerToConsole()
        {
            ObjectManager.Update();
            var objects = ObjectManager.GetGameObjects();

            Thread.Sleep(2000);


            foreach (var gameObject in objects)
            {
                Bot.WriteToConsole(gameObject.Name);
            }
        }

        public void Close()
        {
            // do nothing
        }

    }
}
