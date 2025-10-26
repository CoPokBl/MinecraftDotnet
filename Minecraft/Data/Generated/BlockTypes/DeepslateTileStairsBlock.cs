using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateTileStairsBlock(Identifier Identifier, Direction Facing, DeepslateTileStairsBlock.Half HalfValue, StairShape Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:stair";
    public int ProtocolId => 1131;
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
    public string SoundType => "deepslate_tiles";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:deepslate_tile_stairs";
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
    public string TranslationKey => "block.minecraft.deepslate_tile_stairs";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28547,
                            false => 28548,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28549,
                            false => 28550,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28551,
                            false => 28552,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28553,
                            false => 28554,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28555,
                            false => 28556,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28557,
                            false => 28558,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28559,
                            false => 28560,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28561,
                            false => 28562,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28563,
                            false => 28564,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28565,
                            false => 28566,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28567,
                            false => 28568,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28569,
                            false => 28570,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28571,
                            false => 28572,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28573,
                            false => 28574,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28575,
                            false => 28576,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28577,
                            false => 28578,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28579,
                            false => 28580,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28581,
                            false => 28582,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28583,
                            false => 28584,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28585,
                            false => 28586,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28587,
                            false => 28588,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28589,
                            false => 28590,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28591,
                            false => 28592,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28593,
                            false => 28594,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28595,
                            false => 28596,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28597,
                            false => 28598,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28599,
                            false => 28600,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28601,
                            false => 28602,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28603,
                            false => 28604,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28605,
                            false => 28606,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28607,
                            false => 28608,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28609,
                            false => 28610,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28611,
                            false => 28612,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28613,
                            false => 28614,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28615,
                            false => 28616,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                    },
                    Half.Bottom => Shape switch {
                        StairShape.Straight => Waterlogged switch {
                            true => 28617,
                            false => 28618,
                        },
                        StairShape.InnerLeft => Waterlogged switch {
                            true => 28619,
                            false => 28620,
                        },
                        StairShape.InnerRight => Waterlogged switch {
                            true => 28621,
                            false => 28622,
                        },
                        StairShape.OuterLeft => Waterlogged switch {
                            true => 28623,
                            false => 28624,
                        },
                        StairShape.OuterRight => Waterlogged switch {
                            true => 28625,
                            false => 28626,
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
            28547 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, true),
            28548 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.Straight, false),
            28549 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, true),
            28550 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerLeft, false),
            28551 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, true),
            28552 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.InnerRight, false),
            28553 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, true),
            28554 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterLeft, false),
            28555 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, true),
            28556 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Top, StairShape.OuterRight, false),
            28557 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, true),
            28558 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.Straight, false),
            28559 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, true),
            28560 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerLeft, false),
            28561 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, true),
            28562 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.InnerRight, false),
            28563 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, true),
            28564 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterLeft, false),
            28565 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, true),
            28566 => new DeepslateTileStairsBlock(Identifier, Direction.North, Half.Bottom, StairShape.OuterRight, false),
            28567 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, true),
            28568 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.Straight, false),
            28569 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, true),
            28570 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerLeft, false),
            28571 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, true),
            28572 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.InnerRight, false),
            28573 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, true),
            28574 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterLeft, false),
            28575 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, true),
            28576 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Top, StairShape.OuterRight, false),
            28577 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, true),
            28578 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.Straight, false),
            28579 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, true),
            28580 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerLeft, false),
            28581 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, true),
            28582 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.InnerRight, false),
            28583 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, true),
            28584 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterLeft, false),
            28585 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, true),
            28586 => new DeepslateTileStairsBlock(Identifier, Direction.South, Half.Bottom, StairShape.OuterRight, false),
            28587 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, true),
            28588 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.Straight, false),
            28589 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, true),
            28590 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerLeft, false),
            28591 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, true),
            28592 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.InnerRight, false),
            28593 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, true),
            28594 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterLeft, false),
            28595 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, true),
            28596 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Top, StairShape.OuterRight, false),
            28597 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, true),
            28598 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.Straight, false),
            28599 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, true),
            28600 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerLeft, false),
            28601 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, true),
            28602 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.InnerRight, false),
            28603 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, true),
            28604 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterLeft, false),
            28605 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, true),
            28606 => new DeepslateTileStairsBlock(Identifier, Direction.West, Half.Bottom, StairShape.OuterRight, false),
            28607 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, true),
            28608 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.Straight, false),
            28609 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, true),
            28610 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerLeft, false),
            28611 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, true),
            28612 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.InnerRight, false),
            28613 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, true),
            28614 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterLeft, false),
            28615 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, true),
            28616 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Top, StairShape.OuterRight, false),
            28617 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, true),
            28618 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.Straight, false),
            28619 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, true),
            28620 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerLeft, false),
            28621 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, true),
            28622 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.InnerRight, false),
            28623 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, true),
            28624 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterLeft, false),
            28625 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, true),
            28626 => new DeepslateTileStairsBlock(Identifier, Direction.East, Half.Bottom, StairShape.OuterRight, false),
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
