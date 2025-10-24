using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobbledDeepslateStairsBlock(Identifier Identifier, Direction Facing, CobbledDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1123;
    public double Hardness => 3.5;
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
    public string SoundType => "deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cobbled_deepslate_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.cobbled_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27725,
                            false => 27726,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27727,
                            false => 27728,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27729,
                            false => 27730,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27731,
                            false => 27732,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27733,
                            false => 27734,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27735,
                            false => 27736,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27737,
                            false => 27738,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27739,
                            false => 27740,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27741,
                            false => 27742,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27743,
                            false => 27744,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27745,
                            false => 27746,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27747,
                            false => 27748,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27749,
                            false => 27750,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27751,
                            false => 27752,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27753,
                            false => 27754,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27755,
                            false => 27756,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27757,
                            false => 27758,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27759,
                            false => 27760,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27761,
                            false => 27762,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27763,
                            false => 27764,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27765,
                            false => 27766,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27767,
                            false => 27768,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27769,
                            false => 27770,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27771,
                            false => 27772,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27773,
                            false => 27774,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27775,
                            false => 27776,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27777,
                            false => 27778,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27779,
                            false => 27780,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27781,
                            false => 27782,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27783,
                            false => 27784,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27785,
                            false => 27786,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27787,
                            false => 27788,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27789,
                            false => 27790,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27791,
                            false => 27792,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27793,
                            false => 27794,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27795,
                            false => 27796,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27797,
                            false => 27798,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27799,
                            false => 27800,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27801,
                            false => 27802,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27803,
                            false => 27804,
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
            27725 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27726 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27727 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27728 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27729 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27730 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27731 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27732 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27733 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27734 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27735 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27736 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27737 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27738 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27739 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27740 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27741 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27742 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27743 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27744 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27745 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27746 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27747 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27748 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27749 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27750 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27751 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27752 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27753 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27754 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27755 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27756 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            27757 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            27758 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            27759 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            27760 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            27761 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            27762 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            27763 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            27764 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            27765 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            27766 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            27767 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            27768 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            27769 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            27770 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            27771 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            27772 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            27773 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            27774 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            27775 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            27776 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            27777 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            27778 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            27779 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            27780 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            27781 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            27782 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            27783 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            27784 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            27785 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            27786 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            27787 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            27788 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            27789 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            27790 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            27791 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            27792 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            27793 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            27794 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            27795 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            27796 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            27797 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            27798 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            27799 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            27800 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            27801 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            27802 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            27803 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            27804 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
