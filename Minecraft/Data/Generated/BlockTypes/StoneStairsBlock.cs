using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneStairsBlock(Identifier Identifier, Direction Facing, StoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:stone_stairs";
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
    public string TranslationKey => "block.minecraft.stone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15776,
                            false => 15777,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15778,
                            false => 15779,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15780,
                            false => 15781,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15782,
                            false => 15783,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15784,
                            false => 15785,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15786,
                            false => 15787,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15788,
                            false => 15789,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15790,
                            false => 15791,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15792,
                            false => 15793,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15794,
                            false => 15795,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15796,
                            false => 15797,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15798,
                            false => 15799,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15800,
                            false => 15801,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15802,
                            false => 15803,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15804,
                            false => 15805,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15806,
                            false => 15807,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15808,
                            false => 15809,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15810,
                            false => 15811,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15812,
                            false => 15813,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15814,
                            false => 15815,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15816,
                            false => 15817,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15818,
                            false => 15819,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15820,
                            false => 15821,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15822,
                            false => 15823,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15824,
                            false => 15825,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15826,
                            false => 15827,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15828,
                            false => 15829,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15830,
                            false => 15831,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15832,
                            false => 15833,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15834,
                            false => 15835,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15836,
                            false => 15837,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15838,
                            false => 15839,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15840,
                            false => 15841,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15842,
                            false => 15843,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15844,
                            false => 15845,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15846,
                            false => 15847,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15848,
                            false => 15849,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15850,
                            false => 15851,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15852,
                            false => 15853,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15854,
                            false => 15855,
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
            15776 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15777 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15778 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15779 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15780 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15781 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15782 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15783 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15784 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15785 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15786 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15787 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15788 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15789 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15790 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15791 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15792 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15793 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15794 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15795 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15796 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15797 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15798 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15799 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15800 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15801 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15802 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15803 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15804 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15805 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15806 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15807 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15808 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15809 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15810 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15811 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15812 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15813 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15814 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15815 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15816 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15817 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15818 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15819 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15820 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15821 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15822 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15823 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15824 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15825 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15826 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15827 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15828 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15829 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15830 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15831 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15832 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15833 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15834 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15835 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15836 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15837 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15838 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15839 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15840 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15841 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15842 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15843 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15844 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15845 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15846 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15847 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15848 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15849 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15850 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15851 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15852 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15853 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15854 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15855 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
