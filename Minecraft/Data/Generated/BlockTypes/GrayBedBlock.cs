using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1843,
                        BedPart.Foot => 1844,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1845,
                        BedPart.Foot => 1846,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1847,
                        BedPart.Foot => 1848,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1849,
                        BedPart.Foot => 1850,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1851,
                        BedPart.Foot => 1852,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1853,
                        BedPart.Foot => 1854,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1855,
                        BedPart.Foot => 1856,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1857,
                        BedPart.Foot => 1858,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1843 => new GrayBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1844 => new GrayBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1845 => new GrayBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1846 => new GrayBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1847 => new GrayBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1848 => new GrayBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1849 => new GrayBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1850 => new GrayBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1851 => new GrayBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1852 => new GrayBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1853 => new GrayBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1854 => new GrayBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1855 => new GrayBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1856 => new GrayBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1857 => new GrayBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1858 => new GrayBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
