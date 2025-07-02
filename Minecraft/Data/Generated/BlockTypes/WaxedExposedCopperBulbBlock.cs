using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedExposedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25740,
                    false => 25741,
                },
                false => Powered switch {
                    true => 25742,
                    false => 25743,
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25740 => new WaxedExposedCopperBulbBlock(Identifier, true, true),
            25741 => new WaxedExposedCopperBulbBlock(Identifier, true, false),
            25742 => new WaxedExposedCopperBulbBlock(Identifier, false, true),
            25743 => new WaxedExposedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
