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
    public int ProtocolId => 658;
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
                            true => 14514,
                            false => 14515,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14516,
                            false => 14517,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14518,
                            false => 14519,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14520,
                            false => 14521,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14522,
                            false => 14523,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14524,
                            false => 14525,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14526,
                            false => 14527,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14528,
                            false => 14529,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14530,
                            false => 14531,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14532,
                            false => 14533,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14534,
                            false => 14535,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14536,
                            false => 14537,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14538,
                            false => 14539,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14540,
                            false => 14541,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14542,
                            false => 14543,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14544,
                            false => 14545,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14546,
                            false => 14547,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14548,
                            false => 14549,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14550,
                            false => 14551,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14552,
                            false => 14553,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14554,
                            false => 14555,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14556,
                            false => 14557,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14558,
                            false => 14559,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14560,
                            false => 14561,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14562,
                            false => 14563,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14564,
                            false => 14565,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14566,
                            false => 14567,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14568,
                            false => 14569,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14570,
                            false => 14571,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14572,
                            false => 14573,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14574,
                            false => 14575,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14576,
                            false => 14577,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14578,
                            false => 14579,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14580,
                            false => 14581,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14582,
                            false => 14583,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14584,
                            false => 14585,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14586,
                            false => 14587,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14588,
                            false => 14589,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14590,
                            false => 14591,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14592,
                            false => 14593,
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
            14514 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14515 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14516 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14517 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14518 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14519 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14520 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14521 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14522 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14523 => new PurpurStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14524 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14525 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14526 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14527 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14528 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14529 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14530 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14531 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14532 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14533 => new PurpurStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14534 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14535 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14536 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14537 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14538 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14539 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14540 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14541 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14542 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14543 => new PurpurStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14544 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14545 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14546 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14547 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14548 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14549 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14550 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14551 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14552 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14553 => new PurpurStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14554 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14555 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14556 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14557 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14558 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14559 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14560 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14561 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14562 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14563 => new PurpurStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14564 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14565 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14566 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14567 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14568 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14569 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14570 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14571 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14572 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14573 => new PurpurStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14574 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14575 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14576 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14577 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14578 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14579 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14580 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14581 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14582 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14583 => new PurpurStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14584 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14585 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14586 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14587 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14588 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14589 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14590 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14591 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14592 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14593 => new PurpurStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
