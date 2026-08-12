using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCutCopperStairsBlock(Identifier Identifier, Direction Facing, WeatheredCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weathered_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27968,
                            false => 27969,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27970,
                            false => 27971,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27972,
                            false => 27973,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27974,
                            false => 27975,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27976,
                            false => 27977,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27978,
                            false => 27979,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27980,
                            false => 27981,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27982,
                            false => 27983,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27984,
                            false => 27985,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27986,
                            false => 27987,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27988,
                            false => 27989,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 27990,
                            false => 27991,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 27992,
                            false => 27993,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 27994,
                            false => 27995,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 27996,
                            false => 27997,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 27998,
                            false => 27999,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28000,
                            false => 28001,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28002,
                            false => 28003,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28004,
                            false => 28005,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28006,
                            false => 28007,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28008,
                            false => 28009,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28010,
                            false => 28011,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28012,
                            false => 28013,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28014,
                            false => 28015,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28016,
                            false => 28017,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28018,
                            false => 28019,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28020,
                            false => 28021,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28022,
                            false => 28023,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28024,
                            false => 28025,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28026,
                            false => 28027,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28028,
                            false => 28029,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28030,
                            false => 28031,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28032,
                            false => 28033,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28034,
                            false => 28035,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28036,
                            false => 28037,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28038,
                            false => 28039,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28040,
                            false => 28041,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28042,
                            false => 28043,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28044,
                            false => 28045,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28046,
                            false => 28047,
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
            27968 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            27969 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            27970 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            27971 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            27972 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            27973 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            27974 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            27975 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            27976 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            27977 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            27978 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            27979 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            27980 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            27981 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            27982 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            27983 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            27984 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            27985 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            27986 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            27987 => new WeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            27988 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            27989 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            27990 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            27991 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            27992 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            27993 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            27994 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            27995 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            27996 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            27997 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            27998 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            27999 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28000 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28001 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28002 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28003 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28004 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28005 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28006 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28007 => new WeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28008 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28009 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28010 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28011 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28012 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28013 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28014 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28015 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28016 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28017 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28018 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28019 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28020 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28021 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28022 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28023 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28024 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28025 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28026 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28027 => new WeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28028 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28029 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28030 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28031 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28032 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28033 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28034 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28035 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28036 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28037 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28038 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28039 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28040 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28041 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28042 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28043 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28044 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28045 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28046 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28047 => new WeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
