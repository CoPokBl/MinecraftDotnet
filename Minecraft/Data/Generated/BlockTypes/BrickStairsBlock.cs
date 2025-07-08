using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrickStairsBlock(Identifier Identifier, Direction Facing, BrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7400,
                            false => 7401,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7402,
                            false => 7403,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7404,
                            false => 7405,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7406,
                            false => 7407,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7408,
                            false => 7409,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7410,
                            false => 7411,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7412,
                            false => 7413,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7414,
                            false => 7415,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7416,
                            false => 7417,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7418,
                            false => 7419,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7420,
                            false => 7421,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7422,
                            false => 7423,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7424,
                            false => 7425,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7426,
                            false => 7427,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7428,
                            false => 7429,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7430,
                            false => 7431,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7432,
                            false => 7433,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7434,
                            false => 7435,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7436,
                            false => 7437,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7438,
                            false => 7439,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7440,
                            false => 7441,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7442,
                            false => 7443,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7444,
                            false => 7445,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7446,
                            false => 7447,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7448,
                            false => 7449,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7450,
                            false => 7451,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7452,
                            false => 7453,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7454,
                            false => 7455,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7456,
                            false => 7457,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7458,
                            false => 7459,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7460,
                            false => 7461,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7462,
                            false => 7463,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7464,
                            false => 7465,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7466,
                            false => 7467,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7468,
                            false => 7469,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7470,
                            false => 7471,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7472,
                            false => 7473,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7474,
                            false => 7475,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7476,
                            false => 7477,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7478,
                            false => 7479,
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
            7400 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            7401 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            7402 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            7403 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            7404 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            7405 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            7406 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            7407 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            7408 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            7409 => new BrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            7410 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            7411 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            7412 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            7413 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            7414 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            7415 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            7416 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            7417 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            7418 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            7419 => new BrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            7420 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            7421 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            7422 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            7423 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            7424 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            7425 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            7426 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            7427 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            7428 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            7429 => new BrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            7430 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            7431 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            7432 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            7433 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            7434 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            7435 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            7436 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            7437 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            7438 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            7439 => new BrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            7440 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            7441 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            7442 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            7443 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            7444 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            7445 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            7446 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            7447 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            7448 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            7449 => new BrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            7450 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            7451 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            7452 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            7453 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            7454 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            7455 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            7456 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            7457 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            7458 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            7459 => new BrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            7460 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            7461 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            7462 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            7463 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            7464 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            7465 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            7466 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            7467 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            7468 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            7469 => new BrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            7470 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            7471 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            7472 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            7473 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            7474 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            7475 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            7476 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            7477 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            7478 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            7479 => new BrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
}
