using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MossyCobblestoneStairsBlock(Identifier Identifier, Direction Facing, MossyCobblestoneStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 799;
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
    public Identifier? Item => "minecraft:mossy_cobblestone_stairs";
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
    public string TranslationKey => "block.minecraft.mossy_cobblestone_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15414,
                            false => 15415,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15416,
                            false => 15417,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15418,
                            false => 15419,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15420,
                            false => 15421,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15422,
                            false => 15423,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15424,
                            false => 15425,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15426,
                            false => 15427,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15428,
                            false => 15429,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15430,
                            false => 15431,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15432,
                            false => 15433,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15434,
                            false => 15435,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15436,
                            false => 15437,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15438,
                            false => 15439,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15440,
                            false => 15441,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15442,
                            false => 15443,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15444,
                            false => 15445,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15446,
                            false => 15447,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15448,
                            false => 15449,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15450,
                            false => 15451,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15452,
                            false => 15453,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15454,
                            false => 15455,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15456,
                            false => 15457,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15458,
                            false => 15459,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15460,
                            false => 15461,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15462,
                            false => 15463,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15464,
                            false => 15465,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15466,
                            false => 15467,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15468,
                            false => 15469,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15470,
                            false => 15471,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15472,
                            false => 15473,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15474,
                            false => 15475,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15476,
                            false => 15477,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15478,
                            false => 15479,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15480,
                            false => 15481,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15482,
                            false => 15483,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 15484,
                            false => 15485,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 15486,
                            false => 15487,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 15488,
                            false => 15489,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 15490,
                            false => 15491,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 15492,
                            false => 15493,
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
            15414 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            15415 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            15416 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            15417 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            15418 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            15419 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            15420 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            15421 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            15422 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            15423 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            15424 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            15425 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            15426 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            15427 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            15428 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            15429 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            15430 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            15431 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            15432 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            15433 => new MossyCobblestoneStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            15434 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            15435 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            15436 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            15437 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            15438 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            15439 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            15440 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            15441 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            15442 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            15443 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            15444 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            15445 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            15446 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            15447 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            15448 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            15449 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            15450 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            15451 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            15452 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            15453 => new MossyCobblestoneStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            15454 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            15455 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            15456 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            15457 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            15458 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            15459 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            15460 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            15461 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            15462 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            15463 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            15464 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            15465 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            15466 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            15467 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            15468 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            15469 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            15470 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            15471 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            15472 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            15473 => new MossyCobblestoneStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            15474 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            15475 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            15476 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            15477 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            15478 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            15479 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            15480 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            15481 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            15482 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            15483 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            15484 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            15485 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            15486 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            15487 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            15488 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            15489 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            15490 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            15491 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            15492 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            15493 => new MossyCobblestoneStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
