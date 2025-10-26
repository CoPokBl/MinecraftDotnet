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
    public int ProtocolId => 529;
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
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12532,
                            false => 12533,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12534,
                            false => 12535,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12536,
                            false => 12537,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12538,
                            false => 12539,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12540,
                            false => 12541,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12542,
                            false => 12543,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12544,
                            false => 12545,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12546,
                            false => 12547,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12548,
                            false => 12549,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12550,
                            false => 12551,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12552,
                            false => 12553,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12554,
                            false => 12555,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12556,
                            false => 12557,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12558,
                            false => 12559,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12560,
                            false => 12561,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12562,
                            false => 12563,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12564,
                            false => 12565,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12566,
                            false => 12567,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12568,
                            false => 12569,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12570,
                            false => 12571,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12572,
                            false => 12573,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12574,
                            false => 12575,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12576,
                            false => 12577,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12578,
                            false => 12579,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12580,
                            false => 12581,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12582,
                            false => 12583,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12584,
                            false => 12585,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12586,
                            false => 12587,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12588,
                            false => 12589,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12590,
                            false => 12591,
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
            12512 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12513 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12514 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12515 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12516 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12517 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12518 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12519 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12520 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12521 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12522 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12523 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12524 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12525 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12526 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12527 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12528 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12529 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12530 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12531 => new PrismarineBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12532 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12533 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12534 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12535 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12536 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12537 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12538 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12539 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12540 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12541 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12542 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12543 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12544 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12545 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12546 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12547 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12548 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12549 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12550 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12551 => new PrismarineBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12552 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12553 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12554 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12555 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12556 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12557 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12558 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12559 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12560 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12561 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12562 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12563 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12564 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12565 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12566 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12567 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12568 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12569 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12570 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12571 => new PrismarineBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12572 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12573 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12574 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12575 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12576 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12577 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12578 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12579 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12580 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12581 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12582 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12583 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12584 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12585 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12586 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12587 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12588 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12589 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12590 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12591 => new PrismarineBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
