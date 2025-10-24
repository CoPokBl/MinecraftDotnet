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
    public int ProtocolId => 923;
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
                            true => 21630,
                            false => 21631,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21632,
                            false => 21633,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21634,
                            false => 21635,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21636,
                            false => 21637,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21638,
                            false => 21639,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21640,
                            false => 21641,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21642,
                            false => 21643,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21644,
                            false => 21645,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21646,
                            false => 21647,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21648,
                            false => 21649,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21650,
                            false => 21651,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21652,
                            false => 21653,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21654,
                            false => 21655,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21656,
                            false => 21657,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21658,
                            false => 21659,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21660,
                            false => 21661,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21662,
                            false => 21663,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21664,
                            false => 21665,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21666,
                            false => 21667,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21668,
                            false => 21669,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21670,
                            false => 21671,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21672,
                            false => 21673,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21674,
                            false => 21675,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21676,
                            false => 21677,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21678,
                            false => 21679,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21680,
                            false => 21681,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21682,
                            false => 21683,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21684,
                            false => 21685,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21686,
                            false => 21687,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21688,
                            false => 21689,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21690,
                            false => 21691,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21692,
                            false => 21693,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21694,
                            false => 21695,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21696,
                            false => 21697,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21698,
                            false => 21699,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21700,
                            false => 21701,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21702,
                            false => 21703,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21704,
                            false => 21705,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21706,
                            false => 21707,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21708,
                            false => 21709,
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
            21630 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21631 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21632 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21633 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21634 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21635 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21636 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21637 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21638 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21639 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21640 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21641 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21642 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21643 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21644 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21645 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21646 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21647 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21648 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21649 => new BlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21650 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21651 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21652 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21653 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21654 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21655 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21656 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21657 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21658 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21659 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21660 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21661 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21662 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21663 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21664 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21665 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21666 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21667 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21668 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21669 => new BlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21670 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21671 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21672 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21673 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21674 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21675 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21676 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21677 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21678 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21679 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21680 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21681 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21682 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21683 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21684 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21685 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21686 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21687 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21688 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21689 => new BlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21690 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21691 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21692 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21693 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21694 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21695 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21696 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21697 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21698 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21699 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21700 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21701 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21702 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21703 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21704 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21705 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21706 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21707 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21708 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21709 => new BlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
