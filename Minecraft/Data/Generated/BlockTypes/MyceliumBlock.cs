using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MyceliumBlock(Identifier Identifier, bool Snowy) : IBlock {

    public uint StateId {
        get {
            return Snowy switch {
                true => 7640,
                false => 7641,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7640 => new MyceliumBlock(Identifier, true),
            7641 => new MyceliumBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Snowy = properties["snowy"].GetString() == "true",
        };
    }
    
}
