using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CobblestoneStairsBlock(Identifier Identifier, Direction Facing, CobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 222;
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
    public Identifier? Item => "minecraft:cobblestone_stairs";
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
    public string TranslationKey => "block.minecraft.cobblestone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5546,
                            false => 5547,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5548,
                            false => 5549,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5550,
                            false => 5551,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5552,
                            false => 5553,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5554,
                            false => 5555,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5556,
                            false => 5557,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5558,
                            false => 5559,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5560,
                            false => 5561,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5562,
                            false => 5563,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5564,
                            false => 5565,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5566,
                            false => 5567,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5568,
                            false => 5569,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5570,
                            false => 5571,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5572,
                            false => 5573,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5574,
                            false => 5575,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5576,
                            false => 5577,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5578,
                            false => 5579,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5580,
                            false => 5581,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5582,
                            false => 5583,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5584,
                            false => 5585,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5586,
                            false => 5587,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5588,
                            false => 5589,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5590,
                            false => 5591,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5592,
                            false => 5593,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5594,
                            false => 5595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5596,
                            false => 5597,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5598,
                            false => 5599,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5600,
                            false => 5601,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5602,
                            false => 5603,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5604,
                            false => 5605,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5606,
                            false => 5607,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5608,
                            false => 5609,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5610,
                            false => 5611,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5612,
                            false => 5613,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5614,
                            false => 5615,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 5616,
                            false => 5617,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 5618,
                            false => 5619,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 5620,
                            false => 5621,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 5622,
                            false => 5623,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 5624,
                            false => 5625,
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
            5546 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            5547 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            5548 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            5549 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            5550 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            5551 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            5552 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            5553 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            5554 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            5555 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            5556 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            5557 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            5558 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            5559 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            5560 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            5561 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            5562 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            5563 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            5564 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            5565 => new CobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            5566 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            5567 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            5568 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            5569 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            5570 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            5571 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            5572 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            5573 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            5574 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            5575 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            5576 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            5577 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            5578 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            5579 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            5580 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            5581 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            5582 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            5583 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            5584 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            5585 => new CobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            5586 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            5587 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            5588 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            5589 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            5590 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            5591 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            5592 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            5593 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            5594 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            5595 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            5596 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            5597 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            5598 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            5599 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            5600 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            5601 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            5602 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            5603 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            5604 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            5605 => new CobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            5606 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            5607 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            5608 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            5609 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            5610 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            5611 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            5612 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            5613 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            5614 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            5615 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            5616 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            5617 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            5618 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            5619 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            5620 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            5621 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            5622 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            5623 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            5624 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            5625 => new CobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
