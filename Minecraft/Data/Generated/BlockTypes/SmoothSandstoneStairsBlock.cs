using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmoothSandstoneStairsBlock(Identifier Identifier, Direction Facing, SmoothSandstoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 772;
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
    public Identifier? Item => "minecraft:smooth_sandstone_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.smooth_sandstone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14577,
                            false => 14578,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14579,
                            false => 14580,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14581,
                            false => 14582,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14583,
                            false => 14584,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14585,
                            false => 14586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14587,
                            false => 14588,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14589,
                            false => 14590,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14591,
                            false => 14592,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14593,
                            false => 14594,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14595,
                            false => 14596,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14597,
                            false => 14598,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14599,
                            false => 14600,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14601,
                            false => 14602,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14603,
                            false => 14604,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14605,
                            false => 14606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14607,
                            false => 14608,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14609,
                            false => 14610,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14611,
                            false => 14612,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14613,
                            false => 14614,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14615,
                            false => 14616,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14617,
                            false => 14618,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14619,
                            false => 14620,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14621,
                            false => 14622,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14623,
                            false => 14624,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14625,
                            false => 14626,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14627,
                            false => 14628,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14629,
                            false => 14630,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14631,
                            false => 14632,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14633,
                            false => 14634,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14635,
                            false => 14636,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14637,
                            false => 14638,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14639,
                            false => 14640,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14641,
                            false => 14642,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14643,
                            false => 14644,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14645,
                            false => 14646,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 14647,
                            false => 14648,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 14649,
                            false => 14650,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 14651,
                            false => 14652,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 14653,
                            false => 14654,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 14655,
                            false => 14656,
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
            14577 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            14578 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            14579 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            14580 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            14581 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            14582 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            14583 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            14584 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            14585 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            14586 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            14587 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            14588 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            14589 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            14590 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            14591 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            14592 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            14593 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            14594 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            14595 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            14596 => new SmoothSandstoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            14597 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            14598 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            14599 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            14600 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            14601 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            14602 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            14603 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            14604 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            14605 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            14606 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            14607 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            14608 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            14609 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            14610 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            14611 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            14612 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            14613 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            14614 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            14615 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            14616 => new SmoothSandstoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            14617 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            14618 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            14619 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            14620 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            14621 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            14622 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            14623 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            14624 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            14625 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            14626 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            14627 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            14628 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            14629 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            14630 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            14631 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            14632 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            14633 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            14634 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            14635 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            14636 => new SmoothSandstoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            14637 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            14638 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            14639 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            14640 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            14641 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            14642 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            14643 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            14644 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            14645 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            14646 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            14647 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            14648 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            14649 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            14650 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            14651 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            14652 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            14653 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            14654 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            14655 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            14656 => new SmoothSandstoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
