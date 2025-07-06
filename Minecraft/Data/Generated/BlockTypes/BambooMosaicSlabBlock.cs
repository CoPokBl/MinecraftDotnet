using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooMosaicSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12111,
                    false => 12112,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12113,
                    false => 12114,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12115,
                    false => 12116,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12111 => new BambooMosaicSlabBlock(Identifier, SlabType.Top, true),
            12112 => new BambooMosaicSlabBlock(Identifier, SlabType.Top, false),
            12113 => new BambooMosaicSlabBlock(Identifier, SlabType.Bottom, true),
            12114 => new BambooMosaicSlabBlock(Identifier, SlabType.Bottom, false),
            12115 => new BambooMosaicSlabBlock(Identifier, SlabType.Double, true),
            12116 => new BambooMosaicSlabBlock(Identifier, SlabType.Double, false),
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
