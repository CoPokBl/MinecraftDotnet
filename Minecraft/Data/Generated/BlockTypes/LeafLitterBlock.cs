using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LeafLitterBlock(Identifier Identifier, Direction Facing, int SegmentAmount) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => SegmentAmount switch {
                    1 => 25887,
                    2 => 25888,
                    3 => 25889,
                    4 => 25890,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 25891,
                    2 => 25892,
                    3 => 25893,
                    4 => 25894,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 25895,
                    2 => 25896,
                    3 => 25897,
                    4 => 25898,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 25899,
                    2 => 25900,
                    3 => 25901,
                    4 => 25902,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25887 => new LeafLitterBlock(Identifier, Direction.North, 1),
            25888 => new LeafLitterBlock(Identifier, Direction.North, 2),
            25889 => new LeafLitterBlock(Identifier, Direction.North, 3),
            25890 => new LeafLitterBlock(Identifier, Direction.North, 4),
            25891 => new LeafLitterBlock(Identifier, Direction.South, 1),
            25892 => new LeafLitterBlock(Identifier, Direction.South, 2),
            25893 => new LeafLitterBlock(Identifier, Direction.South, 3),
            25894 => new LeafLitterBlock(Identifier, Direction.South, 4),
            25895 => new LeafLitterBlock(Identifier, Direction.West, 1),
            25896 => new LeafLitterBlock(Identifier, Direction.West, 2),
            25897 => new LeafLitterBlock(Identifier, Direction.West, 3),
            25898 => new LeafLitterBlock(Identifier, Direction.West, 4),
            25899 => new LeafLitterBlock(Identifier, Direction.East, 1),
            25900 => new LeafLitterBlock(Identifier, Direction.East, 2),
            25901 => new LeafLitterBlock(Identifier, Direction.East, 3),
            25902 => new LeafLitterBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            SegmentAmount = int.Parse(properties["segment_amount"].GetString()),
        };
    }
    
}
