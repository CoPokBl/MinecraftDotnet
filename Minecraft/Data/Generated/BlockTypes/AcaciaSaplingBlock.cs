using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaSaplingBlock(Identifier Identifier, int Stage) : IBlock {

    public uint StateId {
        get {
            return Stage switch {
                0 => 37,
                1 => 38,
                _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            37 => new AcaciaSaplingBlock(Identifier, 0),
            38 => new AcaciaSaplingBlock(Identifier, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Stage = int.Parse(properties["stage"].GetString()),
        };
    }
    
}
