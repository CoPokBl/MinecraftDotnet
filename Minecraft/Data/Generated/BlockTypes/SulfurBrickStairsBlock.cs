using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SulfurBrickStairsBlock(Identifier Identifier, Direction Facing, SulfurBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "sulfur";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sulfur_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.sulfur_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25521,
                            false => 25522,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25523,
                            false => 25524,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25525,
                            false => 25526,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25527,
                            false => 25528,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25529,
                            false => 25530,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25531,
                            false => 25532,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25533,
                            false => 25534,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25535,
                            false => 25536,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25537,
                            false => 25538,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25539,
                            false => 25540,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25541,
                            false => 25542,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25543,
                            false => 25544,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25545,
                            false => 25546,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25547,
                            false => 25548,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25549,
                            false => 25550,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25551,
                            false => 25552,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25553,
                            false => 25554,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25555,
                            false => 25556,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25557,
                            false => 25558,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25559,
                            false => 25560,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25561,
                            false => 25562,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25563,
                            false => 25564,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25565,
                            false => 25566,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25567,
                            false => 25568,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25569,
                            false => 25570,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25571,
                            false => 25572,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25573,
                            false => 25574,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25575,
                            false => 25576,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25577,
                            false => 25578,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25579,
                            false => 25580,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25581,
                            false => 25582,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25583,
                            false => 25584,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25585,
                            false => 25586,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25587,
                            false => 25588,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25589,
                            false => 25590,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25591,
                            false => 25592,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25593,
                            false => 25594,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25595,
                            false => 25596,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25597,
                            false => 25598,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25599,
                            false => 25600,
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
            25521 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25522 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25523 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25524 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25525 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25526 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25527 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25528 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25529 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25530 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25531 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25532 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25533 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25534 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25535 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25536 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25537 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25538 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25539 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25540 => new SulfurBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25541 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25542 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25543 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25544 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25545 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25546 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25547 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25548 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25549 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25550 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25551 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25552 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25553 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25554 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25555 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25556 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25557 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25558 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25559 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25560 => new SulfurBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25561 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25562 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25563 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25564 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25565 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25566 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25567 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25568 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25569 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25570 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25571 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25572 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25573 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25574 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25575 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25576 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25577 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25578 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25579 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25580 => new SulfurBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25581 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25582 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25583 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25584 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25585 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25586 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25587 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25588 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25589 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25590 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25591 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25592 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25593 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25594 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25595 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25596 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25597 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25598 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25599 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25600 => new SulfurBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
