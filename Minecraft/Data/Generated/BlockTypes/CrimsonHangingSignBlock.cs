using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5450,
                        false => 5451,
                    },
                    1 => Waterlogged switch {
                        true => 5452,
                        false => 5453,
                    },
                    2 => Waterlogged switch {
                        true => 5454,
                        false => 5455,
                    },
                    3 => Waterlogged switch {
                        true => 5456,
                        false => 5457,
                    },
                    4 => Waterlogged switch {
                        true => 5458,
                        false => 5459,
                    },
                    5 => Waterlogged switch {
                        true => 5460,
                        false => 5461,
                    },
                    6 => Waterlogged switch {
                        true => 5462,
                        false => 5463,
                    },
                    7 => Waterlogged switch {
                        true => 5464,
                        false => 5465,
                    },
                    8 => Waterlogged switch {
                        true => 5466,
                        false => 5467,
                    },
                    9 => Waterlogged switch {
                        true => 5468,
                        false => 5469,
                    },
                    10 => Waterlogged switch {
                        true => 5470,
                        false => 5471,
                    },
                    11 => Waterlogged switch {
                        true => 5472,
                        false => 5473,
                    },
                    12 => Waterlogged switch {
                        true => 5474,
                        false => 5475,
                    },
                    13 => Waterlogged switch {
                        true => 5476,
                        false => 5477,
                    },
                    14 => Waterlogged switch {
                        true => 5478,
                        false => 5479,
                    },
                    15 => Waterlogged switch {
                        true => 5480,
                        false => 5481,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5482,
                        false => 5483,
                    },
                    1 => Waterlogged switch {
                        true => 5484,
                        false => 5485,
                    },
                    2 => Waterlogged switch {
                        true => 5486,
                        false => 5487,
                    },
                    3 => Waterlogged switch {
                        true => 5488,
                        false => 5489,
                    },
                    4 => Waterlogged switch {
                        true => 5490,
                        false => 5491,
                    },
                    5 => Waterlogged switch {
                        true => 5492,
                        false => 5493,
                    },
                    6 => Waterlogged switch {
                        true => 5494,
                        false => 5495,
                    },
                    7 => Waterlogged switch {
                        true => 5496,
                        false => 5497,
                    },
                    8 => Waterlogged switch {
                        true => 5498,
                        false => 5499,
                    },
                    9 => Waterlogged switch {
                        true => 5500,
                        false => 5501,
                    },
                    10 => Waterlogged switch {
                        true => 5502,
                        false => 5503,
                    },
                    11 => Waterlogged switch {
                        true => 5504,
                        false => 5505,
                    },
                    12 => Waterlogged switch {
                        true => 5506,
                        false => 5507,
                    },
                    13 => Waterlogged switch {
                        true => 5508,
                        false => 5509,
                    },
                    14 => Waterlogged switch {
                        true => 5510,
                        false => 5511,
                    },
                    15 => Waterlogged switch {
                        true => 5512,
                        false => 5513,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5450 => new CrimsonHangingSignBlock(Identifier, true, 0, true),
            5451 => new CrimsonHangingSignBlock(Identifier, true, 0, false),
            5452 => new CrimsonHangingSignBlock(Identifier, true, 1, true),
            5453 => new CrimsonHangingSignBlock(Identifier, true, 1, false),
            5454 => new CrimsonHangingSignBlock(Identifier, true, 2, true),
            5455 => new CrimsonHangingSignBlock(Identifier, true, 2, false),
            5456 => new CrimsonHangingSignBlock(Identifier, true, 3, true),
            5457 => new CrimsonHangingSignBlock(Identifier, true, 3, false),
            5458 => new CrimsonHangingSignBlock(Identifier, true, 4, true),
            5459 => new CrimsonHangingSignBlock(Identifier, true, 4, false),
            5460 => new CrimsonHangingSignBlock(Identifier, true, 5, true),
            5461 => new CrimsonHangingSignBlock(Identifier, true, 5, false),
            5462 => new CrimsonHangingSignBlock(Identifier, true, 6, true),
            5463 => new CrimsonHangingSignBlock(Identifier, true, 6, false),
            5464 => new CrimsonHangingSignBlock(Identifier, true, 7, true),
            5465 => new CrimsonHangingSignBlock(Identifier, true, 7, false),
            5466 => new CrimsonHangingSignBlock(Identifier, true, 8, true),
            5467 => new CrimsonHangingSignBlock(Identifier, true, 8, false),
            5468 => new CrimsonHangingSignBlock(Identifier, true, 9, true),
            5469 => new CrimsonHangingSignBlock(Identifier, true, 9, false),
            5470 => new CrimsonHangingSignBlock(Identifier, true, 10, true),
            5471 => new CrimsonHangingSignBlock(Identifier, true, 10, false),
            5472 => new CrimsonHangingSignBlock(Identifier, true, 11, true),
            5473 => new CrimsonHangingSignBlock(Identifier, true, 11, false),
            5474 => new CrimsonHangingSignBlock(Identifier, true, 12, true),
            5475 => new CrimsonHangingSignBlock(Identifier, true, 12, false),
            5476 => new CrimsonHangingSignBlock(Identifier, true, 13, true),
            5477 => new CrimsonHangingSignBlock(Identifier, true, 13, false),
            5478 => new CrimsonHangingSignBlock(Identifier, true, 14, true),
            5479 => new CrimsonHangingSignBlock(Identifier, true, 14, false),
            5480 => new CrimsonHangingSignBlock(Identifier, true, 15, true),
            5481 => new CrimsonHangingSignBlock(Identifier, true, 15, false),
            5482 => new CrimsonHangingSignBlock(Identifier, false, 0, true),
            5483 => new CrimsonHangingSignBlock(Identifier, false, 0, false),
            5484 => new CrimsonHangingSignBlock(Identifier, false, 1, true),
            5485 => new CrimsonHangingSignBlock(Identifier, false, 1, false),
            5486 => new CrimsonHangingSignBlock(Identifier, false, 2, true),
            5487 => new CrimsonHangingSignBlock(Identifier, false, 2, false),
            5488 => new CrimsonHangingSignBlock(Identifier, false, 3, true),
            5489 => new CrimsonHangingSignBlock(Identifier, false, 3, false),
            5490 => new CrimsonHangingSignBlock(Identifier, false, 4, true),
            5491 => new CrimsonHangingSignBlock(Identifier, false, 4, false),
            5492 => new CrimsonHangingSignBlock(Identifier, false, 5, true),
            5493 => new CrimsonHangingSignBlock(Identifier, false, 5, false),
            5494 => new CrimsonHangingSignBlock(Identifier, false, 6, true),
            5495 => new CrimsonHangingSignBlock(Identifier, false, 6, false),
            5496 => new CrimsonHangingSignBlock(Identifier, false, 7, true),
            5497 => new CrimsonHangingSignBlock(Identifier, false, 7, false),
            5498 => new CrimsonHangingSignBlock(Identifier, false, 8, true),
            5499 => new CrimsonHangingSignBlock(Identifier, false, 8, false),
            5500 => new CrimsonHangingSignBlock(Identifier, false, 9, true),
            5501 => new CrimsonHangingSignBlock(Identifier, false, 9, false),
            5502 => new CrimsonHangingSignBlock(Identifier, false, 10, true),
            5503 => new CrimsonHangingSignBlock(Identifier, false, 10, false),
            5504 => new CrimsonHangingSignBlock(Identifier, false, 11, true),
            5505 => new CrimsonHangingSignBlock(Identifier, false, 11, false),
            5506 => new CrimsonHangingSignBlock(Identifier, false, 12, true),
            5507 => new CrimsonHangingSignBlock(Identifier, false, 12, false),
            5508 => new CrimsonHangingSignBlock(Identifier, false, 13, true),
            5509 => new CrimsonHangingSignBlock(Identifier, false, 13, false),
            5510 => new CrimsonHangingSignBlock(Identifier, false, 14, true),
            5511 => new CrimsonHangingSignBlock(Identifier, false, 14, false),
            5512 => new CrimsonHangingSignBlock(Identifier, false, 15, true),
            5513 => new CrimsonHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
