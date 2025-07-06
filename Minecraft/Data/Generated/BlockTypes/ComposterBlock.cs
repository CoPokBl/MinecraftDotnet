using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ComposterBlock(Identifier Identifier, int Level) : IBlock {

    public uint StateId {
        get {
            return Level switch {
                0 => 20400,
                1 => 20401,
                2 => 20402,
                3 => 20403,
                4 => 20404,
                5 => 20405,
                6 => 20406,
                7 => 20407,
                8 => 20408,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20400 => new ComposterBlock(Identifier, 0),
            20401 => new ComposterBlock(Identifier, 1),
            20402 => new ComposterBlock(Identifier, 2),
            20403 => new ComposterBlock(Identifier, 3),
            20404 => new ComposterBlock(Identifier, 4),
            20405 => new ComposterBlock(Identifier, 5),
            20406 => new ComposterBlock(Identifier, 6),
            20407 => new ComposterBlock(Identifier, 7),
            20408 => new ComposterBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = int.Parse(properties["level"].GetString()),
        };
    }
    
}
