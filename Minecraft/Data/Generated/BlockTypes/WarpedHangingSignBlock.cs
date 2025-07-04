using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5514,
                        false => 5515,
                    },
                    1 => Waterlogged switch {
                        true => 5516,
                        false => 5517,
                    },
                    2 => Waterlogged switch {
                        true => 5518,
                        false => 5519,
                    },
                    3 => Waterlogged switch {
                        true => 5520,
                        false => 5521,
                    },
                    4 => Waterlogged switch {
                        true => 5522,
                        false => 5523,
                    },
                    5 => Waterlogged switch {
                        true => 5524,
                        false => 5525,
                    },
                    6 => Waterlogged switch {
                        true => 5526,
                        false => 5527,
                    },
                    7 => Waterlogged switch {
                        true => 5528,
                        false => 5529,
                    },
                    8 => Waterlogged switch {
                        true => 5530,
                        false => 5531,
                    },
                    9 => Waterlogged switch {
                        true => 5532,
                        false => 5533,
                    },
                    10 => Waterlogged switch {
                        true => 5534,
                        false => 5535,
                    },
                    11 => Waterlogged switch {
                        true => 5536,
                        false => 5537,
                    },
                    12 => Waterlogged switch {
                        true => 5538,
                        false => 5539,
                    },
                    13 => Waterlogged switch {
                        true => 5540,
                        false => 5541,
                    },
                    14 => Waterlogged switch {
                        true => 5542,
                        false => 5543,
                    },
                    15 => Waterlogged switch {
                        true => 5544,
                        false => 5545,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5546,
                        false => 5547,
                    },
                    1 => Waterlogged switch {
                        true => 5548,
                        false => 5549,
                    },
                    2 => Waterlogged switch {
                        true => 5550,
                        false => 5551,
                    },
                    3 => Waterlogged switch {
                        true => 5552,
                        false => 5553,
                    },
                    4 => Waterlogged switch {
                        true => 5554,
                        false => 5555,
                    },
                    5 => Waterlogged switch {
                        true => 5556,
                        false => 5557,
                    },
                    6 => Waterlogged switch {
                        true => 5558,
                        false => 5559,
                    },
                    7 => Waterlogged switch {
                        true => 5560,
                        false => 5561,
                    },
                    8 => Waterlogged switch {
                        true => 5562,
                        false => 5563,
                    },
                    9 => Waterlogged switch {
                        true => 5564,
                        false => 5565,
                    },
                    10 => Waterlogged switch {
                        true => 5566,
                        false => 5567,
                    },
                    11 => Waterlogged switch {
                        true => 5568,
                        false => 5569,
                    },
                    12 => Waterlogged switch {
                        true => 5570,
                        false => 5571,
                    },
                    13 => Waterlogged switch {
                        true => 5572,
                        false => 5573,
                    },
                    14 => Waterlogged switch {
                        true => 5574,
                        false => 5575,
                    },
                    15 => Waterlogged switch {
                        true => 5576,
                        false => 5577,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5514 => new WarpedHangingSignBlock(Identifier, true, 0, true),
            5515 => new WarpedHangingSignBlock(Identifier, true, 0, false),
            5516 => new WarpedHangingSignBlock(Identifier, true, 1, true),
            5517 => new WarpedHangingSignBlock(Identifier, true, 1, false),
            5518 => new WarpedHangingSignBlock(Identifier, true, 2, true),
            5519 => new WarpedHangingSignBlock(Identifier, true, 2, false),
            5520 => new WarpedHangingSignBlock(Identifier, true, 3, true),
            5521 => new WarpedHangingSignBlock(Identifier, true, 3, false),
            5522 => new WarpedHangingSignBlock(Identifier, true, 4, true),
            5523 => new WarpedHangingSignBlock(Identifier, true, 4, false),
            5524 => new WarpedHangingSignBlock(Identifier, true, 5, true),
            5525 => new WarpedHangingSignBlock(Identifier, true, 5, false),
            5526 => new WarpedHangingSignBlock(Identifier, true, 6, true),
            5527 => new WarpedHangingSignBlock(Identifier, true, 6, false),
            5528 => new WarpedHangingSignBlock(Identifier, true, 7, true),
            5529 => new WarpedHangingSignBlock(Identifier, true, 7, false),
            5530 => new WarpedHangingSignBlock(Identifier, true, 8, true),
            5531 => new WarpedHangingSignBlock(Identifier, true, 8, false),
            5532 => new WarpedHangingSignBlock(Identifier, true, 9, true),
            5533 => new WarpedHangingSignBlock(Identifier, true, 9, false),
            5534 => new WarpedHangingSignBlock(Identifier, true, 10, true),
            5535 => new WarpedHangingSignBlock(Identifier, true, 10, false),
            5536 => new WarpedHangingSignBlock(Identifier, true, 11, true),
            5537 => new WarpedHangingSignBlock(Identifier, true, 11, false),
            5538 => new WarpedHangingSignBlock(Identifier, true, 12, true),
            5539 => new WarpedHangingSignBlock(Identifier, true, 12, false),
            5540 => new WarpedHangingSignBlock(Identifier, true, 13, true),
            5541 => new WarpedHangingSignBlock(Identifier, true, 13, false),
            5542 => new WarpedHangingSignBlock(Identifier, true, 14, true),
            5543 => new WarpedHangingSignBlock(Identifier, true, 14, false),
            5544 => new WarpedHangingSignBlock(Identifier, true, 15, true),
            5545 => new WarpedHangingSignBlock(Identifier, true, 15, false),
            5546 => new WarpedHangingSignBlock(Identifier, false, 0, true),
            5547 => new WarpedHangingSignBlock(Identifier, false, 0, false),
            5548 => new WarpedHangingSignBlock(Identifier, false, 1, true),
            5549 => new WarpedHangingSignBlock(Identifier, false, 1, false),
            5550 => new WarpedHangingSignBlock(Identifier, false, 2, true),
            5551 => new WarpedHangingSignBlock(Identifier, false, 2, false),
            5552 => new WarpedHangingSignBlock(Identifier, false, 3, true),
            5553 => new WarpedHangingSignBlock(Identifier, false, 3, false),
            5554 => new WarpedHangingSignBlock(Identifier, false, 4, true),
            5555 => new WarpedHangingSignBlock(Identifier, false, 4, false),
            5556 => new WarpedHangingSignBlock(Identifier, false, 5, true),
            5557 => new WarpedHangingSignBlock(Identifier, false, 5, false),
            5558 => new WarpedHangingSignBlock(Identifier, false, 6, true),
            5559 => new WarpedHangingSignBlock(Identifier, false, 6, false),
            5560 => new WarpedHangingSignBlock(Identifier, false, 7, true),
            5561 => new WarpedHangingSignBlock(Identifier, false, 7, false),
            5562 => new WarpedHangingSignBlock(Identifier, false, 8, true),
            5563 => new WarpedHangingSignBlock(Identifier, false, 8, false),
            5564 => new WarpedHangingSignBlock(Identifier, false, 9, true),
            5565 => new WarpedHangingSignBlock(Identifier, false, 9, false),
            5566 => new WarpedHangingSignBlock(Identifier, false, 10, true),
            5567 => new WarpedHangingSignBlock(Identifier, false, 10, false),
            5568 => new WarpedHangingSignBlock(Identifier, false, 11, true),
            5569 => new WarpedHangingSignBlock(Identifier, false, 11, false),
            5570 => new WarpedHangingSignBlock(Identifier, false, 12, true),
            5571 => new WarpedHangingSignBlock(Identifier, false, 12, false),
            5572 => new WarpedHangingSignBlock(Identifier, false, 13, true),
            5573 => new WarpedHangingSignBlock(Identifier, false, 13, false),
            5574 => new WarpedHangingSignBlock(Identifier, false, 14, true),
            5575 => new WarpedHangingSignBlock(Identifier, false, 14, false),
            5576 => new WarpedHangingSignBlock(Identifier, false, 15, true),
            5577 => new WarpedHangingSignBlock(Identifier, false, 15, false),
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
