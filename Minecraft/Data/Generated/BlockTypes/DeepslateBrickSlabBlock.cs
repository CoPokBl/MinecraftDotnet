using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeepslateBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 27281,
                    false => 27282,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 27283,
                    false => 27284,
                },
                SlabType.Double => Waterlogged switch {
                    true => 27285,
                    false => 27286,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27281 => new DeepslateBrickSlabBlock(Identifier, SlabType.Top, true),
            27282 => new DeepslateBrickSlabBlock(Identifier, SlabType.Top, false),
            27283 => new DeepslateBrickSlabBlock(Identifier, SlabType.Bottom, true),
            27284 => new DeepslateBrickSlabBlock(Identifier, SlabType.Bottom, false),
            27285 => new DeepslateBrickSlabBlock(Identifier, SlabType.Double, true),
            27286 => new DeepslateBrickSlabBlock(Identifier, SlabType.Double, false),
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
