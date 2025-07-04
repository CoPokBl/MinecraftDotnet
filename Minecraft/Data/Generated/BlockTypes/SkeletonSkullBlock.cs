using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 9636,
                    1 => 9637,
                    2 => 9638,
                    3 => 9639,
                    4 => 9640,
                    5 => 9641,
                    6 => 9642,
                    7 => 9643,
                    8 => 9644,
                    9 => 9645,
                    10 => 9646,
                    11 => 9647,
                    12 => 9648,
                    13 => 9649,
                    14 => 9650,
                    15 => 9651,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 9652,
                    1 => 9653,
                    2 => 9654,
                    3 => 9655,
                    4 => 9656,
                    5 => 9657,
                    6 => 9658,
                    7 => 9659,
                    8 => 9660,
                    9 => 9661,
                    10 => 9662,
                    11 => 9663,
                    12 => 9664,
                    13 => 9665,
                    14 => 9666,
                    15 => 9667,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9636 => new SkeletonSkullBlock(Identifier, true, 0),
            9637 => new SkeletonSkullBlock(Identifier, true, 1),
            9638 => new SkeletonSkullBlock(Identifier, true, 2),
            9639 => new SkeletonSkullBlock(Identifier, true, 3),
            9640 => new SkeletonSkullBlock(Identifier, true, 4),
            9641 => new SkeletonSkullBlock(Identifier, true, 5),
            9642 => new SkeletonSkullBlock(Identifier, true, 6),
            9643 => new SkeletonSkullBlock(Identifier, true, 7),
            9644 => new SkeletonSkullBlock(Identifier, true, 8),
            9645 => new SkeletonSkullBlock(Identifier, true, 9),
            9646 => new SkeletonSkullBlock(Identifier, true, 10),
            9647 => new SkeletonSkullBlock(Identifier, true, 11),
            9648 => new SkeletonSkullBlock(Identifier, true, 12),
            9649 => new SkeletonSkullBlock(Identifier, true, 13),
            9650 => new SkeletonSkullBlock(Identifier, true, 14),
            9651 => new SkeletonSkullBlock(Identifier, true, 15),
            9652 => new SkeletonSkullBlock(Identifier, false, 0),
            9653 => new SkeletonSkullBlock(Identifier, false, 1),
            9654 => new SkeletonSkullBlock(Identifier, false, 2),
            9655 => new SkeletonSkullBlock(Identifier, false, 3),
            9656 => new SkeletonSkullBlock(Identifier, false, 4),
            9657 => new SkeletonSkullBlock(Identifier, false, 5),
            9658 => new SkeletonSkullBlock(Identifier, false, 6),
            9659 => new SkeletonSkullBlock(Identifier, false, 7),
            9660 => new SkeletonSkullBlock(Identifier, false, 8),
            9661 => new SkeletonSkullBlock(Identifier, false, 9),
            9662 => new SkeletonSkullBlock(Identifier, false, 10),
            9663 => new SkeletonSkullBlock(Identifier, false, 11),
            9664 => new SkeletonSkullBlock(Identifier, false, 12),
            9665 => new SkeletonSkullBlock(Identifier, false, 13),
            9666 => new SkeletonSkullBlock(Identifier, false, 14),
            9667 => new SkeletonSkullBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties["powered"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
