using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25384,
                                false => 25385,
                            },
                            false => Waterlogged switch {
                                true => 25386,
                                false => 25387,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25388,
                                false => 25389,
                            },
                            false => Waterlogged switch {
                                true => 25390,
                                false => 25391,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25392,
                                false => 25393,
                            },
                            false => Waterlogged switch {
                                true => 25394,
                                false => 25395,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25396,
                                false => 25397,
                            },
                            false => Waterlogged switch {
                                true => 25398,
                                false => 25399,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25400,
                                false => 25401,
                            },
                            false => Waterlogged switch {
                                true => 25402,
                                false => 25403,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25404,
                                false => 25405,
                            },
                            false => Waterlogged switch {
                                true => 25406,
                                false => 25407,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25408,
                                false => 25409,
                            },
                            false => Waterlogged switch {
                                true => 25410,
                                false => 25411,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25412,
                                false => 25413,
                            },
                            false => Waterlogged switch {
                                true => 25414,
                                false => 25415,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25416,
                                false => 25417,
                            },
                            false => Waterlogged switch {
                                true => 25418,
                                false => 25419,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25420,
                                false => 25421,
                            },
                            false => Waterlogged switch {
                                true => 25422,
                                false => 25423,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25424,
                                false => 25425,
                            },
                            false => Waterlogged switch {
                                true => 25426,
                                false => 25427,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25428,
                                false => 25429,
                            },
                            false => Waterlogged switch {
                                true => 25430,
                                false => 25431,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25432,
                                false => 25433,
                            },
                            false => Waterlogged switch {
                                true => 25434,
                                false => 25435,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25436,
                                false => 25437,
                            },
                            false => Waterlogged switch {
                                true => 25438,
                                false => 25439,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25440,
                                false => 25441,
                            },
                            false => Waterlogged switch {
                                true => 25442,
                                false => 25443,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25444,
                                false => 25445,
                            },
                            false => Waterlogged switch {
                                true => 25446,
                                false => 25447,
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
            25384 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25385 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25386 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25387 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25388 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25389 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25390 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25391 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25392 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25393 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25394 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25395 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25396 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25397 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25398 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25399 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25400 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25401 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25402 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25403 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25404 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25405 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25406 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25407 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25408 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25409 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25410 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25411 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25412 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25413 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25414 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25415 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25416 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25417 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25418 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25419 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25420 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25421 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25422 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25423 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25424 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25425 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25426 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25427 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25428 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25429 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25430 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25431 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25432 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25433 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25434 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25435 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25436 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25437 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25438 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25439 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25440 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25441 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25442 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25443 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25444 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25445 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25446 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25447 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
