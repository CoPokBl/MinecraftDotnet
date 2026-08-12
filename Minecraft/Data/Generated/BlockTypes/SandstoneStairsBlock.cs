using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SandstoneStairsBlock(Identifier Identifier, Direction Facing, SandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 0.8;
    public double ExplosionResistance => 0.8;
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
    public Identifier? Item => "minecraft:sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9493,
                            false => 9494,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9495,
                            false => 9496,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9497,
                            false => 9498,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9499,
                            false => 9500,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9501,
                            false => 9502,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9503,
                            false => 9504,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9505,
                            false => 9506,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9507,
                            false => 9508,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9509,
                            false => 9510,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9511,
                            false => 9512,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9513,
                            false => 9514,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9515,
                            false => 9516,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9517,
                            false => 9518,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9519,
                            false => 9520,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9521,
                            false => 9522,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9523,
                            false => 9524,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9525,
                            false => 9526,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9527,
                            false => 9528,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9529,
                            false => 9530,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9531,
                            false => 9532,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9533,
                            false => 9534,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9535,
                            false => 9536,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9537,
                            false => 9538,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9539,
                            false => 9540,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9541,
                            false => 9542,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9543,
                            false => 9544,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9545,
                            false => 9546,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9547,
                            false => 9548,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9549,
                            false => 9550,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9551,
                            false => 9552,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9553,
                            false => 9554,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9555,
                            false => 9556,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9557,
                            false => 9558,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9559,
                            false => 9560,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9561,
                            false => 9562,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9563,
                            false => 9564,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9565,
                            false => 9566,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9567,
                            false => 9568,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9569,
                            false => 9570,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9571,
                            false => 9572,
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
            9493 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9494 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9495 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9496 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9497 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9498 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9499 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9500 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9501 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9502 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9503 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9504 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9505 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9506 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9507 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9508 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9509 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9510 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9511 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9512 => new SandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9513 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9514 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9515 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9516 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9517 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9518 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9519 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9520 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9521 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9522 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9523 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9524 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9525 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9526 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9527 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9528 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9529 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9530 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9531 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9532 => new SandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9533 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9534 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9535 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9536 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9537 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9538 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9539 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9540 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9541 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9542 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9543 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9544 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9545 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9546 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9547 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9548 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9549 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9550 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9551 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9552 => new SandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9553 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9554 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9555 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9556 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9557 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9558 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9559 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9560 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9561 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9562 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9563 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9564 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9565 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9566 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9567 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9568 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9569 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9570 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9571 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9572 => new SandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
