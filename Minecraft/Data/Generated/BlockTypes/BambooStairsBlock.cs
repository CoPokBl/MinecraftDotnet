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
                            true => 12372,
                            false => 12373,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12374,
                            false => 12375,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12376,
                            false => 12377,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12378,
                            false => 12379,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12380,
                            false => 12381,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12382,
                            false => 12383,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12384,
                            false => 12385,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12386,
                            false => 12387,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12388,
                            false => 12389,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12390,
                            false => 12391,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12392,
                            false => 12393,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12394,
                            false => 12395,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12396,
                            false => 12397,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12398,
                            false => 12399,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12400,
                            false => 12401,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12402,
                            false => 12403,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12404,
                            false => 12405,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12406,
                            false => 12407,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12408,
                            false => 12409,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12410,
                            false => 12411,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12412,
                            false => 12413,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12414,
                            false => 12415,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12416,
                            false => 12417,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12418,
                            false => 12419,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12420,
                            false => 12421,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12422,
                            false => 12423,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12424,
                            false => 12425,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12426,
                            false => 12427,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12428,
                            false => 12429,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12430,
                            false => 12431,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12432,
                            false => 12433,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12434,
                            false => 12435,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12436,
                            false => 12437,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12438,
                            false => 12439,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12440,
                            false => 12441,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12442,
                            false => 12443,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12444,
                            false => 12445,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12446,
                            false => 12447,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12448,
                            false => 12449,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12450,
                            false => 12451,
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
            12372 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12373 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12374 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12375 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12376 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12377 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12378 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12379 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12380 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12381 => new BambooStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12382 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12383 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12384 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12385 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12386 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12387 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12388 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12389 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12390 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12391 => new BambooStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12392 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12393 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12394 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12395 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12396 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12397 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12398 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12399 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12400 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12401 => new BambooStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12402 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12403 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12404 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12405 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12406 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12407 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12408 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12409 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12410 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12411 => new BambooStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12412 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12413 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12414 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12415 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12416 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12417 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12418 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12419 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12420 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12421 => new BambooStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12422 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12423 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12424 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12425 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12426 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12427 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12428 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12429 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12430 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12431 => new BambooStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12432 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12433 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12434 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12435 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12436 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12437 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12438 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12439 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12440 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12441 => new BambooStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12442 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12443 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12444 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12445 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12446 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12447 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12448 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12449 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12450 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12451 => new BambooStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
