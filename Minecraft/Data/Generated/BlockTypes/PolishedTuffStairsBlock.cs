using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, PolishedTuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 988;
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
    public string SoundType => "polished_tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_tuff_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.polished_tuff_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23668,
                            false => 23669,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23670,
                            false => 23671,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23672,
                            false => 23673,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23674,
                            false => 23675,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23676,
                            false => 23677,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23678,
                            false => 23679,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23680,
                            false => 23681,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23682,
                            false => 23683,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23684,
                            false => 23685,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23686,
                            false => 23687,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23688,
                            false => 23689,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23690,
                            false => 23691,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23692,
                            false => 23693,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23694,
                            false => 23695,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23696,
                            false => 23697,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23698,
                            false => 23699,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23700,
                            false => 23701,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23702,
                            false => 23703,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23704,
                            false => 23705,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23706,
                            false => 23707,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23708,
                            false => 23709,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23710,
                            false => 23711,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23712,
                            false => 23713,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23714,
                            false => 23715,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23716,
                            false => 23717,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23718,
                            false => 23719,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23720,
                            false => 23721,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23722,
                            false => 23723,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23724,
                            false => 23725,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23726,
                            false => 23727,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23728,
                            false => 23729,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23730,
                            false => 23731,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23732,
                            false => 23733,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23734,
                            false => 23735,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23736,
                            false => 23737,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23738,
                            false => 23739,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23740,
                            false => 23741,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23742,
                            false => 23743,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23744,
                            false => 23745,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23746,
                            false => 23747,
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
            23668 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23669 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23670 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23671 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23672 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23673 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23674 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23675 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23676 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23677 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23678 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23679 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23680 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23681 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23682 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23683 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            23684 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            23685 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            23686 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            23687 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            23688 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            23689 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            23690 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            23691 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            23692 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            23693 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            23694 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            23695 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            23696 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23697 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23698 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23699 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23700 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23701 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23702 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23703 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23704 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23705 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23706 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23707 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23708 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23709 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23710 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23711 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23712 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23713 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23714 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23715 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23716 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23717 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23718 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23719 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23720 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23721 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23722 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23723 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23724 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23725 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23726 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23727 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23728 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23729 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23730 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23731 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23732 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23733 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23734 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23735 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23736 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23737 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23738 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23739 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23740 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23741 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23742 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23743 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23744 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23745 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23746 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23747 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
