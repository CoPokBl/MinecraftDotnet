using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5322,
                        false => 5323,
                    },
                    1 => Waterlogged switch {
                        true => 5324,
                        false => 5325,
                    },
                    2 => Waterlogged switch {
                        true => 5326,
                        false => 5327,
                    },
                    3 => Waterlogged switch {
                        true => 5328,
                        false => 5329,
                    },
                    4 => Waterlogged switch {
                        true => 5330,
                        false => 5331,
                    },
                    5 => Waterlogged switch {
                        true => 5332,
                        false => 5333,
                    },
                    6 => Waterlogged switch {
                        true => 5334,
                        false => 5335,
                    },
                    7 => Waterlogged switch {
                        true => 5336,
                        false => 5337,
                    },
                    8 => Waterlogged switch {
                        true => 5338,
                        false => 5339,
                    },
                    9 => Waterlogged switch {
                        true => 5340,
                        false => 5341,
                    },
                    10 => Waterlogged switch {
                        true => 5342,
                        false => 5343,
                    },
                    11 => Waterlogged switch {
                        true => 5344,
                        false => 5345,
                    },
                    12 => Waterlogged switch {
                        true => 5346,
                        false => 5347,
                    },
                    13 => Waterlogged switch {
                        true => 5348,
                        false => 5349,
                    },
                    14 => Waterlogged switch {
                        true => 5350,
                        false => 5351,
                    },
                    15 => Waterlogged switch {
                        true => 5352,
                        false => 5353,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5354,
                        false => 5355,
                    },
                    1 => Waterlogged switch {
                        true => 5356,
                        false => 5357,
                    },
                    2 => Waterlogged switch {
                        true => 5358,
                        false => 5359,
                    },
                    3 => Waterlogged switch {
                        true => 5360,
                        false => 5361,
                    },
                    4 => Waterlogged switch {
                        true => 5362,
                        false => 5363,
                    },
                    5 => Waterlogged switch {
                        true => 5364,
                        false => 5365,
                    },
                    6 => Waterlogged switch {
                        true => 5366,
                        false => 5367,
                    },
                    7 => Waterlogged switch {
                        true => 5368,
                        false => 5369,
                    },
                    8 => Waterlogged switch {
                        true => 5370,
                        false => 5371,
                    },
                    9 => Waterlogged switch {
                        true => 5372,
                        false => 5373,
                    },
                    10 => Waterlogged switch {
                        true => 5374,
                        false => 5375,
                    },
                    11 => Waterlogged switch {
                        true => 5376,
                        false => 5377,
                    },
                    12 => Waterlogged switch {
                        true => 5378,
                        false => 5379,
                    },
                    13 => Waterlogged switch {
                        true => 5380,
                        false => 5381,
                    },
                    14 => Waterlogged switch {
                        true => 5382,
                        false => 5383,
                    },
                    15 => Waterlogged switch {
                        true => 5384,
                        false => 5385,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5322 => new DarkOakHangingSignBlock(Identifier, true, 0, true),
            5323 => new DarkOakHangingSignBlock(Identifier, true, 0, false),
            5324 => new DarkOakHangingSignBlock(Identifier, true, 1, true),
            5325 => new DarkOakHangingSignBlock(Identifier, true, 1, false),
            5326 => new DarkOakHangingSignBlock(Identifier, true, 2, true),
            5327 => new DarkOakHangingSignBlock(Identifier, true, 2, false),
            5328 => new DarkOakHangingSignBlock(Identifier, true, 3, true),
            5329 => new DarkOakHangingSignBlock(Identifier, true, 3, false),
            5330 => new DarkOakHangingSignBlock(Identifier, true, 4, true),
            5331 => new DarkOakHangingSignBlock(Identifier, true, 4, false),
            5332 => new DarkOakHangingSignBlock(Identifier, true, 5, true),
            5333 => new DarkOakHangingSignBlock(Identifier, true, 5, false),
            5334 => new DarkOakHangingSignBlock(Identifier, true, 6, true),
            5335 => new DarkOakHangingSignBlock(Identifier, true, 6, false),
            5336 => new DarkOakHangingSignBlock(Identifier, true, 7, true),
            5337 => new DarkOakHangingSignBlock(Identifier, true, 7, false),
            5338 => new DarkOakHangingSignBlock(Identifier, true, 8, true),
            5339 => new DarkOakHangingSignBlock(Identifier, true, 8, false),
            5340 => new DarkOakHangingSignBlock(Identifier, true, 9, true),
            5341 => new DarkOakHangingSignBlock(Identifier, true, 9, false),
            5342 => new DarkOakHangingSignBlock(Identifier, true, 10, true),
            5343 => new DarkOakHangingSignBlock(Identifier, true, 10, false),
            5344 => new DarkOakHangingSignBlock(Identifier, true, 11, true),
            5345 => new DarkOakHangingSignBlock(Identifier, true, 11, false),
            5346 => new DarkOakHangingSignBlock(Identifier, true, 12, true),
            5347 => new DarkOakHangingSignBlock(Identifier, true, 12, false),
            5348 => new DarkOakHangingSignBlock(Identifier, true, 13, true),
            5349 => new DarkOakHangingSignBlock(Identifier, true, 13, false),
            5350 => new DarkOakHangingSignBlock(Identifier, true, 14, true),
            5351 => new DarkOakHangingSignBlock(Identifier, true, 14, false),
            5352 => new DarkOakHangingSignBlock(Identifier, true, 15, true),
            5353 => new DarkOakHangingSignBlock(Identifier, true, 15, false),
            5354 => new DarkOakHangingSignBlock(Identifier, false, 0, true),
            5355 => new DarkOakHangingSignBlock(Identifier, false, 0, false),
            5356 => new DarkOakHangingSignBlock(Identifier, false, 1, true),
            5357 => new DarkOakHangingSignBlock(Identifier, false, 1, false),
            5358 => new DarkOakHangingSignBlock(Identifier, false, 2, true),
            5359 => new DarkOakHangingSignBlock(Identifier, false, 2, false),
            5360 => new DarkOakHangingSignBlock(Identifier, false, 3, true),
            5361 => new DarkOakHangingSignBlock(Identifier, false, 3, false),
            5362 => new DarkOakHangingSignBlock(Identifier, false, 4, true),
            5363 => new DarkOakHangingSignBlock(Identifier, false, 4, false),
            5364 => new DarkOakHangingSignBlock(Identifier, false, 5, true),
            5365 => new DarkOakHangingSignBlock(Identifier, false, 5, false),
            5366 => new DarkOakHangingSignBlock(Identifier, false, 6, true),
            5367 => new DarkOakHangingSignBlock(Identifier, false, 6, false),
            5368 => new DarkOakHangingSignBlock(Identifier, false, 7, true),
            5369 => new DarkOakHangingSignBlock(Identifier, false, 7, false),
            5370 => new DarkOakHangingSignBlock(Identifier, false, 8, true),
            5371 => new DarkOakHangingSignBlock(Identifier, false, 8, false),
            5372 => new DarkOakHangingSignBlock(Identifier, false, 9, true),
            5373 => new DarkOakHangingSignBlock(Identifier, false, 9, false),
            5374 => new DarkOakHangingSignBlock(Identifier, false, 10, true),
            5375 => new DarkOakHangingSignBlock(Identifier, false, 10, false),
            5376 => new DarkOakHangingSignBlock(Identifier, false, 11, true),
            5377 => new DarkOakHangingSignBlock(Identifier, false, 11, false),
            5378 => new DarkOakHangingSignBlock(Identifier, false, 12, true),
            5379 => new DarkOakHangingSignBlock(Identifier, false, 12, false),
            5380 => new DarkOakHangingSignBlock(Identifier, false, 13, true),
            5381 => new DarkOakHangingSignBlock(Identifier, false, 13, false),
            5382 => new DarkOakHangingSignBlock(Identifier, false, 14, true),
            5383 => new DarkOakHangingSignBlock(Identifier, false, 14, false),
            5384 => new DarkOakHangingSignBlock(Identifier, false, 15, true),
            5385 => new DarkOakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
