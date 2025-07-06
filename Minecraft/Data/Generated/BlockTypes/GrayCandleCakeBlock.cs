using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayCandleCakeBlock(Identifier Identifier, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => 22041,
                false => 22042,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22041 => new GrayCandleCakeBlock(Identifier, true),
            22042 => new GrayCandleCakeBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}
