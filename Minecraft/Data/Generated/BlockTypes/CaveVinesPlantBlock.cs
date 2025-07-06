using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CaveVinesPlantBlock(Identifier Identifier, bool Berries) : IBlock {

    public uint StateId {
        get {
            return Berries switch {
                true => 25849,
                false => 25850,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25849 => new CaveVinesPlantBlock(Identifier, true),
            25850 => new CaveVinesPlantBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Berries = properties["berries"].GetString() == "true",
        };
    }
    
}
