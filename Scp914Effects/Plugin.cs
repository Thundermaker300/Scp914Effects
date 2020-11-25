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
            Events.Scp914.UpgradingItems += Handler.OnUpgradingItems;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // Events
            Events.Scp914.UpgradingItems -= Handler.OnUpgradingItems;

            // Instances
            Handler = null;

            base.OnDisabled();
        }

        public override string Name => "Scp914Effects";
        public override string Author => "Thunder";
        public override Version Version => new Version(0, 0, 0);
        public override Version RequiredExiledVersion => new Version(2, 1, 18);
        public override PluginPriority Priority => PluginPriority.High;
    }
}
