using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackGlazedTerracottaBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 13747,
                Direction.South => 13748,
                Direction.West => 13749,
                Direction.East => 13750,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13747 => new BlackGlazedTerracottaBlock(Identifier, Direction.North),
            13748 => new BlackGlazedTerracottaBlock(Identifier, Direction.South),
            13749 => new BlackGlazedTerracottaBlock(Identifier, Direction.West),
            13750 => new BlackGlazedTerracottaBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
