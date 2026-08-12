using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DioriteStairsBlock(Identifier Identifier, Direction Facing, DioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:diorite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16336,
                            false => 16337,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16338,
                            false => 16339,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16340,
                            false => 16341,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16342,
                            false => 16343,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16344,
                            false => 16345,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16346,
                            false => 16347,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16348,
                            false => 16349,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16350,
                            false => 16351,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16352,
                            false => 16353,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16354,
                            false => 16355,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16356,
                            false => 16357,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16358,
                            false => 16359,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16360,
                            false => 16361,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16362,
                            false => 16363,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16364,
                            false => 16365,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16366,
                            false => 16367,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16368,
                            false => 16369,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16370,
                            false => 16371,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16372,
                            false => 16373,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16374,
                            false => 16375,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16376,
                            false => 16377,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16378,
                            false => 16379,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16380,
                            false => 16381,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16382,
                            false => 16383,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16384,
                            false => 16385,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16386,
                            false => 16387,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16388,
                            false => 16389,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16390,
                            false => 16391,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16392,
                            false => 16393,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16394,
                            false => 16395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16396,
                            false => 16397,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16398,
                            false => 16399,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16400,
                            false => 16401,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16402,
                            false => 16403,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16404,
                            false => 16405,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16406,
                            false => 16407,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16408,
                            false => 16409,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16410,
                            false => 16411,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16412,
                            false => 16413,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16414,
                            false => 16415,
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
            16336 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16337 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16338 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16339 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16340 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16341 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16342 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16343 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16344 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16345 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16346 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16347 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16348 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16349 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16350 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16351 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16352 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16353 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16354 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16355 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16356 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16357 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16358 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16359 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16360 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16361 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16362 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16363 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16364 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16365 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16366 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16367 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16368 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16369 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16370 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16371 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16372 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16373 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16374 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16375 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16376 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16377 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16378 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16379 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16380 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16381 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16382 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16383 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16384 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16385 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16386 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16387 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16388 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16389 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16390 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16391 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16392 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16393 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16394 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16395 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16396 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16397 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16398 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16399 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16400 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16401 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16402 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16403 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16404 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16405 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16406 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16407 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16408 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16409 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16410 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16411 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16412 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16413 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16414 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16415 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
