using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchStairsBlock(Identifier Identifier, Direction Facing, BirchStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 404;
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
    public Identifier? Item => "minecraft:birch_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9607,
                            false => 9608,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9609,
                            false => 9610,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9611,
                            false => 9612,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9613,
                            false => 9614,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9615,
                            false => 9616,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9617,
                            false => 9618,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9619,
                            false => 9620,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9621,
                            false => 9622,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9623,
                            false => 9624,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9625,
                            false => 9626,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9627,
                            false => 9628,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9629,
                            false => 9630,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9631,
                            false => 9632,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9633,
                            false => 9634,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9635,
                            false => 9636,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9637,
                            false => 9638,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9639,
                            false => 9640,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9641,
                            false => 9642,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9643,
                            false => 9644,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9645,
                            false => 9646,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9647,
                            false => 9648,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9649,
                            false => 9650,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9651,
                            false => 9652,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9653,
                            false => 9654,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9655,
                            false => 9656,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9657,
                            false => 9658,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9659,
                            false => 9660,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9661,
                            false => 9662,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9663,
                            false => 9664,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9665,
                            false => 9666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9667,
                            false => 9668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9669,
                            false => 9670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9671,
                            false => 9672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9673,
                            false => 9674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9675,
                            false => 9676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9677,
                            false => 9678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9679,
                            false => 9680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9681,
                            false => 9682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9683,
                            false => 9684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9685,
                            false => 9686,
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
            9607 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9608 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9609 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9610 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9611 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9612 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9613 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9614 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9615 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9616 => new BirchStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9617 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9618 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9619 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9620 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9621 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9622 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9623 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9624 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9625 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9626 => new BirchStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9627 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9628 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9629 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9630 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9631 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9632 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9633 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9634 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9635 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9636 => new BirchStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9637 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9638 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9639 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9640 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9641 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9642 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9643 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9644 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9645 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9646 => new BirchStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9647 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9648 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9649 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9650 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9651 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9652 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9653 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9654 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9655 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9656 => new BirchStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9657 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9658 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9659 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9660 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9661 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9662 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9663 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9664 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9665 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9666 => new BirchStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9667 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9668 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9669 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9670 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9671 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9672 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9673 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9674 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9675 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9676 => new BirchStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9677 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9678 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9679 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9680 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9681 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9682 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9683 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9684 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9685 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9686 => new BirchStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
