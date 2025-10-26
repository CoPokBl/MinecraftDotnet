using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineStairsBlock(Identifier Identifier, Direction Facing, PrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 528;
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
    public Identifier? Item => "minecraft:prismarine_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.prismarine_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12432,
                            false => 12433,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12434,
                            false => 12435,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12436,
                            false => 12437,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12438,
                            false => 12439,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12440,
                            false => 12441,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12442,
                            false => 12443,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12444,
                            false => 12445,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12446,
                            false => 12447,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12448,
                            false => 12449,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12450,
                            false => 12451,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12452,
                            false => 12453,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12454,
                            false => 12455,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12456,
                            false => 12457,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12458,
                            false => 12459,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12460,
                            false => 12461,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12462,
                            false => 12463,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12464,
                            false => 12465,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12466,
                            false => 12467,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12468,
                            false => 12469,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12470,
                            false => 12471,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12472,
                            false => 12473,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12474,
                            false => 12475,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12476,
                            false => 12477,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12478,
                            false => 12479,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12480,
                            false => 12481,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12482,
                            false => 12483,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12484,
                            false => 12485,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12486,
                            false => 12487,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12488,
                            false => 12489,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12490,
                            false => 12491,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12492,
                            false => 12493,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12494,
                            false => 12495,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12496,
                            false => 12497,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12498,
                            false => 12499,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12500,
                            false => 12501,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12502,
                            false => 12503,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12504,
                            false => 12505,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12506,
                            false => 12507,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12508,
                            false => 12509,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12510,
                            false => 12511,
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
            12432 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12433 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12434 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12435 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12436 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12437 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12438 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12439 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12440 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12441 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12442 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12443 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12444 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12445 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12446 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12447 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12448 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12449 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12450 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12451 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12452 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12453 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12454 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12455 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12456 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12457 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12458 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12459 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12460 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12461 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12462 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12463 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12464 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12465 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12466 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12467 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12468 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12469 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12470 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12471 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12472 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12473 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12474 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12475 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12476 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12477 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12478 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12479 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12480 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12481 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12482 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12483 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12484 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12485 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12486 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12487 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12488 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12489 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12490 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12491 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12492 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12493 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12494 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12495 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12496 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12497 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12498 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12499 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12500 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12501 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12502 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12503 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12504 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12505 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12506 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12507 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12508 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12509 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12510 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12511 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
