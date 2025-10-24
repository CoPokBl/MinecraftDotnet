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
    public int ProtocolId => 934;
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
                            true => 22455,
                            false => 22456,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22457,
                            false => 22458,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22459,
                            false => 22460,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22461,
                            false => 22462,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22463,
                            false => 22464,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22465,
                            false => 22466,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22467,
                            false => 22468,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22469,
                            false => 22470,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22471,
                            false => 22472,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22473,
                            false => 22474,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22475,
                            false => 22476,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22477,
                            false => 22478,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22479,
                            false => 22480,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22481,
                            false => 22482,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22483,
                            false => 22484,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22485,
                            false => 22486,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22487,
                            false => 22488,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22489,
                            false => 22490,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22491,
                            false => 22492,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22493,
                            false => 22494,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22495,
                            false => 22496,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22497,
                            false => 22498,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22499,
                            false => 22500,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22501,
                            false => 22502,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22503,
                            false => 22504,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22505,
                            false => 22506,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22507,
                            false => 22508,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22509,
                            false => 22510,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22511,
                            false => 22512,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22513,
                            false => 22514,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22515,
                            false => 22516,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22517,
                            false => 22518,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22519,
                            false => 22520,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22521,
                            false => 22522,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22523,
                            false => 22524,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22525,
                            false => 22526,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22527,
                            false => 22528,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22529,
                            false => 22530,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22531,
                            false => 22532,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22533,
                            false => 22534,
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
            22455 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22456 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22457 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22458 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22459 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22460 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22461 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22462 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22463 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22464 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22465 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22466 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22467 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22468 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22469 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22470 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22471 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22472 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22473 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22474 => new PolishedBlackstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22475 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22476 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22477 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22478 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22479 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22480 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22481 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22482 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22483 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22484 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22485 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22486 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22487 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22488 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22489 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22490 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22491 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22492 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22493 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22494 => new PolishedBlackstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22495 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22496 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22497 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22498 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22499 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22500 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22501 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22502 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22503 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22504 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22505 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22506 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22507 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22508 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22509 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22510 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22511 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22512 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22513 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22514 => new PolishedBlackstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22515 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22516 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22517 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22518 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22519 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22520 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22521 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22522 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22523 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22524 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22525 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22526 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22527 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22528 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22529 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22530 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22531 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22532 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22533 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22534 => new PolishedBlackstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
