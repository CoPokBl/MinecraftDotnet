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
                            true => 14625,
                            false => 14626,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14627,
                            false => 14628,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14629,
                            false => 14630,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14631,
                            false => 14632,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14633,
                            false => 14634,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14635,
                            false => 14636,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14637,
                            false => 14638,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14639,
                            false => 14640,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14641,
                            false => 14642,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14643,
                            false => 14644,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14645,
                            false => 14646,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14647,
                            false => 14648,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14649,
                            false => 14650,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14651,
                            false => 14652,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14653,
                            false => 14654,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14655,
                            false => 14656,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14657,
                            false => 14658,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14659,
                            false => 14660,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14661,
                            false => 14662,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14663,
                            false => 14664,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14665,
                            false => 14666,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14667,
                            false => 14668,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14669,
                            false => 14670,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14671,
                            false => 14672,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14673,
                            false => 14674,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14675,
                            false => 14676,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14677,
                            false => 14678,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14679,
                            false => 14680,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14681,
                            false => 14682,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14683,
                            false => 14684,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14685,
                            false => 14686,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14687,
                            false => 14688,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14689,
                            false => 14690,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14691,
                            false => 14692,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14693,
                            false => 14694,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14695,
                            false => 14696,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14697,
                            false => 14698,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14699,
                            false => 14700,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14701,
                            false => 14702,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14703,
                            false => 14704,
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
            14625 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14626 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14627 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14628 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14629 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14630 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14631 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14632 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14633 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14634 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14635 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14636 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14637 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14638 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14639 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14640 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14641 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14642 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14643 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14644 => new SmoothQuartzStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14645 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14646 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14647 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14648 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14649 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14650 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14651 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14652 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14653 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14654 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14655 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14656 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14657 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14658 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14659 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14660 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14661 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14662 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14663 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14664 => new SmoothQuartzStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14665 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14666 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14667 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14668 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14669 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14670 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14671 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14672 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14673 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14674 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14675 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14676 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14677 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14678 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14679 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14680 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14681 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14682 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14683 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14684 => new SmoothQuartzStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14685 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14686 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14687 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14688 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14689 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14690 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14691 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14692 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14693 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14694 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14695 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14696 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14697 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14698 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14699 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14700 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14701 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14702 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14703 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14704 => new SmoothQuartzStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
}
