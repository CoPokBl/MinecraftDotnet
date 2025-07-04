using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25744,
                    false => 25745,
                },
                false => Powered switch {
                    true => 25746,
                    false => 25747,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25744 => new WaxedWeatheredCopperBulbBlock(Identifier, true, true),
            25745 => new WaxedWeatheredCopperBulbBlock(Identifier, true, false),
            25746 => new WaxedWeatheredCopperBulbBlock(Identifier, false, true),
            25747 => new WaxedWeatheredCopperBulbBlock(Identifier, false, false),
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
