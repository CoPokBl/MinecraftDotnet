using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobblestoneStairsBlock(Identifier Identifier, Direction Facing, CobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:cobblestone_stairs";
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
    public string TranslationKey => "block.minecraft.cobblestone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5747,
                            false => 5748,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5749,
                            false => 5750,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5751,
                            false => 5752,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5753,
                            false => 5754,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5755,
                            false => 5756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5757,
                            false => 5758,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5759,
                            false => 5760,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5761,
                            false => 5762,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5763,
                            false => 5764,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5765,
                            false => 5766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5767,
                            false => 5768,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5769,
                            false => 5770,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5771,
                            false => 5772,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5773,
                            false => 5774,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5775,
                            false => 5776,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5777,
                            false => 5778,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5779,
                            false => 5780,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5781,
                            false => 5782,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5783,
                            false => 5784,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5785,
                            false => 5786,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5787,
                            false => 5788,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5789,
                            false => 5790,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5791,
                            false => 5792,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5793,
                            false => 5794,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5795,
                            false => 5796,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5797,
                            false => 5798,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5799,
                            false => 5800,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5801,
                            false => 5802,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5803,
                            false => 5804,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5805,
                            false => 5806,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5807,
                            false => 5808,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5809,
                            false => 5810,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5811,
                            false => 5812,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5813,
                            false => 5814,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5815,
                            false => 5816,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5817,
                            false => 5818,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5819,
                            false => 5820,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5821,
                            false => 5822,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5823,
                            false => 5824,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5825,
                            false => 5826,
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
            5747 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            5748 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            5749 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            5750 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            5751 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            5752 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            5753 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            5754 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            5755 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            5756 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            5757 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            5758 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            5759 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            5760 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            5761 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            5762 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            5763 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            5764 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            5765 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            5766 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            5767 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            5768 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            5769 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            5770 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            5771 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            5772 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            5773 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            5774 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            5775 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            5776 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            5777 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            5778 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            5779 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            5780 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            5781 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            5782 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            5783 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            5784 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            5785 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            5786 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            5787 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            5788 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            5789 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            5790 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            5791 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            5792 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            5793 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            5794 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            5795 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            5796 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            5797 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            5798 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            5799 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            5800 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            5801 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            5802 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            5803 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            5804 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            5805 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            5806 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            5807 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            5808 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            5809 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            5810 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            5811 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            5812 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            5813 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            5814 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            5815 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            5816 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            5817 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            5818 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            5819 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            5820 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            5821 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            5822 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            5823 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            5824 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            5825 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            5826 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
