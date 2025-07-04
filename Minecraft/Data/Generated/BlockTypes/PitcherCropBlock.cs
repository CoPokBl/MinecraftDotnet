using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PitcherCropBlock(Identifier Identifier, int Age, BlockHalf Half) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => Half switch {
                    BlockHalf.Upper => 13520,
                    BlockHalf.Lower => 13521,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                1 => Half switch {
                    BlockHalf.Upper => 13522,
                    BlockHalf.Lower => 13523,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                2 => Half switch {
                    BlockHalf.Upper => 13524,
                    BlockHalf.Lower => 13525,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                3 => Half switch {
                    BlockHalf.Upper => 13526,
                    BlockHalf.Lower => 13527,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                4 => Half switch {
                    BlockHalf.Upper => 13528,
                    BlockHalf.Lower => 13529,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13520 => new PitcherCropBlock(Identifier, 0, BlockHalf.Upper),
            13521 => new PitcherCropBlock(Identifier, 0, BlockHalf.Lower),
            13522 => new PitcherCropBlock(Identifier, 1, BlockHalf.Upper),
            13523 => new PitcherCropBlock(Identifier, 1, BlockHalf.Lower),
            13524 => new PitcherCropBlock(Identifier, 2, BlockHalf.Upper),
            13525 => new PitcherCropBlock(Identifier, 2, BlockHalf.Lower),
            13526 => new PitcherCropBlock(Identifier, 3, BlockHalf.Upper),
            13527 => new PitcherCropBlock(Identifier, 3, BlockHalf.Lower),
            13528 => new PitcherCropBlock(Identifier, 4, BlockHalf.Upper),
            13529 => new PitcherCropBlock(Identifier, 4, BlockHalf.Lower),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
        };
    }
    
}
