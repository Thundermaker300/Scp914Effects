using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Scp914Effects
{
    public class EventHandlers
    {
        private readonly Plugin _plugin;
        public EventHandlers(Plugin plugin) => _plugin = plugin;

        public void OnUpgradingItems(UpgradingItemsEventArgs ev)
        {
            List<string> Effects = API.GetEffects(ev.KnobSetting);
            foreach (Player Ply in ev.Players)
            {
                if (API.GetChance(ev.KnobSetting))
                {
                    foreach (string Effect in Effects)
                    {
                        List<string> EffectData = Effect.Split(char.Parse(":")).ToList();
                        string EffectName = EffectData[0].ToLower();
                        EffectData.RemoveAt(0);
                        API.EnableEffect(Ply, ev.KnobSetting, EffectName, EffectData.Select(str => str.ToLower()).ToList());
                    }
                }
            }
        }
    }
}
