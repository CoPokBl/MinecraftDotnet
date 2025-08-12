using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleStairsBlock(Identifier Identifier, Direction Facing, JungleStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 375;
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
    public Identifier? Item => "minecraft:jungle_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8610,
                            false => 8611,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8612,
                            false => 8613,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8614,
                            false => 8615,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8616,
                            false => 8617,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8618,
                            false => 8619,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8620,
                            false => 8621,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8622,
                            false => 8623,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8624,
                            false => 8625,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8626,
                            false => 8627,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8628,
                            false => 8629,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8630,
                            false => 8631,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8632,
                            false => 8633,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8634,
                            false => 8635,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8636,
                            false => 8637,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8638,
                            false => 8639,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8640,
                            false => 8641,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8642,
                            false => 8643,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8644,
                            false => 8645,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8646,
                            false => 8647,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8648,
                            false => 8649,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8650,
                            false => 8651,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8652,
                            false => 8653,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8654,
                            false => 8655,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8656,
                            false => 8657,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8658,
                            false => 8659,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8660,
                            false => 8661,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8662,
                            false => 8663,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8664,
                            false => 8665,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8666,
                            false => 8667,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8668,
                            false => 8669,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8670,
                            false => 8671,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8672,
                            false => 8673,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8674,
                            false => 8675,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8676,
                            false => 8677,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8678,
                            false => 8679,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8680,
                            false => 8681,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8682,
                            false => 8683,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8684,
                            false => 8685,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8686,
                            false => 8687,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8688,
                            false => 8689,
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
            8610 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8611 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8612 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8613 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8614 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8615 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8616 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8617 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8618 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8619 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8620 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8621 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8622 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8623 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8624 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8625 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8626 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8627 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8628 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8629 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8630 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8631 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8632 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8633 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8634 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8635 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8636 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8637 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8638 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8639 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8640 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8641 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8642 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8643 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8644 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8645 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8646 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8647 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8648 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8649 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8650 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8651 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8652 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8653 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8654 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8655 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8656 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8657 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8658 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8659 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8660 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8661 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8662 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8663 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8664 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8665 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8666 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8667 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8668 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8669 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8670 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8671 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8672 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8673 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8674 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8675 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8676 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8677 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8678 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8679 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8680 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8681 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8682 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8683 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8684 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8685 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8686 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8687 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8688 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8689 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
