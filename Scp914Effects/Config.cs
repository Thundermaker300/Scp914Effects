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
        [Description("If set to true, all effects will always be enabled, except for teleport which will still use the chances.")]
        public bool AlwaysApplyEffects { get; set; } = false;

        [Description("Determines the effects to happen on each mode.")]
        public Dictionary<Scp914KnobSetting, List<string>> Effects { get; set; } = new Dictionary<Scp914KnobSetting, List<string>>
        {
            [Scp914KnobSetting.Rough] = new List<string> { },
            [Scp914KnobSetting.Coarse] = new List<string> { },
            [Scp914KnobSetting.OneToOne] = new List<string> { },
            [Scp914KnobSetting.Fine] = new List<string> { },
            [Scp914KnobSetting.VeryFine] = new List<string> { },
        };

        [Description("Determines the rooms to teleport to upon going through SCP-914 on certain modes. This will only affect players if 'teleport' is an effect on the specified mode.")]
        public Dictionary<Scp914KnobSetting, List<RoomType>> TeleportRooms { get; set; } = new Dictionary<Scp914KnobSetting, List<RoomType>>
        {
            [Scp914KnobSetting.Rough] = new List<RoomType> { },
            [Scp914KnobSetting.Coarse] = new List<RoomType> { },
            [Scp914KnobSetting.OneToOne] = new List<RoomType> { },
            [Scp914KnobSetting.Fine] = new List<RoomType> { },
            [Scp914KnobSetting.VeryFine] = new List<RoomType> { },
        };

        [Description("Determines the chances of each effect to happen on certain SCP-914 modes.")]
        public Dictionary<Scp914KnobSetting, int> EffectChance { get; set; } = new Dictionary<Scp914KnobSetting, int>
        {
            [Scp914KnobSetting.Rough] = 100,
            [Scp914KnobSetting.Coarse] = 100,
            [Scp914KnobSetting.OneToOne] = 100,
            [Scp914KnobSetting.Fine] = 100,
            [Scp914KnobSetting.VeryFine] = 100,
        };

        [Description("Determines the string displayed for each class in the broadcast effect.")]
        public Dictionary<RoleType, string> RoleStrings { get; set; } = new Dictionary<RoleType, string>
        {
            [RoleType.ClassD] = "Class-D Personnel",
            [RoleType.Scientist] = "Scientist",
            [RoleType.FacilityGuard] = "Facility Guard",
            [RoleType.NtfSpecialist] = "NTF Specialist",
            [RoleType.NtfSergeant] = "NTF Sergeant",
            [RoleType.NtfPrivate] = "NTF Private",
            [RoleType.NtfCaptain] = "NTF Captain",
            [RoleType.ChaosConscript] = "Chaos Conscript",
            [RoleType.ChaosMarauder] = "Chaos Marauder",
            [RoleType.ChaosRepressor] = "Chaos Repressor",
            [RoleType.ChaosRifleman] = "Chaos Rifleman",
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
