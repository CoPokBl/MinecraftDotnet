using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PrismarineStairsBlock(Identifier Identifier, Direction Facing, PrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:prismarine_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.prismarine_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12634,
                            false => 12635,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12636,
                            false => 12637,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12638,
                            false => 12639,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12640,
                            false => 12641,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12642,
                            false => 12643,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12644,
                            false => 12645,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12646,
                            false => 12647,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12648,
                            false => 12649,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12650,
                            false => 12651,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12652,
                            false => 12653,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12654,
                            false => 12655,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12656,
                            false => 12657,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12658,
                            false => 12659,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12660,
                            false => 12661,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12662,
                            false => 12663,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12664,
                            false => 12665,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12666,
                            false => 12667,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12668,
                            false => 12669,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12670,
                            false => 12671,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12672,
                            false => 12673,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12674,
                            false => 12675,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12676,
                            false => 12677,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12678,
                            false => 12679,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12680,
                            false => 12681,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12682,
                            false => 12683,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12684,
                            false => 12685,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12686,
                            false => 12687,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12688,
                            false => 12689,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12690,
                            false => 12691,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12692,
                            false => 12693,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12694,
                            false => 12695,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12696,
                            false => 12697,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12698,
                            false => 12699,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12700,
                            false => 12701,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12702,
                            false => 12703,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12704,
                            false => 12705,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12706,
                            false => 12707,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12708,
                            false => 12709,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12710,
                            false => 12711,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12712,
                            false => 12713,
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
            12634 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12635 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12636 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12637 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12638 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12639 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12640 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12641 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12642 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12643 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12644 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12645 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12646 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12647 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12648 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12649 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12650 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12651 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12652 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12653 => new PrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12654 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12655 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12656 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12657 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12658 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12659 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12660 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12661 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12662 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12663 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12664 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12665 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12666 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12667 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12668 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12669 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12670 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12671 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12672 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12673 => new PrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12674 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12675 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12676 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12677 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12678 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12679 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12680 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12681 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12682 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12683 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12684 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12685 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12686 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12687 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12688 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12689 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12690 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12691 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12692 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12693 => new PrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12694 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12695 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12696 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12697 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12698 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12699 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12700 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12701 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12702 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12703 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12704 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12705 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12706 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12707 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12708 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12709 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12710 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12711 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12712 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12713 => new PrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
