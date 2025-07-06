using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13707,
                Direction.South => 13708,
                Direction.West => 13709,
                Direction.East => 13710,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13707 => new LimeGlazedTerracottaBlock(Identifier, Direction.North),
            13708 => new LimeGlazedTerracottaBlock(Identifier, Direction.South),
            13709 => new LimeGlazedTerracottaBlock(Identifier, Direction.West),
            13710 => new LimeGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
