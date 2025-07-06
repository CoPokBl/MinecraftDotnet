using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GraniteSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15153,
                    false => 15154,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15155,
                    false => 15156,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15157,
                    false => 15158,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15153 => new GraniteSlabBlock(Identifier, SlabType.Top, true),
            15154 => new GraniteSlabBlock(Identifier, SlabType.Top, false),
            15155 => new GraniteSlabBlock(Identifier, SlabType.Bottom, true),
            15156 => new GraniteSlabBlock(Identifier, SlabType.Bottom, false),
            15157 => new GraniteSlabBlock(Identifier, SlabType.Double, true),
            15158 => new GraniteSlabBlock(Identifier, SlabType.Double, false),
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
