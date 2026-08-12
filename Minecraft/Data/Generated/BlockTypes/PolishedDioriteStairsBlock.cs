using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDioriteStairsBlock(Identifier Identifier, Direction Facing, PolishedDioriteStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:polished_diorite_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.polished_diorite_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15536,
                            false => 15537,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15538,
                            false => 15539,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15540,
                            false => 15541,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15542,
                            false => 15543,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15544,
                            false => 15545,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15546,
                            false => 15547,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15548,
                            false => 15549,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15550,
                            false => 15551,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15552,
                            false => 15553,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15554,
                            false => 15555,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15556,
                            false => 15557,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15558,
                            false => 15559,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15560,
                            false => 15561,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15562,
                            false => 15563,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15564,
                            false => 15565,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15566,
                            false => 15567,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15568,
                            false => 15569,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15570,
                            false => 15571,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15572,
                            false => 15573,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15574,
                            false => 15575,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15576,
                            false => 15577,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15578,
                            false => 15579,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15580,
                            false => 15581,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15582,
                            false => 15583,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15584,
                            false => 15585,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15586,
                            false => 15587,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15588,
                            false => 15589,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15590,
                            false => 15591,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15592,
                            false => 15593,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15594,
                            false => 15595,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15596,
                            false => 15597,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15598,
                            false => 15599,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15600,
                            false => 15601,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15602,
                            false => 15603,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15604,
                            false => 15605,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15606,
                            false => 15607,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15608,
                            false => 15609,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15610,
                            false => 15611,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15612,
                            false => 15613,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15614,
                            false => 15615,
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
            15536 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15537 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15538 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15539 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15540 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15541 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15542 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15543 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15544 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15545 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15546 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15547 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15548 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15549 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15550 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15551 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15552 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15553 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15554 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15555 => new PolishedDioriteStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15556 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15557 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15558 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15559 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15560 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15561 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15562 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15563 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15564 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15565 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15566 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15567 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15568 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15569 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15570 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15571 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15572 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15573 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15574 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15575 => new PolishedDioriteStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15576 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15577 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15578 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15579 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15580 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15581 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15582 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15583 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15584 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15585 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15586 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15587 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15588 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15589 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15590 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15591 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15592 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15593 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15594 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15595 => new PolishedDioriteStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15596 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15597 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15598 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15599 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15600 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15601 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15602 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15603 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15604 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15605 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15606 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15607 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15608 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15609 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15610 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15611 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15612 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15613 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15614 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15615 => new PolishedDioriteStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Shape = properties.Contains("shape") ? StairShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
