using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakStairsBlock(Identifier Identifier, Direction Facing, DarkOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 486;
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
    public Identifier? Item => "minecraft:dark_oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10853,
                            false => 10854,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10855,
                            false => 10856,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10857,
                            false => 10858,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10859,
                            false => 10860,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10861,
                            false => 10862,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10863,
                            false => 10864,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10865,
                            false => 10866,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10867,
                            false => 10868,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10869,
                            false => 10870,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10871,
                            false => 10872,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10873,
                            false => 10874,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10875,
                            false => 10876,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10877,
                            false => 10878,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10879,
                            false => 10880,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10881,
                            false => 10882,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10883,
                            false => 10884,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10885,
                            false => 10886,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10887,
                            false => 10888,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10889,
                            false => 10890,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10891,
                            false => 10892,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10893,
                            false => 10894,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10895,
                            false => 10896,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10897,
                            false => 10898,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10899,
                            false => 10900,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10901,
                            false => 10902,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10903,
                            false => 10904,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10905,
                            false => 10906,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10907,
                            false => 10908,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10909,
                            false => 10910,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10911,
                            false => 10912,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10913,
                            false => 10914,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10915,
                            false => 10916,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10917,
                            false => 10918,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10919,
                            false => 10920,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10921,
                            false => 10922,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10923,
                            false => 10924,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10925,
                            false => 10926,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10927,
                            false => 10928,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10929,
                            false => 10930,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10931,
                            false => 10932,
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
            10853 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            10854 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            10855 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            10856 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            10857 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            10858 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            10859 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            10860 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            10861 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            10862 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            10863 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            10864 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            10865 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            10866 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            10867 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            10868 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            10869 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            10870 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            10871 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            10872 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            10873 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            10874 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            10875 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            10876 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            10877 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            10878 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            10879 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            10880 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            10881 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            10882 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            10883 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            10884 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            10885 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            10886 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            10887 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            10888 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            10889 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            10890 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            10891 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            10892 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            10893 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            10894 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            10895 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            10896 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            10897 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            10898 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            10899 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            10900 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            10901 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            10902 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            10903 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            10904 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            10905 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            10906 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            10907 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            10908 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            10909 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            10910 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            10911 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            10912 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            10913 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            10914 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            10915 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            10916 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            10917 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            10918 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            10919 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            10920 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            10921 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            10922 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            10923 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            10924 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            10925 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            10926 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            10927 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            10928 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            10929 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            10930 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            10931 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            10932 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
