using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GreenStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10597,
                                false => 10598,
                            },
                            false => West switch {
                                true => 10599,
                                false => 10600,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10601,
                                false => 10602,
                            },
                            false => West switch {
                                true => 10603,
                                false => 10604,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10605,
                                false => 10606,
                            },
                            false => West switch {
                                true => 10607,
                                false => 10608,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10609,
                                false => 10610,
                            },
                            false => West switch {
                                true => 10611,
                                false => 10612,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10613,
                                false => 10614,
                            },
                            false => West switch {
                                true => 10615,
                                false => 10616,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10617,
                                false => 10618,
                            },
                            false => West switch {
                                true => 10619,
                                false => 10620,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10621,
                                false => 10622,
                            },
                            false => West switch {
                                true => 10623,
                                false => 10624,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10625,
                                false => 10626,
                            },
                            false => West switch {
                                true => 10627,
                                false => 10628,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            10597 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10598 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10599 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10600 => new GreenStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10601 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10602 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10603 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10604 => new GreenStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10605 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10606 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10607 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10608 => new GreenStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10609 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10610 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10611 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10612 => new GreenStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10613 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10614 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10615 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10616 => new GreenStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10617 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10618 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10619 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10620 => new GreenStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10621 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10622 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10623 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10624 => new GreenStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10625 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10626 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10627 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10628 => new GreenStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
