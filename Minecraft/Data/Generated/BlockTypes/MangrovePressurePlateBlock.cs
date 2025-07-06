using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangrovePressurePlateBlock(Identifier Identifier, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => 5908,
                false => 5909,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5908 => new MangrovePressurePlateBlock(Identifier, true),
            5909 => new MangrovePressurePlateBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
