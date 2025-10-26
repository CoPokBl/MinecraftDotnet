using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooStairsBlock(Identifier Identifier, Direction Facing, BambooStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 519;
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
    public string SoundType => "bamboo_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bamboo_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12170,
                            false => 12171,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12172,
                            false => 12173,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12174,
                            false => 12175,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12176,
                            false => 12177,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12178,
                            false => 12179,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12180,
                            false => 12181,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12182,
                            false => 12183,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12184,
                            false => 12185,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12186,
                            false => 12187,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12188,
                            false => 12189,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12190,
                            false => 12191,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12192,
                            false => 12193,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12194,
                            false => 12195,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12196,
                            false => 12197,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12198,
                            false => 12199,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12200,
                            false => 12201,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12202,
                            false => 12203,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12204,
                            false => 12205,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12206,
                            false => 12207,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12208,
                            false => 12209,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12210,
                            false => 12211,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12212,
                            false => 12213,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12214,
                            false => 12215,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12216,
                            false => 12217,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12218,
                            false => 12219,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12220,
                            false => 12221,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12222,
                            false => 12223,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12224,
                            false => 12225,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12226,
                            false => 12227,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12228,
                            false => 12229,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12230,
                            false => 12231,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12232,
                            false => 12233,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12234,
                            false => 12235,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12236,
                            false => 12237,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12238,
                            false => 12239,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12240,
                            false => 12241,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12242,
                            false => 12243,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12244,
                            false => 12245,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12246,
                            false => 12247,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12248,
                            false => 12249,
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
            12170 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12171 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12172 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12173 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12174 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12175 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12176 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12177 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12178 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12179 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12180 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12181 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12182 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12183 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12184 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12185 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12186 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12187 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12188 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12189 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12190 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12191 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12192 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12193 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12194 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12195 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12196 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12197 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12198 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12199 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12200 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12201 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12202 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12203 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12204 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12205 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12206 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12207 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12208 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12209 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12210 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12211 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12212 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12213 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12214 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12215 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12216 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12217 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12218 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12219 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12220 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12221 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12222 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12223 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12224 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12225 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12226 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12227 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12228 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12229 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12230 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12231 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12232 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12233 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12234 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12235 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12236 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12237 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12238 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12239 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12240 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12241 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12242 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12243 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12244 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12245 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12246 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12247 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12248 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12249 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
