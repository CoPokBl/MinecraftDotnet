using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrickStairsBlock(Identifier Identifier, Direction Facing, BrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8678,
                            false => 8679,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8680,
                            false => 8681,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8682,
                            false => 8683,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8684,
                            false => 8685,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8686,
                            false => 8687,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8688,
                            false => 8689,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8690,
                            false => 8691,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8692,
                            false => 8693,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8694,
                            false => 8695,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8696,
                            false => 8697,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8698,
                            false => 8699,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8700,
                            false => 8701,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8702,
                            false => 8703,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8704,
                            false => 8705,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8706,
                            false => 8707,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8708,
                            false => 8709,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8710,
                            false => 8711,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8712,
                            false => 8713,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8714,
                            false => 8715,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8716,
                            false => 8717,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8718,
                            false => 8719,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8720,
                            false => 8721,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8722,
                            false => 8723,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8724,
                            false => 8725,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8726,
                            false => 8727,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8728,
                            false => 8729,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8730,
                            false => 8731,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8732,
                            false => 8733,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8734,
                            false => 8735,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8736,
                            false => 8737,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8738,
                            false => 8739,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8740,
                            false => 8741,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8742,
                            false => 8743,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8744,
                            false => 8745,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8746,
                            false => 8747,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8748,
                            false => 8749,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8750,
                            false => 8751,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8752,
                            false => 8753,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8754,
                            false => 8755,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8756,
                            false => 8757,
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
            8678 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8679 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8680 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8681 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8682 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8683 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8684 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8685 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8686 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8687 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8688 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8689 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8690 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8691 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8692 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8693 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8694 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8695 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8696 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8697 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8698 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8699 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8700 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8701 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8702 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8703 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8704 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8705 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8706 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8707 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8708 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8709 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8710 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8711 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8712 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8713 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8714 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8715 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8716 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8717 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8718 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8719 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8720 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8721 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8722 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8723 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8724 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8725 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8726 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8727 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8728 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8729 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8730 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8731 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8732 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8733 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8734 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8735 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8736 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8737 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8738 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8739 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8740 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8741 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8742 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8743 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8744 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8745 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8746 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8747 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8748 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8749 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8750 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8751 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8752 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8753 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8754 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8755 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8756 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8757 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
