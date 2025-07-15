using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneBrickStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:polished_blackstone_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20941,
                            false => 20942,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20943,
                            false => 20944,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20945,
                            false => 20946,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20947,
                            false => 20948,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20949,
                            false => 20950,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20951,
                            false => 20952,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20953,
                            false => 20954,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20955,
                            false => 20956,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20957,
                            false => 20958,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20959,
                            false => 20960,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20961,
                            false => 20962,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20963,
                            false => 20964,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20965,
                            false => 20966,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20967,
                            false => 20968,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20969,
                            false => 20970,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20971,
                            false => 20972,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20973,
                            false => 20974,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20975,
                            false => 20976,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20977,
                            false => 20978,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20979,
                            false => 20980,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20981,
                            false => 20982,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20983,
                            false => 20984,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20985,
                            false => 20986,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20987,
                            false => 20988,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20989,
                            false => 20990,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20991,
                            false => 20992,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20993,
                            false => 20994,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20995,
                            false => 20996,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20997,
                            false => 20998,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20999,
                            false => 21000,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21001,
                            false => 21002,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21003,
                            false => 21004,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21005,
                            false => 21006,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21007,
                            false => 21008,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21009,
                            false => 21010,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21011,
                            false => 21012,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21013,
                            false => 21014,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21015,
                            false => 21016,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21017,
                            false => 21018,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21019,
                            false => 21020,
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
            20941 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20942 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20943 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20944 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20945 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20946 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20947 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20948 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20949 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20950 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20951 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20952 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20953 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20954 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20955 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20956 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20957 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20958 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20959 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20960 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20961 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20962 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20963 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20964 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20965 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20966 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20967 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20968 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20969 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20970 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20971 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20972 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20973 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20974 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20975 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20976 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20977 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20978 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20979 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20980 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20981 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20982 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20983 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20984 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20985 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20986 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20987 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20988 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20989 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20990 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20991 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20992 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20993 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20994 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20995 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20996 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20997 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20998 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20999 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21000 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21001 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21002 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21003 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21004 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21005 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21006 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21007 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21008 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21009 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21010 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21011 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21012 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21013 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21014 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21015 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21016 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21017 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21018 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21019 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21020 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
}
