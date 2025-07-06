using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LargeFernBlock(Identifier Identifier, BlockHalf Half) : IBlock {

    public uint StateId {
        get {
            return Half switch {
                BlockHalf.Upper => 11646,
                BlockHalf.Lower => 11647,
                _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11646 => new LargeFernBlock(Identifier, BlockHalf.Upper),
            11647 => new LargeFernBlock(Identifier, BlockHalf.Lower),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
        };
    }
    
}
