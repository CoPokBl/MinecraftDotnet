using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonTrapdoorBlock(Identifier Identifier, Direction Facing, CrimsonTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 851;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:crimson_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19803,
                                false => 19804,
                            },
                            false => Waterlogged switch {
                                true => 19805,
                                false => 19806,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19807,
                                false => 19808,
                            },
                            false => Waterlogged switch {
                                true => 19809,
                                false => 19810,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19811,
                                false => 19812,
                            },
                            false => Waterlogged switch {
                                true => 19813,
                                false => 19814,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19815,
                                false => 19816,
                            },
                            false => Waterlogged switch {
                                true => 19817,
                                false => 19818,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19819,
                                false => 19820,
                            },
                            false => Waterlogged switch {
                                true => 19821,
                                false => 19822,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19823,
                                false => 19824,
                            },
                            false => Waterlogged switch {
                                true => 19825,
                                false => 19826,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19827,
                                false => 19828,
                            },
                            false => Waterlogged switch {
                                true => 19829,
                                false => 19830,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19831,
                                false => 19832,
                            },
                            false => Waterlogged switch {
                                true => 19833,
                                false => 19834,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19835,
                                false => 19836,
                            },
                            false => Waterlogged switch {
                                true => 19837,
                                false => 19838,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19839,
                                false => 19840,
                            },
                            false => Waterlogged switch {
                                true => 19841,
                                false => 19842,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19843,
                                false => 19844,
                            },
                            false => Waterlogged switch {
                                true => 19845,
                                false => 19846,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19847,
                                false => 19848,
                            },
                            false => Waterlogged switch {
                                true => 19849,
                                false => 19850,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19851,
                                false => 19852,
                            },
                            false => Waterlogged switch {
                                true => 19853,
                                false => 19854,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19855,
                                false => 19856,
                            },
                            false => Waterlogged switch {
                                true => 19857,
                                false => 19858,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19859,
                                false => 19860,
                            },
                            false => Waterlogged switch {
                                true => 19861,
                                false => 19862,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19863,
                                false => 19864,
                            },
                            false => Waterlogged switch {
                                true => 19865,
                                false => 19866,
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
            19803 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            19804 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            19805 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            19806 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            19807 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            19808 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            19809 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            19810 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            19811 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            19812 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            19813 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            19814 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            19815 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            19816 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            19817 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            19818 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            19819 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            19820 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            19821 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            19822 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            19823 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            19824 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            19825 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            19826 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            19827 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            19828 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            19829 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            19830 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            19831 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            19832 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            19833 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            19834 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            19835 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            19836 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            19837 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            19838 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            19839 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            19840 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            19841 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            19842 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            19843 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            19844 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            19845 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            19846 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            19847 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            19848 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            19849 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            19850 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            19851 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            19852 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            19853 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            19854 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            19855 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            19856 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            19857 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            19858 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            19859 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            19860 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            19861 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            19862 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            19863 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            19864 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            19865 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            19866 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
