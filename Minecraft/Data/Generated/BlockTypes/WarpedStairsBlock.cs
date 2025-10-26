using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedStairsBlock(Identifier Identifier, Direction Facing, WarpedStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 894;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21184,
                            false => 21185,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21186,
                            false => 21187,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21188,
                            false => 21189,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21190,
                            false => 21191,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21192,
                            false => 21193,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21194,
                            false => 21195,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21196,
                            false => 21197,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21198,
                            false => 21199,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21200,
                            false => 21201,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21202,
                            false => 21203,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21204,
                            false => 21205,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21206,
                            false => 21207,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21208,
                            false => 21209,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21210,
                            false => 21211,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21212,
                            false => 21213,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21214,
                            false => 21215,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21216,
                            false => 21217,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21218,
                            false => 21219,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21220,
                            false => 21221,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21222,
                            false => 21223,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21224,
                            false => 21225,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21226,
                            false => 21227,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21228,
                            false => 21229,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21230,
                            false => 21231,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21232,
                            false => 21233,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21234,
                            false => 21235,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21236,
                            false => 21237,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21238,
                            false => 21239,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21240,
                            false => 21241,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21242,
                            false => 21243,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21244,
                            false => 21245,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21246,
                            false => 21247,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21248,
                            false => 21249,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21250,
                            false => 21251,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21252,
                            false => 21253,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21254,
                            false => 21255,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21256,
                            false => 21257,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21258,
                            false => 21259,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21260,
                            false => 21261,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21262,
                            false => 21263,
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
            21184 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21185 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21186 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21187 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21188 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21189 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21190 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21191 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21192 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21193 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21194 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21195 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21196 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21197 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21198 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21199 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21200 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21201 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21202 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21203 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21204 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21205 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21206 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21207 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21208 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21209 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21210 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21211 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21212 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21213 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21214 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21215 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21216 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21217 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21218 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21219 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21220 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21221 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21222 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21223 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21224 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21225 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21226 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21227 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21228 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21229 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21230 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21231 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21232 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21233 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21234 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21235 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21236 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21237 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21238 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21239 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21240 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21241 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21242 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21243 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21244 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21245 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21246 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21247 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21248 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21249 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21250 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21251 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21252 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21253 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21254 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21255 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21256 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21257 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21258 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21259 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21260 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21261 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21262 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21263 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
