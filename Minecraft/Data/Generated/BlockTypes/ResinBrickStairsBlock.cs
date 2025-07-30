using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickStairsBlock(Identifier Identifier, Direction Facing, ResinBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 346;
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
    public string SoundType => "resin_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:resin_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 37;
    public string TranslationKey => "block.minecraft.resin_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7645,
                            false => 7646,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7647,
                            false => 7648,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7649,
                            false => 7650,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7651,
                            false => 7652,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7653,
                            false => 7654,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7655,
                            false => 7656,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7657,
                            false => 7658,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7659,
                            false => 7660,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7661,
                            false => 7662,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7663,
                            false => 7664,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7665,
                            false => 7666,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7667,
                            false => 7668,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7669,
                            false => 7670,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7671,
                            false => 7672,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7673,
                            false => 7674,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7675,
                            false => 7676,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7677,
                            false => 7678,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7679,
                            false => 7680,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7681,
                            false => 7682,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7683,
                            false => 7684,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7685,
                            false => 7686,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7687,
                            false => 7688,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7689,
                            false => 7690,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7691,
                            false => 7692,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7693,
                            false => 7694,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7695,
                            false => 7696,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7697,
                            false => 7698,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7699,
                            false => 7700,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7701,
                            false => 7702,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7703,
                            false => 7704,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7705,
                            false => 7706,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7707,
                            false => 7708,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7709,
                            false => 7710,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7711,
                            false => 7712,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7713,
                            false => 7714,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7715,
                            false => 7716,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7717,
                            false => 7718,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7719,
                            false => 7720,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7721,
                            false => 7722,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7723,
                            false => 7724,
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
            7645 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            7646 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            7647 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            7648 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            7649 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            7650 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            7651 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            7652 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            7653 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            7654 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            7655 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            7656 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            7657 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            7658 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            7659 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            7660 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            7661 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            7662 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            7663 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            7664 => new ResinBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            7665 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            7666 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            7667 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            7668 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            7669 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            7670 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            7671 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            7672 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            7673 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            7674 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            7675 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            7676 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            7677 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            7678 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            7679 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            7680 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            7681 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            7682 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            7683 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            7684 => new ResinBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            7685 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            7686 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            7687 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            7688 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            7689 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            7690 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            7691 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            7692 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            7693 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            7694 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            7695 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            7696 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            7697 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            7698 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            7699 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            7700 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            7701 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            7702 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            7703 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            7704 => new ResinBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            7705 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            7706 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            7707 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            7708 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            7709 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            7710 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            7711 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            7712 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            7713 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            7714 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            7715 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            7716 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            7717 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            7718 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            7719 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            7720 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            7721 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            7722 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            7723 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            7724 => new ResinBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
