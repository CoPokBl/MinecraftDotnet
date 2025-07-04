using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChainBlock(Identifier Identifier, Axis Axis, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Axis switch {
                Axis.X => Waterlogged switch {
                    true => 7016,
                    false => 7017,
                },
                Axis.Y => Waterlogged switch {
                    true => 7018,
                    false => 7019,
                },
                Axis.Z => Waterlogged switch {
                    true => 7020,
                    false => 7021,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7016 => new ChainBlock(Identifier, Axis.X, true),
            7017 => new ChainBlock(Identifier, Axis.X, false),
            7018 => new ChainBlock(Identifier, Axis.Y, true),
            7019 => new ChainBlock(Identifier, Axis.Y, false),
            7020 => new ChainBlock(Identifier, Axis.Z, true),
            7021 => new ChainBlock(Identifier, Axis.Z, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = AxisExtensions.FromString(properties["axis"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
