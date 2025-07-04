using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonPressurePlateBlock(Identifier Identifier, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => 19703,
                false => 19704,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19703 => new CrimsonPressurePlateBlock(Identifier, true),
            19704 => new CrimsonPressurePlateBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
