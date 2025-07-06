using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TntBlock(Identifier Identifier, bool Unstable) : IBlock {

    public uint StateId {
        get {
            return Unstable switch {
                true => 2140,
                false => 2141,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2140 => new TntBlock(Identifier, true),
            2141 => new TntBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Unstable = properties["unstable"].GetString() == "true",
        };
    }
    
}
