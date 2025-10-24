using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCutCopperStairsBlock(Identifier Identifier, Direction Facing, ExposedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_stair";
    public int ProtocolId => 1025;
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
    public Identifier? Item => "minecraft:exposed_cut_copper_stairs";
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
    public string TranslationKey => "block.minecraft.exposed_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25285,
                            false => 25286,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25287,
                            false => 25288,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25289,
                            false => 25290,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25291,
                            false => 25292,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25293,
                            false => 25294,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25295,
                            false => 25296,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25297,
                            false => 25298,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25299,
                            false => 25300,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25301,
                            false => 25302,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25303,
                            false => 25304,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25305,
                            false => 25306,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25307,
                            false => 25308,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25309,
                            false => 25310,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25311,
                            false => 25312,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25313,
                            false => 25314,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25315,
                            false => 25316,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25317,
                            false => 25318,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25319,
                            false => 25320,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25321,
                            false => 25322,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25323,
                            false => 25324,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25325,
                            false => 25326,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25327,
                            false => 25328,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25329,
                            false => 25330,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25331,
                            false => 25332,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25333,
                            false => 25334,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25335,
                            false => 25336,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25337,
                            false => 25338,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25339,
                            false => 25340,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25341,
                            false => 25342,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25343,
                            false => 25344,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25345,
                            false => 25346,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25347,
                            false => 25348,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25349,
                            false => 25350,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25351,
                            false => 25352,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25353,
                            false => 25354,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25355,
                            false => 25356,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25357,
                            false => 25358,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25359,
                            false => 25360,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25361,
                            false => 25362,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25363,
                            false => 25364,
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
            25285 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25286 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25287 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25288 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25289 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25290 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25291 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25292 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25293 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25294 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25295 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25296 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25297 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25298 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25299 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25300 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25301 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25302 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25303 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25304 => new ExposedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25305 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25306 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25307 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25308 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25309 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25310 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25311 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25312 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25313 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25314 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25315 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25316 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25317 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25318 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25319 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25320 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25321 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25322 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25323 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25324 => new ExposedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25325 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25326 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25327 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25328 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25329 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25330 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25331 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25332 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25333 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25334 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25335 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25336 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25337 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25338 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25339 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25340 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25341 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25342 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25343 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25344 => new ExposedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25345 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25346 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25347 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25348 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25349 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25350 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25351 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25352 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25353 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25354 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25355 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25356 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25357 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25358 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25359 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25360 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25361 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25362 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25363 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25364 => new ExposedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
