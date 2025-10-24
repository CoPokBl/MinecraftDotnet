using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StoneBrickStairsBlock(Identifier Identifier, Direction Facing, StoneBrickStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 370;
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
    public Identifier? Item => "minecraft:stone_brick_stairs";
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
    public string TranslationKey => "block.minecraft.stone_brick_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8557,
                            false => 8558,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8559,
                            false => 8560,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8561,
                            false => 8562,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8563,
                            false => 8564,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8565,
                            false => 8566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8567,
                            false => 8568,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8569,
                            false => 8570,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8571,
                            false => 8572,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8573,
                            false => 8574,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8575,
                            false => 8576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8577,
                            false => 8578,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8579,
                            false => 8580,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8581,
                            false => 8582,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8583,
                            false => 8584,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8585,
                            false => 8586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8587,
                            false => 8588,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8589,
                            false => 8590,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8591,
                            false => 8592,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8593,
                            false => 8594,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8595,
                            false => 8596,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8597,
                            false => 8598,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8599,
                            false => 8600,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8601,
                            false => 8602,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8603,
                            false => 8604,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8605,
                            false => 8606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8607,
                            false => 8608,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8609,
                            false => 8610,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8611,
                            false => 8612,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8613,
                            false => 8614,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8615,
                            false => 8616,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8617,
                            false => 8618,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8619,
                            false => 8620,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8621,
                            false => 8622,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8623,
                            false => 8624,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8625,
                            false => 8626,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 8627,
                            false => 8628,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 8629,
                            false => 8630,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 8631,
                            false => 8632,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 8633,
                            false => 8634,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 8635,
                            false => 8636,
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
            8557 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            8558 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            8559 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            8560 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            8561 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            8562 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            8563 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            8564 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            8565 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            8566 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            8567 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            8568 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            8569 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            8570 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            8571 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            8572 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            8573 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            8574 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            8575 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            8576 => new StoneBrickStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            8577 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            8578 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            8579 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            8580 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            8581 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            8582 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            8583 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            8584 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            8585 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            8586 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            8587 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            8588 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            8589 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            8590 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            8591 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            8592 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            8593 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            8594 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            8595 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            8596 => new StoneBrickStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            8597 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            8598 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            8599 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            8600 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            8601 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            8602 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            8603 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            8604 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            8605 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            8606 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            8607 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            8608 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            8609 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            8610 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            8611 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            8612 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            8613 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            8614 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            8615 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            8616 => new StoneBrickStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            8617 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            8618 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            8619 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            8620 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            8621 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            8622 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            8623 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            8624 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            8625 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            8626 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            8627 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            8628 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            8629 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            8630 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            8631 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            8632 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            8633 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            8634 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            8635 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            8636 => new StoneBrickStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
