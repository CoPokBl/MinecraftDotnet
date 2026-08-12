using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:polished_blackstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22657,
                            false => 22658,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22659,
                            false => 22660,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22661,
                            false => 22662,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22663,
                            false => 22664,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22665,
                            false => 22666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22667,
                            false => 22668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22669,
                            false => 22670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22671,
                            false => 22672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22673,
                            false => 22674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22675,
                            false => 22676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22677,
                            false => 22678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22679,
                            false => 22680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22681,
                            false => 22682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22683,
                            false => 22684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22685,
                            false => 22686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22687,
                            false => 22688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22689,
                            false => 22690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22691,
                            false => 22692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22693,
                            false => 22694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22695,
                            false => 22696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22697,
                            false => 22698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22699,
                            false => 22700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22701,
                            false => 22702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22703,
                            false => 22704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22705,
                            false => 22706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22707,
                            false => 22708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22709,
                            false => 22710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22711,
                            false => 22712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22713,
                            false => 22714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22715,
                            false => 22716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22717,
                            false => 22718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22719,
                            false => 22720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22721,
                            false => 22722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22723,
                            false => 22724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22725,
                            false => 22726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22727,
                            false => 22728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22729,
                            false => 22730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22731,
                            false => 22732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22733,
                            false => 22734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22735,
                            false => 22736,
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
            22657 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22658 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22659 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22660 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22661 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22662 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22663 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22664 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22665 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22666 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22667 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22668 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22669 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22670 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22671 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22672 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22673 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22674 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22675 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22676 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22677 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22678 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22679 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22680 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22681 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22682 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22683 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22684 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22685 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22686 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22687 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22688 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22689 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22690 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22691 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22692 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22693 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22694 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22695 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22696 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22697 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22698 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22699 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22700 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22701 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22702 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22703 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22704 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22705 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22706 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22707 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22708 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22709 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22710 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22711 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22712 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22713 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22714 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22715 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22716 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22717 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22718 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22719 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22720 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22721 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22722 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22723 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22724 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22725 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22726 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22727 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22728 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22729 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22730 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22731 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22732 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22733 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22734 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22735 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22736 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
