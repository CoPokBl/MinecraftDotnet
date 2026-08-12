using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooMosaicStairsBlock(Identifier Identifier, Direction Facing, BambooMosaicStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_mosaic_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_mosaic_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
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
                Direction.South => HalfValue switch {
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
                Direction.West => HalfValue switch {
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
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12512,
                            false => 12513,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12514,
                            false => 12515,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12516,
                            false => 12517,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12518,
                            false => 12519,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12520,
                            false => 12521,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12522,
                            false => 12523,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12524,
                            false => 12525,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12526,
                            false => 12527,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12528,
                            false => 12529,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12530,
                            false => 12531,
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
            12452 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12453 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12454 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12455 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12456 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12457 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12458 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12459 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12460 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12461 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12462 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12463 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12464 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12465 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12466 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12467 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12468 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12469 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12470 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12471 => new BambooMosaicStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12472 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12473 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12474 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12475 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12476 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12477 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12478 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12479 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12480 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12481 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12482 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12483 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12484 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12485 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12486 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12487 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12488 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12489 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12490 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12491 => new BambooMosaicStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12492 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12493 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12494 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12495 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12496 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12497 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12498 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12499 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12500 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12501 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12502 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12503 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12504 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12505 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12506 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12507 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12508 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12509 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12510 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12511 => new BambooMosaicStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12512 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12513 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12514 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12515 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12516 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12517 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12518 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12519 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12520 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12521 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12522 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12523 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12524 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12525 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12526 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12527 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12528 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12529 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12530 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12531 => new BambooMosaicStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
