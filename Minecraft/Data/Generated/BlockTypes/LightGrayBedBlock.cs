using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1859,
                        BedPart.Foot => 1860,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1861,
                        BedPart.Foot => 1862,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1863,
                        BedPart.Foot => 1864,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1865,
                        BedPart.Foot => 1866,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1867,
                        BedPart.Foot => 1868,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1869,
                        BedPart.Foot => 1870,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1871,
                        BedPart.Foot => 1872,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1873,
                        BedPart.Foot => 1874,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1859 => new LightGrayBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1860 => new LightGrayBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1861 => new LightGrayBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1862 => new LightGrayBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1863 => new LightGrayBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1864 => new LightGrayBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1865 => new LightGrayBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1866 => new LightGrayBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1867 => new LightGrayBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1868 => new LightGrayBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1869 => new LightGrayBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1870 => new LightGrayBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1871 => new LightGrayBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1872 => new LightGrayBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1873 => new LightGrayBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1874 => new LightGrayBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
