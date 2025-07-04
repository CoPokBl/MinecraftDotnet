using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1731,
                        BedPart.Foot => 1732,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1733,
                        BedPart.Foot => 1734,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1735,
                        BedPart.Foot => 1736,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1737,
                        BedPart.Foot => 1738,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1739,
                        BedPart.Foot => 1740,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1741,
                        BedPart.Foot => 1742,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1743,
                        BedPart.Foot => 1744,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1745,
                        BedPart.Foot => 1746,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1731 => new WhiteBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1732 => new WhiteBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1733 => new WhiteBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1734 => new WhiteBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1735 => new WhiteBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1736 => new WhiteBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1737 => new WhiteBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1738 => new WhiteBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1739 => new WhiteBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1740 => new WhiteBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1741 => new WhiteBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1742 => new WhiteBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1743 => new WhiteBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1744 => new WhiteBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1745 => new WhiteBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1746 => new WhiteBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
