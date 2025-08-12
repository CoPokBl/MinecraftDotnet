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
    public int ProtocolId => 961;
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
                        true => 23379,
                        false => 23380,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23381,
                        false => 23382,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23383,
                        false => 23384,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                1 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23385,
                        false => 23386,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23387,
                        false => 23388,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23389,
                        false => 23390,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                2 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23391,
                        false => 23392,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23393,
                        false => 23394,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23395,
                        false => 23396,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                3 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23397,
                        false => 23398,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23399,
                        false => 23400,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23401,
                        false => 23402,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                4 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23403,
                        false => 23404,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23405,
                        false => 23406,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23407,
                        false => 23408,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                5 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23409,
                        false => 23410,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23411,
                        false => 23412,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23413,
                        false => 23414,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                6 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23415,
                        false => 23416,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23417,
                        false => 23418,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23419,
                        false => 23420,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                7 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23421,
                        false => 23422,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23423,
                        false => 23424,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23425,
                        false => 23426,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                8 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23427,
                        false => 23428,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23429,
                        false => 23430,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23431,
                        false => 23432,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                9 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23433,
                        false => 23434,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23435,
                        false => 23436,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23437,
                        false => 23438,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                10 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23439,
                        false => 23440,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23441,
                        false => 23442,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23443,
                        false => 23444,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                11 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23445,
                        false => 23446,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23447,
                        false => 23448,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23449,
                        false => 23450,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                12 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23451,
                        false => 23452,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23453,
                        false => 23454,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23455,
                        false => 23456,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                13 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23457,
                        false => 23458,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23459,
                        false => 23460,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23461,
                        false => 23462,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                14 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23463,
                        false => 23464,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23465,
                        false => 23466,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23467,
                        false => 23468,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                15 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23469,
                        false => 23470,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23471,
                        false => 23472,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23473,
                        false => 23474,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23379 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, true),
            23380 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, false),
            23381 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, true),
            23382 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, false),
            23383 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, true),
            23384 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, false),
            23385 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, true),
            23386 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, false),
            23387 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, true),
            23388 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, false),
            23389 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, true),
            23390 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, false),
            23391 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, true),
            23392 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, false),
            23393 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, true),
            23394 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, false),
            23395 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, true),
            23396 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, false),
            23397 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, true),
            23398 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, false),
            23399 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, true),
            23400 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, false),
            23401 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, true),
            23402 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, false),
            23403 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, true),
            23404 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, false),
            23405 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, true),
            23406 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, false),
            23407 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, true),
            23408 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, false),
            23409 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, true),
            23410 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, false),
            23411 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, true),
            23412 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, false),
            23413 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, true),
            23414 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, false),
            23415 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, true),
            23416 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, false),
            23417 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, true),
            23418 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, false),
            23419 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, true),
            23420 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, false),
            23421 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, true),
            23422 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, false),
            23423 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, true),
            23424 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, false),
            23425 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, true),
            23426 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, false),
            23427 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, true),
            23428 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, false),
            23429 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, true),
            23430 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, false),
            23431 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, true),
            23432 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, false),
            23433 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, true),
            23434 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, false),
            23435 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, true),
            23436 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, false),
            23437 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, true),
            23438 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, false),
            23439 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, true),
            23440 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, false),
            23441 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, true),
            23442 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, false),
            23443 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, true),
            23444 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, false),
            23445 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, true),
            23446 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, false),
            23447 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, true),
            23448 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, false),
            23449 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, true),
            23450 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, false),
            23451 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, true),
            23452 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, false),
            23453 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, true),
            23454 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, false),
            23455 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, true),
            23456 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, false),
            23457 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, true),
            23458 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, false),
            23459 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, true),
            23460 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, false),
            23461 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, true),
            23462 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, false),
            23463 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, true),
            23464 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, false),
            23465 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, true),
            23466 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, false),
            23467 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, true),
            23468 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, false),
            23469 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, true),
            23470 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, false),
            23471 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, true),
            23472 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, false),
            23473 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, true),
            23474 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, false),
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
