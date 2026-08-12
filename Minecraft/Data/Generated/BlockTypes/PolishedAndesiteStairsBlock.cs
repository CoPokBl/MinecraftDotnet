using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedAndesiteStairsBlock(Identifier Identifier, Direction Facing, PolishedAndesiteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:polished_andesite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.polished_andesite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16256,
                            false => 16257,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16258,
                            false => 16259,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16260,
                            false => 16261,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16262,
                            false => 16263,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16264,
                            false => 16265,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16266,
                            false => 16267,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16268,
                            false => 16269,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16270,
                            false => 16271,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16272,
                            false => 16273,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16274,
                            false => 16275,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16276,
                            false => 16277,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16278,
                            false => 16279,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16280,
                            false => 16281,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16282,
                            false => 16283,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16284,
                            false => 16285,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16286,
                            false => 16287,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16288,
                            false => 16289,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16290,
                            false => 16291,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16292,
                            false => 16293,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16294,
                            false => 16295,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16296,
                            false => 16297,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16298,
                            false => 16299,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16300,
                            false => 16301,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16302,
                            false => 16303,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16304,
                            false => 16305,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16306,
                            false => 16307,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16308,
                            false => 16309,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16310,
                            false => 16311,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16312,
                            false => 16313,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16314,
                            false => 16315,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16316,
                            false => 16317,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16318,
                            false => 16319,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16320,
                            false => 16321,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16322,
                            false => 16323,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16324,
                            false => 16325,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 16326,
                            false => 16327,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 16328,
                            false => 16329,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 16330,
                            false => 16331,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 16332,
                            false => 16333,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 16334,
                            false => 16335,
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
            16256 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            16257 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            16258 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            16259 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            16260 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            16261 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            16262 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            16263 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            16264 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            16265 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            16266 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            16267 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            16268 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            16269 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            16270 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            16271 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            16272 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            16273 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            16274 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            16275 => new PolishedAndesiteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            16276 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            16277 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            16278 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            16279 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            16280 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            16281 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            16282 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            16283 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            16284 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            16285 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            16286 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            16287 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            16288 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            16289 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            16290 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            16291 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            16292 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            16293 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            16294 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            16295 => new PolishedAndesiteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            16296 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            16297 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            16298 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            16299 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            16300 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            16301 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            16302 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            16303 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            16304 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            16305 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            16306 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            16307 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            16308 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            16309 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            16310 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            16311 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            16312 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            16313 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            16314 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            16315 => new PolishedAndesiteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            16316 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            16317 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            16318 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            16319 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            16320 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            16321 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            16322 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            16323 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            16324 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            16325 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            16326 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            16327 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            16328 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            16329 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            16330 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            16331 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            16332 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            16333 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            16334 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            16335 => new PolishedAndesiteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
