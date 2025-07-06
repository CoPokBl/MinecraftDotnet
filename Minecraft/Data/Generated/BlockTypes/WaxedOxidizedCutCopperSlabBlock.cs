using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24656,
                    false => 24657,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24658,
                    false => 24659,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24660,
                    false => 24661,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24656 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24657 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24658 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24659 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24660 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24661 => new WaxedOxidizedCutCopperSlabBlock(Identifier, SlabType.Double, false),
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
