using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedDeepslateStairsBlock(Identifier Identifier, Direction Facing, PolishedDeepslateStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1066;
    public double Hardness => 3.5;
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
    public string SoundType => "polished_deepslate";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:polished_deepslate_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 59;
    public string TranslationKey => "block.minecraft.polished_deepslate_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26411,
                            false => 26412,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26413,
                            false => 26414,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26415,
                            false => 26416,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26417,
                            false => 26418,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26419,
                            false => 26420,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26421,
                            false => 26422,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26423,
                            false => 26424,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26425,
                            false => 26426,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26427,
                            false => 26428,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26429,
                            false => 26430,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26431,
                            false => 26432,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26433,
                            false => 26434,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26435,
                            false => 26436,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26437,
                            false => 26438,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26439,
                            false => 26440,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26441,
                            false => 26442,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26443,
                            false => 26444,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26445,
                            false => 26446,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26447,
                            false => 26448,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26449,
                            false => 26450,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26451,
                            false => 26452,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26453,
                            false => 26454,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26455,
                            false => 26456,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26457,
                            false => 26458,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26459,
                            false => 26460,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26461,
                            false => 26462,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26463,
                            false => 26464,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26465,
                            false => 26466,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26467,
                            false => 26468,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26469,
                            false => 26470,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26471,
                            false => 26472,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26473,
                            false => 26474,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26475,
                            false => 26476,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26477,
                            false => 26478,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26479,
                            false => 26480,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 26481,
                            false => 26482,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 26483,
                            false => 26484,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 26485,
                            false => 26486,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 26487,
                            false => 26488,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 26489,
                            false => 26490,
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
            26411 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            26412 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            26413 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            26414 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            26415 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            26416 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            26417 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            26418 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            26419 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            26420 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            26421 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            26422 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            26423 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            26424 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            26425 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            26426 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            26427 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            26428 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            26429 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            26430 => new PolishedDeepslateStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            26431 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            26432 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            26433 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            26434 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            26435 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            26436 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            26437 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            26438 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            26439 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            26440 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            26441 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            26442 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            26443 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            26444 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            26445 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            26446 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            26447 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            26448 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            26449 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            26450 => new PolishedDeepslateStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            26451 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            26452 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            26453 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            26454 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            26455 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            26456 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            26457 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            26458 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            26459 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            26460 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            26461 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            26462 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            26463 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            26464 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            26465 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            26466 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            26467 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            26468 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            26469 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            26470 => new PolishedDeepslateStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            26471 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            26472 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            26473 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            26474 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            26475 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            26476 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            26477 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            26478 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            26479 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            26480 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            26481 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            26482 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            26483 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            26484 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            26485 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            26486 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            26487 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            26488 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            26489 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            26490 => new PolishedDeepslateStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
