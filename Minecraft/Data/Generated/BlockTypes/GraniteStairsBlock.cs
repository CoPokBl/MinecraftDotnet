using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GraniteStairsBlock(Identifier Identifier, Direction Facing, GraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14705,
                            false => 14706,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14707,
                            false => 14708,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14709,
                            false => 14710,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14711,
                            false => 14712,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14713,
                            false => 14714,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14715,
                            false => 14716,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14717,
                            false => 14718,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14719,
                            false => 14720,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14721,
                            false => 14722,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14723,
                            false => 14724,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14725,
                            false => 14726,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14727,
                            false => 14728,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14729,
                            false => 14730,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14731,
                            false => 14732,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14733,
                            false => 14734,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14735,
                            false => 14736,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14737,
                            false => 14738,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14739,
                            false => 14740,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14741,
                            false => 14742,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14743,
                            false => 14744,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14745,
                            false => 14746,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14747,
                            false => 14748,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14749,
                            false => 14750,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14751,
                            false => 14752,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14753,
                            false => 14754,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14755,
                            false => 14756,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14757,
                            false => 14758,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14759,
                            false => 14760,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14761,
                            false => 14762,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14763,
                            false => 14764,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14765,
                            false => 14766,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14767,
                            false => 14768,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14769,
                            false => 14770,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14771,
                            false => 14772,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14773,
                            false => 14774,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14775,
                            false => 14776,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14777,
                            false => 14778,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14779,
                            false => 14780,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14781,
                            false => 14782,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14783,
                            false => 14784,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            14705 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14706 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14707 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14708 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14709 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14710 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14711 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14712 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14713 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14714 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14715 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14716 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14717 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14718 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14719 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14720 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14721 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14722 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14723 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14724 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14725 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14726 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14727 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14728 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14729 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14730 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14731 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14732 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14733 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14734 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14735 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14736 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14737 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14738 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14739 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14740 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14741 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14742 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14743 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14744 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14745 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14746 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14747 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14748 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14749 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14750 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14751 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14752 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14753 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14754 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14755 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14756 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14757 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14758 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14759 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14760 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14761 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14762 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14763 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14764 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14765 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14766 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14767 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14768 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14769 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14770 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14771 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14772 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14773 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14774 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14775 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14776 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14777 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14778 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14779 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14780 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14781 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14782 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14783 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14784 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
