using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scp914;
using Exiled.API.Enums;
using Exiled.API.Interfaces;

namespace Scp914Effects
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public Dictionary<Scp914Knob, List<string>> Effects { get; set; } = new Dictionary<Scp914Knob, List<string>>
        {
            [Scp914Knob.Rough] = new List<string> { },
            [Scp914Knob.Coarse] = new List<string> { },
            [Scp914Knob.OneToOne] = new List<string> { },
            [Scp914Knob.Fine] = new List<string> { },
            [Scp914Knob.VeryFine] = new List<string> { },
        };
        public Dictionary<Scp914Knob, List<RoomType>> TeleportRooms { get; set; } = new Dictionary<Scp914Knob, List<RoomType>>
        {
            [Scp914Knob.Rough] = new List<RoomType> { },
            [Scp914Knob.Coarse] = new List<RoomType> { },
            [Scp914Knob.OneToOne] = new List<RoomType> { },
            [Scp914Knob.Fine] = new List<RoomType> { },
            [Scp914Knob.VeryFine] = new List<RoomType> { },
        };

        public Dictionary<Scp914Knob, int> EffectChance { get; set; } = new Dictionary<Scp914Knob, int>
        {
            [Scp914Knob.Rough] = 100,
            [Scp914Knob.Coarse] = 100,
            [Scp914Knob.OneToOne] = 100,
            [Scp914Knob.Fine] = 100,
            [Scp914Knob.VeryFine] = 100,
        };
    }
}
