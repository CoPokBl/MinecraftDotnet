using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BlueBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1907,
                        BedPart.Foot => 1908,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1909,
                        BedPart.Foot => 1910,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1911,
                        BedPart.Foot => 1912,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1913,
                        BedPart.Foot => 1914,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1915,
                        BedPart.Foot => 1916,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1917,
                        BedPart.Foot => 1918,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1919,
                        BedPart.Foot => 1920,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1921,
                        BedPart.Foot => 1922,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            1907 => new BlueBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1908 => new BlueBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1909 => new BlueBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1910 => new BlueBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1911 => new BlueBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1912 => new BlueBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1913 => new BlueBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1914 => new BlueBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1915 => new BlueBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1916 => new BlueBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1917 => new BlueBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1918 => new BlueBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1919 => new BlueBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1920 => new BlueBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1921 => new BlueBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1922 => new BlueBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
