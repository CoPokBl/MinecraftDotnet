using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndStoneBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 15135,
                    false => 15136,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 15137,
                    false => 15138,
                },
                SlabType.Double => Waterlogged switch {
                    true => 15139,
                    false => 15140,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15135 => new EndStoneBrickSlabBlock(Identifier, SlabType.Top, true),
            15136 => new EndStoneBrickSlabBlock(Identifier, SlabType.Top, false),
            15137 => new EndStoneBrickSlabBlock(Identifier, SlabType.Bottom, true),
            15138 => new EndStoneBrickSlabBlock(Identifier, SlabType.Bottom, false),
            15139 => new EndStoneBrickSlabBlock(Identifier, SlabType.Double, true),
            15140 => new EndStoneBrickSlabBlock(Identifier, SlabType.Double, false),
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
