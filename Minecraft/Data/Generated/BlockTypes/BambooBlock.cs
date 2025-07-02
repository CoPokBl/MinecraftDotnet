using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BambooBlock(Identifier Identifier, int Age, BambooBlock.Leaves LeavesValue, int Stage) : IBlock {

    public uint StateId {
        get {
            return Age switch {
                0 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 13968,
                        1 => 13969,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 13970,
                        1 => 13971,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 13972,
                        1 => 13973,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                1 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 13974,
                        1 => 13975,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 13976,
                        1 => 13977,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 13978,
                        1 => 13979,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            13968 => new BambooBlock(Identifier, 0, Leaves.None, 0),
            13969 => new BambooBlock(Identifier, 0, Leaves.None, 1),
            13970 => new BambooBlock(Identifier, 0, Leaves.Small, 0),
            13971 => new BambooBlock(Identifier, 0, Leaves.Small, 1),
            13972 => new BambooBlock(Identifier, 0, Leaves.Large, 0),
            13973 => new BambooBlock(Identifier, 0, Leaves.Large, 1),
            13974 => new BambooBlock(Identifier, 1, Leaves.None, 0),
            13975 => new BambooBlock(Identifier, 1, Leaves.None, 1),
            13976 => new BambooBlock(Identifier, 1, Leaves.Small, 0),
            13977 => new BambooBlock(Identifier, 1, Leaves.Small, 1),
            13978 => new BambooBlock(Identifier, 1, Leaves.Large, 0),
            13979 => new BambooBlock(Identifier, 1, Leaves.Large, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Leaves {
        None,
        Small,
        Large,
    }
}
