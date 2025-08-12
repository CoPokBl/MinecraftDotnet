using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaStairsBlock(Identifier Identifier, Direction Facing, AcaciaStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 484;
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
    public Identifier? Item => "minecraft:acacia_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10693,
                            false => 10694,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10695,
                            false => 10696,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10697,
                            false => 10698,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10699,
                            false => 10700,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10701,
                            false => 10702,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10703,
                            false => 10704,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10705,
                            false => 10706,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10707,
                            false => 10708,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10709,
                            false => 10710,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10711,
                            false => 10712,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10713,
                            false => 10714,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10715,
                            false => 10716,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10717,
                            false => 10718,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10719,
                            false => 10720,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10721,
                            false => 10722,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10723,
                            false => 10724,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10725,
                            false => 10726,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10727,
                            false => 10728,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10729,
                            false => 10730,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10731,
                            false => 10732,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10733,
                            false => 10734,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10735,
                            false => 10736,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10737,
                            false => 10738,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10739,
                            false => 10740,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10741,
                            false => 10742,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10743,
                            false => 10744,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10745,
                            false => 10746,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10747,
                            false => 10748,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10749,
                            false => 10750,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10751,
                            false => 10752,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10753,
                            false => 10754,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10755,
                            false => 10756,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10757,
                            false => 10758,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10759,
                            false => 10760,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10761,
                            false => 10762,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10763,
                            false => 10764,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10765,
                            false => 10766,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10767,
                            false => 10768,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10769,
                            false => 10770,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10771,
                            false => 10772,
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
            10693 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            10694 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            10695 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            10696 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            10697 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            10698 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            10699 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            10700 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            10701 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            10702 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            10703 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            10704 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            10705 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            10706 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            10707 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            10708 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            10709 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            10710 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            10711 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            10712 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            10713 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            10714 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            10715 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            10716 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            10717 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            10718 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            10719 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            10720 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            10721 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            10722 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            10723 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            10724 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            10725 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            10726 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            10727 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            10728 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            10729 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            10730 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            10731 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            10732 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            10733 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            10734 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            10735 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            10736 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            10737 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            10738 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            10739 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            10740 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            10741 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            10742 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            10743 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            10744 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            10745 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            10746 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            10747 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            10748 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            10749 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            10750 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            10751 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            10752 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            10753 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            10754 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            10755 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            10756 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            10757 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            10758 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            10759 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            10760 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            10761 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            10762 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            10763 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            10764 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            10765 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            10766 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            10767 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            10768 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            10769 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            10770 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            10771 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            10772 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
