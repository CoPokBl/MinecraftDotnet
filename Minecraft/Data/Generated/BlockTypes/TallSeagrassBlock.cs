using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TallSeagrassBlock(Identifier Identifier, BlockHalf Half) : IBlock {

    public uint StateId {
        get {
            return Half switch {
                BlockHalf.Upper => 2055,
                BlockHalf.Lower => 2056,
                _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2055 => new TallSeagrassBlock(Identifier, BlockHalf.Upper),
            2056 => new TallSeagrassBlock(Identifier, BlockHalf.Lower),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
        };
    }
    
}
