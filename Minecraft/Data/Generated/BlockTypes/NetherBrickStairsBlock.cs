using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickStairsBlock(Identifier Identifier, Direction Facing, NetherBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
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
    public string SoundType => "nether_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:nether_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.nether_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9367,
                            false => 9368,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9369,
                            false => 9370,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9371,
                            false => 9372,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9373,
                            false => 9374,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9375,
                            false => 9376,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9377,
                            false => 9378,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9379,
                            false => 9380,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9381,
                            false => 9382,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9383,
                            false => 9384,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9385,
                            false => 9386,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9387,
                            false => 9388,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9389,
                            false => 9390,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9391,
                            false => 9392,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9393,
                            false => 9394,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9395,
                            false => 9396,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9397,
                            false => 9398,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9399,
                            false => 9400,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9401,
                            false => 9402,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9403,
                            false => 9404,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9405,
                            false => 9406,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9407,
                            false => 9408,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9409,
                            false => 9410,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9411,
                            false => 9412,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9413,
                            false => 9414,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9415,
                            false => 9416,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9417,
                            false => 9418,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9419,
                            false => 9420,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9421,
                            false => 9422,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9423,
                            false => 9424,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9425,
                            false => 9426,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9427,
                            false => 9428,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9429,
                            false => 9430,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9431,
                            false => 9432,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9433,
                            false => 9434,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9435,
                            false => 9436,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9437,
                            false => 9438,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9439,
                            false => 9440,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9441,
                            false => 9442,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9443,
                            false => 9444,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9445,
                            false => 9446,
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
            9367 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9368 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9369 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9370 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9371 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9372 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9373 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9374 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9375 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9376 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9377 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9378 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9379 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9380 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9381 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9382 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9383 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9384 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9385 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9386 => new NetherBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9387 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9388 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9389 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9390 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9391 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9392 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9393 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9394 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9395 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9396 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9397 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9398 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9399 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9400 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9401 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9402 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9403 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9404 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9405 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9406 => new NetherBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9407 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9408 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9409 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9410 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9411 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9412 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9413 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9414 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9415 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9416 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9417 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9418 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9419 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9420 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9421 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9422 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9423 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9424 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9425 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9426 => new NetherBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9427 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9428 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9429 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9430 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9431 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9432 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9433 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9434 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9435 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9436 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9437 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9438 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9439 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9440 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9441 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9442 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9443 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9444 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9445 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9446 => new NetherBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
