using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutCopperStairsBlock(Identifier Identifier, Direction Facing, CutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_stair";
    public int ProtocolId => 1026;
    public double Hardness => 3;
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
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25365,
                            false => 25366,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25367,
                            false => 25368,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25369,
                            false => 25370,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25371,
                            false => 25372,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25373,
                            false => 25374,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25375,
                            false => 25376,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25377,
                            false => 25378,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25379,
                            false => 25380,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25381,
                            false => 25382,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25383,
                            false => 25384,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25385,
                            false => 25386,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25387,
                            false => 25388,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25389,
                            false => 25390,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25391,
                            false => 25392,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25393,
                            false => 25394,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25395,
                            false => 25396,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25397,
                            false => 25398,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25399,
                            false => 25400,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25401,
                            false => 25402,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25403,
                            false => 25404,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25405,
                            false => 25406,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25407,
                            false => 25408,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25409,
                            false => 25410,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25411,
                            false => 25412,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25413,
                            false => 25414,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25415,
                            false => 25416,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25417,
                            false => 25418,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25419,
                            false => 25420,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25421,
                            false => 25422,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25423,
                            false => 25424,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25425,
                            false => 25426,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25427,
                            false => 25428,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25429,
                            false => 25430,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25431,
                            false => 25432,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25433,
                            false => 25434,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 25435,
                            false => 25436,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 25437,
                            false => 25438,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 25439,
                            false => 25440,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 25441,
                            false => 25442,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 25443,
                            false => 25444,
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
            25365 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            25366 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            25367 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            25368 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            25369 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            25370 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            25371 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            25372 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            25373 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            25374 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            25375 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            25376 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            25377 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            25378 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            25379 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            25380 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            25381 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            25382 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            25383 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            25384 => new CutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            25385 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            25386 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            25387 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            25388 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            25389 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            25390 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            25391 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            25392 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            25393 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            25394 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            25395 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            25396 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            25397 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            25398 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            25399 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            25400 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            25401 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            25402 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            25403 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            25404 => new CutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            25405 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            25406 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            25407 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            25408 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            25409 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            25410 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            25411 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            25412 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            25413 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            25414 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            25415 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            25416 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            25417 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            25418 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            25419 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            25420 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            25421 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            25422 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            25423 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            25424 => new CutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            25425 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            25426 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            25427 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            25428 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            25429 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            25430 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            25431 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            25432 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            25433 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            25434 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            25435 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            25436 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            25437 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            25438 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            25439 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            25440 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            25441 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            25442 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            25443 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            25444 => new CutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
