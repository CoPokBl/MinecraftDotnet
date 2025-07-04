using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13639,
                Cardinal.East => 13640,
                Cardinal.South => 13641,
                Cardinal.West => 13642,
                Cardinal.Up => 13643,
                Cardinal.Down => 13644,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13639 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.North),
            13640 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.East),
            13641 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.South),
            13642 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.West),
            13643 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.Up),
            13644 => new LightGrayShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
