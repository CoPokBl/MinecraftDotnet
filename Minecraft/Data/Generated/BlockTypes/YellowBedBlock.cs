using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1795,
                        BedPart.Foot => 1796,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1797,
                        BedPart.Foot => 1798,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1799,
                        BedPart.Foot => 1800,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1801,
                        BedPart.Foot => 1802,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1803,
                        BedPart.Foot => 1804,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1805,
                        BedPart.Foot => 1806,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1807,
                        BedPart.Foot => 1808,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1809,
                        BedPart.Foot => 1810,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1795 => new YellowBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1796 => new YellowBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1797 => new YellowBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1798 => new YellowBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1799 => new YellowBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1800 => new YellowBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1801 => new YellowBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1802 => new YellowBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1803 => new YellowBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1804 => new YellowBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1805 => new YellowBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1806 => new YellowBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1807 => new YellowBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1808 => new YellowBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1809 => new YellowBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1810 => new YellowBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Occupied = properties["occupied"].GetString() == "true",
            Part = BedPartExtensions.FromString(properties["part"].GetString()),
        };
    }
    
}
