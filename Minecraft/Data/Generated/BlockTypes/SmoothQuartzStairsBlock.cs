using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothQuartzStairsBlock(Identifier Identifier, Direction Facing, SmoothQuartzStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 803;
    public double Hardness => 2;
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
    public Identifier? Item => "minecraft:smooth_quartz_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.smooth_quartz_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15734,
                            false => 15735,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15736,
                            false => 15737,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15738,
                            false => 15739,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15740,
                            false => 15741,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15742,
                            false => 15743,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15744,
                            false => 15745,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15746,
                            false => 15747,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15748,
                            false => 15749,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15750,
                            false => 15751,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15752,
                            false => 15753,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15754,
                            false => 15755,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15756,
                            false => 15757,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15758,
                            false => 15759,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15760,
                            false => 15761,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15762,
                            false => 15763,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15764,
                            false => 15765,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15766,
                            false => 15767,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15768,
                            false => 15769,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15770,
                            false => 15771,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15772,
                            false => 15773,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15774,
                            false => 15775,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15776,
                            false => 15777,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15778,
                            false => 15779,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15780,
                            false => 15781,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15782,
                            false => 15783,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15784,
                            false => 15785,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15786,
                            false => 15787,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15788,
                            false => 15789,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15790,
                            false => 15791,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15792,
                            false => 15793,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15794,
                            false => 15795,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15796,
                            false => 15797,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15798,
                            false => 15799,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15800,
                            false => 15801,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15802,
                            false => 15803,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15804,
                            false => 15805,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15806,
                            false => 15807,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15808,
                            false => 15809,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15810,
                            false => 15811,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15812,
                            false => 15813,
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
            15734 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15735 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15736 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15737 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15738 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15739 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15740 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15741 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15742 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15743 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15744 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15745 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15746 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15747 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15748 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15749 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15750 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15751 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15752 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15753 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15754 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15755 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15756 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15757 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15758 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15759 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15760 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15761 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15762 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15763 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15764 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15765 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15766 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15767 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15768 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15769 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15770 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15771 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15772 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15773 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15774 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15775 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15776 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15777 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15778 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15779 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15780 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15781 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15782 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15783 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15784 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15785 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15786 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15787 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15788 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15789 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15790 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15791 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15792 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15793 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15794 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15795 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15796 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15797 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15798 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15799 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15800 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15801 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15802 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15803 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15804 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15805 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15806 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15807 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15808 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15809 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15810 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15811 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15812 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15813 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
