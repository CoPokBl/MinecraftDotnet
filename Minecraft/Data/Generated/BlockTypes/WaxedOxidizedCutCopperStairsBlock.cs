using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1039;
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_oxidized_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25477,
                            false => 25478,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25479,
                            false => 25480,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25481,
                            false => 25482,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25483,
                            false => 25484,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25485,
                            false => 25486,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25487,
                            false => 25488,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25489,
                            false => 25490,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25491,
                            false => 25492,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25493,
                            false => 25494,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25495,
                            false => 25496,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25497,
                            false => 25498,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25499,
                            false => 25500,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25501,
                            false => 25502,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25503,
                            false => 25504,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25505,
                            false => 25506,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25507,
                            false => 25508,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25509,
                            false => 25510,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25511,
                            false => 25512,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25513,
                            false => 25514,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25515,
                            false => 25516,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25517,
                            false => 25518,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25519,
                            false => 25520,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25521,
                            false => 25522,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25523,
                            false => 25524,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25525,
                            false => 25526,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25527,
                            false => 25528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25529,
                            false => 25530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25531,
                            false => 25532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25533,
                            false => 25534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25535,
                            false => 25536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25537,
                            false => 25538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25539,
                            false => 25540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25541,
                            false => 25542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25543,
                            false => 25544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25545,
                            false => 25546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25547,
                            false => 25548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25549,
                            false => 25550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25551,
                            false => 25552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25553,
                            false => 25554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25555,
                            false => 25556,
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
            25477 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25478 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25479 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25480 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25481 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25482 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25483 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25484 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25485 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25486 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25487 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25488 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25489 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25490 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25491 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25492 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25493 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25494 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25495 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25496 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25497 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25498 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25499 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25500 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25501 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25502 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25503 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25504 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25505 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25506 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25507 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25508 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25509 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25510 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25511 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25512 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25513 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25514 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25515 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25516 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25517 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25518 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25519 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25520 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25521 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25522 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25523 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25524 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25525 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25526 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25527 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25528 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25529 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25530 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25531 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25532 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25533 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25534 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25535 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25536 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25537 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25538 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25539 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25540 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25541 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25542 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25543 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25544 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25545 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25546 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25547 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25548 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25549 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25550 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25551 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25552 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25553 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25554 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25555 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25556 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
