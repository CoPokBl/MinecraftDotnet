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
                            true => 20909,
                            false => 20910,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20911,
                            false => 20912,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20913,
                            false => 20914,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20915,
                            false => 20916,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20917,
                            false => 20918,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20919,
                            false => 20920,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20921,
                            false => 20922,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20923,
                            false => 20924,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20925,
                            false => 20926,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20927,
                            false => 20928,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20929,
                            false => 20930,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20931,
                            false => 20932,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20933,
                            false => 20934,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20935,
                            false => 20936,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20937,
                            false => 20938,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20939,
                            false => 20940,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20941,
                            false => 20942,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20943,
                            false => 20944,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20945,
                            false => 20946,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20947,
                            false => 20948,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20949,
                            false => 20950,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20951,
                            false => 20952,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20953,
                            false => 20954,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20955,
                            false => 20956,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20957,
                            false => 20958,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20959,
                            false => 20960,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20961,
                            false => 20962,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20963,
                            false => 20964,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20965,
                            false => 20966,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20967,
                            false => 20968,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20969,
                            false => 20970,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20971,
                            false => 20972,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20973,
                            false => 20974,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20975,
                            false => 20976,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20977,
                            false => 20978,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20979,
                            false => 20980,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20981,
                            false => 20982,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20983,
                            false => 20984,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20985,
                            false => 20986,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20987,
                            false => 20988,
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
            20909 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20910 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20911 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20912 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20913 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20914 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20915 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20916 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20917 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20918 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20919 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20920 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20921 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20922 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20923 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20924 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20925 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20926 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20927 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20928 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20929 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20930 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20931 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20932 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20933 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20934 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20935 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20936 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20937 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20938 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20939 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20940 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20941 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20942 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20943 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20944 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20945 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20946 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20947 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20948 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20949 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20950 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20951 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20952 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20953 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20954 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20955 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20956 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20957 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20958 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20959 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20960 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20961 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20962 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20963 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20964 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20965 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20966 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20967 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20968 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20969 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20970 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20971 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20972 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20973 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20974 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20975 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20976 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20977 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20978 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20979 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20980 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20981 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20982 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20983 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20984 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20985 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20986 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20987 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20988 => new PolishedBlackstoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
