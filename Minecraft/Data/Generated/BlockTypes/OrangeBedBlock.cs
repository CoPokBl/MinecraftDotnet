using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1747,
                        BedPart.Foot => 1748,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1749,
                        BedPart.Foot => 1750,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1751,
                        BedPart.Foot => 1752,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1753,
                        BedPart.Foot => 1754,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1755,
                        BedPart.Foot => 1756,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1757,
                        BedPart.Foot => 1758,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1759,
                        BedPart.Foot => 1760,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1761,
                        BedPart.Foot => 1762,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1747 => new OrangeBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1748 => new OrangeBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1749 => new OrangeBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1750 => new OrangeBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1751 => new OrangeBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1752 => new OrangeBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1753 => new OrangeBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1754 => new OrangeBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1755 => new OrangeBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1756 => new OrangeBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1757 => new OrangeBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1758 => new OrangeBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1759 => new OrangeBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1760 => new OrangeBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1761 => new OrangeBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1762 => new OrangeBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
