using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MudBrickStairsBlock(Identifier Identifier, Direction Facing, MudBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 371;
    public double Hardness => 1.5;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "mud_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mud_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.mud_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8637,
                            false => 8638,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8639,
                            false => 8640,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8641,
                            false => 8642,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8643,
                            false => 8644,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8645,
                            false => 8646,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8647,
                            false => 8648,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8649,
                            false => 8650,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8651,
                            false => 8652,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8653,
                            false => 8654,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8655,
                            false => 8656,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8657,
                            false => 8658,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8659,
                            false => 8660,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8661,
                            false => 8662,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8663,
                            false => 8664,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8665,
                            false => 8666,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8667,
                            false => 8668,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8669,
                            false => 8670,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8671,
                            false => 8672,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8673,
                            false => 8674,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8675,
                            false => 8676,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8677,
                            false => 8678,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8679,
                            false => 8680,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8681,
                            false => 8682,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8683,
                            false => 8684,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8685,
                            false => 8686,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8687,
                            false => 8688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8689,
                            false => 8690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8691,
                            false => 8692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8693,
                            false => 8694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8695,
                            false => 8696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8697,
                            false => 8698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8699,
                            false => 8700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8701,
                            false => 8702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8703,
                            false => 8704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8705,
                            false => 8706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8707,
                            false => 8708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8709,
                            false => 8710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8711,
                            false => 8712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8713,
                            false => 8714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8715,
                            false => 8716,
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
            8637 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8638 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8639 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8640 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8641 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8642 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8643 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8644 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8645 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8646 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8647 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8648 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8649 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8650 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8651 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8652 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8653 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8654 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8655 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8656 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8657 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8658 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8659 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8660 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8661 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8662 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8663 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8664 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8665 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8666 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8667 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8668 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8669 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8670 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8671 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8672 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8673 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8674 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8675 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8676 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8677 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8678 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8679 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8680 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8681 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8682 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8683 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8684 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8685 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8686 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8687 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8688 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8689 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8690 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8691 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8692 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8693 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8694 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8695 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8696 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8697 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8698 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8699 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8700 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8701 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8702 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8703 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8704 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8705 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8706 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8707 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8708 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8709 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8710 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8711 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8712 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8713 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8714 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8715 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8716 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
