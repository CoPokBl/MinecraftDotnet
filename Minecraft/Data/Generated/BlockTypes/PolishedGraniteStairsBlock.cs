using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedGraniteStairsBlock(Identifier Identifier, Direction Facing, PolishedGraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:polished_granite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.polished_granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15296,
                            false => 15297,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15298,
                            false => 15299,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15300,
                            false => 15301,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15302,
                            false => 15303,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15304,
                            false => 15305,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15306,
                            false => 15307,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15308,
                            false => 15309,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15310,
                            false => 15311,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15312,
                            false => 15313,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15314,
                            false => 15315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15316,
                            false => 15317,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15318,
                            false => 15319,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15320,
                            false => 15321,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15322,
                            false => 15323,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15324,
                            false => 15325,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15326,
                            false => 15327,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15328,
                            false => 15329,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15330,
                            false => 15331,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15332,
                            false => 15333,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15334,
                            false => 15335,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15336,
                            false => 15337,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15338,
                            false => 15339,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15340,
                            false => 15341,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15342,
                            false => 15343,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15344,
                            false => 15345,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15346,
                            false => 15347,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15348,
                            false => 15349,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15350,
                            false => 15351,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15352,
                            false => 15353,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15354,
                            false => 15355,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15356,
                            false => 15357,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15358,
                            false => 15359,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15360,
                            false => 15361,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15362,
                            false => 15363,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15364,
                            false => 15365,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15366,
                            false => 15367,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15368,
                            false => 15369,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15370,
                            false => 15371,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15372,
                            false => 15373,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15374,
                            false => 15375,
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
            15296 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15297 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15298 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15299 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15300 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15301 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15302 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15303 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15304 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15305 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15306 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15307 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15308 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15309 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15310 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15311 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15312 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15313 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15314 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15315 => new PolishedGraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15316 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15317 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15318 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15319 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15320 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15321 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15322 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15323 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15324 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15325 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15326 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15327 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15328 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15329 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15330 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15331 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15332 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15333 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15334 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15335 => new PolishedGraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15336 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15337 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15338 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15339 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15340 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15341 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15342 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15343 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15344 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15345 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15346 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15347 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15348 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15349 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15350 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15351 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15352 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15353 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15354 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15355 => new PolishedGraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15356 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15357 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15358 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15359 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15360 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15361 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15362 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15363 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15364 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15365 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15366 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15367 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15368 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15369 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15370 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15371 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15372 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15373 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15374 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15375 => new PolishedGraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
