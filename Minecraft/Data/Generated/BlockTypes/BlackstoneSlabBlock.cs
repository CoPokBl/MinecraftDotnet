using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 20893,
                    false => 20894,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 20895,
                    false => 20896,
                },
                SlabType.Double => Waterlogged switch {
                    true => 20897,
                    false => 20898,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20893 => new BlackstoneSlabBlock(Identifier, SlabType.Top, true),
            20894 => new BlackstoneSlabBlock(Identifier, SlabType.Top, false),
            20895 => new BlackstoneSlabBlock(Identifier, SlabType.Bottom, true),
            20896 => new BlackstoneSlabBlock(Identifier, SlabType.Bottom, false),
            20897 => new BlackstoneSlabBlock(Identifier, SlabType.Double, true),
            20898 => new BlackstoneSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Type = SlabTypeExtensions.FromString(properties["type"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
