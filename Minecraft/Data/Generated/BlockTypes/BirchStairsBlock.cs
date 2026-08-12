using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchStairsBlock(Identifier Identifier, Direction Facing, BirchStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:birch_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9808,
                            false => 9809,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9810,
                            false => 9811,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9812,
                            false => 9813,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9814,
                            false => 9815,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9816,
                            false => 9817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9818,
                            false => 9819,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9820,
                            false => 9821,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9822,
                            false => 9823,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9824,
                            false => 9825,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9826,
                            false => 9827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9828,
                            false => 9829,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9830,
                            false => 9831,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9832,
                            false => 9833,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9834,
                            false => 9835,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9836,
                            false => 9837,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9838,
                            false => 9839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9840,
                            false => 9841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9842,
                            false => 9843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9844,
                            false => 9845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9846,
                            false => 9847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9848,
                            false => 9849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9850,
                            false => 9851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9852,
                            false => 9853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9854,
                            false => 9855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9856,
                            false => 9857,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9858,
                            false => 9859,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9860,
                            false => 9861,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9862,
                            false => 9863,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9864,
                            false => 9865,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9866,
                            false => 9867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9868,
                            false => 9869,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9870,
                            false => 9871,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9872,
                            false => 9873,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9874,
                            false => 9875,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9876,
                            false => 9877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9878,
                            false => 9879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9880,
                            false => 9881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9882,
                            false => 9883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9884,
                            false => 9885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9886,
                            false => 9887,
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
            9808 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9809 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9810 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9811 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9812 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9813 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9814 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9815 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9816 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9817 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9818 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9819 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9820 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9821 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9822 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9823 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9824 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9825 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9826 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9827 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9828 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9829 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9830 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9831 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9832 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9833 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9834 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9835 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9836 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9837 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9838 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9839 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9840 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9841 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9842 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9843 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9844 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9845 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9846 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9847 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9848 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9849 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9850 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9851 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9852 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9853 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9854 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9855 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9856 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9857 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9858 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9859 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9860 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9861 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9862 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9863 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9864 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9865 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9866 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9867 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9868 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9869 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9870 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9871 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9872 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9873 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9874 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9875 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9876 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9877 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9878 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9879 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9880 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9881 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9882 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9883 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9884 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9885 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9886 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9887 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
