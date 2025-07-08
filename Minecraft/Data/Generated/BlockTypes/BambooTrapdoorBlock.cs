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
                                true => 6716,
                                false => 6717,
                            },
                            false => Waterlogged switch {
                                true => 6718,
                                false => 6719,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6720,
                                false => 6721,
                            },
                            false => Waterlogged switch {
                                true => 6722,
                                false => 6723,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6724,
                                false => 6725,
                            },
                            false => Waterlogged switch {
                                true => 6726,
                                false => 6727,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6728,
                                false => 6729,
                            },
                            false => Waterlogged switch {
                                true => 6730,
                                false => 6731,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6732,
                                false => 6733,
                            },
                            false => Waterlogged switch {
                                true => 6734,
                                false => 6735,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6736,
                                false => 6737,
                            },
                            false => Waterlogged switch {
                                true => 6738,
                                false => 6739,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6740,
                                false => 6741,
                            },
                            false => Waterlogged switch {
                                true => 6742,
                                false => 6743,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6744,
                                false => 6745,
                            },
                            false => Waterlogged switch {
                                true => 6746,
                                false => 6747,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6748,
                                false => 6749,
                            },
                            false => Waterlogged switch {
                                true => 6750,
                                false => 6751,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6752,
                                false => 6753,
                            },
                            false => Waterlogged switch {
                                true => 6754,
                                false => 6755,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6756,
                                false => 6757,
                            },
                            false => Waterlogged switch {
                                true => 6758,
                                false => 6759,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6760,
                                false => 6761,
                            },
                            false => Waterlogged switch {
                                true => 6762,
                                false => 6763,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6764,
                                false => 6765,
                            },
                            false => Waterlogged switch {
                                true => 6766,
                                false => 6767,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6768,
                                false => 6769,
                            },
                            false => Waterlogged switch {
                                true => 6770,
                                false => 6771,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6772,
                                false => 6773,
                            },
                            false => Waterlogged switch {
                                true => 6774,
                                false => 6775,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6776,
                                false => 6777,
                            },
                            false => Waterlogged switch {
                                true => 6778,
                                false => 6779,
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
            6716 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6717 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6718 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6719 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6720 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6721 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6722 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6723 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6724 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6725 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6726 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6727 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6728 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6729 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6730 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6731 => new BambooTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6732 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6733 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6734 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6735 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6736 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6737 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6738 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6739 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6740 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6741 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6742 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6743 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6744 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6745 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6746 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6747 => new BambooTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6748 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6749 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6750 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6751 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6752 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6753 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6754 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6755 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6756 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6757 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6758 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6759 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6760 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6761 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6762 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6763 => new BambooTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6764 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6765 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6766 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6767 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6768 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6769 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6770 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6771 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6772 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6773 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6774 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6775 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6776 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6777 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6778 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6779 => new BambooTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
