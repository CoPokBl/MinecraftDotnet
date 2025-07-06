using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13229,
                                false => 13230,
                            },
                            false => Powered switch {
                                true => 13231,
                                false => 13232,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13233,
                                false => 13234,
                            },
                            false => Powered switch {
                                true => 13235,
                                false => 13236,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13237,
                                false => 13238,
                            },
                            false => Powered switch {
                                true => 13239,
                                false => 13240,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13241,
                                false => 13242,
                            },
                            false => Powered switch {
                                true => 13243,
                                false => 13244,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13245,
                                false => 13246,
                            },
                            false => Powered switch {
                                true => 13247,
                                false => 13248,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13249,
                                false => 13250,
                            },
                            false => Powered switch {
                                true => 13251,
                                false => 13252,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13253,
                                false => 13254,
                            },
                            false => Powered switch {
                                true => 13255,
                                false => 13256,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13257,
                                false => 13258,
                            },
                            false => Powered switch {
                                true => 13259,
                                false => 13260,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13261,
                                false => 13262,
                            },
                            false => Powered switch {
                                true => 13263,
                                false => 13264,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13265,
                                false => 13266,
                            },
                            false => Powered switch {
                                true => 13267,
                                false => 13268,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13269,
                                false => 13270,
                            },
                            false => Powered switch {
                                true => 13271,
                                false => 13272,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13273,
                                false => 13274,
                            },
                            false => Powered switch {
                                true => 13275,
                                false => 13276,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13277,
                                false => 13278,
                            },
                            false => Powered switch {
                                true => 13279,
                                false => 13280,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13281,
                                false => 13282,
                            },
                            false => Powered switch {
                                true => 13283,
                                false => 13284,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 13285,
                                false => 13286,
                            },
                            false => Powered switch {
                                true => 13287,
                                false => 13288,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 13289,
                                false => 13290,
                            },
                            false => Powered switch {
                                true => 13291,
                                false => 13292,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13229 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            13230 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            13231 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            13232 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            13233 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            13234 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            13235 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            13236 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            13237 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            13238 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            13239 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            13240 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            13241 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            13242 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            13243 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            13244 => new MangroveDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            13245 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            13246 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            13247 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            13248 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            13249 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            13250 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            13251 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            13252 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            13253 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            13254 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            13255 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            13256 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            13257 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            13258 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            13259 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            13260 => new MangroveDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            13261 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            13262 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            13263 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            13264 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            13265 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            13266 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            13267 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            13268 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            13269 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            13270 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            13271 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            13272 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            13273 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            13274 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            13275 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            13276 => new MangroveDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            13277 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            13278 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            13279 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            13280 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            13281 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            13282 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            13283 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            13284 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            13285 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            13286 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            13287 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            13288 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            13289 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            13290 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            13291 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            13292 => new MangroveDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
            Hinge = LeftRightExtensions.FromString(properties["hinge"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
