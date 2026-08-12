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
    public Identifier Category => "minecraft:trapdoor";
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
                                true => 7562,
                                false => 7563,
                            },
                            false => Waterlogged switch {
                                true => 7564,
                                false => 7565,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7566,
                                false => 7567,
                            },
                            false => Waterlogged switch {
                                true => 7568,
                                false => 7569,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7570,
                                false => 7571,
                            },
                            false => Waterlogged switch {
                                true => 7572,
                                false => 7573,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7574,
                                false => 7575,
                            },
                            false => Waterlogged switch {
                                true => 7576,
                                false => 7577,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7578,
                                false => 7579,
                            },
                            false => Waterlogged switch {
                                true => 7580,
                                false => 7581,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7582,
                                false => 7583,
                            },
                            false => Waterlogged switch {
                                true => 7584,
                                false => 7585,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7586,
                                false => 7587,
                            },
                            false => Waterlogged switch {
                                true => 7588,
                                false => 7589,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7590,
                                false => 7591,
                            },
                            false => Waterlogged switch {
                                true => 7592,
                                false => 7593,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7594,
                                false => 7595,
                            },
                            false => Waterlogged switch {
                                true => 7596,
                                false => 7597,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7598,
                                false => 7599,
                            },
                            false => Waterlogged switch {
                                true => 7600,
                                false => 7601,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7602,
                                false => 7603,
                            },
                            false => Waterlogged switch {
                                true => 7604,
                                false => 7605,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7606,
                                false => 7607,
                            },
                            false => Waterlogged switch {
                                true => 7608,
                                false => 7609,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7610,
                                false => 7611,
                            },
                            false => Waterlogged switch {
                                true => 7612,
                                false => 7613,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7614,
                                false => 7615,
                            },
                            false => Waterlogged switch {
                                true => 7616,
                                false => 7617,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7618,
                                false => 7619,
                            },
                            false => Waterlogged switch {
                                true => 7620,
                                false => 7621,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7622,
                                false => 7623,
                            },
                            false => Waterlogged switch {
                                true => 7624,
                                false => 7625,
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
            7562 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7563 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7564 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7565 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7566 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7567 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7568 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7569 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7570 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7571 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7572 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7573 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7574 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7575 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7576 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7577 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7578 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7579 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7580 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7581 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7582 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7583 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7584 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7585 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7586 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7587 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7588 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7589 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7590 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7591 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7592 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7593 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7594 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7595 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7596 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7597 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7598 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7599 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7600 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7601 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7602 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7603 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7604 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7605 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7606 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7607 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7608 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7609 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7610 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7611 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7612 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7613 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7614 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7615 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7616 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7617 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7618 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7619 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7620 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7621 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7622 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7623 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7624 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7625 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
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
