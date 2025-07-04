using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19899,
                            false => 19900,
                        },
                        false => Powered switch {
                            true => 19901,
                            false => 19902,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19903,
                            false => 19904,
                        },
                        false => Powered switch {
                            true => 19905,
                            false => 19906,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19907,
                            false => 19908,
                        },
                        false => Powered switch {
                            true => 19909,
                            false => 19910,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19911,
                            false => 19912,
                        },
                        false => Powered switch {
                            true => 19913,
                            false => 19914,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19915,
                            false => 19916,
                        },
                        false => Powered switch {
                            true => 19917,
                            false => 19918,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19919,
                            false => 19920,
                        },
                        false => Powered switch {
                            true => 19921,
                            false => 19922,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19923,
                            false => 19924,
                        },
                        false => Powered switch {
                            true => 19925,
                            false => 19926,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19927,
                            false => 19928,
                        },
                        false => Powered switch {
                            true => 19929,
                            false => 19930,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19899 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, true),
            19900 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, false),
            19901 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, true),
            19902 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, false),
            19903 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, true),
            19904 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, false),
            19905 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, true),
            19906 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, false),
            19907 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, true),
            19908 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, false),
            19909 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, true),
            19910 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, false),
            19911 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, true),
            19912 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, false),
            19913 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, true),
            19914 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, false),
            19915 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, true),
            19916 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, false),
            19917 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, true),
            19918 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, false),
            19919 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, true),
            19920 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, false),
            19921 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, true),
            19922 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, false),
            19923 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, true),
            19924 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, false),
            19925 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, true),
            19926 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, false),
            19927 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, true),
            19928 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, false),
            19929 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, true),
            19930 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            InWall = properties["in_wall"].GetString() == "true",
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
