using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndRodBlock(Identifier Identifier, Cardinal Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => 13357,
                Cardinal.East => 13358,
                Cardinal.South => 13359,
                Cardinal.West => 13360,
                Cardinal.Up => 13361,
                Cardinal.Down => 13362,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13357 => new EndRodBlock(Identifier, Cardinal.North),
            13358 => new EndRodBlock(Identifier, Cardinal.East),
            13359 => new EndRodBlock(Identifier, Cardinal.South),
            13360 => new EndRodBlock(Identifier, Cardinal.West),
            13361 => new EndRodBlock(Identifier, Cardinal.Up),
            13362 => new EndRodBlock(Identifier, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
