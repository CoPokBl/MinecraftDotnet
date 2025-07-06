using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TuffSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 22110,
                    false => 22111,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 22112,
                    false => 22113,
                },
                SlabType.Double => Waterlogged switch {
                    true => 22114,
                    false => 22115,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22110 => new TuffSlabBlock(Identifier, SlabType.Top, true),
            22111 => new TuffSlabBlock(Identifier, SlabType.Top, false),
            22112 => new TuffSlabBlock(Identifier, SlabType.Bottom, true),
            22113 => new TuffSlabBlock(Identifier, SlabType.Bottom, false),
            22114 => new TuffSlabBlock(Identifier, SlabType.Double, true),
            22115 => new TuffSlabBlock(Identifier, SlabType.Double, false),
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
