using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record PoweredRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 1987,
                        false => 1988,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 1989,
                        false => 1990,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 1991,
                        false => 1992,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 1993,
                        false => 1994,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 1995,
                        false => 1996,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 1997,
                        false => 1998,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 1999,
                        false => 2000,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2001,
                        false => 2002,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2003,
                        false => 2004,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2005,
                        false => 2006,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2007,
                        false => 2008,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2009,
                        false => 2010,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            1987 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            1988 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            1989 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, true),
            1990 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, false),
            1991 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            1992 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            1993 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            1994 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            1995 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            1996 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            1997 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            1998 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            1999 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2000 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2001 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, true),
            2002 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, false),
            2003 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2004 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2005 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2006 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2007 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2008 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2009 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2010 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
