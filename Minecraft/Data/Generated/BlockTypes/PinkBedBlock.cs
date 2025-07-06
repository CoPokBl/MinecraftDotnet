using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1827,
                        BedPart.Foot => 1828,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1829,
                        BedPart.Foot => 1830,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1831,
                        BedPart.Foot => 1832,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1833,
                        BedPart.Foot => 1834,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1835,
                        BedPart.Foot => 1836,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1837,
                        BedPart.Foot => 1838,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1839,
                        BedPart.Foot => 1840,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1841,
                        BedPart.Foot => 1842,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1827 => new PinkBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1828 => new PinkBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1829 => new PinkBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1830 => new PinkBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1831 => new PinkBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1832 => new PinkBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1833 => new PinkBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1834 => new PinkBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1835 => new PinkBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1836 => new PinkBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1837 => new PinkBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1838 => new PinkBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1839 => new PinkBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1840 => new PinkBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1841 => new PinkBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1842 => new PinkBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
