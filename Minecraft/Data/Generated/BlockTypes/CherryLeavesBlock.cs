using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 392,
                        false => 393,
                    },
                    false => Waterlogged switch {
                        true => 394,
                        false => 395,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 396,
                        false => 397,
                    },
                    false => Waterlogged switch {
                        true => 398,
                        false => 399,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 400,
                        false => 401,
                    },
                    false => Waterlogged switch {
                        true => 402,
                        false => 403,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 404,
                        false => 405,
                    },
                    false => Waterlogged switch {
                        true => 406,
                        false => 407,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 408,
                        false => 409,
                    },
                    false => Waterlogged switch {
                        true => 410,
                        false => 411,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 412,
                        false => 413,
                    },
                    false => Waterlogged switch {
                        true => 414,
                        false => 415,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 416,
                        false => 417,
                    },
                    false => Waterlogged switch {
                        true => 418,
                        false => 419,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            392 => new CherryLeavesBlock(Identifier, 1, true, true),
            393 => new CherryLeavesBlock(Identifier, 1, true, false),
            394 => new CherryLeavesBlock(Identifier, 1, false, true),
            395 => new CherryLeavesBlock(Identifier, 1, false, false),
            396 => new CherryLeavesBlock(Identifier, 2, true, true),
            397 => new CherryLeavesBlock(Identifier, 2, true, false),
            398 => new CherryLeavesBlock(Identifier, 2, false, true),
            399 => new CherryLeavesBlock(Identifier, 2, false, false),
            400 => new CherryLeavesBlock(Identifier, 3, true, true),
            401 => new CherryLeavesBlock(Identifier, 3, true, false),
            402 => new CherryLeavesBlock(Identifier, 3, false, true),
            403 => new CherryLeavesBlock(Identifier, 3, false, false),
            404 => new CherryLeavesBlock(Identifier, 4, true, true),
            405 => new CherryLeavesBlock(Identifier, 4, true, false),
            406 => new CherryLeavesBlock(Identifier, 4, false, true),
            407 => new CherryLeavesBlock(Identifier, 4, false, false),
            408 => new CherryLeavesBlock(Identifier, 5, true, true),
            409 => new CherryLeavesBlock(Identifier, 5, true, false),
            410 => new CherryLeavesBlock(Identifier, 5, false, true),
            411 => new CherryLeavesBlock(Identifier, 5, false, false),
            412 => new CherryLeavesBlock(Identifier, 6, true, true),
            413 => new CherryLeavesBlock(Identifier, 6, true, false),
            414 => new CherryLeavesBlock(Identifier, 6, false, true),
            415 => new CherryLeavesBlock(Identifier, 6, false, false),
            416 => new CherryLeavesBlock(Identifier, 7, true, true),
            417 => new CherryLeavesBlock(Identifier, 7, true, false),
            418 => new CherryLeavesBlock(Identifier, 7, false, true),
            419 => new CherryLeavesBlock(Identifier, 7, false, false),
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
