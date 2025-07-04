using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SnowBlock(Identifier Identifier, int Layers) : IBlock {

    public uint StateId {
        get {
            return Layers switch {
                1 => 5950,
                2 => 5951,
                3 => 5952,
                4 => 5953,
                5 => 5954,
                6 => 5955,
                7 => 5956,
                8 => 5957,
                _ => throw new ArgumentOutOfRangeException(nameof(Layers), Layers, "Unknown value for property layers.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5950 => new SnowBlock(Identifier, 1),
            5951 => new SnowBlock(Identifier, 2),
            5952 => new SnowBlock(Identifier, 3),
            5953 => new SnowBlock(Identifier, 4),
            5954 => new SnowBlock(Identifier, 5),
            5955 => new SnowBlock(Identifier, 6),
            5956 => new SnowBlock(Identifier, 7),
            5957 => new SnowBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Layers = int.Parse(properties["layers"].GetString()),
        };
    }
    
}
