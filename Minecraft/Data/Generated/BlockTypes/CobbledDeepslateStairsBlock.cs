using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobbledDeepslateStairsBlock(Identifier Identifier, Direction Facing, CobbledDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3.5;
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
    public string SoundType => "deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cobbled_deepslate_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.cobbled_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30420,
                            false => 30421,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30422,
                            false => 30423,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30424,
                            false => 30425,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30426,
                            false => 30427,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30428,
                            false => 30429,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30430,
                            false => 30431,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30432,
                            false => 30433,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30434,
                            false => 30435,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30436,
                            false => 30437,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30438,
                            false => 30439,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30440,
                            false => 30441,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30442,
                            false => 30443,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30444,
                            false => 30445,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30446,
                            false => 30447,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30448,
                            false => 30449,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30450,
                            false => 30451,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30452,
                            false => 30453,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30454,
                            false => 30455,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30456,
                            false => 30457,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30458,
                            false => 30459,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30460,
                            false => 30461,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30462,
                            false => 30463,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30464,
                            false => 30465,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30466,
                            false => 30467,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30468,
                            false => 30469,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30470,
                            false => 30471,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30472,
                            false => 30473,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30474,
                            false => 30475,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30476,
                            false => 30477,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30478,
                            false => 30479,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30480,
                            false => 30481,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30482,
                            false => 30483,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30484,
                            false => 30485,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30486,
                            false => 30487,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30488,
                            false => 30489,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 30490,
                            false => 30491,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 30492,
                            false => 30493,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 30494,
                            false => 30495,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 30496,
                            false => 30497,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 30498,
                            false => 30499,
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
            30420 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            30421 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            30422 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            30423 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            30424 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            30425 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            30426 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            30427 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            30428 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            30429 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            30430 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            30431 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            30432 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            30433 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            30434 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            30435 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            30436 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            30437 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            30438 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            30439 => new CobbledDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            30440 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            30441 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            30442 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            30443 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            30444 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            30445 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            30446 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            30447 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            30448 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            30449 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            30450 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            30451 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            30452 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            30453 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            30454 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            30455 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            30456 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            30457 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            30458 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            30459 => new CobbledDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            30460 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            30461 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            30462 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            30463 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            30464 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            30465 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            30466 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            30467 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            30468 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            30469 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            30470 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            30471 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            30472 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            30473 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            30474 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            30475 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            30476 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            30477 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            30478 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            30479 => new CobbledDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            30480 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            30481 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            30482 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            30483 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            30484 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            30485 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            30486 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            30487 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            30488 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            30489 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            30490 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            30491 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            30492 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            30493 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            30494 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            30495 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            30496 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            30497 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            30498 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            30499 => new CobbledDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
