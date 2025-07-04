using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveFenceBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12717,
                                false => 12718,
                            },
                            false => West switch {
                                true => 12719,
                                false => 12720,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12721,
                                false => 12722,
                            },
                            false => West switch {
                                true => 12723,
                                false => 12724,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12725,
                                false => 12726,
                            },
                            false => West switch {
                                true => 12727,
                                false => 12728,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12729,
                                false => 12730,
                            },
                            false => West switch {
                                true => 12731,
                                false => 12732,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12733,
                                false => 12734,
                            },
                            false => West switch {
                                true => 12735,
                                false => 12736,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12737,
                                false => 12738,
                            },
                            false => West switch {
                                true => 12739,
                                false => 12740,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 12741,
                                false => 12742,
                            },
                            false => West switch {
                                true => 12743,
                                false => 12744,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 12745,
                                false => 12746,
                            },
                            false => West switch {
                                true => 12747,
                                false => 12748,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12717 => new MangroveFenceBlock(Identifier, true, true, true, true, true),
            12718 => new MangroveFenceBlock(Identifier, true, true, true, true, false),
            12719 => new MangroveFenceBlock(Identifier, true, true, true, false, true),
            12720 => new MangroveFenceBlock(Identifier, true, true, true, false, false),
            12721 => new MangroveFenceBlock(Identifier, true, true, false, true, true),
            12722 => new MangroveFenceBlock(Identifier, true, true, false, true, false),
            12723 => new MangroveFenceBlock(Identifier, true, true, false, false, true),
            12724 => new MangroveFenceBlock(Identifier, true, true, false, false, false),
            12725 => new MangroveFenceBlock(Identifier, true, false, true, true, true),
            12726 => new MangroveFenceBlock(Identifier, true, false, true, true, false),
            12727 => new MangroveFenceBlock(Identifier, true, false, true, false, true),
            12728 => new MangroveFenceBlock(Identifier, true, false, true, false, false),
            12729 => new MangroveFenceBlock(Identifier, true, false, false, true, true),
            12730 => new MangroveFenceBlock(Identifier, true, false, false, true, false),
            12731 => new MangroveFenceBlock(Identifier, true, false, false, false, true),
            12732 => new MangroveFenceBlock(Identifier, true, false, false, false, false),
            12733 => new MangroveFenceBlock(Identifier, false, true, true, true, true),
            12734 => new MangroveFenceBlock(Identifier, false, true, true, true, false),
            12735 => new MangroveFenceBlock(Identifier, false, true, true, false, true),
            12736 => new MangroveFenceBlock(Identifier, false, true, true, false, false),
            12737 => new MangroveFenceBlock(Identifier, false, true, false, true, true),
            12738 => new MangroveFenceBlock(Identifier, false, true, false, true, false),
            12739 => new MangroveFenceBlock(Identifier, false, true, false, false, true),
            12740 => new MangroveFenceBlock(Identifier, false, true, false, false, false),
            12741 => new MangroveFenceBlock(Identifier, false, false, true, true, true),
            12742 => new MangroveFenceBlock(Identifier, false, false, true, true, false),
            12743 => new MangroveFenceBlock(Identifier, false, false, true, false, true),
            12744 => new MangroveFenceBlock(Identifier, false, false, true, false, false),
            12745 => new MangroveFenceBlock(Identifier, false, false, false, true, true),
            12746 => new MangroveFenceBlock(Identifier, false, false, false, true, false),
            12747 => new MangroveFenceBlock(Identifier, false, false, false, false, true),
            12748 => new MangroveFenceBlock(Identifier, false, false, false, false, false),
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
