using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
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
    
    public IBlock WithState(uint state) {
        return state switch {
            25748 => new WaxedOxidizedCopperBulbBlock(Identifier, true, true),
            25749 => new WaxedOxidizedCopperBulbBlock(Identifier, true, false),
            25750 => new WaxedOxidizedCopperBulbBlock(Identifier, false, true),
            25751 => new WaxedOxidizedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties["lit"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
