using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperTrapdoorBlock(Identifier Identifier, Direction Facing, CopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25192,
                                false => 25193,
                            },
                            false => Waterlogged switch {
                                true => 25194,
                                false => 25195,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25196,
                                false => 25197,
                            },
                            false => Waterlogged switch {
                                true => 25198,
                                false => 25199,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25200,
                                false => 25201,
                            },
                            false => Waterlogged switch {
                                true => 25202,
                                false => 25203,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25204,
                                false => 25205,
                            },
                            false => Waterlogged switch {
                                true => 25206,
                                false => 25207,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25208,
                                false => 25209,
                            },
                            false => Waterlogged switch {
                                true => 25210,
                                false => 25211,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25212,
                                false => 25213,
                            },
                            false => Waterlogged switch {
                                true => 25214,
                                false => 25215,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25216,
                                false => 25217,
                            },
                            false => Waterlogged switch {
                                true => 25218,
                                false => 25219,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25220,
                                false => 25221,
                            },
                            false => Waterlogged switch {
                                true => 25222,
                                false => 25223,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25224,
                                false => 25225,
                            },
                            false => Waterlogged switch {
                                true => 25226,
                                false => 25227,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25228,
                                false => 25229,
                            },
                            false => Waterlogged switch {
                                true => 25230,
                                false => 25231,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25232,
                                false => 25233,
                            },
                            false => Waterlogged switch {
                                true => 25234,
                                false => 25235,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25236,
                                false => 25237,
                            },
                            false => Waterlogged switch {
                                true => 25238,
                                false => 25239,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25240,
                                false => 25241,
                            },
                            false => Waterlogged switch {
                                true => 25242,
                                false => 25243,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25244,
                                false => 25245,
                            },
                            false => Waterlogged switch {
                                true => 25246,
                                false => 25247,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25248,
                                false => 25249,
                            },
                            false => Waterlogged switch {
                                true => 25250,
                                false => 25251,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25252,
                                false => 25253,
                            },
                            false => Waterlogged switch {
                                true => 25254,
                                false => 25255,
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
            25192 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25193 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25194 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25195 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25196 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25197 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25198 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25199 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25200 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25201 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25202 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25203 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25204 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25205 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25206 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25207 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25208 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25209 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25210 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25211 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25212 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25213 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25214 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25215 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25216 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25217 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25218 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25219 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25220 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25221 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25222 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25223 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25224 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25225 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25226 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25227 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25228 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25229 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25230 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25231 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25232 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25233 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25234 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25235 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25236 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25237 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25238 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25239 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25240 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25241 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25242 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25243 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25244 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25245 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25246 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25247 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25248 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25249 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25250 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25251 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25252 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25253 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25254 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25255 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
