using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CutRedSandstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 12189,
                    false => 12190,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 12191,
                    false => 12192,
                },
                SlabType.Double => Waterlogged switch {
                    true => 12193,
                    false => 12194,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12189 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Top, true),
            12190 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Top, false),
            12191 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Bottom, true),
            12192 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Bottom, false),
            12193 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Double, true),
            12194 => new CutRedSandstoneSlabBlock(Identifier, SlabType.Double, false),
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
