using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickStairsBlock(Identifier Identifier, Direction Facing, ResinBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 376;
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
    public string SoundType => "resin_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:resin_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 37;
    public string TranslationKey => "block.minecraft.resin_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8722,
                            false => 8723,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8724,
                            false => 8725,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8726,
                            false => 8727,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8728,
                            false => 8729,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8730,
                            false => 8731,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8732,
                            false => 8733,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8734,
                            false => 8735,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8736,
                            false => 8737,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8738,
                            false => 8739,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8740,
                            false => 8741,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8742,
                            false => 8743,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8744,
                            false => 8745,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8746,
                            false => 8747,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8748,
                            false => 8749,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8750,
                            false => 8751,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8752,
                            false => 8753,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8754,
                            false => 8755,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8756,
                            false => 8757,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8758,
                            false => 8759,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8760,
                            false => 8761,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8762,
                            false => 8763,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8764,
                            false => 8765,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8766,
                            false => 8767,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8768,
                            false => 8769,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8770,
                            false => 8771,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8772,
                            false => 8773,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8774,
                            false => 8775,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8776,
                            false => 8777,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8778,
                            false => 8779,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8780,
                            false => 8781,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8782,
                            false => 8783,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8784,
                            false => 8785,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8786,
                            false => 8787,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8788,
                            false => 8789,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8790,
                            false => 8791,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8792,
                            false => 8793,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8794,
                            false => 8795,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8796,
                            false => 8797,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8798,
                            false => 8799,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8800,
                            false => 8801,
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
            8722 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8723 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8724 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8725 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8726 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8727 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8728 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8729 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8730 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8731 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8732 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8733 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8734 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8735 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8736 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8737 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8738 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8739 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8740 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8741 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8742 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8743 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8744 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8745 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8746 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8747 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8748 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8749 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8750 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8751 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8752 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8753 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8754 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8755 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8756 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8757 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8758 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8759 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8760 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8761 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8762 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8763 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8764 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8765 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8766 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8767 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8768 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8769 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8770 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8771 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8772 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8773 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8774 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8775 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8776 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8777 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8778 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8779 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8780 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8781 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8782 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8783 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8784 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8785 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8786 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8787 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8788 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8789 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8790 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8791 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8792 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8793 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8794 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8795 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8796 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8797 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8798 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8799 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8800 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8801 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
