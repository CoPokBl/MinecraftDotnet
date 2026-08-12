using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SulfurStairsBlock(Identifier Identifier, Direction Facing, SulfurStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "sulfur";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sulfur_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.sulfur_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24699,
                            false => 24700,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24701,
                            false => 24702,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24703,
                            false => 24704,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24705,
                            false => 24706,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24707,
                            false => 24708,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24709,
                            false => 24710,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24711,
                            false => 24712,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24713,
                            false => 24714,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24715,
                            false => 24716,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24717,
                            false => 24718,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24719,
                            false => 24720,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24721,
                            false => 24722,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24723,
                            false => 24724,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24725,
                            false => 24726,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24727,
                            false => 24728,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24729,
                            false => 24730,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24731,
                            false => 24732,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24733,
                            false => 24734,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24735,
                            false => 24736,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24737,
                            false => 24738,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24739,
                            false => 24740,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24741,
                            false => 24742,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24743,
                            false => 24744,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24745,
                            false => 24746,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24747,
                            false => 24748,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24749,
                            false => 24750,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24751,
                            false => 24752,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24753,
                            false => 24754,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24755,
                            false => 24756,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24757,
                            false => 24758,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24759,
                            false => 24760,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24761,
                            false => 24762,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24763,
                            false => 24764,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24765,
                            false => 24766,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24767,
                            false => 24768,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24769,
                            false => 24770,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24771,
                            false => 24772,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24773,
                            false => 24774,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24775,
                            false => 24776,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24777,
                            false => 24778,
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
            24699 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24700 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24701 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24702 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24703 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24704 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24705 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24706 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24707 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24708 => new SulfurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24709 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24710 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24711 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24712 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24713 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24714 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24715 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24716 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24717 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24718 => new SulfurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24719 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24720 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24721 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24722 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24723 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24724 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24725 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24726 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24727 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24728 => new SulfurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24729 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24730 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24731 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24732 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24733 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24734 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24735 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24736 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24737 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24738 => new SulfurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24739 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24740 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24741 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24742 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24743 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24744 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24745 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24746 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24747 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24748 => new SulfurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24749 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24750 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24751 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24752 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24753 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24754 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24755 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24756 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24757 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24758 => new SulfurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24759 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24760 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24761 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24762 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24763 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24764 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24765 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24766 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24767 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24768 => new SulfurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24769 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24770 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24771 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24772 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24773 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24774 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24775 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24776 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24777 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24778 => new SulfurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
