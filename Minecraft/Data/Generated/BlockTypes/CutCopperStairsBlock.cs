using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutCopperStairsBlock(Identifier Identifier, Direction Facing, CutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27808,
                            false => 27809,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27810,
                            false => 27811,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27812,
                            false => 27813,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27814,
                            false => 27815,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27816,
                            false => 27817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27818,
                            false => 27819,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27820,
                            false => 27821,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27822,
                            false => 27823,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27824,
                            false => 27825,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27826,
                            false => 27827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27828,
                            false => 27829,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27830,
                            false => 27831,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27832,
                            false => 27833,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27834,
                            false => 27835,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27836,
                            false => 27837,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27838,
                            false => 27839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27840,
                            false => 27841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27842,
                            false => 27843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27844,
                            false => 27845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27846,
                            false => 27847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27848,
                            false => 27849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27850,
                            false => 27851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27852,
                            false => 27853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27854,
                            false => 27855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27856,
                            false => 27857,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27858,
                            false => 27859,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27860,
                            false => 27861,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27862,
                            false => 27863,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27864,
                            false => 27865,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27866,
                            false => 27867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27868,
                            false => 27869,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27870,
                            false => 27871,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27872,
                            false => 27873,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27874,
                            false => 27875,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27876,
                            false => 27877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27878,
                            false => 27879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27880,
                            false => 27881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27882,
                            false => 27883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27884,
                            false => 27885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27886,
                            false => 27887,
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
            27808 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27809 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27810 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27811 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27812 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27813 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27814 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27815 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27816 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27817 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27818 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27819 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27820 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27821 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27822 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27823 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27824 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27825 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27826 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27827 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27828 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27829 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27830 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27831 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27832 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27833 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27834 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27835 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27836 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27837 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27838 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27839 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            27840 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            27841 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            27842 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            27843 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            27844 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            27845 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            27846 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            27847 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            27848 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            27849 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            27850 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            27851 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            27852 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            27853 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            27854 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            27855 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            27856 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            27857 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            27858 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            27859 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            27860 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            27861 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            27862 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            27863 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            27864 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            27865 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            27866 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            27867 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            27868 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            27869 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            27870 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            27871 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            27872 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            27873 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            27874 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            27875 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            27876 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            27877 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            27878 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            27879 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            27880 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            27881 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            27882 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            27883 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            27884 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            27885 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            27886 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            27887 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
