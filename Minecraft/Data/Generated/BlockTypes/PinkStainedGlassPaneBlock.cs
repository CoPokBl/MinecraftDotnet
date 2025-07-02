using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PinkStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10373,
                                false => 10374,
                            },
                            false => West switch {
                                true => 10375,
                                false => 10376,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10377,
                                false => 10378,
                            },
                            false => West switch {
                                true => 10379,
                                false => 10380,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10381,
                                false => 10382,
                            },
                            false => West switch {
                                true => 10383,
                                false => 10384,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10385,
                                false => 10386,
                            },
                            false => West switch {
                                true => 10387,
                                false => 10388,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10389,
                                false => 10390,
                            },
                            false => West switch {
                                true => 10391,
                                false => 10392,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10393,
                                false => 10394,
                            },
                            false => West switch {
                                true => 10395,
                                false => 10396,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10397,
                                false => 10398,
                            },
                            false => West switch {
                                true => 10399,
                                false => 10400,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10401,
                                false => 10402,
                            },
                            false => West switch {
                                true => 10403,
                                false => 10404,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            10373 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10374 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10375 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10376 => new PinkStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10377 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10378 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10379 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10380 => new PinkStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10381 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10382 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10383 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10384 => new PinkStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10385 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10386 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10387 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10388 => new PinkStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10389 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10390 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10391 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10392 => new PinkStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10393 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10394 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10395 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10396 => new PinkStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10397 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10398 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10399 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10400 => new PinkStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10401 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10402 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10403 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10404 => new PinkStainedGlassPaneBlock(Identifier, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
