using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackstoneStairsBlock(Identifier Identifier, Direction Facing, BlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 1.5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:blackstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.blackstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21832,
                            false => 21833,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21834,
                            false => 21835,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21836,
                            false => 21837,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21838,
                            false => 21839,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21840,
                            false => 21841,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21842,
                            false => 21843,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21844,
                            false => 21845,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21846,
                            false => 21847,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21848,
                            false => 21849,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21850,
                            false => 21851,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21852,
                            false => 21853,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21854,
                            false => 21855,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21856,
                            false => 21857,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21858,
                            false => 21859,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21860,
                            false => 21861,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21862,
                            false => 21863,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21864,
                            false => 21865,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21866,
                            false => 21867,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21868,
                            false => 21869,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21870,
                            false => 21871,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21872,
                            false => 21873,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21874,
                            false => 21875,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21876,
                            false => 21877,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21878,
                            false => 21879,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21880,
                            false => 21881,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21882,
                            false => 21883,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21884,
                            false => 21885,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21886,
                            false => 21887,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21888,
                            false => 21889,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21890,
                            false => 21891,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21892,
                            false => 21893,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21894,
                            false => 21895,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21896,
                            false => 21897,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21898,
                            false => 21899,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21900,
                            false => 21901,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21902,
                            false => 21903,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21904,
                            false => 21905,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21906,
                            false => 21907,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21908,
                            false => 21909,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21910,
                            false => 21911,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21832 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21833 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21834 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21835 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21836 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21837 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21838 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21839 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21840 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21841 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21842 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21843 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21844 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21845 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21846 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21847 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21848 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21849 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21850 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21851 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21852 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21853 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21854 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21855 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21856 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21857 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21858 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21859 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21860 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21861 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21862 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21863 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21864 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21865 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21866 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21867 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21868 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21869 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21870 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21871 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21872 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21873 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21874 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21875 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21876 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21877 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21878 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21879 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21880 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21881 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21882 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21883 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21884 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21885 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21886 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21887 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21888 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21889 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21890 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21891 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21892 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21893 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21894 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21895 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21896 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21897 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21898 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21899 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21900 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21901 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21902 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21903 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21904 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21905 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21906 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21907 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21908 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21909 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21910 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21911 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
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
