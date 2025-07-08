using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneStairsBlock(Identifier Identifier, Direction Facing, StoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:stone_stairs";
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
    public string TranslationKey => "block.minecraft.stone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14465,
                            false => 14466,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14467,
                            false => 14468,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14469,
                            false => 14470,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14471,
                            false => 14472,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14473,
                            false => 14474,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14475,
                            false => 14476,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14477,
                            false => 14478,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14479,
                            false => 14480,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14481,
                            false => 14482,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14483,
                            false => 14484,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14485,
                            false => 14486,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14487,
                            false => 14488,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14489,
                            false => 14490,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14491,
                            false => 14492,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14493,
                            false => 14494,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14495,
                            false => 14496,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14497,
                            false => 14498,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14499,
                            false => 14500,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14501,
                            false => 14502,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14503,
                            false => 14504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14505,
                            false => 14506,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14507,
                            false => 14508,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14509,
                            false => 14510,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14511,
                            false => 14512,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14513,
                            false => 14514,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14515,
                            false => 14516,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14517,
                            false => 14518,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14519,
                            false => 14520,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14521,
                            false => 14522,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14523,
                            false => 14524,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14525,
                            false => 14526,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14527,
                            false => 14528,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14529,
                            false => 14530,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14531,
                            false => 14532,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14533,
                            false => 14534,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14535,
                            false => 14536,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14537,
                            false => 14538,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14539,
                            false => 14540,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14541,
                            false => 14542,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14543,
                            false => 14544,
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
            14465 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14466 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14467 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14468 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14469 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14470 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14471 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14472 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14473 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14474 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14475 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14476 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14477 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14478 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14479 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14480 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14481 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14482 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14483 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14484 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14485 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14486 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14487 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14488 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14489 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14490 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14491 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14492 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14493 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14494 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14495 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14496 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14497 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14498 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14499 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14500 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14501 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14502 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14503 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14504 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14505 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14506 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14507 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14508 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14509 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14510 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14511 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14512 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14513 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14514 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14515 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14516 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14517 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14518 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14519 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14520 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14521 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14522 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14523 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14524 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14525 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14526 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14527 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14528 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14529 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14530 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14531 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14532 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14533 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14534 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14535 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14536 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14537 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14538 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14539 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14540 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14541 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14542 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14543 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14544 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
