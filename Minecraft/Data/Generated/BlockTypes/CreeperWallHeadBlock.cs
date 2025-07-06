using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CreeperWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9828,
                    false => 9829,
                },
                Direction.South => Powered switch {
                    true => 9830,
                    false => 9831,
                },
                Direction.West => Powered switch {
                    true => 9832,
                    false => 9833,
                },
                Direction.East => Powered switch {
                    true => 9834,
                    false => 9835,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9828 => new CreeperWallHeadBlock(Identifier, Direction.North, true),
            9829 => new CreeperWallHeadBlock(Identifier, Direction.North, false),
            9830 => new CreeperWallHeadBlock(Identifier, Direction.South, true),
            9831 => new CreeperWallHeadBlock(Identifier, Direction.South, false),
            9832 => new CreeperWallHeadBlock(Identifier, Direction.West, true),
            9833 => new CreeperWallHeadBlock(Identifier, Direction.West, false),
            9834 => new CreeperWallHeadBlock(Identifier, Direction.East, true),
            9835 => new CreeperWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
