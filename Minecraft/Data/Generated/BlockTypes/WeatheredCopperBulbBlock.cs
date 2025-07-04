using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25728,
                    false => 25729,
                },
                false => Powered switch {
                    true => 25730,
                    false => 25731,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25728 => new WeatheredCopperBulbBlock(Identifier, true, true),
            25729 => new WeatheredCopperBulbBlock(Identifier, true, false),
            25730 => new WeatheredCopperBulbBlock(Identifier, false, true),
            25731 => new WeatheredCopperBulbBlock(Identifier, false, false),
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
