using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Scp914;
using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Scp914Effects
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Determines the effects to happen on each mode.")]
        public Dictionary<Scp914Knob, List<string>> Effects { get; set; } = new Dictionary<Scp914Knob, List<string>>
        {
            [Scp914Knob.Rough] = new List<string> { },
            [Scp914Knob.Coarse] = new List<string> { },
            [Scp914Knob.OneToOne] = new List<string> { },
            [Scp914Knob.Fine] = new List<string> { },
            [Scp914Knob.VeryFine] = new List<string> { },
        };

        [Description("Determines the rooms to teleport to upon going through SCP-914 on certain modes. This will only affect players if 'teleport' is an effect on the specified mode.")]
        public Dictionary<Scp914Knob, List<RoomType>> TeleportRooms { get; set; } = new Dictionary<Scp914Knob, List<RoomType>>
        {
            [Scp914Knob.Rough] = new List<RoomType> { },
            [Scp914Knob.Coarse] = new List<RoomType> { },
            [Scp914Knob.OneToOne] = new List<RoomType> { },
            [Scp914Knob.Fine] = new List<RoomType> { },
            [Scp914Knob.VeryFine] = new List<RoomType> { },
        };

        [Description("Determines the chances of each effect to happen on certain SCP-914 modes.")]
        public Dictionary<Scp914Knob, int> EffectChance { get; set; } = new Dictionary<Scp914Knob, int>
        {
            [Scp914Knob.Rough] = 100,
            [Scp914Knob.Coarse] = 100,
            [Scp914Knob.OneToOne] = 100,
            [Scp914Knob.Fine] = 100,
            [Scp914Knob.VeryFine] = 100,
        };

        [Description("Determines the string displayed for each class in the broadcast effect.")]
        public Dictionary<RoleType, string> RoleStrings { get; set; } = new Dictionary<RoleType, string>
        {
            [RoleType.ClassD] = "Class-D Personnel",
            [RoleType.Scientist] = "Scientist",
            [RoleType.FacilityGuard] = "Facility Guard",
            [RoleType.NtfCadet] = "NTF Cadet",
            [RoleType.NtfLieutenant] = "NTF Lieutenant",
            [RoleType.NtfScientist] = "NTF Scientist",
            [RoleType.NtfCommander] = "NTF Commander",
            [RoleType.ChaosInsurgency] = "Chaos Insurgency",
            [RoleType.Scp049] = "SCP-049",
            [RoleType.Scp0492] = "SCP-049-2",
            [RoleType.Scp096] = "SCP-096",
            [RoleType.Scp106] = "SCP-106",
            [RoleType.Scp173] = "SCP-173",
            [RoleType.Scp93953] = "SCP-939-53",
            [RoleType.Scp93989] = "SCP-939-89",
            [RoleType.Tutorial] = "Tutorial",
        };
    }
}
