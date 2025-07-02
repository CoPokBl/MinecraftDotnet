using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record WaxedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25736,
                    false => 25737,
                },
                false => Powered switch {
                    true => 25738,
                    false => 25739,
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25736 => new WaxedCopperBulbBlock(Identifier, true, true),
            25737 => new WaxedCopperBulbBlock(Identifier, true, false),
            25738 => new WaxedCopperBulbBlock(Identifier, false, true),
            25739 => new WaxedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
