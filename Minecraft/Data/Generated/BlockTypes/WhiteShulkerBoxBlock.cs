using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13591,
                Cardinal.East => 13592,
                Cardinal.South => 13593,
                Cardinal.West => 13594,
                Cardinal.Up => 13595,
                Cardinal.Down => 13596,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13591 => new WhiteShulkerBoxBlock(Identifier, Cardinal.North),
            13592 => new WhiteShulkerBoxBlock(Identifier, Cardinal.East),
            13593 => new WhiteShulkerBoxBlock(Identifier, Cardinal.South),
            13594 => new WhiteShulkerBoxBlock(Identifier, Cardinal.West),
            13595 => new WhiteShulkerBoxBlock(Identifier, Cardinal.Up),
            13596 => new WhiteShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
