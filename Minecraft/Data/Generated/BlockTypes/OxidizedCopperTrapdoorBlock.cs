using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, OxidizedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25320,
                                false => 25321,
                            },
                            false => Waterlogged switch {
                                true => 25322,
                                false => 25323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25324,
                                false => 25325,
                            },
                            false => Waterlogged switch {
                                true => 25326,
                                false => 25327,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25328,
                                false => 25329,
                            },
                            false => Waterlogged switch {
                                true => 25330,
                                false => 25331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25332,
                                false => 25333,
                            },
                            false => Waterlogged switch {
                                true => 25334,
                                false => 25335,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25336,
                                false => 25337,
                            },
                            false => Waterlogged switch {
                                true => 25338,
                                false => 25339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25340,
                                false => 25341,
                            },
                            false => Waterlogged switch {
                                true => 25342,
                                false => 25343,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25344,
                                false => 25345,
                            },
                            false => Waterlogged switch {
                                true => 25346,
                                false => 25347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25348,
                                false => 25349,
                            },
                            false => Waterlogged switch {
                                true => 25350,
                                false => 25351,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25352,
                                false => 25353,
                            },
                            false => Waterlogged switch {
                                true => 25354,
                                false => 25355,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25356,
                                false => 25357,
                            },
                            false => Waterlogged switch {
                                true => 25358,
                                false => 25359,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25360,
                                false => 25361,
                            },
                            false => Waterlogged switch {
                                true => 25362,
                                false => 25363,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25364,
                                false => 25365,
                            },
                            false => Waterlogged switch {
                                true => 25366,
                                false => 25367,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25368,
                                false => 25369,
                            },
                            false => Waterlogged switch {
                                true => 25370,
                                false => 25371,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25372,
                                false => 25373,
                            },
                            false => Waterlogged switch {
                                true => 25374,
                                false => 25375,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25376,
                                false => 25377,
                            },
                            false => Waterlogged switch {
                                true => 25378,
                                false => 25379,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25380,
                                false => 25381,
                            },
                            false => Waterlogged switch {
                                true => 25382,
                                false => 25383,
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
            25320 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25321 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25322 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25323 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25324 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25325 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25326 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25327 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25328 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25329 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25330 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25331 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25332 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25333 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25334 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25335 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25336 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25337 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25338 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25339 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25340 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25341 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25342 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25343 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25344 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25345 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25346 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25347 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25348 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25349 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25350 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25351 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25352 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25353 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25354 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25355 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25356 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25357 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25358 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25359 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25360 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25361 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25362 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25363 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25364 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25365 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25366 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25367 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25368 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25369 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25370 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25371 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25372 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25373 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25374 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25375 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25376 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25377 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25378 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25379 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25380 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25381 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25382 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25383 => new OxidizedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
