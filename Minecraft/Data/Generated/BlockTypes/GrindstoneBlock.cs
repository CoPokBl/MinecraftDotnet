using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrindstoneBlock(Identifier Identifier, AttachDirection Face, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => 19461,
                    Direction.South => 19462,
                    Direction.West => 19463,
                    Direction.East => 19464,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => 19465,
                    Direction.South => 19466,
                    Direction.West => 19467,
                    Direction.East => 19468,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => 19469,
                    Direction.South => 19470,
                    Direction.West => 19471,
                    Direction.East => 19472,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19461 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.North),
            19462 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.South),
            19463 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.West),
            19464 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.East),
            19465 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.North),
            19466 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.South),
            19467 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.West),
            19468 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.East),
            19469 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.North),
            19470 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.South),
            19471 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.West),
            19472 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = AttachDirectionExtensions.FromString(properties["face"].GetString()),
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
