using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkSensorBlock(Identifier Identifier, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:sculk_sensor";
    public int ProtocolId => 999;
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "sculk_sensor";
    public Identifier? BlockEntity => "minecraft:sculk_sensor";
    public Identifier? Item => "minecraft:sculk_sensor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.sculk_sensor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Power switch {
                0 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24488,
                        false => 24489,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24490,
                        false => 24491,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24492,
                        false => 24493,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                1 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24494,
                        false => 24495,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24496,
                        false => 24497,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24498,
                        false => 24499,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                2 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24500,
                        false => 24501,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24502,
                        false => 24503,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24504,
                        false => 24505,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                3 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24506,
                        false => 24507,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24508,
                        false => 24509,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24510,
                        false => 24511,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                4 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24512,
                        false => 24513,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24514,
                        false => 24515,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24516,
                        false => 24517,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                5 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24518,
                        false => 24519,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24520,
                        false => 24521,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24522,
                        false => 24523,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                6 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24524,
                        false => 24525,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24526,
                        false => 24527,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24528,
                        false => 24529,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                7 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24530,
                        false => 24531,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24532,
                        false => 24533,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24534,
                        false => 24535,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                8 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24536,
                        false => 24537,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24538,
                        false => 24539,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24540,
                        false => 24541,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                9 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24542,
                        false => 24543,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24544,
                        false => 24545,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24546,
                        false => 24547,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                10 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24548,
                        false => 24549,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24550,
                        false => 24551,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24552,
                        false => 24553,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                11 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24554,
                        false => 24555,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24556,
                        false => 24557,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24558,
                        false => 24559,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                12 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24560,
                        false => 24561,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24562,
                        false => 24563,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24564,
                        false => 24565,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                13 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24566,
                        false => 24567,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24568,
                        false => 24569,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24570,
                        false => 24571,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                14 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24572,
                        false => 24573,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24574,
                        false => 24575,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24576,
                        false => 24577,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                15 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 24578,
                        false => 24579,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 24580,
                        false => 24581,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 24582,
                        false => 24583,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24488 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, true),
            24489 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, false),
            24490 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, true),
            24491 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, false),
            24492 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, true),
            24493 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, false),
            24494 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, true),
            24495 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, false),
            24496 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, true),
            24497 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, false),
            24498 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, true),
            24499 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, false),
            24500 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, true),
            24501 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, false),
            24502 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, true),
            24503 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, false),
            24504 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, true),
            24505 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, false),
            24506 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, true),
            24507 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, false),
            24508 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, true),
            24509 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, false),
            24510 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, true),
            24511 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, false),
            24512 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, true),
            24513 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, false),
            24514 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, true),
            24515 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, false),
            24516 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, true),
            24517 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, false),
            24518 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, true),
            24519 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, false),
            24520 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, true),
            24521 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, false),
            24522 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, true),
            24523 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, false),
            24524 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, true),
            24525 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, false),
            24526 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, true),
            24527 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, false),
            24528 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, true),
            24529 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, false),
            24530 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, true),
            24531 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, false),
            24532 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, true),
            24533 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, false),
            24534 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, true),
            24535 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, false),
            24536 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, true),
            24537 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, false),
            24538 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, true),
            24539 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, false),
            24540 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, true),
            24541 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, false),
            24542 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, true),
            24543 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, false),
            24544 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, true),
            24545 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, false),
            24546 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, true),
            24547 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, false),
            24548 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, true),
            24549 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, false),
            24550 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, true),
            24551 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, false),
            24552 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, true),
            24553 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, false),
            24554 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, true),
            24555 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, false),
            24556 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, true),
            24557 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, false),
            24558 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, true),
            24559 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, false),
            24560 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, true),
            24561 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, false),
            24562 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, true),
            24563 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, false),
            24564 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, true),
            24565 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, false),
            24566 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, true),
            24567 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, false),
            24568 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, true),
            24569 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, false),
            24570 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, true),
            24571 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, false),
            24572 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, true),
            24573 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, false),
            24574 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, true),
            24575 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, false),
            24576 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, true),
            24577 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, false),
            24578 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, true),
            24579 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, false),
            24580 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, true),
            24581 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, false),
            24582 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, true),
            24583 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.ChildrenMap.ContainsKey("power") ? int.Parse(properties["power"].GetString()) : Power,
            SculkSensorPhase = properties.ChildrenMap.ContainsKey("sculk_sensor_phase") ? SculkSensorPhaseExtensions.FromString(properties["sculk_sensor_phase"].GetString()) : SculkSensorPhase,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("power", Power.ToString()),
            new StringTag("sculk_sensor_phase", SculkSensorPhase.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
