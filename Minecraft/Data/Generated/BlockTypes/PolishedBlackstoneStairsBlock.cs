using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneStairsBlock(Identifier Identifier, Direction Facing, PolishedBlackstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 896;
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
    public Identifier? Item => "minecraft:polished_blackstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.polished_blackstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21346,
                            false => 21347,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21348,
                            false => 21349,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21350,
                            false => 21351,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21352,
                            false => 21353,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21354,
                            false => 21355,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21356,
                            false => 21357,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21358,
                            false => 21359,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21360,
                            false => 21361,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21362,
                            false => 21363,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21364,
                            false => 21365,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21366,
                            false => 21367,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21368,
                            false => 21369,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21370,
                            false => 21371,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21372,
                            false => 21373,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21374,
                            false => 21375,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 21376,
                            false => 21377,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 21378,
                            false => 21379,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 21380,
                            false => 21381,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 21382,
                            false => 21383,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 21384,
                            false => 21385,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
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
                Direction.East => HalfValue switch {
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
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21346 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            21347 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            21348 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            21349 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            21350 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            21351 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            21352 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            21353 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            21354 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            21355 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            21356 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            21357 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            21358 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            21359 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            21360 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            21361 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            21362 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            21363 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            21364 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            21365 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            21366 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            21367 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            21368 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            21369 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            21370 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            21371 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            21372 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            21373 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            21374 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            21375 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            21376 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            21377 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            21378 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            21379 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            21380 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            21381 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            21382 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            21383 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            21384 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            21385 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            21386 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            21387 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            21388 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            21389 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            21390 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            21391 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            21392 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            21393 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            21394 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            21395 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            21396 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            21397 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            21398 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            21399 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            21400 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            21401 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            21402 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            21403 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            21404 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            21405 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            21406 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            21407 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            21408 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            21409 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            21410 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            21411 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            21412 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            21413 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            21414 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            21415 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            21416 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            21417 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            21418 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            21419 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            21420 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            21421 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            21422 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            21423 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            21424 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            21425 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Shape = StairShapeExtensions.FromString(properties["shape"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
