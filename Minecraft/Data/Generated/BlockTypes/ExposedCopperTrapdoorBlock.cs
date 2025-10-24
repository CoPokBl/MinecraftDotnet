using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, ExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1056;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:exposed_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26397,
                                false => 26398,
                            },
                            false => Waterlogged switch {
                                true => 26399,
                                false => 26400,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26401,
                                false => 26402,
                            },
                            false => Waterlogged switch {
                                true => 26403,
                                false => 26404,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26405,
                                false => 26406,
                            },
                            false => Waterlogged switch {
                                true => 26407,
                                false => 26408,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26409,
                                false => 26410,
                            },
                            false => Waterlogged switch {
                                true => 26411,
                                false => 26412,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26413,
                                false => 26414,
                            },
                            false => Waterlogged switch {
                                true => 26415,
                                false => 26416,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26417,
                                false => 26418,
                            },
                            false => Waterlogged switch {
                                true => 26419,
                                false => 26420,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26421,
                                false => 26422,
                            },
                            false => Waterlogged switch {
                                true => 26423,
                                false => 26424,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26425,
                                false => 26426,
                            },
                            false => Waterlogged switch {
                                true => 26427,
                                false => 26428,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26429,
                                false => 26430,
                            },
                            false => Waterlogged switch {
                                true => 26431,
                                false => 26432,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26433,
                                false => 26434,
                            },
                            false => Waterlogged switch {
                                true => 26435,
                                false => 26436,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26437,
                                false => 26438,
                            },
                            false => Waterlogged switch {
                                true => 26439,
                                false => 26440,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26441,
                                false => 26442,
                            },
                            false => Waterlogged switch {
                                true => 26443,
                                false => 26444,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26445,
                                false => 26446,
                            },
                            false => Waterlogged switch {
                                true => 26447,
                                false => 26448,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26449,
                                false => 26450,
                            },
                            false => Waterlogged switch {
                                true => 26451,
                                false => 26452,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26453,
                                false => 26454,
                            },
                            false => Waterlogged switch {
                                true => 26455,
                                false => 26456,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26457,
                                false => 26458,
                            },
                            false => Waterlogged switch {
                                true => 26459,
                                false => 26460,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26397 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26398 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26399 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26400 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26401 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26402 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26403 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26404 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26405 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26406 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26407 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26408 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26409 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26410 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26411 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26412 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26413 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26414 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26415 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26416 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26417 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26418 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26419 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26420 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26421 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26422 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26423 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26424 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26425 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26426 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26427 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26428 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26429 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26430 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26431 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26432 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26433 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26434 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26435 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26436 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26437 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26438 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26439 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26440 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26441 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26442 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26443 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26444 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26445 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26446 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26447 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26448 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26449 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26450 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26451 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26452 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26453 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26454 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26455 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26456 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26457 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26458 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26459 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26460 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
