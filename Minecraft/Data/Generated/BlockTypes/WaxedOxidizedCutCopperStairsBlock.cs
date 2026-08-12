using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCutCopperStairsBlock(Identifier Identifier, Direction Facing, WaxedOxidizedCutCopperStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
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
    public Identifier? Item => "minecraft:waxed_oxidized_cut_copper_stairs";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0], AABB[0.0, 0.5, 0.0] -> [1.0, 1.0, 0.5]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_cut_copper_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28368,
                            false => 28369,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28370,
                            false => 28371,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28372,
                            false => 28373,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28374,
                            false => 28375,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28376,
                            false => 28377,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28378,
                            false => 28379,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28380,
                            false => 28381,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28382,
                            false => 28383,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28384,
                            false => 28385,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28386,
                            false => 28387,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28388,
                            false => 28389,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28390,
                            false => 28391,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28392,
                            false => 28393,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28394,
                            false => 28395,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28396,
                            false => 28397,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28398,
                            false => 28399,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28400,
                            false => 28401,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28402,
                            false => 28403,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28404,
                            false => 28405,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28406,
                            false => 28407,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28408,
                            false => 28409,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28410,
                            false => 28411,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28412,
                            false => 28413,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28414,
                            false => 28415,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28416,
                            false => 28417,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28418,
                            false => 28419,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28420,
                            false => 28421,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28422,
                            false => 28423,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28424,
                            false => 28425,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28426,
                            false => 28427,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28428,
                            false => 28429,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28430,
                            false => 28431,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28432,
                            false => 28433,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28434,
                            false => 28435,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28436,
                            false => 28437,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28438,
                            false => 28439,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28440,
                            false => 28441,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28442,
                            false => 28443,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28444,
                            false => 28445,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28446,
                            false => 28447,
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
            28368 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28369 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28370 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28371 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28372 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28373 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28374 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28375 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28376 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28377 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28378 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28379 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28380 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28381 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28382 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28383 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28384 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28385 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28386 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28387 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28388 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28389 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28390 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28391 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28392 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28393 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28394 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28395 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28396 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28397 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28398 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28399 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28400 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28401 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28402 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28403 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28404 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28405 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28406 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28407 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28408 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28409 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28410 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28411 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28412 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28413 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28414 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28415 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28416 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28417 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28418 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28419 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28420 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28421 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28422 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28423 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28424 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28425 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28426 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28427 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28428 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28429 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28430 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28431 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28432 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28433 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28434 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28435 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28436 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28437 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28438 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28439 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28440 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28441 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28442 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28443 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28444 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28445 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28446 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28447 => new WaxedOxidizedCutCopperStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
