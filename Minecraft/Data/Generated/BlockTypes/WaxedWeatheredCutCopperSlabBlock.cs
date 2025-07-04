using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24662,
                    false => 24663,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24664,
                    false => 24665,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24666,
                    false => 24667,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24662 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24663 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24664 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24665 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24666 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24667 => new WaxedWeatheredCutCopperSlabBlock(Identifier, SlabType.Double, false),
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
