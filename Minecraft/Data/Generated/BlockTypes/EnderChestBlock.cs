using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EnderChestBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 8297,
                    false => 8298,
                },
                Direction.South => Waterlogged switch {
                    true => 8299,
                    false => 8300,
                },
                Direction.West => Waterlogged switch {
                    true => 8301,
                    false => 8302,
                },
                Direction.East => Waterlogged switch {
                    true => 8303,
                    false => 8304,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8297 => new EnderChestBlock(Identifier, Direction.North, true),
            8298 => new EnderChestBlock(Identifier, Direction.North, false),
            8299 => new EnderChestBlock(Identifier, Direction.South, true),
            8300 => new EnderChestBlock(Identifier, Direction.South, false),
            8301 => new EnderChestBlock(Identifier, Direction.West, true),
            8302 => new EnderChestBlock(Identifier, Direction.West, false),
            8303 => new EnderChestBlock(Identifier, Direction.East, true),
            8304 => new EnderChestBlock(Identifier, Direction.East, false),
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
