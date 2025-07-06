using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrassBlockBlock(Identifier Identifier, bool Snowy) : IBlock {

    public uint StateId {
        get {
            return Snowy switch {
                true => 8,
                false => 9,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8 => new GrassBlockBlock(Identifier, true),
            9 => new GrassBlockBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Snowy = properties["snowy"].GetString() == "true",
        };
    }
    
}
