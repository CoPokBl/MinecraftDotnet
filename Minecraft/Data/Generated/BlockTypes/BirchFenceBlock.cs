using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12525,
                                false => 12526,
                            },
                            false => West switch {
                                true => 12527,
                                false => 12528,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12529,
                                false => 12530,
                            },
                            false => West switch {
                                true => 12531,
                                false => 12532,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12533,
                                false => 12534,
                            },
                            false => West switch {
                                true => 12535,
                                false => 12536,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12537,
                                false => 12538,
                            },
                            false => West switch {
                                true => 12539,
                                false => 12540,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12541,
                                false => 12542,
                            },
                            false => West switch {
                                true => 12543,
                                false => 12544,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12545,
                                false => 12546,
                            },
                            false => West switch {
                                true => 12547,
                                false => 12548,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12549,
                                false => 12550,
                            },
                            false => West switch {
                                true => 12551,
                                false => 12552,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12553,
                                false => 12554,
                            },
                            false => West switch {
                                true => 12555,
                                false => 12556,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12525 => new BirchFenceBlock(Identifier, true, true, true, true, true),
            12526 => new BirchFenceBlock(Identifier, true, true, true, true, false),
            12527 => new BirchFenceBlock(Identifier, true, true, true, false, true),
            12528 => new BirchFenceBlock(Identifier, true, true, true, false, false),
            12529 => new BirchFenceBlock(Identifier, true, true, false, true, true),
            12530 => new BirchFenceBlock(Identifier, true, true, false, true, false),
            12531 => new BirchFenceBlock(Identifier, true, true, false, false, true),
            12532 => new BirchFenceBlock(Identifier, true, true, false, false, false),
            12533 => new BirchFenceBlock(Identifier, true, false, true, true, true),
            12534 => new BirchFenceBlock(Identifier, true, false, true, true, false),
            12535 => new BirchFenceBlock(Identifier, true, false, true, false, true),
            12536 => new BirchFenceBlock(Identifier, true, false, true, false, false),
            12537 => new BirchFenceBlock(Identifier, true, false, false, true, true),
            12538 => new BirchFenceBlock(Identifier, true, false, false, true, false),
            12539 => new BirchFenceBlock(Identifier, true, false, false, false, true),
            12540 => new BirchFenceBlock(Identifier, true, false, false, false, false),
            12541 => new BirchFenceBlock(Identifier, false, true, true, true, true),
            12542 => new BirchFenceBlock(Identifier, false, true, true, true, false),
            12543 => new BirchFenceBlock(Identifier, false, true, true, false, true),
            12544 => new BirchFenceBlock(Identifier, false, true, true, false, false),
            12545 => new BirchFenceBlock(Identifier, false, true, false, true, true),
            12546 => new BirchFenceBlock(Identifier, false, true, false, true, false),
            12547 => new BirchFenceBlock(Identifier, false, true, false, false, true),
            12548 => new BirchFenceBlock(Identifier, false, true, false, false, false),
            12549 => new BirchFenceBlock(Identifier, false, false, true, true, true),
            12550 => new BirchFenceBlock(Identifier, false, false, true, true, false),
            12551 => new BirchFenceBlock(Identifier, false, false, true, false, true),
            12552 => new BirchFenceBlock(Identifier, false, false, true, false, false),
            12553 => new BirchFenceBlock(Identifier, false, false, false, true, true),
            12554 => new BirchFenceBlock(Identifier, false, false, false, true, false),
            12555 => new BirchFenceBlock(Identifier, false, false, false, false, true),
            12556 => new BirchFenceBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            East = properties["east"].GetString() == "true",
            North = properties["north"].GetString() == "true",
            South = properties["south"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
            West = properties["west"].GetString() == "true",
        };
    }
    
}
