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
                            true => 14785,
                            false => 14786,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14787,
                            false => 14788,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14789,
                            false => 14790,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14791,
                            false => 14792,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14793,
                            false => 14794,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14795,
                            false => 14796,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14797,
                            false => 14798,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14799,
                            false => 14800,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14801,
                            false => 14802,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14803,
                            false => 14804,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14805,
                            false => 14806,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14807,
                            false => 14808,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14809,
                            false => 14810,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14811,
                            false => 14812,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14813,
                            false => 14814,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14815,
                            false => 14816,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14817,
                            false => 14818,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14819,
                            false => 14820,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14821,
                            false => 14822,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14823,
                            false => 14824,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14825,
                            false => 14826,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14827,
                            false => 14828,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14829,
                            false => 14830,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14831,
                            false => 14832,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14833,
                            false => 14834,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14835,
                            false => 14836,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14837,
                            false => 14838,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14839,
                            false => 14840,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14841,
                            false => 14842,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14843,
                            false => 14844,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14845,
                            false => 14846,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14847,
                            false => 14848,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14849,
                            false => 14850,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14851,
                            false => 14852,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14853,
                            false => 14854,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14855,
                            false => 14856,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14857,
                            false => 14858,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14859,
                            false => 14860,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14861,
                            false => 14862,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14863,
                            false => 14864,
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
            14785 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14786 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14787 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14788 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14789 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14790 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14791 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14792 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14793 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14794 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14795 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14796 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14797 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14798 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14799 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14800 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14801 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14802 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14803 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14804 => new AndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14805 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14806 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14807 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14808 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14809 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14810 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14811 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14812 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14813 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14814 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14815 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14816 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14817 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14818 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14819 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14820 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14821 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14822 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14823 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14824 => new AndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14825 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14826 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14827 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14828 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14829 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14830 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14831 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14832 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14833 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14834 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14835 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14836 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14837 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14838 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14839 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14840 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14841 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14842 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14843 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14844 => new AndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14845 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14846 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14847 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14848 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14849 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14850 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14851 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14852 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14853 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14854 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14855 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14856 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14857 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14858 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14859 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14860 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14861 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14862 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14863 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14864 => new AndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
