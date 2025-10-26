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
    public int ProtocolId => 514;
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
                            true => 11770,
                            false => 11771,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11772,
                            false => 11773,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11774,
                            false => 11775,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11776,
                            false => 11777,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11778,
                            false => 11779,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11780,
                            false => 11781,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11782,
                            false => 11783,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11784,
                            false => 11785,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11786,
                            false => 11787,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11788,
                            false => 11789,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11790,
                            false => 11791,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11792,
                            false => 11793,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11794,
                            false => 11795,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11796,
                            false => 11797,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11798,
                            false => 11799,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11800,
                            false => 11801,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11802,
                            false => 11803,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11804,
                            false => 11805,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11806,
                            false => 11807,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11808,
                            false => 11809,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11810,
                            false => 11811,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11812,
                            false => 11813,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11814,
                            false => 11815,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11816,
                            false => 11817,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11818,
                            false => 11819,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11820,
                            false => 11821,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11822,
                            false => 11823,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11824,
                            false => 11825,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11826,
                            false => 11827,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11828,
                            false => 11829,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11830,
                            false => 11831,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11832,
                            false => 11833,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11834,
                            false => 11835,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11836,
                            false => 11837,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11838,
                            false => 11839,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11840,
                            false => 11841,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11842,
                            false => 11843,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11844,
                            false => 11845,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11846,
                            false => 11847,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11848,
                            false => 11849,
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
            11770 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11771 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11772 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11773 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11774 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11775 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11776 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11777 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11778 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11779 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11780 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11781 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11782 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11783 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11784 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11785 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11786 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11787 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11788 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11789 => new AcaciaStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11790 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11791 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11792 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11793 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11794 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11795 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11796 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11797 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11798 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11799 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11800 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11801 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11802 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11803 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11804 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11805 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11806 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11807 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11808 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11809 => new AcaciaStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11810 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11811 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11812 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11813 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11814 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11815 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11816 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11817 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11818 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11819 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11820 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11821 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11822 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11823 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11824 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11825 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11826 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11827 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11828 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11829 => new AcaciaStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11830 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11831 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11832 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11833 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11834 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11835 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11836 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11837 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11838 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11839 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11840 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11841 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11842 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11843 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11844 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11845 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11846 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11847 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11848 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11849 => new AcaciaStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
