using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5002,
                        false => 5003,
                    },
                    1 => Waterlogged switch {
                        true => 5004,
                        false => 5005,
                    },
                    2 => Waterlogged switch {
                        true => 5006,
                        false => 5007,
                    },
                    3 => Waterlogged switch {
                        true => 5008,
                        false => 5009,
                    },
                    4 => Waterlogged switch {
                        true => 5010,
                        false => 5011,
                    },
                    5 => Waterlogged switch {
                        true => 5012,
                        false => 5013,
                    },
                    6 => Waterlogged switch {
                        true => 5014,
                        false => 5015,
                    },
                    7 => Waterlogged switch {
                        true => 5016,
                        false => 5017,
                    },
                    8 => Waterlogged switch {
                        true => 5018,
                        false => 5019,
                    },
                    9 => Waterlogged switch {
                        true => 5020,
                        false => 5021,
                    },
                    10 => Waterlogged switch {
                        true => 5022,
                        false => 5023,
                    },
                    11 => Waterlogged switch {
                        true => 5024,
                        false => 5025,
                    },
                    12 => Waterlogged switch {
                        true => 5026,
                        false => 5027,
                    },
                    13 => Waterlogged switch {
                        true => 5028,
                        false => 5029,
                    },
                    14 => Waterlogged switch {
                        true => 5030,
                        false => 5031,
                    },
                    15 => Waterlogged switch {
                        true => 5032,
                        false => 5033,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5034,
                        false => 5035,
                    },
                    1 => Waterlogged switch {
                        true => 5036,
                        false => 5037,
                    },
                    2 => Waterlogged switch {
                        true => 5038,
                        false => 5039,
                    },
                    3 => Waterlogged switch {
                        true => 5040,
                        false => 5041,
                    },
                    4 => Waterlogged switch {
                        true => 5042,
                        false => 5043,
                    },
                    5 => Waterlogged switch {
                        true => 5044,
                        false => 5045,
                    },
                    6 => Waterlogged switch {
                        true => 5046,
                        false => 5047,
                    },
                    7 => Waterlogged switch {
                        true => 5048,
                        false => 5049,
                    },
                    8 => Waterlogged switch {
                        true => 5050,
                        false => 5051,
                    },
                    9 => Waterlogged switch {
                        true => 5052,
                        false => 5053,
                    },
                    10 => Waterlogged switch {
                        true => 5054,
                        false => 5055,
                    },
                    11 => Waterlogged switch {
                        true => 5056,
                        false => 5057,
                    },
                    12 => Waterlogged switch {
                        true => 5058,
                        false => 5059,
                    },
                    13 => Waterlogged switch {
                        true => 5060,
                        false => 5061,
                    },
                    14 => Waterlogged switch {
                        true => 5062,
                        false => 5063,
                    },
                    15 => Waterlogged switch {
                        true => 5064,
                        false => 5065,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5002 => new SpruceHangingSignBlock(Identifier, true, 0, true),
            5003 => new SpruceHangingSignBlock(Identifier, true, 0, false),
            5004 => new SpruceHangingSignBlock(Identifier, true, 1, true),
            5005 => new SpruceHangingSignBlock(Identifier, true, 1, false),
            5006 => new SpruceHangingSignBlock(Identifier, true, 2, true),
            5007 => new SpruceHangingSignBlock(Identifier, true, 2, false),
            5008 => new SpruceHangingSignBlock(Identifier, true, 3, true),
            5009 => new SpruceHangingSignBlock(Identifier, true, 3, false),
            5010 => new SpruceHangingSignBlock(Identifier, true, 4, true),
            5011 => new SpruceHangingSignBlock(Identifier, true, 4, false),
            5012 => new SpruceHangingSignBlock(Identifier, true, 5, true),
            5013 => new SpruceHangingSignBlock(Identifier, true, 5, false),
            5014 => new SpruceHangingSignBlock(Identifier, true, 6, true),
            5015 => new SpruceHangingSignBlock(Identifier, true, 6, false),
            5016 => new SpruceHangingSignBlock(Identifier, true, 7, true),
            5017 => new SpruceHangingSignBlock(Identifier, true, 7, false),
            5018 => new SpruceHangingSignBlock(Identifier, true, 8, true),
            5019 => new SpruceHangingSignBlock(Identifier, true, 8, false),
            5020 => new SpruceHangingSignBlock(Identifier, true, 9, true),
            5021 => new SpruceHangingSignBlock(Identifier, true, 9, false),
            5022 => new SpruceHangingSignBlock(Identifier, true, 10, true),
            5023 => new SpruceHangingSignBlock(Identifier, true, 10, false),
            5024 => new SpruceHangingSignBlock(Identifier, true, 11, true),
            5025 => new SpruceHangingSignBlock(Identifier, true, 11, false),
            5026 => new SpruceHangingSignBlock(Identifier, true, 12, true),
            5027 => new SpruceHangingSignBlock(Identifier, true, 12, false),
            5028 => new SpruceHangingSignBlock(Identifier, true, 13, true),
            5029 => new SpruceHangingSignBlock(Identifier, true, 13, false),
            5030 => new SpruceHangingSignBlock(Identifier, true, 14, true),
            5031 => new SpruceHangingSignBlock(Identifier, true, 14, false),
            5032 => new SpruceHangingSignBlock(Identifier, true, 15, true),
            5033 => new SpruceHangingSignBlock(Identifier, true, 15, false),
            5034 => new SpruceHangingSignBlock(Identifier, false, 0, true),
            5035 => new SpruceHangingSignBlock(Identifier, false, 0, false),
            5036 => new SpruceHangingSignBlock(Identifier, false, 1, true),
            5037 => new SpruceHangingSignBlock(Identifier, false, 1, false),
            5038 => new SpruceHangingSignBlock(Identifier, false, 2, true),
            5039 => new SpruceHangingSignBlock(Identifier, false, 2, false),
            5040 => new SpruceHangingSignBlock(Identifier, false, 3, true),
            5041 => new SpruceHangingSignBlock(Identifier, false, 3, false),
            5042 => new SpruceHangingSignBlock(Identifier, false, 4, true),
            5043 => new SpruceHangingSignBlock(Identifier, false, 4, false),
            5044 => new SpruceHangingSignBlock(Identifier, false, 5, true),
            5045 => new SpruceHangingSignBlock(Identifier, false, 5, false),
            5046 => new SpruceHangingSignBlock(Identifier, false, 6, true),
            5047 => new SpruceHangingSignBlock(Identifier, false, 6, false),
            5048 => new SpruceHangingSignBlock(Identifier, false, 7, true),
            5049 => new SpruceHangingSignBlock(Identifier, false, 7, false),
            5050 => new SpruceHangingSignBlock(Identifier, false, 8, true),
            5051 => new SpruceHangingSignBlock(Identifier, false, 8, false),
            5052 => new SpruceHangingSignBlock(Identifier, false, 9, true),
            5053 => new SpruceHangingSignBlock(Identifier, false, 9, false),
            5054 => new SpruceHangingSignBlock(Identifier, false, 10, true),
            5055 => new SpruceHangingSignBlock(Identifier, false, 10, false),
            5056 => new SpruceHangingSignBlock(Identifier, false, 11, true),
            5057 => new SpruceHangingSignBlock(Identifier, false, 11, false),
            5058 => new SpruceHangingSignBlock(Identifier, false, 12, true),
            5059 => new SpruceHangingSignBlock(Identifier, false, 12, false),
            5060 => new SpruceHangingSignBlock(Identifier, false, 13, true),
            5061 => new SpruceHangingSignBlock(Identifier, false, 13, false),
            5062 => new SpruceHangingSignBlock(Identifier, false, 14, true),
            5063 => new SpruceHangingSignBlock(Identifier, false, 14, false),
            5064 => new SpruceHangingSignBlock(Identifier, false, 15, true),
            5065 => new SpruceHangingSignBlock(Identifier, false, 15, false),
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
