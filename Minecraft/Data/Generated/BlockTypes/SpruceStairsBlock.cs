using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceStairsBlock(Identifier Identifier, Direction Facing, SpruceStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:spruce_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9728,
                            false => 9729,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9730,
                            false => 9731,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9732,
                            false => 9733,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9734,
                            false => 9735,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9736,
                            false => 9737,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9738,
                            false => 9739,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9740,
                            false => 9741,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9742,
                            false => 9743,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9744,
                            false => 9745,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9746,
                            false => 9747,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9748,
                            false => 9749,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9750,
                            false => 9751,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9752,
                            false => 9753,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9754,
                            false => 9755,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9756,
                            false => 9757,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9758,
                            false => 9759,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9760,
                            false => 9761,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9762,
                            false => 9763,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9764,
                            false => 9765,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9766,
                            false => 9767,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9768,
                            false => 9769,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9770,
                            false => 9771,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9772,
                            false => 9773,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9774,
                            false => 9775,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9776,
                            false => 9777,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9778,
                            false => 9779,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9780,
                            false => 9781,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9782,
                            false => 9783,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9784,
                            false => 9785,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9786,
                            false => 9787,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9788,
                            false => 9789,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9790,
                            false => 9791,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9792,
                            false => 9793,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9794,
                            false => 9795,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9796,
                            false => 9797,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9798,
                            false => 9799,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9800,
                            false => 9801,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9802,
                            false => 9803,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9804,
                            false => 9805,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9806,
                            false => 9807,
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
            9728 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9729 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9730 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9731 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9732 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9733 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9734 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9735 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9736 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9737 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9738 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9739 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9740 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9741 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9742 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9743 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9744 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9745 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9746 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9747 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9748 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9749 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9750 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9751 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9752 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9753 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9754 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9755 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9756 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9757 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9758 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9759 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9760 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9761 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9762 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9763 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9764 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9765 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9766 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9767 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9768 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9769 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9770 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9771 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9772 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9773 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9774 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9775 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9776 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9777 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9778 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9779 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9780 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9781 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9782 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9783 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9784 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9785 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9786 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9787 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9788 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9789 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9790 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9791 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9792 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9793 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9794 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9795 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9796 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9797 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9798 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9799 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9800 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9801 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9802 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9803 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9804 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9805 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9806 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9807 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
