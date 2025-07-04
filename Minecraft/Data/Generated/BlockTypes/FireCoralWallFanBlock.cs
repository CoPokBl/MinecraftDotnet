using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FireCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13940,
                    false => 13941,
                },
                Direction.South => Waterlogged switch {
                    true => 13942,
                    false => 13943,
                },
                Direction.West => Waterlogged switch {
                    true => 13944,
                    false => 13945,
                },
                Direction.East => Waterlogged switch {
                    true => 13946,
                    false => 13947,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13940 => new FireCoralWallFanBlock(Identifier, Direction.North, true),
            13941 => new FireCoralWallFanBlock(Identifier, Direction.North, false),
            13942 => new FireCoralWallFanBlock(Identifier, Direction.South, true),
            13943 => new FireCoralWallFanBlock(Identifier, Direction.South, false),
            13944 => new FireCoralWallFanBlock(Identifier, Direction.West, true),
            13945 => new FireCoralWallFanBlock(Identifier, Direction.West, false),
            13946 => new FireCoralWallFanBlock(Identifier, Direction.East, true),
            13947 => new FireCoralWallFanBlock(Identifier, Direction.East, false),
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
