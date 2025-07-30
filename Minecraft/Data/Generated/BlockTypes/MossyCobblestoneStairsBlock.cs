using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyCobblestoneStairsBlock(Identifier Identifier, Direction Facing, MossyCobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 769;
    public double Hardness => 2;
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
    public Identifier? Item => "minecraft:mossy_cobblestone_stairs";
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
    public string TranslationKey => "block.minecraft.mossy_cobblestone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14337,
                            false => 14338,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14339,
                            false => 14340,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14341,
                            false => 14342,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14343,
                            false => 14344,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14345,
                            false => 14346,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14347,
                            false => 14348,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14349,
                            false => 14350,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14351,
                            false => 14352,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14353,
                            false => 14354,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14355,
                            false => 14356,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14357,
                            false => 14358,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14359,
                            false => 14360,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14361,
                            false => 14362,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14363,
                            false => 14364,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14365,
                            false => 14366,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14367,
                            false => 14368,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14369,
                            false => 14370,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14371,
                            false => 14372,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14373,
                            false => 14374,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14375,
                            false => 14376,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14377,
                            false => 14378,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14379,
                            false => 14380,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14381,
                            false => 14382,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14383,
                            false => 14384,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14385,
                            false => 14386,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14387,
                            false => 14388,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14389,
                            false => 14390,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14391,
                            false => 14392,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14393,
                            false => 14394,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14395,
                            false => 14396,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14397,
                            false => 14398,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14399,
                            false => 14400,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14401,
                            false => 14402,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14403,
                            false => 14404,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14405,
                            false => 14406,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14407,
                            false => 14408,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14409,
                            false => 14410,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14411,
                            false => 14412,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14413,
                            false => 14414,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14415,
                            false => 14416,
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
            14337 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14338 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14339 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14340 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14341 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14342 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14343 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14344 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14345 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14346 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14347 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14348 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14349 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14350 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14351 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14352 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14353 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14354 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14355 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14356 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14357 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14358 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14359 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14360 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14361 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14362 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14363 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14364 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14365 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14366 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14367 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14368 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14369 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14370 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14371 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14372 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14373 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14374 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14375 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14376 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14377 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14378 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14379 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14380 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14381 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14382 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14383 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14384 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14385 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14386 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14387 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14388 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14389 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14390 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14391 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14392 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14393 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14394 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14395 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14396 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14397 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14398 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14399 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14400 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14401 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14402 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14403 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14404 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14405 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14406 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14407 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14408 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14409 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14410 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14411 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14412 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14413 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14414 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14415 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14416 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
