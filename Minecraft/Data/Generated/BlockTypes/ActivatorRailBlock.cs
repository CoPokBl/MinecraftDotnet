using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record ActivatorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 10129,
                        false => 10130,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 10131,
                        false => 10132,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 10133,
                        false => 10134,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 10135,
                        false => 10136,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 10137,
                        false => 10138,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 10139,
                        false => 10140,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 10141,
                        false => 10142,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 10143,
                        false => 10144,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 10145,
                        false => 10146,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 10147,
                        false => 10148,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 10149,
                        false => 10150,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 10151,
                        false => 10152,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            10129 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            10130 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            10131 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            10132 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            10133 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            10134 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            10135 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            10136 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            10137 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            10138 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            10139 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            10140 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            10141 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            10142 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            10143 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            10144 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            10145 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            10146 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            10147 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            10148 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            10149 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            10150 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            10151 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            10152 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
}
