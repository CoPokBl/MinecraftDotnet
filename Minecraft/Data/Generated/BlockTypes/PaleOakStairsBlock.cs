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
                            true => 12212,
                            false => 12213,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12214,
                            false => 12215,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12216,
                            false => 12217,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12218,
                            false => 12219,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12220,
                            false => 12221,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12222,
                            false => 12223,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12224,
                            false => 12225,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12226,
                            false => 12227,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12228,
                            false => 12229,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12230,
                            false => 12231,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12232,
                            false => 12233,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12234,
                            false => 12235,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12236,
                            false => 12237,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12238,
                            false => 12239,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12240,
                            false => 12241,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12242,
                            false => 12243,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12244,
                            false => 12245,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12246,
                            false => 12247,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12248,
                            false => 12249,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12250,
                            false => 12251,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12252,
                            false => 12253,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12254,
                            false => 12255,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12256,
                            false => 12257,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12258,
                            false => 12259,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12260,
                            false => 12261,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12262,
                            false => 12263,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12264,
                            false => 12265,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12266,
                            false => 12267,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12268,
                            false => 12269,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12270,
                            false => 12271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12272,
                            false => 12273,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12274,
                            false => 12275,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12276,
                            false => 12277,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12278,
                            false => 12279,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12280,
                            false => 12281,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12282,
                            false => 12283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12284,
                            false => 12285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12286,
                            false => 12287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12288,
                            false => 12289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12290,
                            false => 12291,
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
            12212 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12213 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12214 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12215 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12216 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12217 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12218 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12219 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12220 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12221 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12222 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12223 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12224 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12225 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12226 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12227 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12228 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12229 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12230 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12231 => new PaleOakStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12232 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12233 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12234 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12235 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12236 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12237 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12238 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12239 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12240 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12241 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12242 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12243 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12244 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12245 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12246 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12247 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12248 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12249 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12250 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12251 => new PaleOakStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12252 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12253 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12254 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12255 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12256 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12257 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12258 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12259 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12260 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12261 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12262 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12263 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12264 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12265 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12266 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12267 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12268 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12269 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12270 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12271 => new PaleOakStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12272 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12273 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12274 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12275 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12276 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12277 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12278 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12279 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12280 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12281 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12282 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12283 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12284 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12285 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12286 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12287 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12288 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12289 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12290 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12291 => new PaleOakStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
