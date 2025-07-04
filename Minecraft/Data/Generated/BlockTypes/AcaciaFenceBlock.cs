using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12589,
                                false => 12590,
                            },
                            false => West switch {
                                true => 12591,
                                false => 12592,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12593,
                                false => 12594,
                            },
                            false => West switch {
                                true => 12595,
                                false => 12596,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12597,
                                false => 12598,
                            },
                            false => West switch {
                                true => 12599,
                                false => 12600,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12601,
                                false => 12602,
                            },
                            false => West switch {
                                true => 12603,
                                false => 12604,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12605,
                                false => 12606,
                            },
                            false => West switch {
                                true => 12607,
                                false => 12608,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12609,
                                false => 12610,
                            },
                            false => West switch {
                                true => 12611,
                                false => 12612,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12613,
                                false => 12614,
                            },
                            false => West switch {
                                true => 12615,
                                false => 12616,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12617,
                                false => 12618,
                            },
                            false => West switch {
                                true => 12619,
                                false => 12620,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12589 => new AcaciaFenceBlock(Identifier, true, true, true, true, true),
            12590 => new AcaciaFenceBlock(Identifier, true, true, true, true, false),
            12591 => new AcaciaFenceBlock(Identifier, true, true, true, false, true),
            12592 => new AcaciaFenceBlock(Identifier, true, true, true, false, false),
            12593 => new AcaciaFenceBlock(Identifier, true, true, false, true, true),
            12594 => new AcaciaFenceBlock(Identifier, true, true, false, true, false),
            12595 => new AcaciaFenceBlock(Identifier, true, true, false, false, true),
            12596 => new AcaciaFenceBlock(Identifier, true, true, false, false, false),
            12597 => new AcaciaFenceBlock(Identifier, true, false, true, true, true),
            12598 => new AcaciaFenceBlock(Identifier, true, false, true, true, false),
            12599 => new AcaciaFenceBlock(Identifier, true, false, true, false, true),
            12600 => new AcaciaFenceBlock(Identifier, true, false, true, false, false),
            12601 => new AcaciaFenceBlock(Identifier, true, false, false, true, true),
            12602 => new AcaciaFenceBlock(Identifier, true, false, false, true, false),
            12603 => new AcaciaFenceBlock(Identifier, true, false, false, false, true),
            12604 => new AcaciaFenceBlock(Identifier, true, false, false, false, false),
            12605 => new AcaciaFenceBlock(Identifier, false, true, true, true, true),
            12606 => new AcaciaFenceBlock(Identifier, false, true, true, true, false),
            12607 => new AcaciaFenceBlock(Identifier, false, true, true, false, true),
            12608 => new AcaciaFenceBlock(Identifier, false, true, true, false, false),
            12609 => new AcaciaFenceBlock(Identifier, false, true, false, true, true),
            12610 => new AcaciaFenceBlock(Identifier, false, true, false, true, false),
            12611 => new AcaciaFenceBlock(Identifier, false, true, false, false, true),
            12612 => new AcaciaFenceBlock(Identifier, false, true, false, false, false),
            12613 => new AcaciaFenceBlock(Identifier, false, false, true, true, true),
            12614 => new AcaciaFenceBlock(Identifier, false, false, true, true, false),
            12615 => new AcaciaFenceBlock(Identifier, false, false, true, false, true),
            12616 => new AcaciaFenceBlock(Identifier, false, false, true, false, false),
            12617 => new AcaciaFenceBlock(Identifier, false, false, false, true, true),
            12618 => new AcaciaFenceBlock(Identifier, false, false, false, true, false),
            12619 => new AcaciaFenceBlock(Identifier, false, false, false, false, true),
            12620 => new AcaciaFenceBlock(Identifier, false, false, false, false, false),
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
