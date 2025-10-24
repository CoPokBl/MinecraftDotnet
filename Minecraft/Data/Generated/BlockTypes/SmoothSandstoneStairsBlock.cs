using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 802;
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
    public Identifier? Item => "minecraft:smooth_sandstone_stairs";
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
    public string TranslationKey => "block.minecraft.smooth_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15654,
                            false => 15655,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15656,
                            false => 15657,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15658,
                            false => 15659,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15660,
                            false => 15661,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15662,
                            false => 15663,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15664,
                            false => 15665,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15666,
                            false => 15667,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15668,
                            false => 15669,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15670,
                            false => 15671,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15672,
                            false => 15673,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15674,
                            false => 15675,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15676,
                            false => 15677,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15678,
                            false => 15679,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15680,
                            false => 15681,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15682,
                            false => 15683,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15684,
                            false => 15685,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15686,
                            false => 15687,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15688,
                            false => 15689,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15690,
                            false => 15691,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15692,
                            false => 15693,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15694,
                            false => 15695,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15696,
                            false => 15697,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15698,
                            false => 15699,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15700,
                            false => 15701,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15702,
                            false => 15703,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15704,
                            false => 15705,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15706,
                            false => 15707,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15708,
                            false => 15709,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15710,
                            false => 15711,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15712,
                            false => 15713,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15714,
                            false => 15715,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15716,
                            false => 15717,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15718,
                            false => 15719,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15720,
                            false => 15721,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15722,
                            false => 15723,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15724,
                            false => 15725,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15726,
                            false => 15727,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15728,
                            false => 15729,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15730,
                            false => 15731,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15732,
                            false => 15733,
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
            15654 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15655 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15656 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15657 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15658 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15659 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15660 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15661 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15662 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15663 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15664 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15665 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15666 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15667 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15668 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15669 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15670 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15671 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15672 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15673 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15674 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15675 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15676 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15677 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15678 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15679 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15680 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15681 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15682 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15683 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15684 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15685 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15686 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15687 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15688 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15689 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15690 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15691 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15692 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15693 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15694 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15695 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15696 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15697 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15698 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15699 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15700 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15701 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15702 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15703 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15704 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15705 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15706 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15707 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15708 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15709 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15710 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15711 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15712 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15713 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15714 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15715 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15716 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15717 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15718 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15719 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15720 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15721 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15722 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15723 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15724 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15725 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15726 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15727 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15728 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15729 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15730 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15731 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15732 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15733 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
