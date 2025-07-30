using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AndesiteStairsBlock(Identifier Identifier, Direction Facing, AndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 775;
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
    public Identifier? Item => "minecraft:andesite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14817,
                            false => 14818,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14819,
                            false => 14820,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14821,
                            false => 14822,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14823,
                            false => 14824,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14825,
                            false => 14826,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14827,
                            false => 14828,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14829,
                            false => 14830,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14831,
                            false => 14832,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14833,
                            false => 14834,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14835,
                            false => 14836,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14837,
                            false => 14838,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14839,
                            false => 14840,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14841,
                            false => 14842,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14843,
                            false => 14844,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14845,
                            false => 14846,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14847,
                            false => 14848,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14849,
                            false => 14850,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14851,
                            false => 14852,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14853,
                            false => 14854,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14855,
                            false => 14856,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14857,
                            false => 14858,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14859,
                            false => 14860,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14861,
                            false => 14862,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14863,
                            false => 14864,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14865,
                            false => 14866,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14867,
                            false => 14868,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14869,
                            false => 14870,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14871,
                            false => 14872,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14873,
                            false => 14874,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14875,
                            false => 14876,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14877,
                            false => 14878,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14879,
                            false => 14880,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14881,
                            false => 14882,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14883,
                            false => 14884,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14885,
                            false => 14886,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14887,
                            false => 14888,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14889,
                            false => 14890,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14891,
                            false => 14892,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14893,
                            false => 14894,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14895,
                            false => 14896,
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
            14817 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14818 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14819 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14820 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14821 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14822 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14823 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14824 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14825 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14826 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14827 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14828 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14829 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14830 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14831 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14832 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14833 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14834 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14835 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14836 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14837 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14838 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14839 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14840 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14841 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14842 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14843 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14844 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14845 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14846 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14847 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14848 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14849 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14850 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14851 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14852 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14853 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14854 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14855 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14856 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14857 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14858 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14859 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14860 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14861 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14862 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14863 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14864 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14865 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14866 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14867 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14868 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14869 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14870 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14871 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14872 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14873 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14874 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14875 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14876 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14877 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14878 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14879 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14880 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14881 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14882 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14883 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14884 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14885 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14886 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14887 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14888 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14889 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14890 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14891 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14892 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14893 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14894 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14895 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14896 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("shape", Shape.ToName()),
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
