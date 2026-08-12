using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveStairsBlock(Identifier Identifier, Direction Facing, MangroveStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:mangrove_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12292,
                            false => 12293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12294,
                            false => 12295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12296,
                            false => 12297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12298,
                            false => 12299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12300,
                            false => 12301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12302,
                            false => 12303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12304,
                            false => 12305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12306,
                            false => 12307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12308,
                            false => 12309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12310,
                            false => 12311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12312,
                            false => 12313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12314,
                            false => 12315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12316,
                            false => 12317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12318,
                            false => 12319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12320,
                            false => 12321,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12322,
                            false => 12323,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12324,
                            false => 12325,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12326,
                            false => 12327,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12328,
                            false => 12329,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12330,
                            false => 12331,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12332,
                            false => 12333,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12334,
                            false => 12335,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12336,
                            false => 12337,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12338,
                            false => 12339,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12340,
                            false => 12341,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12342,
                            false => 12343,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12344,
                            false => 12345,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12346,
                            false => 12347,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12348,
                            false => 12349,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12350,
                            false => 12351,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12352,
                            false => 12353,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12354,
                            false => 12355,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12356,
                            false => 12357,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12358,
                            false => 12359,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12360,
                            false => 12361,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12362,
                            false => 12363,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12364,
                            false => 12365,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12366,
                            false => 12367,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12368,
                            false => 12369,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12370,
                            false => 12371,
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
            12292 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12293 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12294 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12295 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12296 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12297 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12298 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12299 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12300 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12301 => new MangroveStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12302 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12303 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12304 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12305 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12306 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12307 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12308 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12309 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12310 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12311 => new MangroveStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12312 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12313 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12314 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12315 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12316 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12317 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12318 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12319 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12320 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12321 => new MangroveStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12322 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12323 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12324 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12325 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12326 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12327 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12328 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12329 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12330 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12331 => new MangroveStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12332 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12333 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12334 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12335 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12336 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12337 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12338 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12339 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12340 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12341 => new MangroveStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12342 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12343 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12344 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12345 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12346 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12347 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12348 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12349 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12350 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12351 => new MangroveStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12352 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12353 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12354 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12355 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12356 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12357 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12358 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12359 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12360 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12361 => new MangroveStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12362 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12363 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12364 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12365 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12366 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12367 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12368 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12369 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12370 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12371 => new MangroveStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
