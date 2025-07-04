using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19931,
                            false => 19932,
                        },
                        false => Powered switch {
                            true => 19933,
                            false => 19934,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19935,
                            false => 19936,
                        },
                        false => Powered switch {
                            true => 19937,
                            false => 19938,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19939,
                            false => 19940,
                        },
                        false => Powered switch {
                            true => 19941,
                            false => 19942,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19943,
                            false => 19944,
                        },
                        false => Powered switch {
                            true => 19945,
                            false => 19946,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19947,
                            false => 19948,
                        },
                        false => Powered switch {
                            true => 19949,
                            false => 19950,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19951,
                            false => 19952,
                        },
                        false => Powered switch {
                            true => 19953,
                            false => 19954,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19955,
                            false => 19956,
                        },
                        false => Powered switch {
                            true => 19957,
                            false => 19958,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19959,
                            false => 19960,
                        },
                        false => Powered switch {
                            true => 19961,
                            false => 19962,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19931 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, true),
            19932 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, false),
            19933 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, true),
            19934 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, false),
            19935 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, true),
            19936 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, false),
            19937 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, true),
            19938 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, false),
            19939 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, true),
            19940 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, false),
            19941 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, true),
            19942 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, false),
            19943 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, true),
            19944 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, false),
            19945 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, true),
            19946 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, false),
            19947 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, true),
            19948 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, false),
            19949 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, true),
            19950 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, false),
            19951 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, true),
            19952 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, false),
            19953 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, true),
            19954 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, false),
            19955 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, true),
            19956 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, false),
            19957 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, true),
            19958 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, false),
            19959 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, true),
            19960 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, false),
            19961 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, true),
            19962 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, false),
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
