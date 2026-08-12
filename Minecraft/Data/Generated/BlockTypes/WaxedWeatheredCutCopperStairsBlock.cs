using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedWeatheredCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_weathered_cut_copper_stairs";
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
    public string TranslationKey => "block.minecraft.waxed_weathered_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28288,
                            false => 28289,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28290,
                            false => 28291,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28292,
                            false => 28293,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28294,
                            false => 28295,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28296,
                            false => 28297,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28298,
                            false => 28299,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28300,
                            false => 28301,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28302,
                            false => 28303,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28304,
                            false => 28305,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28306,
                            false => 28307,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28308,
                            false => 28309,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28310,
                            false => 28311,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28312,
                            false => 28313,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28314,
                            false => 28315,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28316,
                            false => 28317,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28318,
                            false => 28319,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28320,
                            false => 28321,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28322,
                            false => 28323,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28324,
                            false => 28325,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28326,
                            false => 28327,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28328,
                            false => 28329,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28330,
                            false => 28331,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28332,
                            false => 28333,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28334,
                            false => 28335,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28336,
                            false => 28337,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28338,
                            false => 28339,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28340,
                            false => 28341,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28342,
                            false => 28343,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28344,
                            false => 28345,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28346,
                            false => 28347,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28348,
                            false => 28349,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28350,
                            false => 28351,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28352,
                            false => 28353,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28354,
                            false => 28355,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28356,
                            false => 28357,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28358,
                            false => 28359,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28360,
                            false => 28361,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28362,
                            false => 28363,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28364,
                            false => 28365,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28366,
                            false => 28367,
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
            28288 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28289 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28290 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28291 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28292 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28293 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28294 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28295 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28296 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28297 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28298 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28299 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28300 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28301 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28302 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28303 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28304 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28305 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28306 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28307 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28308 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28309 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28310 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28311 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28312 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28313 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28314 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28315 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28316 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28317 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28318 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28319 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28320 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28321 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28322 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28323 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28324 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28325 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28326 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28327 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28328 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28329 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28330 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28331 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28332 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28333 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28334 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28335 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28336 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28337 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28338 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28339 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28340 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28341 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28342 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28343 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28344 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28345 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28346 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28347 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28348 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28349 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28350 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28351 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28352 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28353 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28354 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28355 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28356 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28357 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28358 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28359 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28360 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28361 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28362 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28363 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28364 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28365 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28366 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28367 => new WaxedWeatheredCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
