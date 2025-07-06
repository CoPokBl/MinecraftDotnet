using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1779,
                        BedPart.Foot => 1780,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1781,
                        BedPart.Foot => 1782,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1783,
                        BedPart.Foot => 1784,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1785,
                        BedPart.Foot => 1786,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1787,
                        BedPart.Foot => 1788,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1789,
                        BedPart.Foot => 1790,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1791,
                        BedPart.Foot => 1792,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1793,
                        BedPart.Foot => 1794,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1779 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1780 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1781 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1782 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1783 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1784 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1785 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1786 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1787 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1788 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1789 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1790 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1791 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1792 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1793 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1794 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
