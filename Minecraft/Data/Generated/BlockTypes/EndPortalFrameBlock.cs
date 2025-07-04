using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record EndPortalFrameBlock(Identifier Identifier, bool Eye, Direction Facing) : IBlock {

    public uint StateId {
        get {
            return Eye switch {
                true => Facing switch {
                    Direction.North => 8191,
                    Direction.South => 8192,
                    Direction.West => 8193,
                    Direction.East => 8194,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => 8195,
                    Direction.South => 8196,
                    Direction.West => 8197,
                    Direction.East => 8198,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8191 => new EndPortalFrameBlock(Identifier, true, Direction.North),
            8192 => new EndPortalFrameBlock(Identifier, true, Direction.South),
            8193 => new EndPortalFrameBlock(Identifier, true, Direction.West),
            8194 => new EndPortalFrameBlock(Identifier, true, Direction.East),
            8195 => new EndPortalFrameBlock(Identifier, false, Direction.North),
            8196 => new EndPortalFrameBlock(Identifier, false, Direction.South),
            8197 => new EndPortalFrameBlock(Identifier, false, Direction.West),
            8198 => new EndPortalFrameBlock(Identifier, false, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eye = properties["eye"].GetString() == "true",
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
