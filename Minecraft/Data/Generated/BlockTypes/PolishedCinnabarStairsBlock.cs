using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedCinnabarStairsBlock(Identifier Identifier, Direction Facing, PolishedCinnabarStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "cinnabar";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_cinnabar_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.polished_cinnabar_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26344,
                            false => 26345,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26346,
                            false => 26347,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26348,
                            false => 26349,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26350,
                            false => 26351,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26352,
                            false => 26353,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26354,
                            false => 26355,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26356,
                            false => 26357,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26358,
                            false => 26359,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26360,
                            false => 26361,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26362,
                            false => 26363,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26364,
                            false => 26365,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26366,
                            false => 26367,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26368,
                            false => 26369,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26370,
                            false => 26371,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26372,
                            false => 26373,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26374,
                            false => 26375,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26376,
                            false => 26377,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26378,
                            false => 26379,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26380,
                            false => 26381,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26382,
                            false => 26383,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26384,
                            false => 26385,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26386,
                            false => 26387,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26388,
                            false => 26389,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26390,
                            false => 26391,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26392,
                            false => 26393,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26394,
                            false => 26395,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26396,
                            false => 26397,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26398,
                            false => 26399,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26400,
                            false => 26401,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26402,
                            false => 26403,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26404,
                            false => 26405,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26406,
                            false => 26407,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26408,
                            false => 26409,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26410,
                            false => 26411,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26412,
                            false => 26413,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26414,
                            false => 26415,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26416,
                            false => 26417,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26418,
                            false => 26419,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26420,
                            false => 26421,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26422,
                            false => 26423,
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
            26344 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26345 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26346 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26347 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26348 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26349 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26350 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26351 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26352 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26353 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26354 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26355 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26356 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26357 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26358 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26359 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26360 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26361 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26362 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26363 => new PolishedCinnabarStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26364 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26365 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26366 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26367 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26368 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26369 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26370 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26371 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26372 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26373 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26374 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26375 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26376 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26377 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26378 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26379 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26380 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26381 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26382 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26383 => new PolishedCinnabarStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26384 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26385 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26386 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26387 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26388 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26389 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26390 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26391 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26392 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26393 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26394 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26395 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26396 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26397 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26398 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26399 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26400 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26401 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26402 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26403 => new PolishedCinnabarStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26404 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26405 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26406 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26407 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26408 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26409 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26410 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26411 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26412 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26413 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26414 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26415 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26416 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26417 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26418 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26419 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26420 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26421 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26422 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26423 => new PolishedCinnabarStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
