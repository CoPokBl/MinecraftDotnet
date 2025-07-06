using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12171,
                    false => 12172,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12173,
                    false => 12174,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12175,
                    false => 12176,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12171 => new NetherBrickSlabBlock(Identifier, SlabType.Top, true),
            12172 => new NetherBrickSlabBlock(Identifier, SlabType.Top, false),
            12173 => new NetherBrickSlabBlock(Identifier, SlabType.Bottom, true),
            12174 => new NetherBrickSlabBlock(Identifier, SlabType.Bottom, false),
            12175 => new NetherBrickSlabBlock(Identifier, SlabType.Double, true),
            12176 => new NetherBrickSlabBlock(Identifier, SlabType.Double, false),
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
