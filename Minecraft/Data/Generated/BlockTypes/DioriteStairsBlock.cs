using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DioriteStairsBlock(Identifier Identifier, Direction Facing, DioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 778;
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
    public Identifier? Item => "minecraft:diorite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15057,
                            false => 15058,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15059,
                            false => 15060,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15061,
                            false => 15062,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15063,
                            false => 15064,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15065,
                            false => 15066,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15067,
                            false => 15068,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15069,
                            false => 15070,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15071,
                            false => 15072,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15073,
                            false => 15074,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15075,
                            false => 15076,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15077,
                            false => 15078,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15079,
                            false => 15080,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15081,
                            false => 15082,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15083,
                            false => 15084,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15085,
                            false => 15086,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15087,
                            false => 15088,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15089,
                            false => 15090,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15091,
                            false => 15092,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15093,
                            false => 15094,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15095,
                            false => 15096,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15097,
                            false => 15098,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15099,
                            false => 15100,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15101,
                            false => 15102,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15103,
                            false => 15104,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15105,
                            false => 15106,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15107,
                            false => 15108,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15109,
                            false => 15110,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15111,
                            false => 15112,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15113,
                            false => 15114,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15115,
                            false => 15116,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15117,
                            false => 15118,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15119,
                            false => 15120,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15121,
                            false => 15122,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15123,
                            false => 15124,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15125,
                            false => 15126,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15127,
                            false => 15128,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15129,
                            false => 15130,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15131,
                            false => 15132,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15133,
                            false => 15134,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15135,
                            false => 15136,
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
            15057 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15058 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15059 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15060 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15061 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15062 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15063 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15064 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15065 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15066 => new DioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15067 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15068 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15069 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15070 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15071 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15072 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15073 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15074 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15075 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15076 => new DioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15077 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15078 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15079 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15080 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15081 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15082 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15083 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15084 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15085 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15086 => new DioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15087 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15088 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15089 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15090 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15091 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15092 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15093 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15094 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15095 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15096 => new DioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15097 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15098 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15099 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15100 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15101 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15102 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15103 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15104 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15105 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15106 => new DioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15107 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15108 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15109 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15110 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15111 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15112 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15113 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15114 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15115 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15116 => new DioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15117 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15118 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15119 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15120 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15121 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15122 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15123 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15124 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15125 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15126 => new DioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15127 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15128 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15129 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15130 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15131 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15132 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15133 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15134 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15135 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15136 => new DioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
