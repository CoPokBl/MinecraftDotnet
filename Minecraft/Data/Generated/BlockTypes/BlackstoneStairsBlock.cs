using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackstoneStairsBlock(Identifier Identifier, Direction Facing, BlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 885;
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
    public Identifier? Item => "minecraft:blackstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.blackstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20521,
                            false => 20522,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20523,
                            false => 20524,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20525,
                            false => 20526,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20527,
                            false => 20528,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20529,
                            false => 20530,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20531,
                            false => 20532,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20533,
                            false => 20534,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20535,
                            false => 20536,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20537,
                            false => 20538,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20539,
                            false => 20540,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20541,
                            false => 20542,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20543,
                            false => 20544,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20545,
                            false => 20546,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20547,
                            false => 20548,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20549,
                            false => 20550,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20551,
                            false => 20552,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20553,
                            false => 20554,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20555,
                            false => 20556,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20557,
                            false => 20558,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20559,
                            false => 20560,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20561,
                            false => 20562,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20563,
                            false => 20564,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20565,
                            false => 20566,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20567,
                            false => 20568,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20569,
                            false => 20570,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20571,
                            false => 20572,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20573,
                            false => 20574,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20575,
                            false => 20576,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20577,
                            false => 20578,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20579,
                            false => 20580,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20581,
                            false => 20582,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20583,
                            false => 20584,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20585,
                            false => 20586,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20587,
                            false => 20588,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20589,
                            false => 20590,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 20591,
                            false => 20592,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 20593,
                            false => 20594,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 20595,
                            false => 20596,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 20597,
                            false => 20598,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 20599,
                            false => 20600,
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
            20521 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            20522 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            20523 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            20524 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            20525 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            20526 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            20527 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            20528 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            20529 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            20530 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            20531 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            20532 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            20533 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            20534 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            20535 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            20536 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            20537 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            20538 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            20539 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            20540 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            20541 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            20542 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            20543 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            20544 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            20545 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            20546 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            20547 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            20548 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            20549 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            20550 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            20551 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            20552 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            20553 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            20554 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            20555 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            20556 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            20557 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            20558 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            20559 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            20560 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            20561 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            20562 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            20563 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            20564 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            20565 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            20566 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            20567 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            20568 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            20569 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            20570 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            20571 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            20572 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            20573 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            20574 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            20575 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            20576 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            20577 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            20578 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            20579 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            20580 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            20581 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            20582 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            20583 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            20584 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            20585 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            20586 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            20587 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            20588 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            20589 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            20590 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            20591 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            20592 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            20593 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            20594 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            20595 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            20596 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            20597 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            20598 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            20599 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            20600 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
