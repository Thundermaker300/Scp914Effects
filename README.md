## SCP-914 Effects
Adds realism (in some cases) and fun to SCP-914 by adding effects to users who are "upgraded" inside of SCP-914.

## Configurations
More settings are planned.
| Setting               | Type                                    | Default                                                                                   | Description                                                                                                                                                                               |
|-----------------------|-----------------------------------------|-------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| is_enabled            | boolean                                 | true                                                                                      | Enables the plugin.                                                                                                                                                                       |
| effects               | Dictionary<Scp914Knob, List<string>>    | Empty lists for all 5 modes                                                               | Sets the effects to occur for each mode. Effects are listed below.                                                                                                                        |
| teleport_rooms        | Dictionary<Scp914Knob, List<RoomType>>  | Empty lists for all 5 modes                                                               | Determines which rooms can be teleported to for each mode that have the `teleport` effect. Valid rooms can be found below.                                                                |
| effect_chance         | Dictionary<Scp914Knob, int>             | 100% for all 5 modes                                                                      | Determines the chance per player that effects can happen on the specified mode.                                                                                                           |


## TeleportEffects - Valid Strings
Note: Values in <> are parameters, and should be changed in the configs.
- `ahp:<amount>` - Gives the player the specified amount of AHP (gradually decays over time). This effect will not function for SCP-096.
- `damage:<amount>` - Deals the specified amount of damage to the player.
- `dropitems:<amount/*>` - Drops the specified amount of items (or `*` to drop all items). If the player is teleported, the items will be dropped at their new location.
- `effect:EffectType:duration` - Gives the player the specified effect for the given duration of time. Valid effects listed below.
- `god:duration` - Gives the player god mode (inability to die) for the specified duration of time.
- `heal:<amount>` - Opposite of `damage`; heals the player the specified amount of health.
- `kill` - Kills the player.
- `teleport` - Teleports the player to one of the rooms described in the `teleport_rooms` config.
- `setrole:original:new` - Changes the player's role from `original` to `new`. Their role must be matching `original`, or else they will not be changed. Valid role list found below.
- (More soon!)

## Valid Roles (for setclass effect)
Note: Case sensitive
- `ClassD` - Class-D Personnel
- `Scientist` - Scientists
- `FacilityGuard` - Facility Guards
- `NtfCadet` - NTF Cadets
- `NtfLieutenant` - NTF Lieutenants
- `NtfScientist` - NTF Scientists
- `NtfCommander` - NTF Commanders
- `ChaosInsurgency` - Chaos Insurgency
- `Scp049` - SCP-049
- `Scp0492` - SCP-049-2
- `Scp096` - SCP-096
- `Scp106` - SCP-106
- `Scp173` - SCP-173
- `Scp93953` - SCP-939-53
- `Scp93989` - SCP-939-89
- `Tutorial` - Tutorials

## TeleportRooms - Valid Rooms
**Light Containment Zone**  
- `Lcz012` - SCP-012's hallway
- `Lcz173` - Outside of SCP-173's chamber *WARNING: I've tested this and discovered that it sometimes does teleport out of the map. Would not recommend using this one.*
- `Lcz914` - Inside of SCP-914's chamber
- `LczAirlock` - One of the two LCZ airlocks (random)
- `LczArmory` - Outside of the LCZ armory.
- `LczCafe` - The PC15 room.
- `LczChkpA` - Exit A on the LCZ side.
- `LczChkpB` - Exit B on the LCZ side.
- `LczClassDSpawn` - The Class-D cell hallway.
- `LczCrossing` - One of the LCZ four ways (labled IX) (random)
- `LczCurve` - One of the LCZ curves (labeled HC) (random)
- `LczGlassBox` - SCP-372's containment chamber, also known as GR18
- `LczPlants` - VT00
- `LczStraight` - One of the LCZ straights (labeled HS) (random)
- `LczTCross` - One of the LCZ T-Crosses (labeled IT) (random)
- `LczToilets` - The WC hallway.  

**Heavy Containment Zone**  
- `Hcz049` - The hallway outside of SCP-049's elevator.
- `Hcz079` - The short hallway outside of SCP-079's containment chamber.
- `Hcz096` - The small workspace outside of SCP-096's containment chamber.
- `Hcz106` - The walkway outside of SCP-106's containment chamber.
- `Hcz939` - The walkway above SCP-939's containment chamber.
- `HczArmory` - Outside of the HCZ armory.
- `HczChkpA` - Elevator system A in heavy.
- `HczChkpB` - Elevator system B in heavy.
- `HczCrossing` - One of the HCZ four ways (random)
- `HczCurve` - One of the HCZ turns (random)
- `HczEzCheckpoint` - The HCZ/EZ checkpoint.
- `HczHid` - The Micro-HID hallway.
- `HczNuke` - The hallway leading to the alpha warhead.
- `HczServers` - The HCZ servers room
- `HczTCross` - One of the HCZ T-Crosses (random)

**Entrance Zone**  
- `EzCafeteria` - The EZ straight hallway consisting of two benches.
- `EzCollapsedTunnel` - One of the EZ dead-ends featuring scattered debris *WARNING: Can sometimes teleport ON the debris and cause stuck players. Use with caution.*
- `EzConference` - The EZ straight hallway consisting of two locked doors, one of Dr. L's room and one of Conference Room 9B.
- `EzCrossing` - One of the EZ four ways (random)
- `EzCurve` - One of the EZ turns (random)
- `EzDownstairsPcs` - The EZ straight hallway with a stairwell downward, consisting of offices.
- `EzGateA` - Outside of Gate A.
- `EzGateB` - Outside of Gate B.
- `EzIntercom` - Outside of the intercom room.
- `EzPcs` - The EZ straight hallway consisting of offices and TV screens.
- `EzStraight` - A standard EZ straight hallway.
- `EzUpstairsPcs` - The EZ straight hallway with a stairwell upward, consisting of offices.
- `EzVent` - One of the EZ red room dead-ends.  

**Surface**  
- `Surface` - Gate A at the surface.