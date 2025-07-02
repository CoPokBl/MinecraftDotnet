using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record BigDripleafBlock(Identifier Identifier, Direction Facing, BigDripleafBlock.Tilt TiltValue, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25904,
                        false => 25905,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25906,
                        false => 25907,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25908,
                        false => 25909,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25910,
                        false => 25911,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25912,
                        false => 25913,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25914,
                        false => 25915,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25916,
                        false => 25917,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25918,
                        false => 25919,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25920,
                        false => 25921,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25922,
                        false => 25923,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25924,
                        false => 25925,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25926,
                        false => 25927,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 25928,
                        false => 25929,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 25930,
                        false => 25931,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 25932,
                        false => 25933,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 25934,
                        false => 25935,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            25904 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            25905 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            25906 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            25907 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            25908 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            25909 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            25910 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            25911 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            25912 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            25913 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            25914 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            25915 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            25916 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            25917 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            25918 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            25919 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            25920 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            25921 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            25922 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            25923 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            25924 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            25925 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            25926 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            25927 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            25928 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            25929 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            25930 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            25931 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            25932 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            25933 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            25934 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            25935 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public enum Tilt {
        None,
        Unstable,
        Partial,
        Full,
    }
}
