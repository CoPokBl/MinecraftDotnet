using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WarpedTrapdoorBlock(Identifier Identifier, Direction Facing, WarpedTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
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
                Direction.South => HalfValue switch {
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
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19867,
                                false => 19868,
                            },
                            false => Waterlogged switch {
                                true => 19869,
                                false => 19870,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19871,
                                false => 19872,
                            },
                            false => Waterlogged switch {
                                true => 19873,
                                false => 19874,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19875,
                                false => 19876,
                            },
                            false => Waterlogged switch {
                                true => 19877,
                                false => 19878,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19879,
                                false => 19880,
                            },
                            false => Waterlogged switch {
                                true => 19881,
                                false => 19882,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19883,
                                false => 19884,
                            },
                            false => Waterlogged switch {
                                true => 19885,
                                false => 19886,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19887,
                                false => 19888,
                            },
                            false => Waterlogged switch {
                                true => 19889,
                                false => 19890,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 19891,
                                false => 19892,
                            },
                            false => Waterlogged switch {
                                true => 19893,
                                false => 19894,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 19895,
                                false => 19896,
                            },
                            false => Waterlogged switch {
                                true => 19897,
                                false => 19898,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            19835 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            19836 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            19837 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            19838 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            19839 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            19840 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            19841 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            19842 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            19843 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            19844 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            19845 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            19846 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            19847 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            19848 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            19849 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            19850 => new WarpedTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            19851 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            19852 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            19853 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            19854 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            19855 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            19856 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            19857 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            19858 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            19859 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            19860 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            19861 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            19862 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            19863 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            19864 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            19865 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            19866 => new WarpedTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            19867 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            19868 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            19869 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            19870 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            19871 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            19872 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            19873 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            19874 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            19875 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            19876 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            19877 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            19878 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            19879 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            19880 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            19881 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            19882 => new WarpedTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            19883 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            19884 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            19885 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            19886 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            19887 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            19888 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            19889 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            19890 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            19891 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            19892 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            19893 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            19894 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            19895 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            19896 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            19897 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            19898 => new WarpedTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }
}
