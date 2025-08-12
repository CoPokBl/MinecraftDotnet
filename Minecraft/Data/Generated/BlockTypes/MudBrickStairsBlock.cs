using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MudBrickStairsBlock(Identifier Identifier, Direction Facing, MudBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 341;
    public double Hardness => 1.5;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "mud_bricks";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:mud_brick_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.mud_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7560,
                            false => 7561,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7562,
                            false => 7563,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7564,
                            false => 7565,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7566,
                            false => 7567,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7568,
                            false => 7569,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7570,
                            false => 7571,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7572,
                            false => 7573,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7574,
                            false => 7575,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7576,
                            false => 7577,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7578,
                            false => 7579,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7580,
                            false => 7581,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7582,
                            false => 7583,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7584,
                            false => 7585,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7586,
                            false => 7587,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7588,
                            false => 7589,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7590,
                            false => 7591,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7592,
                            false => 7593,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7594,
                            false => 7595,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7596,
                            false => 7597,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7598,
                            false => 7599,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7600,
                            false => 7601,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7602,
                            false => 7603,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7604,
                            false => 7605,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7606,
                            false => 7607,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7608,
                            false => 7609,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7610,
                            false => 7611,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7612,
                            false => 7613,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7614,
                            false => 7615,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7616,
                            false => 7617,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7618,
                            false => 7619,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7620,
                            false => 7621,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7622,
                            false => 7623,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7624,
                            false => 7625,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7626,
                            false => 7627,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7628,
                            false => 7629,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 7630,
                            false => 7631,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 7632,
                            false => 7633,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 7634,
                            false => 7635,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 7636,
                            false => 7637,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 7638,
                            false => 7639,
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
            7560 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            7561 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            7562 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            7563 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            7564 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            7565 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            7566 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            7567 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            7568 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            7569 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            7570 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            7571 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            7572 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            7573 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            7574 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            7575 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            7576 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            7577 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            7578 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            7579 => new MudBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            7580 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            7581 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            7582 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            7583 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            7584 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            7585 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            7586 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            7587 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            7588 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            7589 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            7590 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            7591 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            7592 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            7593 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            7594 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            7595 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            7596 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            7597 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            7598 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            7599 => new MudBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            7600 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            7601 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            7602 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            7603 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            7604 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            7605 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            7606 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            7607 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            7608 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            7609 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            7610 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            7611 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            7612 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            7613 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            7614 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            7615 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            7616 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            7617 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            7618 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            7619 => new MudBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            7620 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            7621 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            7622 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            7623 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            7624 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            7625 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            7626 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            7627 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            7628 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            7629 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            7630 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            7631 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            7632 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            7633 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            7634 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            7635 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            7636 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            7637 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            7638 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            7639 => new MudBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
