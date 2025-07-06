using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1811,
                        BedPart.Foot => 1812,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1813,
                        BedPart.Foot => 1814,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1815,
                        BedPart.Foot => 1816,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1817,
                        BedPart.Foot => 1818,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1819,
                        BedPart.Foot => 1820,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1821,
                        BedPart.Foot => 1822,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1823,
                        BedPart.Foot => 1824,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1825,
                        BedPart.Foot => 1826,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1811 => new LimeBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1812 => new LimeBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1813 => new LimeBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1814 => new LimeBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1815 => new LimeBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1816 => new LimeBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1817 => new LimeBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1818 => new LimeBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1819 => new LimeBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1820 => new LimeBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1821 => new LimeBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1822 => new LimeBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1823 => new LimeBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1824 => new LimeBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1825 => new LimeBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1826 => new LimeBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
