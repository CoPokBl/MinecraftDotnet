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
    public int ProtocolId => 1062;
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
                                true => 26781,
                                false => 26782,
                            },
                            false => Waterlogged switch {
                                true => 26783,
                                false => 26784,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26785,
                                false => 26786,
                            },
                            false => Waterlogged switch {
                                true => 26787,
                                false => 26788,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26789,
                                false => 26790,
                            },
                            false => Waterlogged switch {
                                true => 26791,
                                false => 26792,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26793,
                                false => 26794,
                            },
                            false => Waterlogged switch {
                                true => 26795,
                                false => 26796,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26797,
                                false => 26798,
                            },
                            false => Waterlogged switch {
                                true => 26799,
                                false => 26800,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26801,
                                false => 26802,
                            },
                            false => Waterlogged switch {
                                true => 26803,
                                false => 26804,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26805,
                                false => 26806,
                            },
                            false => Waterlogged switch {
                                true => 26807,
                                false => 26808,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26809,
                                false => 26810,
                            },
                            false => Waterlogged switch {
                                true => 26811,
                                false => 26812,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26813,
                                false => 26814,
                            },
                            false => Waterlogged switch {
                                true => 26815,
                                false => 26816,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26817,
                                false => 26818,
                            },
                            false => Waterlogged switch {
                                true => 26819,
                                false => 26820,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26821,
                                false => 26822,
                            },
                            false => Waterlogged switch {
                                true => 26823,
                                false => 26824,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26825,
                                false => 26826,
                            },
                            false => Waterlogged switch {
                                true => 26827,
                                false => 26828,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26829,
                                false => 26830,
                            },
                            false => Waterlogged switch {
                                true => 26831,
                                false => 26832,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26833,
                                false => 26834,
                            },
                            false => Waterlogged switch {
                                true => 26835,
                                false => 26836,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26837,
                                false => 26838,
                            },
                            false => Waterlogged switch {
                                true => 26839,
                                false => 26840,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26841,
                                false => 26842,
                            },
                            false => Waterlogged switch {
                                true => 26843,
                                false => 26844,
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
            26781 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26782 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26783 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26784 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26785 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26786 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26787 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26788 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26789 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26790 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26791 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26792 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26793 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26794 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26795 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26796 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26797 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26798 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26799 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26800 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26801 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26802 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26803 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26804 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26805 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26806 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26807 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26808 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26809 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26810 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26811 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26812 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26813 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26814 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26815 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26816 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26817 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26818 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26819 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26820 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26821 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26822 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26823 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26824 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26825 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26826 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26827 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26828 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26829 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26830 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26831 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26832 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26833 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26834 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26835 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26836 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26837 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26838 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26839 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26840 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26841 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26842 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26843 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26844 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
