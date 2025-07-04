using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceWallSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 4866,
                    false => 4867,
                },
                Direction.South => Waterlogged switch {
                    true => 4868,
                    false => 4869,
                },
                Direction.West => Waterlogged switch {
                    true => 4870,
                    false => 4871,
                },
                Direction.East => Waterlogged switch {
                    true => 4872,
                    false => 4873,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4866 => new SpruceWallSignBlock(Identifier, Direction.North, true),
            4867 => new SpruceWallSignBlock(Identifier, Direction.North, false),
            4868 => new SpruceWallSignBlock(Identifier, Direction.South, true),
            4869 => new SpruceWallSignBlock(Identifier, Direction.South, false),
            4870 => new SpruceWallSignBlock(Identifier, Direction.West, true),
            4871 => new SpruceWallSignBlock(Identifier, Direction.West, false),
            4872 => new SpruceWallSignBlock(Identifier, Direction.East, true),
            4873 => new SpruceWallSignBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
