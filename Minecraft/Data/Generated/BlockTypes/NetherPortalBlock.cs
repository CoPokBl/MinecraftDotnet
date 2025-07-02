using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record NetherPortalBlock(Identifier Identifier, NetherPortalBlock.Axis AxisValue) : IBlock {

    public uint StateId {
        get {
            return AxisValue switch {
                Axis.X => 6043,
                Axis.Z => 6044,
                _ => throw new ArgumentOutOfRangeException(nameof(AxisValue), AxisValue, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            6043 => new NetherPortalBlock(Identifier, Axis.X),
            6044 => new NetherPortalBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Axis {
        X,
        Z,
    }
}
