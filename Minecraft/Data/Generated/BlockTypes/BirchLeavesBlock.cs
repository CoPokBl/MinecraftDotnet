using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 308,
                        false => 309,
                    },
                    false => Waterlogged switch {
                        true => 310,
                        false => 311,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 312,
                        false => 313,
                    },
                    false => Waterlogged switch {
                        true => 314,
                        false => 315,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 316,
                        false => 317,
                    },
                    false => Waterlogged switch {
                        true => 318,
                        false => 319,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 320,
                        false => 321,
                    },
                    false => Waterlogged switch {
                        true => 322,
                        false => 323,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 324,
                        false => 325,
                    },
                    false => Waterlogged switch {
                        true => 326,
                        false => 327,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 328,
                        false => 329,
                    },
                    false => Waterlogged switch {
                        true => 330,
                        false => 331,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 332,
                        false => 333,
                    },
                    false => Waterlogged switch {
                        true => 334,
                        false => 335,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            308 => new BirchLeavesBlock(Identifier, 1, true, true),
            309 => new BirchLeavesBlock(Identifier, 1, true, false),
            310 => new BirchLeavesBlock(Identifier, 1, false, true),
            311 => new BirchLeavesBlock(Identifier, 1, false, false),
            312 => new BirchLeavesBlock(Identifier, 2, true, true),
            313 => new BirchLeavesBlock(Identifier, 2, true, false),
            314 => new BirchLeavesBlock(Identifier, 2, false, true),
            315 => new BirchLeavesBlock(Identifier, 2, false, false),
            316 => new BirchLeavesBlock(Identifier, 3, true, true),
            317 => new BirchLeavesBlock(Identifier, 3, true, false),
            318 => new BirchLeavesBlock(Identifier, 3, false, true),
            319 => new BirchLeavesBlock(Identifier, 3, false, false),
            320 => new BirchLeavesBlock(Identifier, 4, true, true),
            321 => new BirchLeavesBlock(Identifier, 4, true, false),
            322 => new BirchLeavesBlock(Identifier, 4, false, true),
            323 => new BirchLeavesBlock(Identifier, 4, false, false),
            324 => new BirchLeavesBlock(Identifier, 5, true, true),
            325 => new BirchLeavesBlock(Identifier, 5, true, false),
            326 => new BirchLeavesBlock(Identifier, 5, false, true),
            327 => new BirchLeavesBlock(Identifier, 5, false, false),
            328 => new BirchLeavesBlock(Identifier, 6, true, true),
            329 => new BirchLeavesBlock(Identifier, 6, true, false),
            330 => new BirchLeavesBlock(Identifier, 6, false, true),
            331 => new BirchLeavesBlock(Identifier, 6, false, false),
            332 => new BirchLeavesBlock(Identifier, 7, true, true),
            333 => new BirchLeavesBlock(Identifier, 7, true, false),
            334 => new BirchLeavesBlock(Identifier, 7, false, true),
            335 => new BirchLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = int.Parse(properties["distance"].GetString()),
            Persistent = properties["persistent"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
