using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WitherSkeletonWallSkullBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9708,
                    false => 9709,
                },
                Direction.South => Powered switch {
                    true => 9710,
                    false => 9711,
                },
                Direction.West => Powered switch {
                    true => 9712,
                    false => 9713,
                },
                Direction.East => Powered switch {
                    true => 9714,
                    false => 9715,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9708 => new WitherSkeletonWallSkullBlock(Identifier, Direction.North, true),
            9709 => new WitherSkeletonWallSkullBlock(Identifier, Direction.North, false),
            9710 => new WitherSkeletonWallSkullBlock(Identifier, Direction.South, true),
            9711 => new WitherSkeletonWallSkullBlock(Identifier, Direction.South, false),
            9712 => new WitherSkeletonWallSkullBlock(Identifier, Direction.West, true),
            9713 => new WitherSkeletonWallSkullBlock(Identifier, Direction.West, false),
            9714 => new WitherSkeletonWallSkullBlock(Identifier, Direction.East, true),
            9715 => new WitherSkeletonWallSkullBlock(Identifier, Direction.East, false),
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
