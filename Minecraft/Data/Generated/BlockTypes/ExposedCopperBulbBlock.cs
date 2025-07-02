using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ExposedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25724,
                    false => 25725,
                },
                false => Powered switch {
                    true => 25726,
                    false => 25727,
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25724 => new ExposedCopperBulbBlock(Identifier, true, true),
            25725 => new ExposedCopperBulbBlock(Identifier, true, false),
            25726 => new ExposedCopperBulbBlock(Identifier, false, true),
            25727 => new ExposedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
