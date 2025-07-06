using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1955,
                        BedPart.Foot => 1956,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1957,
                        BedPart.Foot => 1958,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1959,
                        BedPart.Foot => 1960,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1961,
                        BedPart.Foot => 1962,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1963,
                        BedPart.Foot => 1964,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1965,
                        BedPart.Foot => 1966,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1967,
                        BedPart.Foot => 1968,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1969,
                        BedPart.Foot => 1970,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1955 => new RedBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1956 => new RedBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1957 => new RedBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1958 => new RedBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1959 => new RedBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1960 => new RedBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1961 => new RedBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1962 => new RedBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1963 => new RedBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1964 => new RedBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1965 => new RedBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1966 => new RedBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1967 => new RedBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1968 => new RedBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1969 => new RedBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1970 => new RedBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
