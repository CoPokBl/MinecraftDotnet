using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedstoneLampBlock(Identifier Identifier, bool Lit) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => 8201,
                false => 8202,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8201 => new RedstoneLampBlock(Identifier, true),
            8202 => new RedstoneLampBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
        };
    }
    
}
