using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedAndesiteStairsBlock(Identifier Identifier, Direction Facing, PolishedAndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:polished_andesite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.polished_andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14945,
                            false => 14946,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14947,
                            false => 14948,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14949,
                            false => 14950,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14951,
                            false => 14952,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14953,
                            false => 14954,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14955,
                            false => 14956,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14957,
                            false => 14958,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14959,
                            false => 14960,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14961,
                            false => 14962,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14963,
                            false => 14964,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14965,
                            false => 14966,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14967,
                            false => 14968,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14969,
                            false => 14970,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14971,
                            false => 14972,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14973,
                            false => 14974,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14975,
                            false => 14976,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14977,
                            false => 14978,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14979,
                            false => 14980,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14981,
                            false => 14982,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14983,
                            false => 14984,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14985,
                            false => 14986,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14987,
                            false => 14988,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14989,
                            false => 14990,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14991,
                            false => 14992,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14993,
                            false => 14994,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14995,
                            false => 14996,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14997,
                            false => 14998,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14999,
                            false => 15000,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15001,
                            false => 15002,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15003,
                            false => 15004,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15005,
                            false => 15006,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15007,
                            false => 15008,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15009,
                            false => 15010,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15011,
                            false => 15012,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15013,
                            false => 15014,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15015,
                            false => 15016,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15017,
                            false => 15018,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15019,
                            false => 15020,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15021,
                            false => 15022,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15023,
                            false => 15024,
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
            14945 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14946 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14947 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14948 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14949 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14950 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14951 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14952 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14953 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14954 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14955 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14956 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14957 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14958 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14959 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14960 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14961 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14962 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14963 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14964 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14965 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14966 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14967 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14968 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14969 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14970 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14971 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14972 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14973 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14974 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14975 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14976 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14977 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14978 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14979 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14980 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14981 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14982 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14983 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14984 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14985 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14986 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14987 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14988 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14989 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14990 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14991 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14992 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14993 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14994 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14995 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14996 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14997 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14998 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14999 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15000 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15001 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15002 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15003 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15004 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15005 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15006 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15007 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15008 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15009 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15010 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15011 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15012 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15013 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15014 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15015 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15016 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15017 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15018 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15019 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15020 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15021 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15022 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15023 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15024 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
