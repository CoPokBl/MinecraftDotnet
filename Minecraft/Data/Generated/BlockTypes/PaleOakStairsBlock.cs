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
    public int ProtocolId => 517;
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
                            true => 12010,
                            false => 12011,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12012,
                            false => 12013,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12014,
                            false => 12015,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12016,
                            false => 12017,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12018,
                            false => 12019,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12020,
                            false => 12021,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12022,
                            false => 12023,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12024,
                            false => 12025,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12026,
                            false => 12027,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12028,
                            false => 12029,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12030,
                            false => 12031,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12032,
                            false => 12033,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12034,
                            false => 12035,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12036,
                            false => 12037,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12038,
                            false => 12039,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12040,
                            false => 12041,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12042,
                            false => 12043,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12044,
                            false => 12045,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12046,
                            false => 12047,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12048,
                            false => 12049,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12050,
                            false => 12051,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12052,
                            false => 12053,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12054,
                            false => 12055,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12056,
                            false => 12057,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12058,
                            false => 12059,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12060,
                            false => 12061,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12062,
                            false => 12063,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12064,
                            false => 12065,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12066,
                            false => 12067,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12068,
                            false => 12069,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12070,
                            false => 12071,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12072,
                            false => 12073,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12074,
                            false => 12075,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12076,
                            false => 12077,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12078,
                            false => 12079,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12080,
                            false => 12081,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12082,
                            false => 12083,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12084,
                            false => 12085,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12086,
                            false => 12087,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12088,
                            false => 12089,
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
            12010 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12011 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12012 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12013 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12014 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12015 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12016 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12017 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12018 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12019 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12020 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12021 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12022 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12023 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12024 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12025 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12026 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12027 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12028 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12029 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12030 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12031 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12032 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12033 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12034 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12035 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12036 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12037 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12038 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12039 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12040 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12041 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12042 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12043 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12044 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12045 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12046 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12047 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12048 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12049 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12050 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12051 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12052 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12053 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12054 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12055 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12056 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12057 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12058 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12059 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12060 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12061 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12062 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12063 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12064 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12065 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12066 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12067 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12068 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12069 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12070 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12071 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12072 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12073 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12074 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12075 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12076 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12077 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12078 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12079 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12080 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12081 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12082 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12083 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12084 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12085 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12086 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12087 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12088 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12089 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
