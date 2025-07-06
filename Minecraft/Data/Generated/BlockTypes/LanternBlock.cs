using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LanternBlock(Identifier Identifier, bool Hanging, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Hanging switch {
                true => Waterlogged switch {
                    true => 19526,
                    false => 19527,
                },
                false => Waterlogged switch {
                    true => 19528,
                    false => 19529,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19526 => new LanternBlock(Identifier, true, true),
            19527 => new LanternBlock(Identifier, true, false),
            19528 => new LanternBlock(Identifier, false, true),
            19529 => new LanternBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Hanging = properties["hanging"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
