using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record CaveVinesPlantBlock(Identifier Identifier, bool Berries) : IBlock {

    public uint StateId {
        get {
            return Berries switch {
                true => 25849,
                false => 25850,
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25849 => new CaveVinesPlantBlock(Identifier, true),
            25850 => new CaveVinesPlantBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
