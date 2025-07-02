using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlackBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1971,
                        BedPart.Foot => 1972,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1973,
                        BedPart.Foot => 1974,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1975,
                        BedPart.Foot => 1976,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1977,
                        BedPart.Foot => 1978,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1979,
                        BedPart.Foot => 1980,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1981,
                        BedPart.Foot => 1982,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1983,
                        BedPart.Foot => 1984,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1985,
                        BedPart.Foot => 1986,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            1971 => new BlackBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1972 => new BlackBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1973 => new BlackBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1974 => new BlackBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1975 => new BlackBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1976 => new BlackBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1977 => new BlackBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1978 => new BlackBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1979 => new BlackBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1980 => new BlackBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1981 => new BlackBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1982 => new BlackBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1983 => new BlackBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1984 => new BlackBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1985 => new BlackBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1986 => new BlackBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
