using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakStairsBlock(Identifier Identifier, Direction Facing, PaleOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 487;
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
    public Identifier? Item => "minecraft:pale_oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10933,
                            false => 10934,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10935,
                            false => 10936,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10937,
                            false => 10938,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10939,
                            false => 10940,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10941,
                            false => 10942,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10943,
                            false => 10944,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10945,
                            false => 10946,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10947,
                            false => 10948,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10949,
                            false => 10950,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10951,
                            false => 10952,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10953,
                            false => 10954,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10955,
                            false => 10956,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10957,
                            false => 10958,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10959,
                            false => 10960,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10961,
                            false => 10962,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10963,
                            false => 10964,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10965,
                            false => 10966,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10967,
                            false => 10968,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10969,
                            false => 10970,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10971,
                            false => 10972,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10973,
                            false => 10974,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10975,
                            false => 10976,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10977,
                            false => 10978,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10979,
                            false => 10980,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10981,
                            false => 10982,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10983,
                            false => 10984,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10985,
                            false => 10986,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10987,
                            false => 10988,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10989,
                            false => 10990,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 10991,
                            false => 10992,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 10993,
                            false => 10994,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 10995,
                            false => 10996,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 10997,
                            false => 10998,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 10999,
                            false => 11000,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11001,
                            false => 11002,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 11003,
                            false => 11004,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 11005,
                            false => 11006,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 11007,
                            false => 11008,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 11009,
                            false => 11010,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 11011,
                            false => 11012,
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
            10933 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            10934 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            10935 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            10936 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            10937 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            10938 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            10939 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            10940 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            10941 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            10942 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            10943 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            10944 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            10945 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            10946 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            10947 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            10948 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            10949 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            10950 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            10951 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            10952 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            10953 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            10954 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            10955 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            10956 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            10957 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            10958 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            10959 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            10960 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            10961 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            10962 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            10963 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            10964 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            10965 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            10966 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            10967 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            10968 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            10969 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            10970 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            10971 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            10972 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            10973 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            10974 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            10975 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            10976 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            10977 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            10978 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            10979 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            10980 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            10981 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            10982 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            10983 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            10984 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            10985 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            10986 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            10987 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            10988 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            10989 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            10990 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            10991 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            10992 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            10993 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            10994 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            10995 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            10996 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            10997 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            10998 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            10999 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            11000 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            11001 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            11002 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            11003 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            11004 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            11005 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            11006 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            11007 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            11008 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            11009 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            11010 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            11011 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            11012 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
