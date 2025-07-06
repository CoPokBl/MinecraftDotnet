using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
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
    
    public IBlock WithState(uint state) {
        return state switch {
            25724 => new ExposedCopperBulbBlock(Identifier, true, true),
            25725 => new ExposedCopperBulbBlock(Identifier, true, false),
            25726 => new ExposedCopperBulbBlock(Identifier, false, true),
            25727 => new ExposedCopperBulbBlock(Identifier, false, false),
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
