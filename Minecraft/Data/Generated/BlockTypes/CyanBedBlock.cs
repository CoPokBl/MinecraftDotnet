using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1875,
                        BedPart.Foot => 1876,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1877,
                        BedPart.Foot => 1878,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1879,
                        BedPart.Foot => 1880,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1881,
                        BedPart.Foot => 1882,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1883,
                        BedPart.Foot => 1884,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1885,
                        BedPart.Foot => 1886,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1887,
                        BedPart.Foot => 1888,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1889,
                        BedPart.Foot => 1890,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1875 => new CyanBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1876 => new CyanBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1877 => new CyanBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1878 => new CyanBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1879 => new CyanBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1880 => new CyanBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1881 => new CyanBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1882 => new CyanBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1883 => new CyanBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1884 => new CyanBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1885 => new CyanBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1886 => new CyanBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1887 => new CyanBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1888 => new CyanBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1889 => new CyanBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1890 => new CyanBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
