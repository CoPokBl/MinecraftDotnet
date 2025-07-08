using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCutCopperStairsBlock(Identifier Identifier, Direction Facing, OxidizedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:oxidized_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23984,
                            false => 23985,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23986,
                            false => 23987,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23988,
                            false => 23989,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23990,
                            false => 23991,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23992,
                            false => 23993,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23994,
                            false => 23995,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23996,
                            false => 23997,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23998,
                            false => 23999,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24000,
                            false => 24001,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24002,
                            false => 24003,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24004,
                            false => 24005,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24006,
                            false => 24007,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24008,
                            false => 24009,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24010,
                            false => 24011,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24012,
                            false => 24013,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24014,
                            false => 24015,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24016,
                            false => 24017,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24018,
                            false => 24019,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24020,
                            false => 24021,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24022,
                            false => 24023,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24024,
                            false => 24025,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24026,
                            false => 24027,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24028,
                            false => 24029,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24030,
                            false => 24031,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24032,
                            false => 24033,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24034,
                            false => 24035,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24036,
                            false => 24037,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24038,
                            false => 24039,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24040,
                            false => 24041,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24042,
                            false => 24043,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24044,
                            false => 24045,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24046,
                            false => 24047,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24048,
                            false => 24049,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24050,
                            false => 24051,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24052,
                            false => 24053,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24054,
                            false => 24055,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24056,
                            false => 24057,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24058,
                            false => 24059,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24060,
                            false => 24061,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24062,
                            false => 24063,
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
            23984 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23985 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23986 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23987 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23988 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23989 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23990 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23991 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23992 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23993 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23994 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23995 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23996 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23997 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23998 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23999 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24000 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24001 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24002 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24003 => new OxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24004 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24005 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24006 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24007 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24008 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24009 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24010 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24011 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24012 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24013 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24014 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24015 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24016 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24017 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24018 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24019 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24020 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24021 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24022 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24023 => new OxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24024 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24025 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24026 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24027 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24028 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24029 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24030 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24031 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24032 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24033 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24034 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24035 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24036 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24037 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24038 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24039 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24040 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24041 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24042 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24043 => new OxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24044 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24045 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24046 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24047 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24048 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24049 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24050 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24051 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24052 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24053 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24054 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24055 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24056 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24057 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24058 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24059 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24060 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24061 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24062 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24063 => new OxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
