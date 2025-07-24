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
    public int ProtocolId => 771;
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
                            true => 14497,
                            false => 14498,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14499,
                            false => 14500,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14501,
                            false => 14502,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14503,
                            false => 14504,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14505,
                            false => 14506,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14507,
                            false => 14508,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14509,
                            false => 14510,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14511,
                            false => 14512,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14513,
                            false => 14514,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14515,
                            false => 14516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14517,
                            false => 14518,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14519,
                            false => 14520,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14521,
                            false => 14522,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14523,
                            false => 14524,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14525,
                            false => 14526,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14527,
                            false => 14528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14529,
                            false => 14530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14531,
                            false => 14532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14533,
                            false => 14534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14535,
                            false => 14536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14537,
                            false => 14538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14539,
                            false => 14540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14541,
                            false => 14542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14543,
                            false => 14544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14545,
                            false => 14546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14547,
                            false => 14548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14549,
                            false => 14550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14551,
                            false => 14552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14553,
                            false => 14554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14555,
                            false => 14556,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14557,
                            false => 14558,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14559,
                            false => 14560,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14561,
                            false => 14562,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14563,
                            false => 14564,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14565,
                            false => 14566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14567,
                            false => 14568,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14569,
                            false => 14570,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14571,
                            false => 14572,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14573,
                            false => 14574,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14575,
                            false => 14576,
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
            14497 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14498 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14499 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14500 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14501 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14502 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14503 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14504 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14505 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14506 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14507 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14508 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14509 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14510 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14511 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14512 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14513 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14514 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14515 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14516 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14517 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14518 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14519 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14520 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14521 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14522 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14523 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14524 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14525 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14526 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14527 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14528 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14529 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14530 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14531 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14532 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14533 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14534 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14535 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14536 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14537 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14538 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14539 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14540 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14541 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14542 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14543 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14544 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14545 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14546 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14547 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14548 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14549 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14550 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14551 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14552 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14553 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14554 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14555 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14556 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14557 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14558 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14559 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14560 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14561 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14562 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14563 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14564 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14565 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14566 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14567 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14568 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14569 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14570 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14571 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14572 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14573 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14574 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14575 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14576 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
