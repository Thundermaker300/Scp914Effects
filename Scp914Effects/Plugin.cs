using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using Events = Exiled.Events.Handlers;

namespace Scp914Effects
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        private EventHandlers Handler;
        public override void OnEnabled()
        {
            // Instances
            Singleton = this;
            Handler = new EventHandlers(this);

            // Events
            Events.Scp914.UpgradingPlayer += Handler.OnUpgradingPlayer;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // Events
            Events.Scp914.UpgradingPlayer -= Handler.OnUpgradingPlayer;

            // Instances
            Handler = null;

            base.OnDisabled();
        }

        public override string Name => "Scp914Effects";
        public override string Author => "Thunder";
        public override Version Version => new Version(1, 0, 3);
        public override Version RequiredExiledVersion => new Version(4, 2, 0);
        public override PluginPriority Priority => PluginPriority.High;
    }
}
