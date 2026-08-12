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
                            true => 31242,
                            false => 31243,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31244,
                            false => 31245,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31246,
                            false => 31247,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31248,
                            false => 31249,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31250,
                            false => 31251,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31252,
                            false => 31253,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31254,
                            false => 31255,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31256,
                            false => 31257,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31258,
                            false => 31259,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31260,
                            false => 31261,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31262,
                            false => 31263,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31264,
                            false => 31265,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31266,
                            false => 31267,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31268,
                            false => 31269,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31270,
                            false => 31271,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31272,
                            false => 31273,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31274,
                            false => 31275,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31276,
                            false => 31277,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31278,
                            false => 31279,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31280,
                            false => 31281,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31282,
                            false => 31283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31284,
                            false => 31285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31286,
                            false => 31287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31288,
                            false => 31289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31290,
                            false => 31291,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31292,
                            false => 31293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31294,
                            false => 31295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31296,
                            false => 31297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31298,
                            false => 31299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31300,
                            false => 31301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31302,
                            false => 31303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31304,
                            false => 31305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31306,
                            false => 31307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31308,
                            false => 31309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31310,
                            false => 31311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 31312,
                            false => 31313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 31314,
                            false => 31315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 31316,
                            false => 31317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 31318,
                            false => 31319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 31320,
                            false => 31321,
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
            31242 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            31243 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            31244 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            31245 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            31246 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            31247 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            31248 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            31249 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            31250 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            31251 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            31252 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            31253 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            31254 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            31255 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            31256 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            31257 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            31258 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            31259 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            31260 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            31261 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            31262 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            31263 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            31264 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            31265 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            31266 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            31267 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            31268 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            31269 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            31270 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            31271 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            31272 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            31273 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            31274 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            31275 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            31276 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            31277 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            31278 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            31279 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            31280 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            31281 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            31282 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            31283 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            31284 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            31285 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            31286 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            31287 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            31288 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            31289 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            31290 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            31291 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            31292 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            31293 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            31294 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            31295 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            31296 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            31297 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            31298 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            31299 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            31300 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            31301 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            31302 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            31303 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            31304 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            31305 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            31306 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            31307 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            31308 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            31309 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            31310 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            31311 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            31312 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            31313 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            31314 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            31315 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            31316 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            31317 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            31318 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            31319 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            31320 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            31321 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
