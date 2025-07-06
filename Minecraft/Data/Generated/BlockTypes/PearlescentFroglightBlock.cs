using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PearlescentFroglightBlock(Identifier Identifier, Axis Axis) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => 27629,
                Axis.Y => 27630,
                Axis.Z => 27631,
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27629 => new PearlescentFroglightBlock(Identifier, Axis.X),
            27630 => new PearlescentFroglightBlock(Identifier, Axis.Y),
            27631 => new PearlescentFroglightBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = AxisExtensions.FromString(properties["axis"].GetString()),
        };
    }
    
}
