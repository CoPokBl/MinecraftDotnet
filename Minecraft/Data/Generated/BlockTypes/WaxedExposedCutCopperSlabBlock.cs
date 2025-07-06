using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24668,
                    false => 24669,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24670,
                    false => 24671,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24672,
                    false => 24673,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24668 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24669 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24670 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24671 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24672 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24673 => new WaxedExposedCutCopperSlabBlock(Identifier, SlabType.Double, false),
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
