using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RespawnAnchorBlock(Identifier Identifier, int Charges) : IBlock {

    public uint StateId {
        get {
            return Charges switch {
                0 => 20478,
                1 => 20479,
                2 => 20480,
                3 => 20481,
                4 => 20482,
                _ => throw new ArgumentOutOfRangeException(nameof(Charges), Charges, "Unknown value for property charges.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20478 => new RespawnAnchorBlock(Identifier, 0),
            20479 => new RespawnAnchorBlock(Identifier, 1),
            20480 => new RespawnAnchorBlock(Identifier, 2),
            20481 => new RespawnAnchorBlock(Identifier, 3),
            20482 => new RespawnAnchorBlock(Identifier, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Charges = int.Parse(properties["charges"].GetString()),
        };
    }
    
}
