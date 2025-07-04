using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SkeletonWallSkullBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9668,
                    false => 9669,
                },
                Direction.South => Powered switch {
                    true => 9670,
                    false => 9671,
                },
                Direction.West => Powered switch {
                    true => 9672,
                    false => 9673,
                },
                Direction.East => Powered switch {
                    true => 9674,
                    false => 9675,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9668 => new SkeletonWallSkullBlock(Identifier, Direction.North, true),
            9669 => new SkeletonWallSkullBlock(Identifier, Direction.North, false),
            9670 => new SkeletonWallSkullBlock(Identifier, Direction.South, true),
            9671 => new SkeletonWallSkullBlock(Identifier, Direction.South, false),
            9672 => new SkeletonWallSkullBlock(Identifier, Direction.West, true),
            9673 => new SkeletonWallSkullBlock(Identifier, Direction.West, false),
            9674 => new SkeletonWallSkullBlock(Identifier, Direction.East, true),
            9675 => new SkeletonWallSkullBlock(Identifier, Direction.East, false),
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
