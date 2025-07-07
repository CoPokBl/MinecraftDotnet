using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceStairsBlock(Identifier Identifier, Direction Facing, SpruceStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:spruce_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8450,
                            false => 8451,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8452,
                            false => 8453,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8454,
                            false => 8455,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8456,
                            false => 8457,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8458,
                            false => 8459,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8460,
                            false => 8461,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8462,
                            false => 8463,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8464,
                            false => 8465,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8466,
                            false => 8467,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8468,
                            false => 8469,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8470,
                            false => 8471,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8472,
                            false => 8473,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8474,
                            false => 8475,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8476,
                            false => 8477,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8478,
                            false => 8479,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8480,
                            false => 8481,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8482,
                            false => 8483,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8484,
                            false => 8485,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8486,
                            false => 8487,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8488,
                            false => 8489,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8490,
                            false => 8491,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8492,
                            false => 8493,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8494,
                            false => 8495,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8496,
                            false => 8497,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8498,
                            false => 8499,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8500,
                            false => 8501,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8502,
                            false => 8503,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8504,
                            false => 8505,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8506,
                            false => 8507,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8508,
                            false => 8509,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8510,
                            false => 8511,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8512,
                            false => 8513,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8514,
                            false => 8515,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8516,
                            false => 8517,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8518,
                            false => 8519,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8520,
                            false => 8521,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8522,
                            false => 8523,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8524,
                            false => 8525,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8526,
                            false => 8527,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8528,
                            false => 8529,
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
            8450 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8451 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8452 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8453 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8454 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8455 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8456 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8457 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8458 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8459 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8460 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8461 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8462 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8463 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8464 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8465 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8466 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8467 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8468 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8469 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8470 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8471 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8472 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8473 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8474 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8475 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8476 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8477 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8478 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8479 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8480 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8481 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8482 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8483 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8484 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8485 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8486 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8487 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8488 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8489 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8490 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8491 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8492 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8493 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8494 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8495 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8496 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8497 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8498 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8499 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8500 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8501 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8502 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8503 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8504 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8505 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8506 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8507 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8508 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8509 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8510 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8511 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8512 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8513 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8514 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8515 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8516 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8517 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8518 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8519 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8520 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8521 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8522 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8523 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8524 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8525 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8526 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8527 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8528 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8529 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
}
