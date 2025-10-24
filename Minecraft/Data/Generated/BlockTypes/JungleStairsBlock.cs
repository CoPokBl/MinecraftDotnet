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
    public int ProtocolId => 405;
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
                            true => 9687,
                            false => 9688,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9689,
                            false => 9690,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9691,
                            false => 9692,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9693,
                            false => 9694,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9695,
                            false => 9696,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9697,
                            false => 9698,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9699,
                            false => 9700,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9701,
                            false => 9702,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9703,
                            false => 9704,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9705,
                            false => 9706,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9707,
                            false => 9708,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9709,
                            false => 9710,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9711,
                            false => 9712,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9713,
                            false => 9714,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9715,
                            false => 9716,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9717,
                            false => 9718,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9719,
                            false => 9720,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9721,
                            false => 9722,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9723,
                            false => 9724,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9725,
                            false => 9726,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9727,
                            false => 9728,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9729,
                            false => 9730,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9731,
                            false => 9732,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9733,
                            false => 9734,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9735,
                            false => 9736,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9737,
                            false => 9738,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9739,
                            false => 9740,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9741,
                            false => 9742,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9743,
                            false => 9744,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9745,
                            false => 9746,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9747,
                            false => 9748,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9749,
                            false => 9750,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9751,
                            false => 9752,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9753,
                            false => 9754,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9755,
                            false => 9756,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9757,
                            false => 9758,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9759,
                            false => 9760,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9761,
                            false => 9762,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9763,
                            false => 9764,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9765,
                            false => 9766,
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
            9687 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9688 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9689 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9690 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9691 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9692 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9693 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9694 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9695 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9696 => new JungleStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9697 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9698 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9699 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9700 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9701 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9702 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9703 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9704 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9705 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9706 => new JungleStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9707 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9708 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9709 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9710 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9711 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9712 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9713 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9714 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9715 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9716 => new JungleStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9717 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9718 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9719 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9720 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9721 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9722 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9723 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9724 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9725 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9726 => new JungleStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9727 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9728 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9729 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9730 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9731 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9732 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9733 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9734 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9735 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9736 => new JungleStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9737 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9738 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9739 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9740 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9741 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9742 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9743 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9744 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9745 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9746 => new JungleStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9747 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9748 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9749 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9750 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9751 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9752 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9753 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9754 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9755 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9756 => new JungleStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9757 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9758 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9759 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9760 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9761 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9762 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9763 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9764 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9765 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9766 => new JungleStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
