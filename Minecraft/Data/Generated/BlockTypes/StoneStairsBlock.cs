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
    public int ProtocolId => 801;
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
                            true => 15574,
                            false => 15575,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15576,
                            false => 15577,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15578,
                            false => 15579,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15580,
                            false => 15581,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15582,
                            false => 15583,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15584,
                            false => 15585,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15586,
                            false => 15587,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15588,
                            false => 15589,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15590,
                            false => 15591,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15592,
                            false => 15593,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15594,
                            false => 15595,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15596,
                            false => 15597,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15598,
                            false => 15599,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15600,
                            false => 15601,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15602,
                            false => 15603,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15604,
                            false => 15605,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15606,
                            false => 15607,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15608,
                            false => 15609,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15610,
                            false => 15611,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15612,
                            false => 15613,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15614,
                            false => 15615,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15616,
                            false => 15617,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15618,
                            false => 15619,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15620,
                            false => 15621,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15622,
                            false => 15623,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15624,
                            false => 15625,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15626,
                            false => 15627,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15628,
                            false => 15629,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15630,
                            false => 15631,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15632,
                            false => 15633,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15634,
                            false => 15635,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15636,
                            false => 15637,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15638,
                            false => 15639,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15640,
                            false => 15641,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15642,
                            false => 15643,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15644,
                            false => 15645,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15646,
                            false => 15647,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15648,
                            false => 15649,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15650,
                            false => 15651,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15652,
                            false => 15653,
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
            15574 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15575 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15576 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15577 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15578 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15579 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15580 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15581 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15582 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15583 => new StoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15584 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15585 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15586 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15587 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15588 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15589 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15590 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15591 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15592 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15593 => new StoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15594 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15595 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15596 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15597 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15598 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15599 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15600 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15601 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15602 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15603 => new StoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15604 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15605 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15606 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15607 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15608 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15609 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15610 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15611 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15612 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15613 => new StoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15614 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15615 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15616 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15617 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15618 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15619 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15620 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15621 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15622 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15623 => new StoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15624 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15625 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15626 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15627 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15628 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15629 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15630 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15631 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15632 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15633 => new StoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15634 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15635 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15636 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15637 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15638 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15639 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15640 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15641 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15642 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15643 => new StoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15644 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15645 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15646 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15647 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15648 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15649 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15650 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15651 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15652 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15653 => new StoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
