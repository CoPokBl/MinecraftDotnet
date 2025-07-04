using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SoulLanternBlock(Identifier Identifier, bool Hanging, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Hanging switch {
                true => Waterlogged switch {
                    true => 19530,
                    false => 19531,
                },
                false => Waterlogged switch {
                    true => 19532,
                    false => 19533,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19530 => new SoulLanternBlock(Identifier, true, true),
            19531 => new SoulLanternBlock(Identifier, true, false),
            19532 => new SoulLanternBlock(Identifier, false, true),
            19533 => new SoulLanternBlock(Identifier, false, false),
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
