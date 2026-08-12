using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryTrapdoorBlock(Identifier Identifier, Direction Facing, CherryTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7434,
                                false => 7435,
                            },
                            false => Waterlogged switch {
                                true => 7436,
                                false => 7437,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7438,
                                false => 7439,
                            },
                            false => Waterlogged switch {
                                true => 7440,
                                false => 7441,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7442,
                                false => 7443,
                            },
                            false => Waterlogged switch {
                                true => 7444,
                                false => 7445,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7446,
                                false => 7447,
                            },
                            false => Waterlogged switch {
                                true => 7448,
                                false => 7449,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7450,
                                false => 7451,
                            },
                            false => Waterlogged switch {
                                true => 7452,
                                false => 7453,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7454,
                                false => 7455,
                            },
                            false => Waterlogged switch {
                                true => 7456,
                                false => 7457,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7458,
                                false => 7459,
                            },
                            false => Waterlogged switch {
                                true => 7460,
                                false => 7461,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7462,
                                false => 7463,
                            },
                            false => Waterlogged switch {
                                true => 7464,
                                false => 7465,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7466,
                                false => 7467,
                            },
                            false => Waterlogged switch {
                                true => 7468,
                                false => 7469,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7470,
                                false => 7471,
                            },
                            false => Waterlogged switch {
                                true => 7472,
                                false => 7473,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7474,
                                false => 7475,
                            },
                            false => Waterlogged switch {
                                true => 7476,
                                false => 7477,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7478,
                                false => 7479,
                            },
                            false => Waterlogged switch {
                                true => 7480,
                                false => 7481,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7482,
                                false => 7483,
                            },
                            false => Waterlogged switch {
                                true => 7484,
                                false => 7485,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7486,
                                false => 7487,
                            },
                            false => Waterlogged switch {
                                true => 7488,
                                false => 7489,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7490,
                                false => 7491,
                            },
                            false => Waterlogged switch {
                                true => 7492,
                                false => 7493,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7494,
                                false => 7495,
                            },
                            false => Waterlogged switch {
                                true => 7496,
                                false => 7497,
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
            7434 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7435 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7436 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7437 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7438 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7439 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7440 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7441 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7442 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7443 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7444 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7445 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7446 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7447 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7448 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7449 => new CherryTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7450 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7451 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7452 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7453 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7454 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7455 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7456 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7457 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7458 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7459 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7460 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7461 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7462 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7463 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7464 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7465 => new CherryTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7466 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7467 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7468 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7469 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7470 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7471 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7472 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7473 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7474 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7475 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7476 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7477 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7478 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7479 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7480 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7481 => new CherryTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7482 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7483 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7484 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7485 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7486 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7487 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7488 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7489 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7490 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7491 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7492 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7493 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7494 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7495 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7496 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7497 => new CherryTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
