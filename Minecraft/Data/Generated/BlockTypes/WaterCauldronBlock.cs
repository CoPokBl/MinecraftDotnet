using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaterCauldronBlock(Identifier Identifier, int Level) : IBlock {

    public uint StateId {
        get {
            return Level switch {
                1 => 8183,
                2 => 8184,
                3 => 8185,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8183 => new WaterCauldronBlock(Identifier, 1),
            8184 => new WaterCauldronBlock(Identifier, 2),
            8185 => new WaterCauldronBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = int.Parse(properties["level"].GetString()),
        };
    }
    
}
