using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1763,
                        BedPart.Foot => 1764,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1765,
                        BedPart.Foot => 1766,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1767,
                        BedPart.Foot => 1768,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1769,
                        BedPart.Foot => 1770,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1771,
                        BedPart.Foot => 1772,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1773,
                        BedPart.Foot => 1774,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1775,
                        BedPart.Foot => 1776,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1777,
                        BedPart.Foot => 1778,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1763 => new MagentaBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1764 => new MagentaBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1765 => new MagentaBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1766 => new MagentaBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1767 => new MagentaBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1768 => new MagentaBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1769 => new MagentaBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1770 => new MagentaBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1771 => new MagentaBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1772 => new MagentaBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1773 => new MagentaBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1774 => new MagentaBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1775 => new MagentaBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1776 => new MagentaBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1777 => new MagentaBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1778 => new MagentaBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
