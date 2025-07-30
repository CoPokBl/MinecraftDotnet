using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryStairsBlock(Identifier Identifier, Direction Facing, CherryStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 485;
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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10773,
                            false => 10774,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10775,
                            false => 10776,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10777,
                            false => 10778,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10779,
                            false => 10780,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10781,
                            false => 10782,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10783,
                            false => 10784,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10785,
                            false => 10786,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10787,
                            false => 10788,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10789,
                            false => 10790,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10791,
                            false => 10792,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10793,
                            false => 10794,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10795,
                            false => 10796,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10797,
                            false => 10798,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10799,
                            false => 10800,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10801,
                            false => 10802,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10803,
                            false => 10804,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10805,
                            false => 10806,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10807,
                            false => 10808,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10809,
                            false => 10810,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10811,
                            false => 10812,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10813,
                            false => 10814,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10815,
                            false => 10816,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10817,
                            false => 10818,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10819,
                            false => 10820,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10821,
                            false => 10822,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10823,
                            false => 10824,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10825,
                            false => 10826,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10827,
                            false => 10828,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10829,
                            false => 10830,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10831,
                            false => 10832,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10833,
                            false => 10834,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10835,
                            false => 10836,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10837,
                            false => 10838,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10839,
                            false => 10840,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10841,
                            false => 10842,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10843,
                            false => 10844,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10845,
                            false => 10846,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10847,
                            false => 10848,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10849,
                            false => 10850,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10851,
                            false => 10852,
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
            10773 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            10774 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            10775 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            10776 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            10777 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            10778 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            10779 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            10780 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            10781 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            10782 => new CherryStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            10783 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            10784 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            10785 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            10786 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            10787 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            10788 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            10789 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            10790 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            10791 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            10792 => new CherryStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            10793 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            10794 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            10795 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            10796 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            10797 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            10798 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            10799 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            10800 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            10801 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            10802 => new CherryStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            10803 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            10804 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            10805 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            10806 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            10807 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            10808 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            10809 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            10810 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            10811 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            10812 => new CherryStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            10813 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            10814 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            10815 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            10816 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            10817 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            10818 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            10819 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            10820 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            10821 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            10822 => new CherryStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            10823 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            10824 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            10825 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            10826 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            10827 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            10828 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            10829 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            10830 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            10831 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            10832 => new CherryStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            10833 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            10834 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            10835 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            10836 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            10837 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            10838 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            10839 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            10840 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            10841 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            10842 => new CherryStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            10843 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            10844 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            10845 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            10846 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            10847 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            10848 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            10849 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            10850 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            10851 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            10852 => new CherryStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
