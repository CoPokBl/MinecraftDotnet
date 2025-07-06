using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1891,
                        BedPart.Foot => 1892,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1893,
                        BedPart.Foot => 1894,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1895,
                        BedPart.Foot => 1896,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1897,
                        BedPart.Foot => 1898,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1899,
                        BedPart.Foot => 1900,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1901,
                        BedPart.Foot => 1902,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1903,
                        BedPart.Foot => 1904,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1905,
                        BedPart.Foot => 1906,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1891 => new PurpleBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1892 => new PurpleBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1893 => new PurpleBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1894 => new PurpleBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1895 => new PurpleBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1896 => new PurpleBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1897 => new PurpleBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1898 => new PurpleBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1899 => new PurpleBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1900 => new PurpleBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1901 => new PurpleBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1902 => new PurpleBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1903 => new PurpleBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1904 => new PurpleBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1905 => new PurpleBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1906 => new PurpleBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
