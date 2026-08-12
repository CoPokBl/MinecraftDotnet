using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkPrismarineStairsBlock(Identifier Identifier, Direction Facing, DarkPrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:dark_prismarine_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 31;
    public string TranslationKey => "block.minecraft.dark_prismarine_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12794,
                            false => 12795,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12796,
                            false => 12797,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12798,
                            false => 12799,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12800,
                            false => 12801,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12802,
                            false => 12803,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12804,
                            false => 12805,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12806,
                            false => 12807,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12808,
                            false => 12809,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12810,
                            false => 12811,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12812,
                            false => 12813,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12814,
                            false => 12815,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12816,
                            false => 12817,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12818,
                            false => 12819,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12820,
                            false => 12821,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12822,
                            false => 12823,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12824,
                            false => 12825,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12826,
                            false => 12827,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12828,
                            false => 12829,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12830,
                            false => 12831,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12832,
                            false => 12833,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12834,
                            false => 12835,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12836,
                            false => 12837,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12838,
                            false => 12839,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12840,
                            false => 12841,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12842,
                            false => 12843,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12844,
                            false => 12845,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12846,
                            false => 12847,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12848,
                            false => 12849,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12850,
                            false => 12851,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12852,
                            false => 12853,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12854,
                            false => 12855,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12856,
                            false => 12857,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12858,
                            false => 12859,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12860,
                            false => 12861,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12862,
                            false => 12863,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12864,
                            false => 12865,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12866,
                            false => 12867,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12868,
                            false => 12869,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12870,
                            false => 12871,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12872,
                            false => 12873,
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
            12794 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12795 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12796 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12797 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12798 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12799 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12800 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12801 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12802 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12803 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12804 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12805 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12806 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12807 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12808 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12809 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12810 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12811 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12812 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12813 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12814 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12815 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12816 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12817 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12818 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12819 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12820 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12821 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12822 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12823 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12824 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12825 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12826 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12827 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12828 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12829 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12830 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12831 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12832 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12833 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12834 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12835 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12836 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12837 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12838 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12839 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12840 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12841 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12842 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12843 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12844 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12845 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12846 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12847 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12848 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12849 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12850 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12851 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12852 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12853 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12854 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12855 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12856 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12857 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12858 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12859 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12860 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12861 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12862 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12863 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12864 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12865 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12866 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12867 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12868 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12869 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12870 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12871 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12872 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12873 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
