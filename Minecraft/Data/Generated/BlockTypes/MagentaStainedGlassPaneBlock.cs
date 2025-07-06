using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaStainedGlassPaneBlock(Identifier Identifier, bool East, bool North, bool South, bool Waterlogged, bool West) : IBlock {

    public uint StateId {
        get {
            return East switch {
                true => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10245,
                                false => 10246,
                            },
                            false => West switch {
                                true => 10247,
                                false => 10248,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10249,
                                false => 10250,
                            },
                            false => West switch {
                                true => 10251,
                                false => 10252,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10253,
                                false => 10254,
                            },
                            false => West switch {
                                true => 10255,
                                false => 10256,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10257,
                                false => 10258,
                            },
                            false => West switch {
                                true => 10259,
                                false => 10260,
                            },
                        },
                    },
                },
                false => North switch {
                    true => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10261,
                                false => 10262,
                            },
                            false => West switch {
                                true => 10263,
                                false => 10264,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10265,
                                false => 10266,
                            },
                            false => West switch {
                                true => 10267,
                                false => 10268,
                            },
                        },
                    },
                    false => South switch {
                        true => Waterlogged switch {
                            true => West switch {
                                true => 10269,
                                false => 10270,
                            },
                            false => West switch {
                                true => 10271,
                                false => 10272,
                            },
                        },
                        false => Waterlogged switch {
                            true => West switch {
                                true => 10273,
                                false => 10274,
                            },
                            false => West switch {
                                true => 10275,
                                false => 10276,
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10245 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, true),
            10246 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, true, false),
            10247 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, true),
            10248 => new MagentaStainedGlassPaneBlock(Identifier, true, true, true, false, false),
            10249 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, true),
            10250 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, true, false),
            10251 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, true),
            10252 => new MagentaStainedGlassPaneBlock(Identifier, true, true, false, false, false),
            10253 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, true),
            10254 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, true, false),
            10255 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, true),
            10256 => new MagentaStainedGlassPaneBlock(Identifier, true, false, true, false, false),
            10257 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, true),
            10258 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, true, false),
            10259 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, true),
            10260 => new MagentaStainedGlassPaneBlock(Identifier, true, false, false, false, false),
            10261 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, true),
            10262 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, true, false),
            10263 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, true),
            10264 => new MagentaStainedGlassPaneBlock(Identifier, false, true, true, false, false),
            10265 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, true),
            10266 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, true, false),
            10267 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, true),
            10268 => new MagentaStainedGlassPaneBlock(Identifier, false, true, false, false, false),
            10269 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, true),
            10270 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, true, false),
            10271 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, true),
            10272 => new MagentaStainedGlassPaneBlock(Identifier, false, false, true, false, false),
            10273 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, true),
            10274 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, true, false),
            10275 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, true),
            10276 => new MagentaStainedGlassPaneBlock(Identifier, false, false, false, false, false),
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
