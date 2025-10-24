using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakStairsBlock(Identifier Identifier, Direction Facing, OakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 199;
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
    public Identifier? Item => "minecraft:oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3706,
                            false => 3707,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3708,
                            false => 3709,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3710,
                            false => 3711,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3712,
                            false => 3713,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3714,
                            false => 3715,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3716,
                            false => 3717,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3718,
                            false => 3719,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3720,
                            false => 3721,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3722,
                            false => 3723,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3724,
                            false => 3725,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3726,
                            false => 3727,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3728,
                            false => 3729,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3730,
                            false => 3731,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3732,
                            false => 3733,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3734,
                            false => 3735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3736,
                            false => 3737,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3738,
                            false => 3739,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3740,
                            false => 3741,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3742,
                            false => 3743,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3744,
                            false => 3745,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3746,
                            false => 3747,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3748,
                            false => 3749,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3750,
                            false => 3751,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3752,
                            false => 3753,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3754,
                            false => 3755,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3756,
                            false => 3757,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3758,
                            false => 3759,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3760,
                            false => 3761,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3762,
                            false => 3763,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3764,
                            false => 3765,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3766,
                            false => 3767,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3768,
                            false => 3769,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3770,
                            false => 3771,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3772,
                            false => 3773,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3774,
                            false => 3775,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 3776,
                            false => 3777,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 3778,
                            false => 3779,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 3780,
                            false => 3781,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 3782,
                            false => 3783,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 3784,
                            false => 3785,
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
            3706 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            3707 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            3708 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            3709 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            3710 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            3711 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            3712 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            3713 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            3714 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            3715 => new OakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            3716 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            3717 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            3718 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            3719 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            3720 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            3721 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            3722 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            3723 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            3724 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            3725 => new OakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            3726 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            3727 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            3728 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            3729 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            3730 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            3731 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            3732 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            3733 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            3734 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            3735 => new OakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            3736 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            3737 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            3738 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            3739 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            3740 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            3741 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            3742 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            3743 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            3744 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            3745 => new OakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            3746 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            3747 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            3748 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            3749 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            3750 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            3751 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            3752 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            3753 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            3754 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            3755 => new OakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            3756 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            3757 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            3758 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            3759 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            3760 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            3761 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            3762 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            3763 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            3764 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            3765 => new OakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            3766 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            3767 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            3768 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            3769 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            3770 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            3771 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            3772 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            3773 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            3774 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            3775 => new OakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            3776 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            3777 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            3778 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            3779 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            3780 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            3781 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            3782 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            3783 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            3784 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            3785 => new OakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
