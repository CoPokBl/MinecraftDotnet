using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PotatoesBlock(Identifier Identifier, int Age) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => 9388,
                1 => 9389,
                2 => 9390,
                3 => 9391,
                4 => 9392,
                5 => 9393,
                6 => 9394,
                7 => 9395,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9388 => new PotatoesBlock(Identifier, 0),
            9389 => new PotatoesBlock(Identifier, 1),
            9390 => new PotatoesBlock(Identifier, 2),
            9391 => new PotatoesBlock(Identifier, 3),
            9392 => new PotatoesBlock(Identifier, 4),
            9393 => new PotatoesBlock(Identifier, 5),
            9394 => new PotatoesBlock(Identifier, 6),
            9395 => new PotatoesBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
