using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakTrapdoorBlock(Identifier Identifier, Direction Facing, PaleOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_oak_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6588,
                                false => 6589,
                            },
                            false => Waterlogged switch {
                                true => 6590,
                                false => 6591,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6592,
                                false => 6593,
                            },
                            false => Waterlogged switch {
                                true => 6594,
                                false => 6595,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6596,
                                false => 6597,
                            },
                            false => Waterlogged switch {
                                true => 6598,
                                false => 6599,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6600,
                                false => 6601,
                            },
                            false => Waterlogged switch {
                                true => 6602,
                                false => 6603,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6604,
                                false => 6605,
                            },
                            false => Waterlogged switch {
                                true => 6606,
                                false => 6607,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6608,
                                false => 6609,
                            },
                            false => Waterlogged switch {
                                true => 6610,
                                false => 6611,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6612,
                                false => 6613,
                            },
                            false => Waterlogged switch {
                                true => 6614,
                                false => 6615,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6616,
                                false => 6617,
                            },
                            false => Waterlogged switch {
                                true => 6618,
                                false => 6619,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6620,
                                false => 6621,
                            },
                            false => Waterlogged switch {
                                true => 6622,
                                false => 6623,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6624,
                                false => 6625,
                            },
                            false => Waterlogged switch {
                                true => 6626,
                                false => 6627,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6628,
                                false => 6629,
                            },
                            false => Waterlogged switch {
                                true => 6630,
                                false => 6631,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6632,
                                false => 6633,
                            },
                            false => Waterlogged switch {
                                true => 6634,
                                false => 6635,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6636,
                                false => 6637,
                            },
                            false => Waterlogged switch {
                                true => 6638,
                                false => 6639,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6640,
                                false => 6641,
                            },
                            false => Waterlogged switch {
                                true => 6642,
                                false => 6643,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6644,
                                false => 6645,
                            },
                            false => Waterlogged switch {
                                true => 6646,
                                false => 6647,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6648,
                                false => 6649,
                            },
                            false => Waterlogged switch {
                                true => 6650,
                                false => 6651,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6588 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6589 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6590 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6591 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6592 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6593 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6594 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6595 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6596 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6597 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6598 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6599 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6600 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6601 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6602 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6603 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6604 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6605 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6606 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6607 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6608 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6609 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6610 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6611 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6612 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6613 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6614 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6615 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6616 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6617 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6618 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6619 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6620 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6621 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6622 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6623 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6624 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6625 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6626 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6627 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6628 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6629 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6630 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6631 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6632 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6633 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6634 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6635 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6636 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6637 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6638 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6639 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6640 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6641 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6642 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6643 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6644 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6645 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6646 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6647 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6648 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6649 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6650 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6651 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
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
