using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakLogBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 157,
                Axis.Y => 158,
                Axis.Z => 159,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            157 => new PaleOakLogBlock(Identifier, Axis.X),
            158 => new PaleOakLogBlock(Identifier, Axis.Y),
            159 => new PaleOakLogBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = AxisExtensions.FromString(properties["axis"].GetString()),
        };
    }
    
}
