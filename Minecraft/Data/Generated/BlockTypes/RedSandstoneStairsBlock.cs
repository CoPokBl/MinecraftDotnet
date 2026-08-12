using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedSandstoneStairsBlock(Identifier Identifier, Direction Facing, RedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 0.8;
    public double ExplosionResistance => 0.8;
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
    public Identifier? Item => "minecraft:red_sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.red_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13250,
                            false => 13251,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13252,
                            false => 13253,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13254,
                            false => 13255,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13256,
                            false => 13257,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13258,
                            false => 13259,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13260,
                            false => 13261,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13262,
                            false => 13263,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13264,
                            false => 13265,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13266,
                            false => 13267,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13268,
                            false => 13269,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13270,
                            false => 13271,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13272,
                            false => 13273,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13274,
                            false => 13275,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13276,
                            false => 13277,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13278,
                            false => 13279,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13280,
                            false => 13281,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13282,
                            false => 13283,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13284,
                            false => 13285,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13286,
                            false => 13287,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13288,
                            false => 13289,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13290,
                            false => 13291,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13292,
                            false => 13293,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13294,
                            false => 13295,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13296,
                            false => 13297,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13298,
                            false => 13299,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13300,
                            false => 13301,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13302,
                            false => 13303,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13304,
                            false => 13305,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13306,
                            false => 13307,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13308,
                            false => 13309,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13310,
                            false => 13311,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13312,
                            false => 13313,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13314,
                            false => 13315,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13316,
                            false => 13317,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13318,
                            false => 13319,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13320,
                            false => 13321,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13322,
                            false => 13323,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13324,
                            false => 13325,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13326,
                            false => 13327,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13328,
                            false => 13329,
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
            13250 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            13251 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            13252 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            13253 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            13254 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            13255 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            13256 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            13257 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            13258 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            13259 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            13260 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            13261 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            13262 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            13263 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            13264 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            13265 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            13266 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            13267 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            13268 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            13269 => new RedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            13270 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            13271 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            13272 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            13273 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            13274 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            13275 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            13276 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            13277 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            13278 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            13279 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            13280 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            13281 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            13282 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            13283 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            13284 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            13285 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            13286 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            13287 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            13288 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            13289 => new RedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            13290 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            13291 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            13292 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            13293 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            13294 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            13295 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            13296 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            13297 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            13298 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            13299 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            13300 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            13301 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            13302 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            13303 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            13304 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            13305 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            13306 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            13307 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            13308 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            13309 => new RedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            13310 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            13311 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            13312 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            13313 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            13314 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            13315 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            13316 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            13317 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            13318 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            13319 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            13320 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            13321 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            13322 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            13323 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            13324 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            13325 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            13326 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            13327 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            13328 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            13329 => new RedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
