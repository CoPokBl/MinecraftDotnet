using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDioriteStairsBlock(Identifier Identifier, Direction Facing, PolishedDioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 798;
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
    public Identifier? Item => "minecraft:polished_diorite_stairs";
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
    public string TranslationKey => "block.minecraft.polished_diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15334,
                            false => 15335,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15336,
                            false => 15337,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15338,
                            false => 15339,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15340,
                            false => 15341,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15342,
                            false => 15343,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15344,
                            false => 15345,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15346,
                            false => 15347,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15348,
                            false => 15349,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15350,
                            false => 15351,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15352,
                            false => 15353,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15354,
                            false => 15355,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15356,
                            false => 15357,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15358,
                            false => 15359,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15360,
                            false => 15361,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15362,
                            false => 15363,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15364,
                            false => 15365,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15366,
                            false => 15367,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15368,
                            false => 15369,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15370,
                            false => 15371,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15372,
                            false => 15373,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15374,
                            false => 15375,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15376,
                            false => 15377,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15378,
                            false => 15379,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15380,
                            false => 15381,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15382,
                            false => 15383,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15384,
                            false => 15385,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15386,
                            false => 15387,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15388,
                            false => 15389,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15390,
                            false => 15391,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15392,
                            false => 15393,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15394,
                            false => 15395,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15396,
                            false => 15397,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15398,
                            false => 15399,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15400,
                            false => 15401,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15402,
                            false => 15403,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15404,
                            false => 15405,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15406,
                            false => 15407,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15408,
                            false => 15409,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15410,
                            false => 15411,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15412,
                            false => 15413,
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
            15334 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15335 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15336 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15337 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15338 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15339 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15340 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15341 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15342 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15343 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15344 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15345 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15346 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15347 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15348 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15349 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15350 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15351 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15352 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15353 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15354 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15355 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15356 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15357 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15358 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15359 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15360 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15361 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15362 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15363 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15364 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15365 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15366 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15367 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15368 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15369 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15370 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15371 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15372 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15373 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15374 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15375 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15376 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15377 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15378 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15379 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15380 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15381 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15382 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15383 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15384 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15385 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15386 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15387 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15388 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15389 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15390 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15391 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15392 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15393 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15394 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15395 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15396 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15397 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15398 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15399 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15400 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15401 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15402 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15403 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15404 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15405 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15406 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15407 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15408 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15409 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15410 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15411 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15412 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15413 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
