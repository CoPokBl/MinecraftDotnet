using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutSandstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12135,
                    false => 12136,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12137,
                    false => 12138,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12139,
                    false => 12140,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12135 => new CutSandstoneSlabBlock(Identifier, SlabType.Top, true),
            12136 => new CutSandstoneSlabBlock(Identifier, SlabType.Top, false),
            12137 => new CutSandstoneSlabBlock(Identifier, SlabType.Bottom, true),
            12138 => new CutSandstoneSlabBlock(Identifier, SlabType.Bottom, false),
            12139 => new CutSandstoneSlabBlock(Identifier, SlabType.Double, true),
            12140 => new CutSandstoneSlabBlock(Identifier, SlabType.Double, false),
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
