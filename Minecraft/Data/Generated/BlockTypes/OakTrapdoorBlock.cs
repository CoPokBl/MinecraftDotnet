using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakTrapdoorBlock(Identifier Identifier, Direction Facing, OakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6140,
                                false => 6141,
                            },
                            false => Waterlogged switch {
                                true => 6142,
                                false => 6143,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6144,
                                false => 6145,
                            },
                            false => Waterlogged switch {
                                true => 6146,
                                false => 6147,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6148,
                                false => 6149,
                            },
                            false => Waterlogged switch {
                                true => 6150,
                                false => 6151,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6152,
                                false => 6153,
                            },
                            false => Waterlogged switch {
                                true => 6154,
                                false => 6155,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6156,
                                false => 6157,
                            },
                            false => Waterlogged switch {
                                true => 6158,
                                false => 6159,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6160,
                                false => 6161,
                            },
                            false => Waterlogged switch {
                                true => 6162,
                                false => 6163,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6164,
                                false => 6165,
                            },
                            false => Waterlogged switch {
                                true => 6166,
                                false => 6167,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6168,
                                false => 6169,
                            },
                            false => Waterlogged switch {
                                true => 6170,
                                false => 6171,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6172,
                                false => 6173,
                            },
                            false => Waterlogged switch {
                                true => 6174,
                                false => 6175,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6176,
                                false => 6177,
                            },
                            false => Waterlogged switch {
                                true => 6178,
                                false => 6179,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6180,
                                false => 6181,
                            },
                            false => Waterlogged switch {
                                true => 6182,
                                false => 6183,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6184,
                                false => 6185,
                            },
                            false => Waterlogged switch {
                                true => 6186,
                                false => 6187,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6188,
                                false => 6189,
                            },
                            false => Waterlogged switch {
                                true => 6190,
                                false => 6191,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6192,
                                false => 6193,
                            },
                            false => Waterlogged switch {
                                true => 6194,
                                false => 6195,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6196,
                                false => 6197,
                            },
                            false => Waterlogged switch {
                                true => 6198,
                                false => 6199,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6200,
                                false => 6201,
                            },
                            false => Waterlogged switch {
                                true => 6202,
                                false => 6203,
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
            6140 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6141 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6142 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6143 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6144 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6145 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6146 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6147 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6148 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6149 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6150 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6151 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6152 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6153 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6154 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6155 => new OakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6156 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6157 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6158 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6159 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6160 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6161 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6162 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6163 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6164 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6165 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6166 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6167 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6168 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6169 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6170 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6171 => new OakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6172 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6173 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6174 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6175 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6176 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6177 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6178 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6179 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6180 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6181 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6182 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6183 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6184 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6185 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6186 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6187 => new OakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6188 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6189 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6190 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6191 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6192 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6193 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6194 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6195 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6196 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6197 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6198 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6199 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6200 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6201 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6202 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6203 => new OakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
