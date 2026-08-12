using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneBrickStairsBlock(Identifier Identifier, Direction Facing, StoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:stone_brick_stairs";
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
    public string TranslationKey => "block.minecraft.stone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8758,
                            false => 8759,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8760,
                            false => 8761,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8762,
                            false => 8763,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8764,
                            false => 8765,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8766,
                            false => 8767,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8768,
                            false => 8769,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8770,
                            false => 8771,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8772,
                            false => 8773,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8774,
                            false => 8775,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8776,
                            false => 8777,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8778,
                            false => 8779,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8780,
                            false => 8781,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8782,
                            false => 8783,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8784,
                            false => 8785,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8786,
                            false => 8787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8788,
                            false => 8789,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8790,
                            false => 8791,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8792,
                            false => 8793,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8794,
                            false => 8795,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8796,
                            false => 8797,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8798,
                            false => 8799,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8800,
                            false => 8801,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8802,
                            false => 8803,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8804,
                            false => 8805,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8806,
                            false => 8807,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8808,
                            false => 8809,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8810,
                            false => 8811,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8812,
                            false => 8813,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8814,
                            false => 8815,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8816,
                            false => 8817,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8818,
                            false => 8819,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8820,
                            false => 8821,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8822,
                            false => 8823,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8824,
                            false => 8825,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8826,
                            false => 8827,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8828,
                            false => 8829,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8830,
                            false => 8831,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8832,
                            false => 8833,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8834,
                            false => 8835,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8836,
                            false => 8837,
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
            8758 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8759 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8760 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8761 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8762 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8763 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8764 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8765 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8766 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8767 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8768 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8769 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8770 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8771 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8772 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8773 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8774 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8775 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8776 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8777 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8778 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8779 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8780 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8781 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8782 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8783 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8784 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8785 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8786 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8787 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8788 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8789 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8790 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8791 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8792 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8793 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8794 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8795 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8796 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8797 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8798 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8799 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8800 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8801 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8802 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8803 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8804 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8805 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8806 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8807 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8808 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8809 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8810 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8811 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8812 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8813 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8814 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8815 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8816 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8817 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8818 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8819 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8820 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8821 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8822 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8823 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8824 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8825 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8826 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8827 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8828 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8829 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8830 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8831 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8832 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8833 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8834 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8835 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8836 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8837 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
