using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothQuartzStairsBlock(Identifier Identifier, Direction Facing, SmoothQuartzStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 773;
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
    public Identifier? Item => "minecraft:smooth_quartz_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.smooth_quartz_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14657,
                            false => 14658,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14659,
                            false => 14660,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14661,
                            false => 14662,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14663,
                            false => 14664,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14665,
                            false => 14666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14667,
                            false => 14668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14669,
                            false => 14670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14671,
                            false => 14672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14673,
                            false => 14674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14675,
                            false => 14676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14677,
                            false => 14678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14679,
                            false => 14680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14681,
                            false => 14682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14683,
                            false => 14684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14685,
                            false => 14686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14687,
                            false => 14688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14689,
                            false => 14690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14691,
                            false => 14692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14693,
                            false => 14694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14695,
                            false => 14696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14697,
                            false => 14698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14699,
                            false => 14700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14701,
                            false => 14702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14703,
                            false => 14704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14705,
                            false => 14706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14707,
                            false => 14708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14709,
                            false => 14710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14711,
                            false => 14712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14713,
                            false => 14714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14715,
                            false => 14716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14717,
                            false => 14718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14719,
                            false => 14720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14721,
                            false => 14722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14723,
                            false => 14724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14725,
                            false => 14726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14727,
                            false => 14728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14729,
                            false => 14730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14731,
                            false => 14732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14733,
                            false => 14734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14735,
                            false => 14736,
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
            14657 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14658 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14659 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14660 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14661 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14662 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14663 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14664 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14665 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14666 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14667 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14668 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14669 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14670 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14671 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14672 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14673 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14674 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14675 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14676 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14677 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14678 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14679 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14680 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14681 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14682 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14683 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14684 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14685 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14686 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14687 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14688 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14689 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14690 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14691 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14692 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14693 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14694 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14695 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14696 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14697 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14698 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14699 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14700 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14701 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14702 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14703 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14704 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14705 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14706 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14707 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14708 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14709 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14710 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14711 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14712 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14713 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14714 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14715 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14716 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14717 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14718 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14719 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14720 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14721 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14722 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14723 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14724 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14725 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14726 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14727 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14728 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14729 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14730 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14731 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14732 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14733 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14734 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14735 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14736 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
