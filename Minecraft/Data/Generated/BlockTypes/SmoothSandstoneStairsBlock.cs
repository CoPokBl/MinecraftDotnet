using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
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
    public Identifier? Item => "minecraft:smooth_sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.smooth_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15856,
                            false => 15857,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15858,
                            false => 15859,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15860,
                            false => 15861,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15862,
                            false => 15863,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15864,
                            false => 15865,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15866,
                            false => 15867,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15868,
                            false => 15869,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15870,
                            false => 15871,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15872,
                            false => 15873,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15874,
                            false => 15875,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15876,
                            false => 15877,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15878,
                            false => 15879,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15880,
                            false => 15881,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15882,
                            false => 15883,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15884,
                            false => 15885,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15886,
                            false => 15887,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15888,
                            false => 15889,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15890,
                            false => 15891,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15892,
                            false => 15893,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15894,
                            false => 15895,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15896,
                            false => 15897,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15898,
                            false => 15899,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15900,
                            false => 15901,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15902,
                            false => 15903,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15904,
                            false => 15905,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15906,
                            false => 15907,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15908,
                            false => 15909,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15910,
                            false => 15911,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15912,
                            false => 15913,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15914,
                            false => 15915,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15916,
                            false => 15917,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15918,
                            false => 15919,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15920,
                            false => 15921,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15922,
                            false => 15923,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15924,
                            false => 15925,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15926,
                            false => 15927,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15928,
                            false => 15929,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15930,
                            false => 15931,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15932,
                            false => 15933,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15934,
                            false => 15935,
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
            15856 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15857 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15858 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15859 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15860 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15861 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15862 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15863 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15864 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15865 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15866 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15867 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15868 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15869 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15870 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15871 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15872 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15873 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15874 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15875 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15876 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15877 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15878 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15879 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15880 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15881 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15882 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15883 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15884 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15885 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15886 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15887 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15888 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15889 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15890 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15891 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15892 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15893 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15894 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15895 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15896 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15897 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15898 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15899 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15900 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15901 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15902 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15903 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15904 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15905 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15906 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15907 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15908 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15909 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15910 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15911 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15912 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15913 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15914 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15915 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15916 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15917 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15918 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15919 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15920 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15921 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15922 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15923 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15924 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15925 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15926 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15927 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15928 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15929 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15930 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15931 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15932 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15933 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15934 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15935 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
