using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 1059;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.waxed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26589,
                                false => 26590,
                            },
                            false => Waterlogged switch {
                                true => 26591,
                                false => 26592,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26593,
                                false => 26594,
                            },
                            false => Waterlogged switch {
                                true => 26595,
                                false => 26596,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26597,
                                false => 26598,
                            },
                            false => Waterlogged switch {
                                true => 26599,
                                false => 26600,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26601,
                                false => 26602,
                            },
                            false => Waterlogged switch {
                                true => 26603,
                                false => 26604,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26605,
                                false => 26606,
                            },
                            false => Waterlogged switch {
                                true => 26607,
                                false => 26608,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26609,
                                false => 26610,
                            },
                            false => Waterlogged switch {
                                true => 26611,
                                false => 26612,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26613,
                                false => 26614,
                            },
                            false => Waterlogged switch {
                                true => 26615,
                                false => 26616,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26617,
                                false => 26618,
                            },
                            false => Waterlogged switch {
                                true => 26619,
                                false => 26620,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26621,
                                false => 26622,
                            },
                            false => Waterlogged switch {
                                true => 26623,
                                false => 26624,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26625,
                                false => 26626,
                            },
                            false => Waterlogged switch {
                                true => 26627,
                                false => 26628,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26629,
                                false => 26630,
                            },
                            false => Waterlogged switch {
                                true => 26631,
                                false => 26632,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26633,
                                false => 26634,
                            },
                            false => Waterlogged switch {
                                true => 26635,
                                false => 26636,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26637,
                                false => 26638,
                            },
                            false => Waterlogged switch {
                                true => 26639,
                                false => 26640,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26641,
                                false => 26642,
                            },
                            false => Waterlogged switch {
                                true => 26643,
                                false => 26644,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26645,
                                false => 26646,
                            },
                            false => Waterlogged switch {
                                true => 26647,
                                false => 26648,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26649,
                                false => 26650,
                            },
                            false => Waterlogged switch {
                                true => 26651,
                                false => 26652,
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
            26589 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26590 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26591 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26592 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26593 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26594 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26595 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26596 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26597 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26598 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26599 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26600 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26601 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26602 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26603 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26604 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26605 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26606 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26607 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26608 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26609 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26610 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26611 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26612 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26613 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26614 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26615 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26616 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26617 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26618 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26619 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26620 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26621 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26622 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26623 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26624 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26625 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26626 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26627 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26628 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26629 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26630 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26631 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26632 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26633 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26634 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26635 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26636 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26637 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26638 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26639 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26640 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26641 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26642 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26643 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26644 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26645 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26646 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26647 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26648 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26649 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26650 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26651 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26652 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
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
