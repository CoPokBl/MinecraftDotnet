using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffBrickStairsBlock(Identifier Identifier, Direction Facing, TuffBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "tuff_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:tuff_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.tuff_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24282,
                            false => 24283,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24284,
                            false => 24285,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24286,
                            false => 24287,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24288,
                            false => 24289,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24290,
                            false => 24291,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24292,
                            false => 24293,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24294,
                            false => 24295,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24296,
                            false => 24297,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24298,
                            false => 24299,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24300,
                            false => 24301,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24302,
                            false => 24303,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24304,
                            false => 24305,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24306,
                            false => 24307,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24308,
                            false => 24309,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24310,
                            false => 24311,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24312,
                            false => 24313,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24314,
                            false => 24315,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24316,
                            false => 24317,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24318,
                            false => 24319,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24320,
                            false => 24321,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24322,
                            false => 24323,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24324,
                            false => 24325,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24326,
                            false => 24327,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24328,
                            false => 24329,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24330,
                            false => 24331,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24332,
                            false => 24333,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24334,
                            false => 24335,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24336,
                            false => 24337,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24338,
                            false => 24339,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24340,
                            false => 24341,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24342,
                            false => 24343,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24344,
                            false => 24345,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24346,
                            false => 24347,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24348,
                            false => 24349,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24350,
                            false => 24351,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 24352,
                            false => 24353,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 24354,
                            false => 24355,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 24356,
                            false => 24357,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 24358,
                            false => 24359,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 24360,
                            false => 24361,
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
            24282 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            24283 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            24284 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            24285 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            24286 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            24287 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            24288 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            24289 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            24290 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            24291 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            24292 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            24293 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            24294 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            24295 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            24296 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            24297 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            24298 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            24299 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            24300 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            24301 => new TuffBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            24302 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            24303 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            24304 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            24305 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            24306 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            24307 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            24308 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            24309 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            24310 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            24311 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            24312 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            24313 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            24314 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            24315 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            24316 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            24317 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            24318 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            24319 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            24320 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            24321 => new TuffBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            24322 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            24323 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            24324 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            24325 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            24326 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            24327 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            24328 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            24329 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            24330 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            24331 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            24332 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            24333 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            24334 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            24335 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            24336 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            24337 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            24338 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            24339 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            24340 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            24341 => new TuffBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            24342 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            24343 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            24344 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            24345 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            24346 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            24347 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            24348 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            24349 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            24350 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            24351 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            24352 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            24353 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            24354 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            24355 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            24356 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            24357 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            24358 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            24359 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            24360 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            24361 => new TuffBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
