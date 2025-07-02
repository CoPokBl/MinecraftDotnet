using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BrownBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1923,
                        BedPart.Foot => 1924,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1925,
                        BedPart.Foot => 1926,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1927,
                        BedPart.Foot => 1928,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1929,
                        BedPart.Foot => 1930,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1931,
                        BedPart.Foot => 1932,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1933,
                        BedPart.Foot => 1934,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1935,
                        BedPart.Foot => 1936,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1937,
                        BedPart.Foot => 1938,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            1923 => new BrownBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1924 => new BrownBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1925 => new BrownBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1926 => new BrownBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1927 => new BrownBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1928 => new BrownBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1929 => new BrownBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1930 => new BrownBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1931 => new BrownBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1932 => new BrownBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1933 => new BrownBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1934 => new BrownBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1935 => new BrownBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1936 => new BrownBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1937 => new BrownBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1938 => new BrownBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
