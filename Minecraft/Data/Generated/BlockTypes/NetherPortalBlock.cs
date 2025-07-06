using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
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
    
    public IBlock WithState(uint state) {
        return state switch {
            6043 => new NetherPortalBlock(Identifier, Axis.X),
            6044 => new NetherPortalBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AxisValue = AxisFromString(properties["axis"].GetString()),
        };
    }
    
    public enum Axis {
        X,
        Z,
    }

    public static Axis AxisFromString(string value) {
        return value switch {
            "x" => Axis.X,
            "z" => Axis.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Axis.")
        };
    }
}
