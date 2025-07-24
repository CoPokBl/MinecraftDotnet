using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GraniteStairsBlock(Identifier Identifier, Direction Facing, GraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 774;
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
    public Identifier? Item => "minecraft:granite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14737,
                            false => 14738,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14739,
                            false => 14740,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14741,
                            false => 14742,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14743,
                            false => 14744,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14745,
                            false => 14746,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14747,
                            false => 14748,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14749,
                            false => 14750,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14751,
                            false => 14752,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14753,
                            false => 14754,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14755,
                            false => 14756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14757,
                            false => 14758,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14759,
                            false => 14760,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14761,
                            false => 14762,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14763,
                            false => 14764,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14765,
                            false => 14766,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14767,
                            false => 14768,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14769,
                            false => 14770,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14771,
                            false => 14772,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14773,
                            false => 14774,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14775,
                            false => 14776,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14777,
                            false => 14778,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14779,
                            false => 14780,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14781,
                            false => 14782,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14783,
                            false => 14784,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14785,
                            false => 14786,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14787,
                            false => 14788,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14789,
                            false => 14790,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14791,
                            false => 14792,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14793,
                            false => 14794,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14795,
                            false => 14796,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14797,
                            false => 14798,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14799,
                            false => 14800,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14801,
                            false => 14802,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14803,
                            false => 14804,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14805,
                            false => 14806,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14807,
                            false => 14808,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14809,
                            false => 14810,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14811,
                            false => 14812,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14813,
                            false => 14814,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14815,
                            false => 14816,
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
            14737 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14738 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14739 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14740 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14741 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14742 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14743 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14744 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14745 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14746 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14747 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14748 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14749 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14750 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14751 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14752 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14753 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14754 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14755 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14756 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14757 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14758 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14759 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14760 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14761 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14762 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14763 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14764 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14765 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14766 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14767 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14768 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14769 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14770 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14771 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14772 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14773 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14774 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14775 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14776 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14777 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14778 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14779 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14780 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14781 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14782 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14783 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14784 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14785 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14786 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14787 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14788 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14789 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14790 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14791 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14792 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14793 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14794 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14795 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14796 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14797 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14798 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14799 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14800 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14801 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14802 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14803 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14804 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14805 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14806 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14807 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14808 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14809 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14810 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14811 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14812 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14813 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14814 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14815 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14816 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
