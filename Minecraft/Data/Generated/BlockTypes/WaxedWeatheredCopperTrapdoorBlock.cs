using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedWeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 1024;
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
    public Identifier? Item => "minecraft:waxed_weathered_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25672,
                                false => 25673,
                            },
                            false => Waterlogged switch {
                                true => 25674,
                                false => 25675,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25676,
                                false => 25677,
                            },
                            false => Waterlogged switch {
                                true => 25678,
                                false => 25679,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25680,
                                false => 25681,
                            },
                            false => Waterlogged switch {
                                true => 25682,
                                false => 25683,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25684,
                                false => 25685,
                            },
                            false => Waterlogged switch {
                                true => 25686,
                                false => 25687,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25688,
                                false => 25689,
                            },
                            false => Waterlogged switch {
                                true => 25690,
                                false => 25691,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25692,
                                false => 25693,
                            },
                            false => Waterlogged switch {
                                true => 25694,
                                false => 25695,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25696,
                                false => 25697,
                            },
                            false => Waterlogged switch {
                                true => 25698,
                                false => 25699,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25700,
                                false => 25701,
                            },
                            false => Waterlogged switch {
                                true => 25702,
                                false => 25703,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25704,
                                false => 25705,
                            },
                            false => Waterlogged switch {
                                true => 25706,
                                false => 25707,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25708,
                                false => 25709,
                            },
                            false => Waterlogged switch {
                                true => 25710,
                                false => 25711,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25712,
                                false => 25713,
                            },
                            false => Waterlogged switch {
                                true => 25714,
                                false => 25715,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25716,
                                false => 25717,
                            },
                            false => Waterlogged switch {
                                true => 25718,
                                false => 25719,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25720,
                                false => 25721,
                            },
                            false => Waterlogged switch {
                                true => 25722,
                                false => 25723,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25724,
                                false => 25725,
                            },
                            false => Waterlogged switch {
                                true => 25726,
                                false => 25727,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25728,
                                false => 25729,
                            },
                            false => Waterlogged switch {
                                true => 25730,
                                false => 25731,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25732,
                                false => 25733,
                            },
                            false => Waterlogged switch {
                                true => 25734,
                                false => 25735,
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
            25672 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25673 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25674 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25675 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25676 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25677 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25678 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25679 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25680 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25681 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25682 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25683 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25684 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25685 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25686 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25687 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25688 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25689 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25690 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25691 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25692 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25693 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25694 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25695 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25696 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25697 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25698 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25699 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25700 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25701 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25702 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25703 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25704 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25705 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25706 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25707 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25708 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25709 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25710 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25711 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25712 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25713 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25714 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25715 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25716 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25717 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25718 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25719 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25720 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25721 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25722 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25723 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25724 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25725 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25726 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25727 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25728 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25729 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25730 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25731 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25732 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25733 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25734 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25735 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
