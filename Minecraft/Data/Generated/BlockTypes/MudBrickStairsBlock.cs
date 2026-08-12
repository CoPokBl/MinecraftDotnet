using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MudBrickStairsBlock(Identifier Identifier, Direction Facing, MudBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 1.5;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "mud_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mud_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.mud_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8838,
                            false => 8839,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8840,
                            false => 8841,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8842,
                            false => 8843,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8844,
                            false => 8845,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8846,
                            false => 8847,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8848,
                            false => 8849,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8850,
                            false => 8851,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8852,
                            false => 8853,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8854,
                            false => 8855,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8856,
                            false => 8857,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8858,
                            false => 8859,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8860,
                            false => 8861,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8862,
                            false => 8863,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8864,
                            false => 8865,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8866,
                            false => 8867,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8868,
                            false => 8869,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8870,
                            false => 8871,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8872,
                            false => 8873,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8874,
                            false => 8875,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8876,
                            false => 8877,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8878,
                            false => 8879,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8880,
                            false => 8881,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8882,
                            false => 8883,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8884,
                            false => 8885,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8886,
                            false => 8887,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8888,
                            false => 8889,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8890,
                            false => 8891,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8892,
                            false => 8893,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8894,
                            false => 8895,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8896,
                            false => 8897,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8898,
                            false => 8899,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8900,
                            false => 8901,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8902,
                            false => 8903,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8904,
                            false => 8905,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8906,
                            false => 8907,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8908,
                            false => 8909,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8910,
                            false => 8911,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8912,
                            false => 8913,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8914,
                            false => 8915,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8916,
                            false => 8917,
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
            8838 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8839 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8840 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8841 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8842 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8843 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8844 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8845 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8846 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8847 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8848 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8849 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8850 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8851 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8852 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8853 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8854 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8855 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8856 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8857 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8858 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8859 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8860 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8861 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8862 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8863 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8864 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8865 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8866 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8867 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8868 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8869 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8870 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8871 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8872 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8873 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8874 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8875 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8876 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8877 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8878 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8879 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8880 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8881 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8882 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8883 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8884 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8885 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8886 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8887 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8888 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8889 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8890 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8891 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8892 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8893 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8894 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8895 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8896 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8897 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8898 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8899 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8900 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8901 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8902 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8903 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8904 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8905 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8906 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8907 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8908 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8909 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8910 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8911 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8912 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8913 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8914 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8915 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8916 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8917 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
