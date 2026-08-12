using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakStairsBlock(Identifier Identifier, Direction Facing, DarkOakStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:dark_oak_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12132,
                            false => 12133,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12134,
                            false => 12135,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12136,
                            false => 12137,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12138,
                            false => 12139,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12140,
                            false => 12141,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12142,
                            false => 12143,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12144,
                            false => 12145,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12146,
                            false => 12147,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12148,
                            false => 12149,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12150,
                            false => 12151,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12152,
                            false => 12153,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12154,
                            false => 12155,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12156,
                            false => 12157,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12158,
                            false => 12159,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12160,
                            false => 12161,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12162,
                            false => 12163,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12164,
                            false => 12165,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12166,
                            false => 12167,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12168,
                            false => 12169,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12170,
                            false => 12171,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12172,
                            false => 12173,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12174,
                            false => 12175,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12176,
                            false => 12177,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12178,
                            false => 12179,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12180,
                            false => 12181,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12182,
                            false => 12183,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12184,
                            false => 12185,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12186,
                            false => 12187,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12188,
                            false => 12189,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12190,
                            false => 12191,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12192,
                            false => 12193,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12194,
                            false => 12195,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12196,
                            false => 12197,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12198,
                            false => 12199,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12200,
                            false => 12201,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12202,
                            false => 12203,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12204,
                            false => 12205,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12206,
                            false => 12207,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12208,
                            false => 12209,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12210,
                            false => 12211,
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
            12132 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12133 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12134 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12135 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12136 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12137 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12138 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12139 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12140 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12141 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12142 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12143 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12144 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12145 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12146 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12147 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12148 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12149 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12150 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12151 => new DarkOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12152 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12153 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12154 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12155 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12156 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12157 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12158 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12159 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12160 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12161 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12162 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12163 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12164 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12165 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12166 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12167 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12168 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12169 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12170 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12171 => new DarkOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12172 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12173 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12174 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12175 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12176 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12177 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12178 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12179 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12180 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12181 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12182 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12183 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12184 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12185 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12186 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12187 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12188 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12189 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12190 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12191 => new DarkOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12192 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12193 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12194 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12195 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12196 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12197 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12198 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12199 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12200 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12201 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12202 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12203 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12204 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12205 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12206 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12207 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12208 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12209 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12210 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12211 => new DarkOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
