using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooTrapdoorBlock(Identifier Identifier, Direction Facing, BambooTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 324;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7489,
                                false => 7490,
                            },
                            false => Waterlogged switch {
                                true => 7491,
                                false => 7492,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7493,
                                false => 7494,
                            },
                            false => Waterlogged switch {
                                true => 7495,
                                false => 7496,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7497,
                                false => 7498,
                            },
                            false => Waterlogged switch {
                                true => 7499,
                                false => 7500,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7501,
                                false => 7502,
                            },
                            false => Waterlogged switch {
                                true => 7503,
                                false => 7504,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7505,
                                false => 7506,
                            },
                            false => Waterlogged switch {
                                true => 7507,
                                false => 7508,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7509,
                                false => 7510,
                            },
                            false => Waterlogged switch {
                                true => 7511,
                                false => 7512,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7513,
                                false => 7514,
                            },
                            false => Waterlogged switch {
                                true => 7515,
                                false => 7516,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7517,
                                false => 7518,
                            },
                            false => Waterlogged switch {
                                true => 7519,
                                false => 7520,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7521,
                                false => 7522,
                            },
                            false => Waterlogged switch {
                                true => 7523,
                                false => 7524,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7525,
                                false => 7526,
                            },
                            false => Waterlogged switch {
                                true => 7527,
                                false => 7528,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7529,
                                false => 7530,
                            },
                            false => Waterlogged switch {
                                true => 7531,
                                false => 7532,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7533,
                                false => 7534,
                            },
                            false => Waterlogged switch {
                                true => 7535,
                                false => 7536,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7537,
                                false => 7538,
                            },
                            false => Waterlogged switch {
                                true => 7539,
                                false => 7540,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7541,
                                false => 7542,
                            },
                            false => Waterlogged switch {
                                true => 7543,
                                false => 7544,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7545,
                                false => 7546,
                            },
                            false => Waterlogged switch {
                                true => 7547,
                                false => 7548,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7549,
                                false => 7550,
                            },
                            false => Waterlogged switch {
                                true => 7551,
                                false => 7552,
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
            7489 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7490 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7491 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7492 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7493 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7494 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7495 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7496 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7497 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7498 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7499 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7500 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7501 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7502 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7503 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7504 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7505 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7506 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7507 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7508 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7509 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7510 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7511 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7512 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7513 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7514 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7515 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7516 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7517 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7518 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7519 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7520 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7521 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7522 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7523 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7524 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7525 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7526 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7527 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7528 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7529 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7530 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7531 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7532 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7533 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7534 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7535 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7536 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7537 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7538 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7539 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7540 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7541 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7542 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7543 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7544 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7545 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7546 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7547 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7548 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7549 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7550 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7551 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7552 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
