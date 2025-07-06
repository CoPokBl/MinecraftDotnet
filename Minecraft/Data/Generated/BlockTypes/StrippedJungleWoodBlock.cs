using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StrippedJungleWoodBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 234,
                Axis.Y => 235,
                Axis.Z => 236,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            234 => new StrippedJungleWoodBlock(Identifier, Axis.X),
            235 => new StrippedJungleWoodBlock(Identifier, Axis.Y),
            236 => new StrippedJungleWoodBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = AxisExtensions.FromString(properties["axis"].GetString()),
        };
    }
    
}
