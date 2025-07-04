using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCutCopperSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 24316,
                    false => 24317,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 24318,
                    false => 24319,
                },
                SlabType.Double => Waterlogged switch {
                    true => 24320,
                    false => 24321,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24316 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Top, true),
            24317 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Top, false),
            24318 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Bottom, true),
            24319 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Bottom, false),
            24320 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Double, true),
            24321 => new ExposedCutCopperSlabBlock(Identifier, SlabType.Double, false),
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
