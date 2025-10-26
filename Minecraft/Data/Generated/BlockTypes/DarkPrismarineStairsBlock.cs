using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkPrismarineStairsBlock(Identifier Identifier, Direction Facing, DarkPrismarineStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 530;
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
    public Identifier? Item => "minecraft:dark_prismarine_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 31;
    public string TranslationKey => "block.minecraft.dark_prismarine_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12592,
                            false => 12593,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12594,
                            false => 12595,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12596,
                            false => 12597,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12598,
                            false => 12599,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12600,
                            false => 12601,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12602,
                            false => 12603,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12604,
                            false => 12605,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12606,
                            false => 12607,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12608,
                            false => 12609,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12610,
                            false => 12611,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12612,
                            false => 12613,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12614,
                            false => 12615,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12616,
                            false => 12617,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12618,
                            false => 12619,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12620,
                            false => 12621,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12622,
                            false => 12623,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12624,
                            false => 12625,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12626,
                            false => 12627,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12628,
                            false => 12629,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12630,
                            false => 12631,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12632,
                            false => 12633,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12634,
                            false => 12635,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12636,
                            false => 12637,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12638,
                            false => 12639,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12640,
                            false => 12641,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12642,
                            false => 12643,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12644,
                            false => 12645,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12646,
                            false => 12647,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12648,
                            false => 12649,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12650,
                            false => 12651,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12652,
                            false => 12653,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12654,
                            false => 12655,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12656,
                            false => 12657,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12658,
                            false => 12659,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12660,
                            false => 12661,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 12662,
                            false => 12663,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 12664,
                            false => 12665,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 12666,
                            false => 12667,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 12668,
                            false => 12669,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 12670,
                            false => 12671,
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
            12592 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            12593 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            12594 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            12595 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            12596 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            12597 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            12598 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            12599 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            12600 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            12601 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            12602 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            12603 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            12604 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            12605 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            12606 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            12607 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            12608 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            12609 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            12610 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            12611 => new DarkPrismarineStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            12612 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            12613 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            12614 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            12615 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            12616 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            12617 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            12618 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            12619 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            12620 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            12621 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            12622 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            12623 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            12624 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            12625 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            12626 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            12627 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            12628 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            12629 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            12630 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            12631 => new DarkPrismarineStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            12632 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            12633 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            12634 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            12635 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            12636 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            12637 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            12638 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            12639 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            12640 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            12641 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            12642 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            12643 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            12644 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            12645 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            12646 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            12647 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            12648 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            12649 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            12650 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            12651 => new DarkPrismarineStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            12652 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            12653 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            12654 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            12655 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            12656 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            12657 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            12658 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            12659 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            12660 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            12661 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            12662 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            12663 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            12664 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            12665 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            12666 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            12667 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            12668 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            12669 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            12670 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            12671 => new DarkPrismarineStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
