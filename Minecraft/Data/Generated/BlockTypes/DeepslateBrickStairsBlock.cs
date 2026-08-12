using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateBrickStairsBlock(Identifier Identifier, Direction Facing, DeepslateBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3.5;
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
    public string SoundType => "deepslate_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:deepslate_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.deepslate_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31653,
                            false => 31654,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31655,
                            false => 31656,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31657,
                            false => 31658,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31659,
                            false => 31660,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31661,
                            false => 31662,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31663,
                            false => 31664,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31665,
                            false => 31666,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31667,
                            false => 31668,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31669,
                            false => 31670,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31671,
                            false => 31672,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31673,
                            false => 31674,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31675,
                            false => 31676,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31677,
                            false => 31678,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31679,
                            false => 31680,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31681,
                            false => 31682,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31683,
                            false => 31684,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31685,
                            false => 31686,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31687,
                            false => 31688,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31689,
                            false => 31690,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31691,
                            false => 31692,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31693,
                            false => 31694,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31695,
                            false => 31696,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31697,
                            false => 31698,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31699,
                            false => 31700,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31701,
                            false => 31702,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31703,
                            false => 31704,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31705,
                            false => 31706,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31707,
                            false => 31708,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31709,
                            false => 31710,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31711,
                            false => 31712,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31713,
                            false => 31714,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31715,
                            false => 31716,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31717,
                            false => 31718,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31719,
                            false => 31720,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31721,
                            false => 31722,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31723,
                            false => 31724,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31725,
                            false => 31726,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31727,
                            false => 31728,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31729,
                            false => 31730,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31731,
                            false => 31732,
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
            31653 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            31654 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            31655 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            31656 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            31657 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            31658 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            31659 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            31660 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            31661 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            31662 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            31663 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            31664 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            31665 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            31666 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            31667 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            31668 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            31669 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            31670 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            31671 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            31672 => new DeepslateBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            31673 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            31674 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            31675 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            31676 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            31677 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            31678 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            31679 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            31680 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            31681 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            31682 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            31683 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            31684 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            31685 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            31686 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            31687 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            31688 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            31689 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            31690 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            31691 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            31692 => new DeepslateBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            31693 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            31694 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            31695 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            31696 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            31697 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            31698 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            31699 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            31700 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            31701 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            31702 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            31703 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            31704 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            31705 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            31706 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            31707 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            31708 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            31709 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            31710 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            31711 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            31712 => new DeepslateBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            31713 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            31714 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            31715 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            31716 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            31717 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            31718 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            31719 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            31720 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            31721 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            31722 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            31723 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            31724 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            31725 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            31726 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            31727 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            31728 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            31729 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            31730 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            31731 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            31732 => new DeepslateBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
