using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineBrickStairsBlock(Identifier Identifier, Direction Facing, PrismarineBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:prismarine_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 31;
    public string TranslationKey => "block.minecraft.prismarine_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12714,
                            false => 12715,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12716,
                            false => 12717,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12718,
                            false => 12719,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12720,
                            false => 12721,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12722,
                            false => 12723,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12724,
                            false => 12725,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12726,
                            false => 12727,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12728,
                            false => 12729,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12730,
                            false => 12731,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12732,
                            false => 12733,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12734,
                            false => 12735,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12736,
                            false => 12737,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12738,
                            false => 12739,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12740,
                            false => 12741,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12742,
                            false => 12743,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12744,
                            false => 12745,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12746,
                            false => 12747,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12748,
                            false => 12749,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12750,
                            false => 12751,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12752,
                            false => 12753,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12754,
                            false => 12755,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12756,
                            false => 12757,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12758,
                            false => 12759,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12760,
                            false => 12761,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12762,
                            false => 12763,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12764,
                            false => 12765,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12766,
                            false => 12767,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12768,
                            false => 12769,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12770,
                            false => 12771,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12772,
                            false => 12773,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12774,
                            false => 12775,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12776,
                            false => 12777,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12778,
                            false => 12779,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12780,
                            false => 12781,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12782,
                            false => 12783,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12784,
                            false => 12785,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12786,
                            false => 12787,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12788,
                            false => 12789,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12790,
                            false => 12791,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12792,
                            false => 12793,
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
            12714 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12715 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12716 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12717 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12718 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12719 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12720 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12721 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12722 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12723 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12724 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12725 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12726 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12727 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12728 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12729 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12730 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12731 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12732 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12733 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12734 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12735 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12736 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12737 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12738 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12739 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12740 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12741 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12742 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12743 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12744 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12745 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12746 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12747 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12748 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12749 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12750 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12751 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12752 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12753 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12754 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12755 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12756 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12757 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12758 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12759 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12760 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12761 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12762 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12763 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12764 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12765 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12766 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12767 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12768 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12769 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12770 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12771 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12772 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12773 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12774 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12775 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12776 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12777 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12778 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12779 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12780 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12781 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12782 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12783 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12784 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12785 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12786 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12787 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12788 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12789 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12790 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12791 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12792 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12793 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
