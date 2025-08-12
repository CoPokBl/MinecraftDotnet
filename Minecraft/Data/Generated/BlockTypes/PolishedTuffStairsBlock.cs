using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedTuffStairsBlock(Identifier Identifier, Direction Facing, PolishedTuffStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 950;
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
    public string SoundType => "polished_tuff";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_tuff_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 43;
    public string TranslationKey => "block.minecraft.polished_tuff_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22559,
                            false => 22560,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22561,
                            false => 22562,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22563,
                            false => 22564,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22565,
                            false => 22566,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22567,
                            false => 22568,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22569,
                            false => 22570,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22571,
                            false => 22572,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22573,
                            false => 22574,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22575,
                            false => 22576,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22577,
                            false => 22578,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22579,
                            false => 22580,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22581,
                            false => 22582,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22583,
                            false => 22584,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22585,
                            false => 22586,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22587,
                            false => 22588,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22589,
                            false => 22590,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22591,
                            false => 22592,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22593,
                            false => 22594,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22595,
                            false => 22596,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22597,
                            false => 22598,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22599,
                            false => 22600,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22601,
                            false => 22602,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22603,
                            false => 22604,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22605,
                            false => 22606,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22607,
                            false => 22608,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22609,
                            false => 22610,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22611,
                            false => 22612,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22613,
                            false => 22614,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22615,
                            false => 22616,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22617,
                            false => 22618,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22619,
                            false => 22620,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22621,
                            false => 22622,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22623,
                            false => 22624,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22625,
                            false => 22626,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22627,
                            false => 22628,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 22629,
                            false => 22630,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 22631,
                            false => 22632,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 22633,
                            false => 22634,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 22635,
                            false => 22636,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 22637,
                            false => 22638,
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
            22559 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            22560 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            22561 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            22562 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            22563 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            22564 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            22565 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            22566 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            22567 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            22568 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            22569 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            22570 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            22571 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            22572 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            22573 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            22574 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            22575 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            22576 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            22577 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            22578 => new PolishedTuffStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            22579 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            22580 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            22581 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            22582 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            22583 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            22584 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            22585 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            22586 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            22587 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            22588 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            22589 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            22590 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            22591 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            22592 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            22593 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            22594 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            22595 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            22596 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            22597 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            22598 => new PolishedTuffStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            22599 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            22600 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            22601 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            22602 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            22603 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            22604 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            22605 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            22606 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            22607 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            22608 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            22609 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            22610 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            22611 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            22612 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            22613 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            22614 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            22615 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            22616 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            22617 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            22618 => new PolishedTuffStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            22619 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            22620 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            22621 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            22622 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            22623 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            22624 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            22625 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            22626 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            22627 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            22628 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            22629 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            22630 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            22631 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            22632 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            22633 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            22634 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            22635 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            22636 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            22637 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            22638 => new PolishedTuffStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
