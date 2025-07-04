using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DamagedAnvilBlock(Identifier Identifier, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 9924,
                Direction.South => 9925,
                Direction.West => 9926,
                Direction.East => 9927,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9924 => new DamagedAnvilBlock(Identifier, Direction.North),
            9925 => new DamagedAnvilBlock(Identifier, Direction.South),
            9926 => new DamagedAnvilBlock(Identifier, Direction.West),
            9927 => new DamagedAnvilBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
