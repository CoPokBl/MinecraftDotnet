using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrickStairsBlock(Identifier Identifier, Direction Facing, BrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 369;
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
    public Identifier? Item => "minecraft:brick_stairs";
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
    public string TranslationKey => "block.minecraft.brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8477,
                            false => 8478,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8479,
                            false => 8480,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8481,
                            false => 8482,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8483,
                            false => 8484,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8485,
                            false => 8486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8487,
                            false => 8488,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8489,
                            false => 8490,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8491,
                            false => 8492,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8493,
                            false => 8494,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8495,
                            false => 8496,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8497,
                            false => 8498,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8499,
                            false => 8500,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8501,
                            false => 8502,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8503,
                            false => 8504,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8505,
                            false => 8506,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8507,
                            false => 8508,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8509,
                            false => 8510,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8511,
                            false => 8512,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8513,
                            false => 8514,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8515,
                            false => 8516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8517,
                            false => 8518,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8519,
                            false => 8520,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8521,
                            false => 8522,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8523,
                            false => 8524,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8525,
                            false => 8526,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8527,
                            false => 8528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8529,
                            false => 8530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8531,
                            false => 8532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8533,
                            false => 8534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8535,
                            false => 8536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8537,
                            false => 8538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8539,
                            false => 8540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8541,
                            false => 8542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8543,
                            false => 8544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8545,
                            false => 8546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8547,
                            false => 8548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8549,
                            false => 8550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8551,
                            false => 8552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8553,
                            false => 8554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8555,
                            false => 8556,
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
            8477 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8478 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8479 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8480 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8481 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8482 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8483 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8484 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8485 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8486 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8487 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8488 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8489 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8490 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8491 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8492 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8493 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8494 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8495 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8496 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8497 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8498 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8499 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8500 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8501 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8502 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8503 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8504 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8505 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8506 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8507 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8508 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8509 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8510 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8511 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8512 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8513 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8514 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8515 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8516 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8517 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8518 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8519 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8520 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8521 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8522 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8523 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8524 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8525 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8526 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8527 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8528 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8529 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8530 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8531 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8532 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8533 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8534 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8535 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8536 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8537 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8538 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8539 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8540 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8541 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8542 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8543 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8544 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8545 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8546 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8547 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8548 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8549 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8550 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8551 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8552 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8553 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8554 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8555 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8556 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
