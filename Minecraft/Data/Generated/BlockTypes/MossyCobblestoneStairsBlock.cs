using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyCobblestoneStairsBlock(Identifier Identifier, Direction Facing, MossyCobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:mossy_cobblestone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.mossy_cobblestone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15616,
                            false => 15617,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15618,
                            false => 15619,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15620,
                            false => 15621,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15622,
                            false => 15623,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15624,
                            false => 15625,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15626,
                            false => 15627,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15628,
                            false => 15629,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15630,
                            false => 15631,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15632,
                            false => 15633,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15634,
                            false => 15635,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15636,
                            false => 15637,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15638,
                            false => 15639,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15640,
                            false => 15641,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15642,
                            false => 15643,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15644,
                            false => 15645,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15646,
                            false => 15647,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15648,
                            false => 15649,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15650,
                            false => 15651,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15652,
                            false => 15653,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15654,
                            false => 15655,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15656,
                            false => 15657,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15658,
                            false => 15659,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15660,
                            false => 15661,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15662,
                            false => 15663,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15664,
                            false => 15665,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15666,
                            false => 15667,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15668,
                            false => 15669,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15670,
                            false => 15671,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15672,
                            false => 15673,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15674,
                            false => 15675,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15676,
                            false => 15677,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15678,
                            false => 15679,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15680,
                            false => 15681,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15682,
                            false => 15683,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15684,
                            false => 15685,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15686,
                            false => 15687,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15688,
                            false => 15689,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15690,
                            false => 15691,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15692,
                            false => 15693,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15694,
                            false => 15695,
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
            15616 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15617 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15618 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15619 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15620 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15621 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15622 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15623 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15624 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15625 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15626 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15627 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15628 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15629 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15630 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15631 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15632 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15633 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15634 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15635 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15636 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15637 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15638 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15639 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15640 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15641 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15642 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15643 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15644 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15645 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15646 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15647 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15648 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15649 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15650 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15651 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15652 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15653 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15654 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15655 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15656 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15657 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15658 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15659 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15660 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15661 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15662 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15663 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15664 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15665 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15666 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15667 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15668 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15669 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15670 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15671 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15672 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15673 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15674 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15675 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15676 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15677 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15678 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15679 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15680 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15681 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15682 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15683 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15684 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15685 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15686 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15687 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15688 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15689 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15690 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15691 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15692 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15693 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15694 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15695 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
