using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceWallHangingSignBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 5714,
                    false => 5715,
                },
                Direction.South => Waterlogged switch {
                    true => 5716,
                    false => 5717,
                },
                Direction.West => Waterlogged switch {
                    true => 5718,
                    false => 5719,
                },
                Direction.East => Waterlogged switch {
                    true => 5720,
                    false => 5721,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5714 => new SpruceWallHangingSignBlock(Identifier, Direction.North, true),
            5715 => new SpruceWallHangingSignBlock(Identifier, Direction.North, false),
            5716 => new SpruceWallHangingSignBlock(Identifier, Direction.South, true),
            5717 => new SpruceWallHangingSignBlock(Identifier, Direction.South, false),
            5718 => new SpruceWallHangingSignBlock(Identifier, Direction.West, true),
            5719 => new SpruceWallHangingSignBlock(Identifier, Direction.West, false),
            5720 => new SpruceWallHangingSignBlock(Identifier, Direction.East, true),
            5721 => new SpruceWallHangingSignBlock(Identifier, Direction.East, false),
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
