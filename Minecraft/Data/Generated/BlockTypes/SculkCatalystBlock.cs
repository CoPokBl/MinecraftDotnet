using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkCatalystBlock(Identifier Identifier, bool Bloom) : IBlock {

    public uint StateId {
        get {
            return Bloom switch {
                true => 23956,
                false => 23957,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23956 => new SculkCatalystBlock(Identifier, true),
            23957 => new SculkCatalystBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bloom = properties["bloom"].GetString() == "true",
        };
    }
    
}
