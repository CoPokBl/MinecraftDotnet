using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffStairsBlock(Identifier Identifier, Direction Facing, TuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23459,
                            false => 23460,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23461,
                            false => 23462,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23463,
                            false => 23464,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23465,
                            false => 23466,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23467,
                            false => 23468,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23469,
                            false => 23470,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23471,
                            false => 23472,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23473,
                            false => 23474,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23475,
                            false => 23476,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23477,
                            false => 23478,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23479,
                            false => 23480,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23481,
                            false => 23482,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23483,
                            false => 23484,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23485,
                            false => 23486,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23487,
                            false => 23488,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23489,
                            false => 23490,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23491,
                            false => 23492,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23493,
                            false => 23494,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23495,
                            false => 23496,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23497,
                            false => 23498,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23499,
                            false => 23500,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23501,
                            false => 23502,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23503,
                            false => 23504,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23505,
                            false => 23506,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23507,
                            false => 23508,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23509,
                            false => 23510,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23511,
                            false => 23512,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23513,
                            false => 23514,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23515,
                            false => 23516,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23517,
                            false => 23518,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23519,
                            false => 23520,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23521,
                            false => 23522,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23523,
                            false => 23524,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23525,
                            false => 23526,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23527,
                            false => 23528,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 23529,
                            false => 23530,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 23531,
                            false => 23532,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 23533,
                            false => 23534,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 23535,
                            false => 23536,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 23537,
                            false => 23538,
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
            23459 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            23460 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            23461 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            23462 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            23463 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            23464 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            23465 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            23466 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            23467 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            23468 => new TuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            23469 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            23470 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            23471 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            23472 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            23473 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            23474 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            23475 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            23476 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            23477 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            23478 => new TuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            23479 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            23480 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            23481 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            23482 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            23483 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            23484 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            23485 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            23486 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            23487 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            23488 => new TuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            23489 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            23490 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            23491 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            23492 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            23493 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            23494 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            23495 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            23496 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            23497 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            23498 => new TuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            23499 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            23500 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            23501 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            23502 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            23503 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            23504 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            23505 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            23506 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            23507 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            23508 => new TuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            23509 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            23510 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            23511 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            23512 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            23513 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            23514 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            23515 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            23516 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            23517 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            23518 => new TuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            23519 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            23520 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            23521 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            23522 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            23523 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            23524 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            23525 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            23526 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            23527 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            23528 => new TuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            23529 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            23530 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            23531 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            23532 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            23533 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            23534 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            23535 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            23536 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            23537 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            23538 => new TuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
