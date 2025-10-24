using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceStairsBlock(Identifier Identifier, Direction Facing, SpruceStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 403;
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:spruce_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9527,
                            false => 9528,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9529,
                            false => 9530,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9531,
                            false => 9532,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9533,
                            false => 9534,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9535,
                            false => 9536,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9537,
                            false => 9538,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9539,
                            false => 9540,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9541,
                            false => 9542,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9543,
                            false => 9544,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9545,
                            false => 9546,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9547,
                            false => 9548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9549,
                            false => 9550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9551,
                            false => 9552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9553,
                            false => 9554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9555,
                            false => 9556,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9557,
                            false => 9558,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9559,
                            false => 9560,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9561,
                            false => 9562,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9563,
                            false => 9564,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9565,
                            false => 9566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9567,
                            false => 9568,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9569,
                            false => 9570,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9571,
                            false => 9572,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9573,
                            false => 9574,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9575,
                            false => 9576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9577,
                            false => 9578,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9579,
                            false => 9580,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9581,
                            false => 9582,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9583,
                            false => 9584,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9585,
                            false => 9586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9587,
                            false => 9588,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9589,
                            false => 9590,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9591,
                            false => 9592,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9593,
                            false => 9594,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9595,
                            false => 9596,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 9597,
                            false => 9598,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 9599,
                            false => 9600,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 9601,
                            false => 9602,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 9603,
                            false => 9604,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 9605,
                            false => 9606,
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
            9527 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            9528 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            9529 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            9530 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            9531 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            9532 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            9533 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            9534 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            9535 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            9536 => new SpruceStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            9537 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            9538 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            9539 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            9540 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            9541 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            9542 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            9543 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            9544 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            9545 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            9546 => new SpruceStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            9547 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            9548 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            9549 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            9550 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            9551 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            9552 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            9553 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            9554 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            9555 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            9556 => new SpruceStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            9557 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            9558 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            9559 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            9560 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            9561 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            9562 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            9563 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            9564 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            9565 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            9566 => new SpruceStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            9567 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            9568 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            9569 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            9570 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            9571 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            9572 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            9573 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            9574 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            9575 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            9576 => new SpruceStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            9577 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            9578 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            9579 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            9580 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            9581 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            9582 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            9583 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            9584 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            9585 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            9586 => new SpruceStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            9587 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            9588 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            9589 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            9590 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            9591 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            9592 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            9593 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            9594 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            9595 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            9596 => new SpruceStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            9597 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            9598 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            9599 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            9600 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            9601 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            9602 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            9603 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            9604 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            9605 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            9606 => new SpruceStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
