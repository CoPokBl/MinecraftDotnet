using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record TargetBlock(Identifier Identifier, int Power) : IBlock {

    public uint StateId {
        get {
            return Power switch {
                0 => 20409,
                1 => 20410,
                2 => 20411,
                3 => 20412,
                4 => 20413,
                5 => 20414,
                6 => 20415,
                7 => 20416,
                8 => 20417,
                9 => 20418,
                10 => 20419,
                11 => 20420,
                12 => 20421,
                13 => 20422,
                14 => 20423,
                15 => 20424,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            20409 => new TargetBlock(Identifier, 0),
            20410 => new TargetBlock(Identifier, 1),
            20411 => new TargetBlock(Identifier, 2),
            20412 => new TargetBlock(Identifier, 3),
            20413 => new TargetBlock(Identifier, 4),
            20414 => new TargetBlock(Identifier, 5),
            20415 => new TargetBlock(Identifier, 6),
            20416 => new TargetBlock(Identifier, 7),
            20417 => new TargetBlock(Identifier, 8),
            20418 => new TargetBlock(Identifier, 9),
            20419 => new TargetBlock(Identifier, 10),
            20420 => new TargetBlock(Identifier, 11),
            20421 => new TargetBlock(Identifier, 12),
            20422 => new TargetBlock(Identifier, 13),
            20423 => new TargetBlock(Identifier, 14),
            20424 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
