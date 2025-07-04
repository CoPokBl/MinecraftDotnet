using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedDoorBlock(Identifier Identifier, Direction Facing, BlockHalf Half, LeftRight Hinge, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20235,
                                false => 20236,
                            },
                            false => Powered switch {
                                true => 20237,
                                false => 20238,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20239,
                                false => 20240,
                            },
                            false => Powered switch {
                                true => 20241,
                                false => 20242,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20243,
                                false => 20244,
                            },
                            false => Powered switch {
                                true => 20245,
                                false => 20246,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20247,
                                false => 20248,
                            },
                            false => Powered switch {
                                true => 20249,
                                false => 20250,
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
                                true => 20251,
                                false => 20252,
                            },
                            false => Powered switch {
                                true => 20253,
                                false => 20254,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20255,
                                false => 20256,
                            },
                            false => Powered switch {
                                true => 20257,
                                false => 20258,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20259,
                                false => 20260,
                            },
                            false => Powered switch {
                                true => 20261,
                                false => 20262,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20263,
                                false => 20264,
                            },
                            false => Powered switch {
                                true => 20265,
                                false => 20266,
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
                                true => 20267,
                                false => 20268,
                            },
                            false => Powered switch {
                                true => 20269,
                                false => 20270,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20271,
                                false => 20272,
                            },
                            false => Powered switch {
                                true => 20273,
                                false => 20274,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20275,
                                false => 20276,
                            },
                            false => Powered switch {
                                true => 20277,
                                false => 20278,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20279,
                                false => 20280,
                            },
                            false => Powered switch {
                                true => 20281,
                                false => 20282,
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
                                true => 20283,
                                false => 20284,
                            },
                            false => Powered switch {
                                true => 20285,
                                false => 20286,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20287,
                                false => 20288,
                            },
                            false => Powered switch {
                                true => 20289,
                                false => 20290,
                            },
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Hinge), Hinge, "Unknown value for property hinge.")
                    },
                    BlockHalf.Lower => Hinge switch {
                        LeftRight.Left => Open switch {
                            true => Powered switch {
                                true => 20291,
                                false => 20292,
                            },
                            false => Powered switch {
                                true => 20293,
                                false => 20294,
                            },
                        },
                        LeftRight.Right => Open switch {
                            true => Powered switch {
                                true => 20295,
                                false => 20296,
                            },
                            false => Powered switch {
                                true => 20297,
                                false => 20298,
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
            20235 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, true),
            20236 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, true, false),
            20237 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, true),
            20238 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Left, false, false),
            20239 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, true),
            20240 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, true, false),
            20241 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, true),
            20242 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Upper, LeftRight.Right, false, false),
            20243 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, true),
            20244 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, true, false),
            20245 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, true),
            20246 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Left, false, false),
            20247 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, true),
            20248 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, true, false),
            20249 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, true),
            20250 => new WarpedDoorBlock(Identifier, Direction.North, BlockHalf.Lower, LeftRight.Right, false, false),
            20251 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, true),
            20252 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, true, false),
            20253 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, true),
            20254 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Left, false, false),
            20255 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, true),
            20256 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, true, false),
            20257 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, true),
            20258 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Upper, LeftRight.Right, false, false),
            20259 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, true),
            20260 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, true, false),
            20261 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, true),
            20262 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Left, false, false),
            20263 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, true),
            20264 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, true, false),
            20265 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, true),
            20266 => new WarpedDoorBlock(Identifier, Direction.South, BlockHalf.Lower, LeftRight.Right, false, false),
            20267 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, true),
            20268 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, true, false),
            20269 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, true),
            20270 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Left, false, false),
            20271 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, true),
            20272 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, true, false),
            20273 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, true),
            20274 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Upper, LeftRight.Right, false, false),
            20275 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, true),
            20276 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, true, false),
            20277 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, true),
            20278 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Left, false, false),
            20279 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, true),
            20280 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, true, false),
            20281 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, true),
            20282 => new WarpedDoorBlock(Identifier, Direction.West, BlockHalf.Lower, LeftRight.Right, false, false),
            20283 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, true),
            20284 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, true, false),
            20285 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, true),
            20286 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Left, false, false),
            20287 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, true),
            20288 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, true, false),
            20289 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, true),
            20290 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Upper, LeftRight.Right, false, false),
            20291 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, true),
            20292 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, true, false),
            20293 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, true),
            20294 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Left, false, false),
            20295 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, true),
            20296 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, true, false),
            20297 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, true),
            20298 => new WarpedDoorBlock(Identifier, Direction.East, BlockHalf.Lower, LeftRight.Right, false, false),
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
