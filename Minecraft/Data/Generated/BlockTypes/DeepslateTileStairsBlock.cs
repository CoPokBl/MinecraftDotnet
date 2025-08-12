using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateTileStairsBlock(Identifier Identifier, Direction Facing, DeepslateTileStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1070;
    public double Hardness => 3.5;
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
    public string SoundType => "deepslate_tiles";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:deepslate_tile_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.deepslate_tile_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26822,
                            false => 26823,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26824,
                            false => 26825,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26826,
                            false => 26827,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26828,
                            false => 26829,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26830,
                            false => 26831,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26832,
                            false => 26833,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26834,
                            false => 26835,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26836,
                            false => 26837,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26838,
                            false => 26839,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26840,
                            false => 26841,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26842,
                            false => 26843,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26844,
                            false => 26845,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26846,
                            false => 26847,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26848,
                            false => 26849,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26850,
                            false => 26851,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26852,
                            false => 26853,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26854,
                            false => 26855,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26856,
                            false => 26857,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26858,
                            false => 26859,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26860,
                            false => 26861,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26862,
                            false => 26863,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26864,
                            false => 26865,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26866,
                            false => 26867,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26868,
                            false => 26869,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26870,
                            false => 26871,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26872,
                            false => 26873,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26874,
                            false => 26875,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26876,
                            false => 26877,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26878,
                            false => 26879,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26880,
                            false => 26881,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26882,
                            false => 26883,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26884,
                            false => 26885,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26886,
                            false => 26887,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26888,
                            false => 26889,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26890,
                            false => 26891,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26892,
                            false => 26893,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26894,
                            false => 26895,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26896,
                            false => 26897,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26898,
                            false => 26899,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26900,
                            false => 26901,
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
            26822 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26823 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26824 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26825 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26826 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26827 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26828 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26829 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26830 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26831 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26832 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26833 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26834 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26835 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26836 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26837 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26838 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26839 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26840 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26841 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26842 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26843 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26844 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26845 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26846 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26847 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26848 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26849 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26850 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26851 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26852 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26853 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26854 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26855 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26856 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26857 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26858 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26859 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26860 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26861 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26862 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26863 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26864 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26865 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26866 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26867 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26868 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26869 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26870 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26871 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26872 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26873 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26874 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26875 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26876 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26877 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26878 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26879 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26880 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26881 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26882 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26883 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26884 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26885 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26886 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26887 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26888 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26889 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26890 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26891 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26892 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26893 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26894 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26895 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26896 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26897 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26898 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26899 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26900 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26901 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
