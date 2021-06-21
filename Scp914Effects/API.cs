using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exiled.API.Features;
using Exiled.API.Enums;
using Scp914;
using UnityEngine;

using MEC;

using Random = System.Random;

namespace Scp914Effects
{
    public class API
    {
        private static Random Rng = new Random();

        public static Dictionary<string, Action<Player, List<string>, Scp914Knob>> Effects = new Dictionary<string, Action<Player, List<string>, Scp914Knob>>
        {
            ["ahp"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                if (Ply.Role == RoleType.Scp096)
                {
                    return;
                }
                bool canParse = float.TryParse(Args[0], out float amount);
                if (!canParse)
                {
                    Log.Error("AHP effect must have a numerical argument!");
                    return;
                }
                Ply.ArtificialHealth += amount;
            },

            ["broadcast"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = ushort.TryParse(Args[1], out ushort duration);
                string type = Args[0];
                if (!canParse)
                {
                    Log.Error("Broadcast effect 2nd argument must be a numerical argument!");
                    return;
                }
                Args.RemoveRange(0, 2);
                string message = string.Join(" ", Args).Replace("{name}", (Ply.DisplayNickname != null ? Ply.DisplayNickname : Ply.Nickname)).Replace("{class}", $"<color={Ply.RoleColor.ToHex()}>{Plugin.Singleton.Config.RoleStrings[Ply.Role]}</color>");
                if (type == "*")
                {
                    Map.Broadcast(duration, message);
                }
                else if (type == "adminchat")
                {
                    Map.Broadcast(duration, message, Broadcast.BroadcastFlags.AdminChat);
                }
                else if (type == "self")
                {
                    Ply.Broadcast(duration, message);
                }
                else
                {
                    string[] teams = type.Split(char.Parse("."));
                    foreach(string teamStr in teams)
                    {
                        if (!Enum.TryParse(teamStr, true, out Team team))
                        {
                            Log.Warn($"Broadcast effect: {teamStr} is not a valid team. Skipping.");
                            continue;
                        }
                        foreach (Player TeamPly in Player.Get(team))
                        {
                            TeamPly.Broadcast(duration, message);
                        }
                    }
                }
            },

            ["damage"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = float.TryParse(Args[0], out float amount);
                if (!canParse)
                {
                    Log.Error("Damage effect must have a numerical damage amount!");
                    return;
                }
                Ply.Hurt(amount, DamageTypes.Wall, "SCP-914");
            },

            ["dropitems"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                Timing.CallDelayed(0.15f, () => // If the player is teleported, we want dropped items to teleport to their new location
                {
                    if (Args[0] == "*")
                    {
                        Ply.DropItems();
                    }
                    else
                    {
                        bool canParse = int.TryParse(Args[0], out int amount);
                        if (!canParse)
                        {
                            Log.Error("Dropitems effect must have a numerical # amount (whole number) or * for all items!");
                            return;
                        }
                        for (int i = 0; i < amount; i++)
                        {
                            Inventory.SyncItemInfo Chosen = Ply.Inventory.items[Rng.Next(Ply.Inventory.items.Count)];
                            Ply.DropItem(Chosen);
                        }
                    }
                });
            },

            ["effect"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = float.TryParse(Args[1], out float amount);
                if (!canParse)
                {
                    Log.Error("Effect effect must have a valid effect name and a numerical length argument!");
                    return;
                }
                Ply.EnableEffect(Args[0], amount, true);
            },

            ["god"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = float.TryParse(Args[0], out float amount);
                if (!canParse)
                {
                    Log.Error("God effect must have a numerical damage amount!");
                    return;
                }
                Ply.IsGodModeEnabled = true;
                Timing.CallDelayed(amount, () =>
                {
                    Ply.IsGodModeEnabled = false;
                });
            },

            ["heal"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = float.TryParse(Args[0], out float amount);
                if (!canParse)
                {
                    Log.Error("Heal effect must have a numerical argument!");
                    return;
                }
                Ply.Health += amount;
            },

            ["kill"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) => Ply.Kill(DamageTypes.Wall),

            ["setrole"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                if (!Enum.TryParse(Args[0], true, out RoleType RoleOriginal))
                {
                    Log.Error("Setclass effect must have a valid original role type!");
                    return;
                }
                if (!Enum.TryParse(Args[1], true, out RoleType RoleNew))
                {
                    Log.Error("Setclass effect must have a valid new role type!");
                    return;
                }
                if (Ply.Role == RoleOriginal)
                {
                    Ply.SetRole(RoleNew, true, false);
                }
            },

            ["stamina"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                bool canParse = float.TryParse(Args[0], out float amount);
                if (!canParse)
                {
                    Log.Error("Stamina effect must have a numerical argument!");
                    return;
                }
                Ply.Stamina.RemainingStamina = amount;
            },

            ["teleport"] = (Player Ply, List<string> Args, Scp914Knob KnobSetting) =>
            {
                if (!Plugin.Singleton.Config.TeleportRooms.ContainsKey(KnobSetting))
                {
                    Log.Error($"Teleport effect: Rooms for {KnobSetting} setting not configured.");
                    return;
                }
                Scp914Knob setting = Scp914Machine.singleton.knobState;
                List<RoomType> Rooms = Plugin.Singleton.Config.TeleportRooms[KnobSetting];
                RoomType ChosenRoomType = Rooms[Rng.Next(Rooms.Count)];
                Room ChosenRoom = Map.Rooms.FirstOrDefault(r => r.Type == ChosenRoomType);
                if (!PlayerMovementSync.FindSafePosition(ChosenRoom.Position, out Vector3 SafePos))
                {
                    Log.Error($"Teleport effect: Could not find safe area to teleport player in room {ChosenRoomType}.");
                    return;
                }
                Timing.CallDelayed(0.1f, () =>
                {
                    Ply.Position = SafePos;
                });
            },
        };

        public static void EnableEffect(Player Ply, Scp914Knob setting, string name, List<string> args)
        {
            try
            {
                var Info = Effects[name];
                Info(Ply, args, setting);
            }
            catch (KeyNotFoundException)
            {
                Log.Warn($"Invalid teleport effect: {name}. Ignoring.");
            }
        }

        public static List<string> GetEffects(Scp914Knob mode) => Plugin.Singleton.Config.Effects[mode];

        public static bool GetChance(Scp914Knob mode) => Rng.Next(1, 100) <= Plugin.Singleton.Config.EffectChance[mode];
    }
}
