using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PolishedBlackstoneSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 21394,
                    false => 21395,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 21396,
                    false => 21397,
                },
                SlabType.Double => Waterlogged switch {
                    true => 21398,
                    false => 21399,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21394 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Top, true),
            21395 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Top, false),
            21396 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Bottom, true),
            21397 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Bottom, false),
            21398 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Double, true),
            21399 => new PolishedBlackstoneSlabBlock(Identifier, SlabType.Double, false),
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
