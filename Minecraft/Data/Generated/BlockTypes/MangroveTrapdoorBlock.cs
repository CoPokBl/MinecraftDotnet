using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveTrapdoorBlock(Identifier Identifier, Direction Facing, MangroveTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 323;
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mangrove_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7425,
                                false => 7426,
                            },
                            false => Waterlogged switch {
                                true => 7427,
                                false => 7428,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7429,
                                false => 7430,
                            },
                            false => Waterlogged switch {
                                true => 7431,
                                false => 7432,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7433,
                                false => 7434,
                            },
                            false => Waterlogged switch {
                                true => 7435,
                                false => 7436,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7437,
                                false => 7438,
                            },
                            false => Waterlogged switch {
                                true => 7439,
                                false => 7440,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7441,
                                false => 7442,
                            },
                            false => Waterlogged switch {
                                true => 7443,
                                false => 7444,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7445,
                                false => 7446,
                            },
                            false => Waterlogged switch {
                                true => 7447,
                                false => 7448,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7449,
                                false => 7450,
                            },
                            false => Waterlogged switch {
                                true => 7451,
                                false => 7452,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7453,
                                false => 7454,
                            },
                            false => Waterlogged switch {
                                true => 7455,
                                false => 7456,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7457,
                                false => 7458,
                            },
                            false => Waterlogged switch {
                                true => 7459,
                                false => 7460,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7461,
                                false => 7462,
                            },
                            false => Waterlogged switch {
                                true => 7463,
                                false => 7464,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7465,
                                false => 7466,
                            },
                            false => Waterlogged switch {
                                true => 7467,
                                false => 7468,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7469,
                                false => 7470,
                            },
                            false => Waterlogged switch {
                                true => 7471,
                                false => 7472,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7473,
                                false => 7474,
                            },
                            false => Waterlogged switch {
                                true => 7475,
                                false => 7476,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7477,
                                false => 7478,
                            },
                            false => Waterlogged switch {
                                true => 7479,
                                false => 7480,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7481,
                                false => 7482,
                            },
                            false => Waterlogged switch {
                                true => 7483,
                                false => 7484,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7485,
                                false => 7486,
                            },
                            false => Waterlogged switch {
                                true => 7487,
                                false => 7488,
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
            7425 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7426 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7427 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7428 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7429 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7430 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7431 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7432 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7433 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7434 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7435 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7436 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7437 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7438 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7439 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7440 => new MangroveTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7441 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7442 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7443 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7444 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7445 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7446 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7447 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7448 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7449 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7450 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7451 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7452 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7453 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7454 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7455 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7456 => new MangroveTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7457 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7458 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7459 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7460 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7461 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7462 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7463 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7464 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7465 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7466 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7467 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7468 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7469 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7470 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7471 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7472 => new MangroveTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7473 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7474 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7475 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7476 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7477 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7478 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7479 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7480 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7481 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7482 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7483 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7484 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7485 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7486 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7487 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7488 => new MangroveTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
