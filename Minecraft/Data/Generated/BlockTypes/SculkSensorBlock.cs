using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record SculkSensorBlock(Identifier Identifier, int Power, SculkSensorPhase SculkSensorPhase, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Power switch {
                0 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23347,
                        false => 23348,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23349,
                        false => 23350,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23351,
                        false => 23352,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                1 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23353,
                        false => 23354,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23355,
                        false => 23356,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23357,
                        false => 23358,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                2 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23359,
                        false => 23360,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23361,
                        false => 23362,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23363,
                        false => 23364,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                3 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23365,
                        false => 23366,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23367,
                        false => 23368,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23369,
                        false => 23370,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                4 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23371,
                        false => 23372,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23373,
                        false => 23374,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23375,
                        false => 23376,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                5 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23377,
                        false => 23378,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23379,
                        false => 23380,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23381,
                        false => 23382,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                6 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23383,
                        false => 23384,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23385,
                        false => 23386,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23387,
                        false => 23388,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                7 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23389,
                        false => 23390,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23391,
                        false => 23392,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23393,
                        false => 23394,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                8 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23395,
                        false => 23396,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23397,
                        false => 23398,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23399,
                        false => 23400,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                9 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23401,
                        false => 23402,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23403,
                        false => 23404,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23405,
                        false => 23406,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                10 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23407,
                        false => 23408,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23409,
                        false => 23410,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23411,
                        false => 23412,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                11 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23413,
                        false => 23414,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23415,
                        false => 23416,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23417,
                        false => 23418,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                12 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23419,
                        false => 23420,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23421,
                        false => 23422,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23423,
                        false => 23424,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                13 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23425,
                        false => 23426,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23427,
                        false => 23428,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23429,
                        false => 23430,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                14 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23431,
                        false => 23432,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23433,
                        false => 23434,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23435,
                        false => 23436,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                15 => SculkSensorPhase switch {
                    SculkSensorPhase.Inactive => Waterlogged switch {
                        true => 23437,
                        false => 23438,
                    },
                    SculkSensorPhase.Active => Waterlogged switch {
                        true => 23439,
                        false => 23440,
                    },
                    SculkSensorPhase.Cooldown => Waterlogged switch {
                        true => 23441,
                        false => 23442,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(SculkSensorPhase), SculkSensorPhase, "Unknown value for property sculk_sensor_phase.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            23347 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, true),
            23348 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Inactive, false),
            23349 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, true),
            23350 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Active, false),
            23351 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, true),
            23352 => new SculkSensorBlock(Identifier, 0, SculkSensorPhase.Cooldown, false),
            23353 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, true),
            23354 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Inactive, false),
            23355 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, true),
            23356 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Active, false),
            23357 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, true),
            23358 => new SculkSensorBlock(Identifier, 1, SculkSensorPhase.Cooldown, false),
            23359 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, true),
            23360 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Inactive, false),
            23361 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, true),
            23362 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Active, false),
            23363 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, true),
            23364 => new SculkSensorBlock(Identifier, 2, SculkSensorPhase.Cooldown, false),
            23365 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, true),
            23366 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Inactive, false),
            23367 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, true),
            23368 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Active, false),
            23369 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, true),
            23370 => new SculkSensorBlock(Identifier, 3, SculkSensorPhase.Cooldown, false),
            23371 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, true),
            23372 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Inactive, false),
            23373 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, true),
            23374 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Active, false),
            23375 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, true),
            23376 => new SculkSensorBlock(Identifier, 4, SculkSensorPhase.Cooldown, false),
            23377 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, true),
            23378 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Inactive, false),
            23379 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, true),
            23380 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Active, false),
            23381 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, true),
            23382 => new SculkSensorBlock(Identifier, 5, SculkSensorPhase.Cooldown, false),
            23383 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, true),
            23384 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Inactive, false),
            23385 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, true),
            23386 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Active, false),
            23387 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, true),
            23388 => new SculkSensorBlock(Identifier, 6, SculkSensorPhase.Cooldown, false),
            23389 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, true),
            23390 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Inactive, false),
            23391 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, true),
            23392 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Active, false),
            23393 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, true),
            23394 => new SculkSensorBlock(Identifier, 7, SculkSensorPhase.Cooldown, false),
            23395 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, true),
            23396 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Inactive, false),
            23397 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, true),
            23398 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Active, false),
            23399 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, true),
            23400 => new SculkSensorBlock(Identifier, 8, SculkSensorPhase.Cooldown, false),
            23401 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, true),
            23402 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Inactive, false),
            23403 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, true),
            23404 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Active, false),
            23405 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, true),
            23406 => new SculkSensorBlock(Identifier, 9, SculkSensorPhase.Cooldown, false),
            23407 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, true),
            23408 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Inactive, false),
            23409 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, true),
            23410 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Active, false),
            23411 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, true),
            23412 => new SculkSensorBlock(Identifier, 10, SculkSensorPhase.Cooldown, false),
            23413 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, true),
            23414 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Inactive, false),
            23415 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, true),
            23416 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Active, false),
            23417 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, true),
            23418 => new SculkSensorBlock(Identifier, 11, SculkSensorPhase.Cooldown, false),
            23419 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, true),
            23420 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Inactive, false),
            23421 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, true),
            23422 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Active, false),
            23423 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, true),
            23424 => new SculkSensorBlock(Identifier, 12, SculkSensorPhase.Cooldown, false),
            23425 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, true),
            23426 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Inactive, false),
            23427 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, true),
            23428 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Active, false),
            23429 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, true),
            23430 => new SculkSensorBlock(Identifier, 13, SculkSensorPhase.Cooldown, false),
            23431 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, true),
            23432 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Inactive, false),
            23433 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, true),
            23434 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Active, false),
            23435 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, true),
            23436 => new SculkSensorBlock(Identifier, 14, SculkSensorPhase.Cooldown, false),
            23437 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, true),
            23438 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Inactive, false),
            23439 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, true),
            23440 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Active, false),
            23441 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, true),
            23442 => new SculkSensorBlock(Identifier, 15, SculkSensorPhase.Cooldown, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
