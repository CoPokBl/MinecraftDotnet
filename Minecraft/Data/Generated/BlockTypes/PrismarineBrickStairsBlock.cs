using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineBrickStairsBlock(Identifier Identifier, Direction Facing, PrismarineBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 499;
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
    public Identifier? Item => "minecraft:prismarine_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 31;
    public string TranslationKey => "block.minecraft.prismarine_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11435,
                            false => 11436,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11437,
                            false => 11438,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11439,
                            false => 11440,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11441,
                            false => 11442,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11443,
                            false => 11444,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11445,
                            false => 11446,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11447,
                            false => 11448,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11449,
                            false => 11450,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11451,
                            false => 11452,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11453,
                            false => 11454,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11455,
                            false => 11456,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11457,
                            false => 11458,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11459,
                            false => 11460,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11461,
                            false => 11462,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11463,
                            false => 11464,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11465,
                            false => 11466,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11467,
                            false => 11468,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11469,
                            false => 11470,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11471,
                            false => 11472,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11473,
                            false => 11474,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11475,
                            false => 11476,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11477,
                            false => 11478,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11479,
                            false => 11480,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11481,
                            false => 11482,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11483,
                            false => 11484,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11485,
                            false => 11486,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11487,
                            false => 11488,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11489,
                            false => 11490,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11491,
                            false => 11492,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11493,
                            false => 11494,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11495,
                            false => 11496,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11497,
                            false => 11498,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11499,
                            false => 11500,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11501,
                            false => 11502,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11503,
                            false => 11504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11505,
                            false => 11506,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11507,
                            false => 11508,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11509,
                            false => 11510,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11511,
                            false => 11512,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11513,
                            false => 11514,
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
            11435 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            11436 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            11437 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            11438 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            11439 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            11440 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            11441 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            11442 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            11443 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            11444 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            11445 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            11446 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            11447 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            11448 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            11449 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            11450 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            11451 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            11452 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            11453 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            11454 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            11455 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            11456 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            11457 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            11458 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            11459 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            11460 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            11461 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            11462 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            11463 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            11464 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            11465 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            11466 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            11467 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            11468 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            11469 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            11470 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            11471 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            11472 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            11473 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            11474 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            11475 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            11476 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            11477 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            11478 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            11479 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            11480 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            11481 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            11482 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            11483 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            11484 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            11485 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            11486 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            11487 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            11488 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            11489 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            11490 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            11491 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            11492 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            11493 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            11494 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            11495 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            11496 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            11497 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            11498 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            11499 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            11500 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            11501 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11502 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11503 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11504 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11505 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11506 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11507 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11508 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11509 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11510 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11511 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11512 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11513 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11514 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
