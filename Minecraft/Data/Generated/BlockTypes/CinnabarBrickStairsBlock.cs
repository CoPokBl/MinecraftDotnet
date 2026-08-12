using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CinnabarBrickStairsBlock(Identifier Identifier, Direction Facing, CinnabarBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "cinnabar";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cinnabar_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.cinnabar_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26755,
                            false => 26756,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26757,
                            false => 26758,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26759,
                            false => 26760,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26761,
                            false => 26762,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26763,
                            false => 26764,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26765,
                            false => 26766,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26767,
                            false => 26768,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26769,
                            false => 26770,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26771,
                            false => 26772,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26773,
                            false => 26774,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26775,
                            false => 26776,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26777,
                            false => 26778,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26779,
                            false => 26780,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26781,
                            false => 26782,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26783,
                            false => 26784,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26785,
                            false => 26786,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26787,
                            false => 26788,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26789,
                            false => 26790,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26791,
                            false => 26792,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26793,
                            false => 26794,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26795,
                            false => 26796,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26797,
                            false => 26798,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26799,
                            false => 26800,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26801,
                            false => 26802,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26803,
                            false => 26804,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26805,
                            false => 26806,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26807,
                            false => 26808,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26809,
                            false => 26810,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26811,
                            false => 26812,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26813,
                            false => 26814,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26815,
                            false => 26816,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26817,
                            false => 26818,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26819,
                            false => 26820,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26821,
                            false => 26822,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26823,
                            false => 26824,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26825,
                            false => 26826,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26827,
                            false => 26828,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26829,
                            false => 26830,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26831,
                            false => 26832,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26833,
                            false => 26834,
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
            26755 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26756 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26757 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26758 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26759 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26760 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26761 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26762 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26763 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26764 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26765 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26766 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26767 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26768 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26769 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26770 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26771 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26772 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26773 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26774 => new CinnabarBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26775 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26776 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26777 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26778 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26779 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26780 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26781 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26782 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26783 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26784 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26785 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26786 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26787 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26788 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26789 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26790 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26791 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26792 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26793 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26794 => new CinnabarBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26795 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26796 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26797 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26798 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26799 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26800 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26801 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26802 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26803 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26804 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26805 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26806 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26807 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26808 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26809 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26810 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26811 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26812 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26813 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26814 => new CinnabarBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26815 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26816 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26817 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26818 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26819 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26820 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26821 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26822 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26823 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26824 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26825 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26826 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26827 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26828 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26829 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26830 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26831 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26832 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26833 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26834 => new CinnabarBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
