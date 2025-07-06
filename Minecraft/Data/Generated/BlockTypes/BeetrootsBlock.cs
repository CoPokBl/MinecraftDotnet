using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BeetrootsBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 13532,
                1 => 13533,
                2 => 13534,
                3 => 13535,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13532 => new BeetrootsBlock(Identifier, 0),
            13533 => new BeetrootsBlock(Identifier, 1),
            13534 => new BeetrootsBlock(Identifier, 2),
            13535 => new BeetrootsBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
