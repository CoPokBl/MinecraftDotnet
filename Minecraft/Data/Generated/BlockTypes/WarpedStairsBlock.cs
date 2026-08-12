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
                            true => 21386,
                            false => 21387,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21388,
                            false => 21389,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21390,
                            false => 21391,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21392,
                            false => 21393,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21394,
                            false => 21395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21396,
                            false => 21397,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21398,
                            false => 21399,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21400,
                            false => 21401,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21402,
                            false => 21403,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21404,
                            false => 21405,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21406,
                            false => 21407,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21408,
                            false => 21409,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21410,
                            false => 21411,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21412,
                            false => 21413,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21414,
                            false => 21415,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21416,
                            false => 21417,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21418,
                            false => 21419,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21420,
                            false => 21421,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21422,
                            false => 21423,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21424,
                            false => 21425,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21426,
                            false => 21427,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21428,
                            false => 21429,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21430,
                            false => 21431,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21432,
                            false => 21433,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21434,
                            false => 21435,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21436,
                            false => 21437,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21438,
                            false => 21439,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21440,
                            false => 21441,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21442,
                            false => 21443,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21444,
                            false => 21445,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21446,
                            false => 21447,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21448,
                            false => 21449,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21450,
                            false => 21451,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21452,
                            false => 21453,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21454,
                            false => 21455,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21456,
                            false => 21457,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21458,
                            false => 21459,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21460,
                            false => 21461,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21462,
                            false => 21463,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21464,
                            false => 21465,
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
            21386 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21387 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21388 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21389 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21390 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21391 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21392 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21393 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21394 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21395 => new WarpedStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21396 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21397 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21398 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21399 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21400 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21401 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21402 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21403 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21404 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21405 => new WarpedStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21406 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21407 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21408 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21409 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21410 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21411 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21412 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21413 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21414 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21415 => new WarpedStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21416 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21417 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21418 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21419 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21420 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21421 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21422 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21423 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21424 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21425 => new WarpedStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21426 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21427 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21428 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21429 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21430 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21431 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21432 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21433 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21434 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21435 => new WarpedStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21436 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21437 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21438 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21439 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21440 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21441 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21442 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21443 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21444 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21445 => new WarpedStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21446 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21447 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21448 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21449 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21450 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21451 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21452 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21453 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21454 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21455 => new WarpedStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21456 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21457 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21458 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21459 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21460 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21461 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21462 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21463 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21464 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21465 => new WarpedStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
