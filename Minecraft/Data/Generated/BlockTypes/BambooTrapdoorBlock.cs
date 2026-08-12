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
                                true => 7690,
                                false => 7691,
                            },
                            false => Waterlogged switch {
                                true => 7692,
                                false => 7693,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7694,
                                false => 7695,
                            },
                            false => Waterlogged switch {
                                true => 7696,
                                false => 7697,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7698,
                                false => 7699,
                            },
                            false => Waterlogged switch {
                                true => 7700,
                                false => 7701,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7702,
                                false => 7703,
                            },
                            false => Waterlogged switch {
                                true => 7704,
                                false => 7705,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7706,
                                false => 7707,
                            },
                            false => Waterlogged switch {
                                true => 7708,
                                false => 7709,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7710,
                                false => 7711,
                            },
                            false => Waterlogged switch {
                                true => 7712,
                                false => 7713,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7714,
                                false => 7715,
                            },
                            false => Waterlogged switch {
                                true => 7716,
                                false => 7717,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7718,
                                false => 7719,
                            },
                            false => Waterlogged switch {
                                true => 7720,
                                false => 7721,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7722,
                                false => 7723,
                            },
                            false => Waterlogged switch {
                                true => 7724,
                                false => 7725,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7726,
                                false => 7727,
                            },
                            false => Waterlogged switch {
                                true => 7728,
                                false => 7729,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7730,
                                false => 7731,
                            },
                            false => Waterlogged switch {
                                true => 7732,
                                false => 7733,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7734,
                                false => 7735,
                            },
                            false => Waterlogged switch {
                                true => 7736,
                                false => 7737,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7738,
                                false => 7739,
                            },
                            false => Waterlogged switch {
                                true => 7740,
                                false => 7741,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7742,
                                false => 7743,
                            },
                            false => Waterlogged switch {
                                true => 7744,
                                false => 7745,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7746,
                                false => 7747,
                            },
                            false => Waterlogged switch {
                                true => 7748,
                                false => 7749,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7750,
                                false => 7751,
                            },
                            false => Waterlogged switch {
                                true => 7752,
                                false => 7753,
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
            7690 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7691 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7692 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7693 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7694 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7695 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7696 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7697 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7698 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7699 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7700 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7701 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7702 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7703 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7704 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7705 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7706 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7707 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7708 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7709 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7710 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7711 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7712 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7713 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7714 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7715 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7716 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7717 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7718 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7719 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7720 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7721 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7722 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7723 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7724 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7725 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7726 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7727 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7728 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7729 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7730 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7731 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7732 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7733 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7734 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7735 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7736 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7737 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7738 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7739 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7740 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7741 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7742 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7743 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7744 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7745 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7746 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7747 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7748 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7749 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7750 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7751 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7752 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7753 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
