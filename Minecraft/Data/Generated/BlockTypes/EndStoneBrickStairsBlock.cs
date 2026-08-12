using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndStoneBrickStairsBlock(Identifier Identifier, Direction Facing, EndStoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3;
    public double ExplosionResistance => 9;
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
    public Identifier? Item => "minecraft:end_stone_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.end_stone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15696,
                            false => 15697,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15698,
                            false => 15699,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15700,
                            false => 15701,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15702,
                            false => 15703,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15704,
                            false => 15705,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15706,
                            false => 15707,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15708,
                            false => 15709,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15710,
                            false => 15711,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15712,
                            false => 15713,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15714,
                            false => 15715,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15716,
                            false => 15717,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15718,
                            false => 15719,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15720,
                            false => 15721,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15722,
                            false => 15723,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15724,
                            false => 15725,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15726,
                            false => 15727,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15728,
                            false => 15729,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15730,
                            false => 15731,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15732,
                            false => 15733,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15734,
                            false => 15735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15736,
                            false => 15737,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15738,
                            false => 15739,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15740,
                            false => 15741,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15742,
                            false => 15743,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15744,
                            false => 15745,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15746,
                            false => 15747,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15748,
                            false => 15749,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15750,
                            false => 15751,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15752,
                            false => 15753,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15754,
                            false => 15755,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15756,
                            false => 15757,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15758,
                            false => 15759,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15760,
                            false => 15761,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15762,
                            false => 15763,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15764,
                            false => 15765,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15766,
                            false => 15767,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15768,
                            false => 15769,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15770,
                            false => 15771,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15772,
                            false => 15773,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15774,
                            false => 15775,
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
            15696 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15697 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15698 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15699 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15700 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15701 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15702 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15703 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15704 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15705 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15706 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15707 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15708 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15709 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15710 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15711 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15712 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15713 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15714 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15715 => new EndStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15716 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15717 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15718 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15719 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15720 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15721 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15722 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15723 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15724 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15725 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15726 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15727 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15728 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15729 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15730 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15731 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15732 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15733 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15734 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15735 => new EndStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15736 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15737 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15738 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15739 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15740 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15741 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15742 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15743 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15744 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15745 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15746 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15747 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15748 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15749 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15750 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15751 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15752 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15753 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15754 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15755 => new EndStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15756 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15757 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15758 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15759 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15760 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15761 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15762 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15763 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15764 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15765 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15766 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15767 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15768 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15769 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15770 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15771 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15772 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15773 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15774 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15775 => new EndStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
