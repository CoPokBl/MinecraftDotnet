using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DragonWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 9868,
                    false => 9869,
                },
                Direction.South => Powered switch {
                    true => 9870,
                    false => 9871,
                },
                Direction.West => Powered switch {
                    true => 9872,
                    false => 9873,
                },
                Direction.East => Powered switch {
                    true => 9874,
                    false => 9875,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9868 => new DragonWallHeadBlock(Identifier, Direction.North, true),
            9869 => new DragonWallHeadBlock(Identifier, Direction.North, false),
            9870 => new DragonWallHeadBlock(Identifier, Direction.South, true),
            9871 => new DragonWallHeadBlock(Identifier, Direction.South, false),
            9872 => new DragonWallHeadBlock(Identifier, Direction.West, true),
            9873 => new DragonWallHeadBlock(Identifier, Direction.West, false),
            9874 => new DragonWallHeadBlock(Identifier, Direction.East, true),
            9875 => new DragonWallHeadBlock(Identifier, Direction.East, false),
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
