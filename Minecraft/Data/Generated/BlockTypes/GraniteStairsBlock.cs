using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GraniteStairsBlock(Identifier Identifier, Direction Facing, GraniteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 804;
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
    public Identifier? Item => "minecraft:granite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.granite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15814,
                            false => 15815,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15816,
                            false => 15817,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15818,
                            false => 15819,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15820,
                            false => 15821,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15822,
                            false => 15823,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15824,
                            false => 15825,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15826,
                            false => 15827,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15828,
                            false => 15829,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15830,
                            false => 15831,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15832,
                            false => 15833,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15834,
                            false => 15835,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15836,
                            false => 15837,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15838,
                            false => 15839,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15840,
                            false => 15841,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15842,
                            false => 15843,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15844,
                            false => 15845,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15846,
                            false => 15847,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15848,
                            false => 15849,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15850,
                            false => 15851,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15852,
                            false => 15853,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15854,
                            false => 15855,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15856,
                            false => 15857,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15858,
                            false => 15859,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15860,
                            false => 15861,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15862,
                            false => 15863,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15864,
                            false => 15865,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15866,
                            false => 15867,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15868,
                            false => 15869,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15870,
                            false => 15871,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15872,
                            false => 15873,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15874,
                            false => 15875,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15876,
                            false => 15877,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15878,
                            false => 15879,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15880,
                            false => 15881,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15882,
                            false => 15883,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15884,
                            false => 15885,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15886,
                            false => 15887,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15888,
                            false => 15889,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15890,
                            false => 15891,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15892,
                            false => 15893,
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
            15814 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15815 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15816 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15817 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15818 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15819 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15820 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15821 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15822 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15823 => new GraniteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15824 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15825 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15826 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15827 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15828 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15829 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15830 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15831 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15832 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15833 => new GraniteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15834 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15835 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15836 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15837 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15838 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15839 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15840 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15841 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15842 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15843 => new GraniteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15844 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15845 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15846 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15847 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15848 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15849 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15850 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15851 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15852 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15853 => new GraniteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15854 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15855 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15856 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15857 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15858 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15859 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15860 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15861 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15862 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15863 => new GraniteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15864 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15865 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15866 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15867 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15868 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15869 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15870 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15871 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15872 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15873 => new GraniteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15874 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15875 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15876 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15877 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15878 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15879 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15880 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15881 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15882 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15883 => new GraniteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15884 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15885 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15886 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15887 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15888 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15889 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15890 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15891 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15892 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15893 => new GraniteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
