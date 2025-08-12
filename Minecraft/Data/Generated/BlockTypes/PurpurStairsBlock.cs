using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpurStairsBlock(Identifier Identifier, Direction Facing, PurpurStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 628;
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
    public Identifier? Item => "minecraft:purpur_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 16;
    public string TranslationKey => "block.minecraft.purpur_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13437,
                            false => 13438,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13439,
                            false => 13440,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13441,
                            false => 13442,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13443,
                            false => 13444,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13445,
                            false => 13446,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13447,
                            false => 13448,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13449,
                            false => 13450,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13451,
                            false => 13452,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13453,
                            false => 13454,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13455,
                            false => 13456,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13457,
                            false => 13458,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13459,
                            false => 13460,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13461,
                            false => 13462,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13463,
                            false => 13464,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13465,
                            false => 13466,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13467,
                            false => 13468,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13469,
                            false => 13470,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13471,
                            false => 13472,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13473,
                            false => 13474,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13475,
                            false => 13476,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13477,
                            false => 13478,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13479,
                            false => 13480,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13481,
                            false => 13482,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13483,
                            false => 13484,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13485,
                            false => 13486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13487,
                            false => 13488,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13489,
                            false => 13490,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13491,
                            false => 13492,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13493,
                            false => 13494,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13495,
                            false => 13496,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13497,
                            false => 13498,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13499,
                            false => 13500,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13501,
                            false => 13502,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13503,
                            false => 13504,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13505,
                            false => 13506,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 13507,
                            false => 13508,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 13509,
                            false => 13510,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 13511,
                            false => 13512,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 13513,
                            false => 13514,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 13515,
                            false => 13516,
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
            13437 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            13438 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            13439 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            13440 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            13441 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            13442 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            13443 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            13444 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            13445 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            13446 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            13447 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            13448 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            13449 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            13450 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            13451 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            13452 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            13453 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            13454 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            13455 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            13456 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            13457 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            13458 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            13459 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            13460 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            13461 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            13462 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            13463 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            13464 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            13465 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            13466 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            13467 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            13468 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            13469 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            13470 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            13471 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            13472 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            13473 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            13474 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            13475 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            13476 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            13477 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            13478 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            13479 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            13480 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            13481 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            13482 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            13483 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            13484 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            13485 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            13486 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            13487 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            13488 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            13489 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            13490 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            13491 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            13492 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            13493 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            13494 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            13495 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            13496 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            13497 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            13498 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            13499 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            13500 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            13501 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            13502 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            13503 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            13504 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            13505 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            13506 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            13507 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            13508 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            13509 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            13510 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            13511 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            13512 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            13513 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            13514 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            13515 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            13516 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
