using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyStoneBrickStairsBlock(Identifier Identifier, Direction Facing, MossyStoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:mossy_stone_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.mossy_stone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15456,
                            false => 15457,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15458,
                            false => 15459,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15460,
                            false => 15461,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15462,
                            false => 15463,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15464,
                            false => 15465,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15466,
                            false => 15467,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15468,
                            false => 15469,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15470,
                            false => 15471,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15472,
                            false => 15473,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15474,
                            false => 15475,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15476,
                            false => 15477,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15478,
                            false => 15479,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15480,
                            false => 15481,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15482,
                            false => 15483,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15484,
                            false => 15485,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15486,
                            false => 15487,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15488,
                            false => 15489,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15490,
                            false => 15491,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15492,
                            false => 15493,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15494,
                            false => 15495,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15496,
                            false => 15497,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15498,
                            false => 15499,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15500,
                            false => 15501,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15502,
                            false => 15503,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15504,
                            false => 15505,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15506,
                            false => 15507,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15508,
                            false => 15509,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15510,
                            false => 15511,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15512,
                            false => 15513,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15514,
                            false => 15515,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15516,
                            false => 15517,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15518,
                            false => 15519,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15520,
                            false => 15521,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15522,
                            false => 15523,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15524,
                            false => 15525,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15526,
                            false => 15527,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15528,
                            false => 15529,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15530,
                            false => 15531,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15532,
                            false => 15533,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15534,
                            false => 15535,
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
            15456 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15457 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15458 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15459 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15460 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15461 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15462 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15463 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15464 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15465 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15466 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15467 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15468 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15469 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15470 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15471 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15472 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15473 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15474 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15475 => new MossyStoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15476 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15477 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15478 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15479 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15480 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15481 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15482 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15483 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15484 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15485 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15486 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15487 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15488 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15489 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15490 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15491 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15492 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15493 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15494 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15495 => new MossyStoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15496 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15497 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15498 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15499 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15500 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15501 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15502 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15503 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15504 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15505 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15506 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15507 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15508 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15509 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15510 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15511 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15512 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15513 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15514 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15515 => new MossyStoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15516 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15517 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15518 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15519 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15520 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15521 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15522 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15523 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15524 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15525 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15526 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15527 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15528 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15529 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15530 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15531 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15532 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15533 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15534 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15535 => new MossyStoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
