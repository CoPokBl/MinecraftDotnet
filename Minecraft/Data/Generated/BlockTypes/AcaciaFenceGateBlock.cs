using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12301,
                            false => 12302,
                        },
                        false => Powered switch {
                            true => 12303,
                            false => 12304,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12305,
                            false => 12306,
                        },
                        false => Powered switch {
                            true => 12307,
                            false => 12308,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12309,
                            false => 12310,
                        },
                        false => Powered switch {
                            true => 12311,
                            false => 12312,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12313,
                            false => 12314,
                        },
                        false => Powered switch {
                            true => 12315,
                            false => 12316,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12317,
                            false => 12318,
                        },
                        false => Powered switch {
                            true => 12319,
                            false => 12320,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12321,
                            false => 12322,
                        },
                        false => Powered switch {
                            true => 12323,
                            false => 12324,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12325,
                            false => 12326,
                        },
                        false => Powered switch {
                            true => 12327,
                            false => 12328,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12329,
                            false => 12330,
                        },
                        false => Powered switch {
                            true => 12331,
                            false => 12332,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12301 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, true),
            12302 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, false),
            12303 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, true),
            12304 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, false),
            12305 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, true),
            12306 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, false),
            12307 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, true),
            12308 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, false),
            12309 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, true),
            12310 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, false),
            12311 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, true),
            12312 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, false),
            12313 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, true),
            12314 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, false),
            12315 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, true),
            12316 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, false),
            12317 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, true),
            12318 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, false),
            12319 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, true),
            12320 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, false),
            12321 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, true),
            12322 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, false),
            12323 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, true),
            12324 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, false),
            12325 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, true),
            12326 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, false),
            12327 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, true),
            12328 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, false),
            12329 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, true),
            12330 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, false),
            12331 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, true),
            12332 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, false),
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
