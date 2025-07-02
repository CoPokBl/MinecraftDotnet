using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record GreenBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1939,
                        BedPart.Foot => 1940,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1941,
                        BedPart.Foot => 1942,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1943,
                        BedPart.Foot => 1944,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1945,
                        BedPart.Foot => 1946,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1947,
                        BedPart.Foot => 1948,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1949,
                        BedPart.Foot => 1950,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1951,
                        BedPart.Foot => 1952,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1953,
                        BedPart.Foot => 1954,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            1939 => new GreenBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1940 => new GreenBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1941 => new GreenBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1942 => new GreenBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1943 => new GreenBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1944 => new GreenBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1945 => new GreenBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1946 => new GreenBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1947 => new GreenBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1948 => new GreenBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1949 => new GreenBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1950 => new GreenBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1951 => new GreenBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1952 => new GreenBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1953 => new GreenBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1954 => new GreenBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
