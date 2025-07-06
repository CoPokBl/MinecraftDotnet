using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25732,
                    false => 25733,
                },
                false => Powered switch {
                    true => 25734,
                    false => 25735,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25732 => new OxidizedCopperBulbBlock(Identifier, true, true),
            25733 => new OxidizedCopperBulbBlock(Identifier, true, false),
            25734 => new OxidizedCopperBulbBlock(Identifier, false, true),
            25735 => new OxidizedCopperBulbBlock(Identifier, false, false),
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
