using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12105,
                    false => 12106,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12107,
                    false => 12108,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12109,
                    false => 12110,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12105 => new BambooSlabBlock(Identifier, SlabType.Top, true),
            12106 => new BambooSlabBlock(Identifier, SlabType.Top, false),
            12107 => new BambooSlabBlock(Identifier, SlabType.Bottom, true),
            12108 => new BambooSlabBlock(Identifier, SlabType.Bottom, false),
            12109 => new BambooSlabBlock(Identifier, SlabType.Double, true),
            12110 => new BambooSlabBlock(Identifier, SlabType.Double, false),
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
