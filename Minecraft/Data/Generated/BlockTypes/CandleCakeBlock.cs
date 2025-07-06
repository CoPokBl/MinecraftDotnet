using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CandleCakeBlock(Identifier Identifier, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => 22025,
                false => 22026,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22025 => new CandleCakeBlock(Identifier, true),
            22026 => new CandleCakeBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}
