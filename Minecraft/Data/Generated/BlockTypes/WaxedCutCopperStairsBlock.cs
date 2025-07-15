using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.waxed_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24608,
                            false => 24609,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24610,
                            false => 24611,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24612,
                            false => 24613,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24614,
                            false => 24615,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24616,
                            false => 24617,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24618,
                            false => 24619,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24620,
                            false => 24621,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24622,
                            false => 24623,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24624,
                            false => 24625,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24626,
                            false => 24627,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24628,
                            false => 24629,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24630,
                            false => 24631,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24632,
                            false => 24633,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24634,
                            false => 24635,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24636,
                            false => 24637,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24638,
                            false => 24639,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24640,
                            false => 24641,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24642,
                            false => 24643,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24644,
                            false => 24645,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24646,
                            false => 24647,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24648,
                            false => 24649,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24650,
                            false => 24651,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24652,
                            false => 24653,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24654,
                            false => 24655,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24656,
                            false => 24657,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24658,
                            false => 24659,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24660,
                            false => 24661,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24662,
                            false => 24663,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24664,
                            false => 24665,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24666,
                            false => 24667,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24668,
                            false => 24669,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24670,
                            false => 24671,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24672,
                            false => 24673,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24674,
                            false => 24675,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24676,
                            false => 24677,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24678,
                            false => 24679,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24680,
                            false => 24681,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24682,
                            false => 24683,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24684,
                            false => 24685,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24686,
                            false => 24687,
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
            24608 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24609 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24610 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24611 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24612 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24613 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24614 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24615 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24616 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24617 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24618 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24619 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24620 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24621 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24622 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24623 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24624 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24625 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24626 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24627 => new WaxedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24628 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24629 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24630 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24631 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24632 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24633 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24634 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24635 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24636 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24637 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24638 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24639 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24640 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24641 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24642 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24643 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24644 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24645 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24646 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24647 => new WaxedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24648 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24649 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24650 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24651 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24652 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24653 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24654 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24655 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24656 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24657 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24658 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24659 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24660 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24661 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24662 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24663 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24664 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24665 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24666 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24667 => new WaxedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24668 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24669 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24670 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24671 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24672 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24673 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24674 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24675 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24676 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24677 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24678 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24679 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24680 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24681 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24682 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24683 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24684 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24685 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24686 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24687 => new WaxedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
