using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedOxidizedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25748,
                    false => 25749,
                },
                false => Powered switch {
                    true => 25750,
                    false => 25751,
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25748 => new WaxedOxidizedCopperBulbBlock(Identifier, true, true),
            25749 => new WaxedOxidizedCopperBulbBlock(Identifier, true, false),
            25750 => new WaxedOxidizedCopperBulbBlock(Identifier, false, true),
            25751 => new WaxedOxidizedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
