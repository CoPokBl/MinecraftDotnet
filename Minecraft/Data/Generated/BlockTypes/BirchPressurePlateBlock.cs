using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchPressurePlateBlock(Identifier Identifier, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => 5896,
                false => 5897,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5896 => new BirchPressurePlateBlock(Identifier, true),
            5897 => new BirchPressurePlateBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
