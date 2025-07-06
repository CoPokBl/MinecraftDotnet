using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 25720,
                    false => 25721,
                },
                false => Powered switch {
                    true => 25722,
                    false => 25723,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25720 => new CopperBulbBlock(Identifier, true, true),
            25721 => new CopperBulbBlock(Identifier, true, false),
            25722 => new CopperBulbBlock(Identifier, false, true),
            25723 => new CopperBulbBlock(Identifier, false, false),
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
