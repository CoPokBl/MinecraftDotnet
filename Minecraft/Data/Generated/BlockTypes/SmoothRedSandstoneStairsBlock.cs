using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothRedSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothRedSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public double Hardness => 2;
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
    public Identifier? Item => "minecraft:smooth_red_sandstone_stairs";
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
    public string TranslationKey => "block.minecraft.smooth_red_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15376,
                            false => 15377,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15378,
                            false => 15379,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15380,
                            false => 15381,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15382,
                            false => 15383,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15384,
                            false => 15385,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15386,
                            false => 15387,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15388,
                            false => 15389,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15390,
                            false => 15391,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15392,
                            false => 15393,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15394,
                            false => 15395,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15396,
                            false => 15397,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15398,
                            false => 15399,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15400,
                            false => 15401,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15402,
                            false => 15403,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15404,
                            false => 15405,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15406,
                            false => 15407,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15408,
                            false => 15409,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15410,
                            false => 15411,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15412,
                            false => 15413,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15414,
                            false => 15415,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15416,
                            false => 15417,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15418,
                            false => 15419,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15420,
                            false => 15421,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15422,
                            false => 15423,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15424,
                            false => 15425,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15426,
                            false => 15427,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15428,
                            false => 15429,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15430,
                            false => 15431,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15432,
                            false => 15433,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15434,
                            false => 15435,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15436,
                            false => 15437,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15438,
                            false => 15439,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15440,
                            false => 15441,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15442,
                            false => 15443,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15444,
                            false => 15445,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15446,
                            false => 15447,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15448,
                            false => 15449,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15450,
                            false => 15451,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15452,
                            false => 15453,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15454,
                            false => 15455,
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
            15376 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15377 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15378 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15379 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15380 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15381 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15382 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15383 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15384 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15385 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15386 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15387 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15388 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15389 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15390 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15391 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15392 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15393 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15394 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15395 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15396 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15397 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15398 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15399 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15400 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15401 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15402 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15403 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15404 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15405 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15406 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15407 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15408 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15409 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15410 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15411 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15412 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15413 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15414 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15415 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15416 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15417 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15418 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15419 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15420 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15421 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15422 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15423 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15424 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15425 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15426 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15427 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15428 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15429 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15430 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15431 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15432 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15433 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15434 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15435 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15436 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15437 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15438 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15439 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15440 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15441 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15442 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15443 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15444 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15445 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15446 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15447 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15448 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15449 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15450 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15451 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15452 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15453 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15454 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15455 => new SmoothRedSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
