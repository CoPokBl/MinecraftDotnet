using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpurStairsBlock(Identifier Identifier, Direction Facing, PurpurStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:purpur_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 16;
    public string TranslationKey => "block.minecraft.purpur_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14716,
                            false => 14717,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14718,
                            false => 14719,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14720,
                            false => 14721,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14722,
                            false => 14723,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14724,
                            false => 14725,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14726,
                            false => 14727,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14728,
                            false => 14729,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14730,
                            false => 14731,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14732,
                            false => 14733,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14734,
                            false => 14735,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14736,
                            false => 14737,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14738,
                            false => 14739,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14740,
                            false => 14741,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14742,
                            false => 14743,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14744,
                            false => 14745,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14746,
                            false => 14747,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14748,
                            false => 14749,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14750,
                            false => 14751,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14752,
                            false => 14753,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14754,
                            false => 14755,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14756,
                            false => 14757,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14758,
                            false => 14759,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14760,
                            false => 14761,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14762,
                            false => 14763,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14764,
                            false => 14765,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14766,
                            false => 14767,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14768,
                            false => 14769,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14770,
                            false => 14771,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14772,
                            false => 14773,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14774,
                            false => 14775,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14776,
                            false => 14777,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14778,
                            false => 14779,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14780,
                            false => 14781,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14782,
                            false => 14783,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14784,
                            false => 14785,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14786,
                            false => 14787,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14788,
                            false => 14789,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14790,
                            false => 14791,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14792,
                            false => 14793,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14794,
                            false => 14795,
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
            14716 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14717 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14718 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14719 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14720 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14721 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14722 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14723 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14724 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14725 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14726 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14727 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14728 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14729 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14730 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14731 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14732 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14733 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14734 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14735 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14736 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14737 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14738 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14739 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14740 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14741 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14742 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14743 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14744 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14745 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14746 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14747 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14748 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14749 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14750 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14751 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14752 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14753 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14754 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14755 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14756 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14757 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14758 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14759 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14760 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14761 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14762 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14763 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14764 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14765 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14766 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14767 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14768 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14769 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14770 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14771 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14772 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14773 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14774 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14775 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14776 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14777 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14778 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14779 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14780 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14781 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14782 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14783 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14784 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14785 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14786 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14787 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14788 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14789 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14790 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14791 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14792 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14793 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14794 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14795 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
