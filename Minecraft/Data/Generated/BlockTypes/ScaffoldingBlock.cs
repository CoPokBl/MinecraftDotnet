using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ScaffoldingBlock(Identifier Identifier, bool Bottom, int Distance, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Bottom switch {
                true => Distance switch {
                    0 => Waterlogged switch {
                        true => 19395,
                        false => 19396,
                    },
                    1 => Waterlogged switch {
                        true => 19397,
                        false => 19398,
                    },
                    2 => Waterlogged switch {
                        true => 19399,
                        false => 19400,
                    },
                    3 => Waterlogged switch {
                        true => 19401,
                        false => 19402,
                    },
                    4 => Waterlogged switch {
                        true => 19403,
                        false => 19404,
                    },
                    5 => Waterlogged switch {
                        true => 19405,
                        false => 19406,
                    },
                    6 => Waterlogged switch {
                        true => 19407,
                        false => 19408,
                    },
                    7 => Waterlogged switch {
                        true => 19409,
                        false => 19410,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 19411,
                        false => 19412,
                    },
                    1 => Waterlogged switch {
                        true => 19413,
                        false => 19414,
                    },
                    2 => Waterlogged switch {
                        true => 19415,
                        false => 19416,
                    },
                    3 => Waterlogged switch {
                        true => 19417,
                        false => 19418,
                    },
                    4 => Waterlogged switch {
                        true => 19419,
                        false => 19420,
                    },
                    5 => Waterlogged switch {
                        true => 19421,
                        false => 19422,
                    },
                    6 => Waterlogged switch {
                        true => 19423,
                        false => 19424,
                    },
                    7 => Waterlogged switch {
                        true => 19425,
                        false => 19426,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19395 => new ScaffoldingBlock(Identifier, true, 0, true),
            19396 => new ScaffoldingBlock(Identifier, true, 0, false),
            19397 => new ScaffoldingBlock(Identifier, true, 1, true),
            19398 => new ScaffoldingBlock(Identifier, true, 1, false),
            19399 => new ScaffoldingBlock(Identifier, true, 2, true),
            19400 => new ScaffoldingBlock(Identifier, true, 2, false),
            19401 => new ScaffoldingBlock(Identifier, true, 3, true),
            19402 => new ScaffoldingBlock(Identifier, true, 3, false),
            19403 => new ScaffoldingBlock(Identifier, true, 4, true),
            19404 => new ScaffoldingBlock(Identifier, true, 4, false),
            19405 => new ScaffoldingBlock(Identifier, true, 5, true),
            19406 => new ScaffoldingBlock(Identifier, true, 5, false),
            19407 => new ScaffoldingBlock(Identifier, true, 6, true),
            19408 => new ScaffoldingBlock(Identifier, true, 6, false),
            19409 => new ScaffoldingBlock(Identifier, true, 7, true),
            19410 => new ScaffoldingBlock(Identifier, true, 7, false),
            19411 => new ScaffoldingBlock(Identifier, false, 0, true),
            19412 => new ScaffoldingBlock(Identifier, false, 0, false),
            19413 => new ScaffoldingBlock(Identifier, false, 1, true),
            19414 => new ScaffoldingBlock(Identifier, false, 1, false),
            19415 => new ScaffoldingBlock(Identifier, false, 2, true),
            19416 => new ScaffoldingBlock(Identifier, false, 2, false),
            19417 => new ScaffoldingBlock(Identifier, false, 3, true),
            19418 => new ScaffoldingBlock(Identifier, false, 3, false),
            19419 => new ScaffoldingBlock(Identifier, false, 4, true),
            19420 => new ScaffoldingBlock(Identifier, false, 4, false),
            19421 => new ScaffoldingBlock(Identifier, false, 5, true),
            19422 => new ScaffoldingBlock(Identifier, false, 5, false),
            19423 => new ScaffoldingBlock(Identifier, false, 6, true),
            19424 => new ScaffoldingBlock(Identifier, false, 6, false),
            19425 => new ScaffoldingBlock(Identifier, false, 7, true),
            19426 => new ScaffoldingBlock(Identifier, false, 7, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties["bottom"].GetString() == "true",
            Distance = int.Parse(properties["distance"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
