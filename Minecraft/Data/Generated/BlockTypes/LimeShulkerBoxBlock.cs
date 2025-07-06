using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeShulkerBoxBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13621,
                Cardinal.East => 13622,
                Cardinal.South => 13623,
                Cardinal.West => 13624,
                Cardinal.Up => 13625,
                Cardinal.Down => 13626,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13621 => new LimeShulkerBoxBlock(Identifier, Cardinal.North),
            13622 => new LimeShulkerBoxBlock(Identifier, Cardinal.East),
            13623 => new LimeShulkerBoxBlock(Identifier, Cardinal.South),
            13624 => new LimeShulkerBoxBlock(Identifier, Cardinal.West),
            13625 => new LimeShulkerBoxBlock(Identifier, Cardinal.Up),
            13626 => new LimeShulkerBoxBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
