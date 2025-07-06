using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 280,
                        false => 281,
                    },
                    false => Waterlogged switch {
                        true => 282,
                        false => 283,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 284,
                        false => 285,
                    },
                    false => Waterlogged switch {
                        true => 286,
                        false => 287,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 288,
                        false => 289,
                    },
                    false => Waterlogged switch {
                        true => 290,
                        false => 291,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 292,
                        false => 293,
                    },
                    false => Waterlogged switch {
                        true => 294,
                        false => 295,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 296,
                        false => 297,
                    },
                    false => Waterlogged switch {
                        true => 298,
                        false => 299,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 300,
                        false => 301,
                    },
                    false => Waterlogged switch {
                        true => 302,
                        false => 303,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 304,
                        false => 305,
                    },
                    false => Waterlogged switch {
                        true => 306,
                        false => 307,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            280 => new SpruceLeavesBlock(Identifier, 1, true, true),
            281 => new SpruceLeavesBlock(Identifier, 1, true, false),
            282 => new SpruceLeavesBlock(Identifier, 1, false, true),
            283 => new SpruceLeavesBlock(Identifier, 1, false, false),
            284 => new SpruceLeavesBlock(Identifier, 2, true, true),
            285 => new SpruceLeavesBlock(Identifier, 2, true, false),
            286 => new SpruceLeavesBlock(Identifier, 2, false, true),
            287 => new SpruceLeavesBlock(Identifier, 2, false, false),
            288 => new SpruceLeavesBlock(Identifier, 3, true, true),
            289 => new SpruceLeavesBlock(Identifier, 3, true, false),
            290 => new SpruceLeavesBlock(Identifier, 3, false, true),
            291 => new SpruceLeavesBlock(Identifier, 3, false, false),
            292 => new SpruceLeavesBlock(Identifier, 4, true, true),
            293 => new SpruceLeavesBlock(Identifier, 4, true, false),
            294 => new SpruceLeavesBlock(Identifier, 4, false, true),
            295 => new SpruceLeavesBlock(Identifier, 4, false, false),
            296 => new SpruceLeavesBlock(Identifier, 5, true, true),
            297 => new SpruceLeavesBlock(Identifier, 5, true, false),
            298 => new SpruceLeavesBlock(Identifier, 5, false, true),
            299 => new SpruceLeavesBlock(Identifier, 5, false, false),
            300 => new SpruceLeavesBlock(Identifier, 6, true, true),
            301 => new SpruceLeavesBlock(Identifier, 6, true, false),
            302 => new SpruceLeavesBlock(Identifier, 6, false, true),
            303 => new SpruceLeavesBlock(Identifier, 6, false, false),
            304 => new SpruceLeavesBlock(Identifier, 7, true, true),
            305 => new SpruceLeavesBlock(Identifier, 7, true, false),
            306 => new SpruceLeavesBlock(Identifier, 7, false, true),
            307 => new SpruceLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = int.Parse(properties["distance"].GetString()),
            Persistent = properties["persistent"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
