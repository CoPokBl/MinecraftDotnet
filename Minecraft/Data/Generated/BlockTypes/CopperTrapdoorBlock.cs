using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperTrapdoorBlock(Identifier Identifier, Direction Facing, CopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25224,
                                false => 25225,
                            },
                            false => Waterlogged switch {
                                true => 25226,
                                false => 25227,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25228,
                                false => 25229,
                            },
                            false => Waterlogged switch {
                                true => 25230,
                                false => 25231,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25232,
                                false => 25233,
                            },
                            false => Waterlogged switch {
                                true => 25234,
                                false => 25235,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25236,
                                false => 25237,
                            },
                            false => Waterlogged switch {
                                true => 25238,
                                false => 25239,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25240,
                                false => 25241,
                            },
                            false => Waterlogged switch {
                                true => 25242,
                                false => 25243,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25244,
                                false => 25245,
                            },
                            false => Waterlogged switch {
                                true => 25246,
                                false => 25247,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25248,
                                false => 25249,
                            },
                            false => Waterlogged switch {
                                true => 25250,
                                false => 25251,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25252,
                                false => 25253,
                            },
                            false => Waterlogged switch {
                                true => 25254,
                                false => 25255,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25256,
                                false => 25257,
                            },
                            false => Waterlogged switch {
                                true => 25258,
                                false => 25259,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25260,
                                false => 25261,
                            },
                            false => Waterlogged switch {
                                true => 25262,
                                false => 25263,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25264,
                                false => 25265,
                            },
                            false => Waterlogged switch {
                                true => 25266,
                                false => 25267,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25268,
                                false => 25269,
                            },
                            false => Waterlogged switch {
                                true => 25270,
                                false => 25271,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25272,
                                false => 25273,
                            },
                            false => Waterlogged switch {
                                true => 25274,
                                false => 25275,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25276,
                                false => 25277,
                            },
                            false => Waterlogged switch {
                                true => 25278,
                                false => 25279,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25280,
                                false => 25281,
                            },
                            false => Waterlogged switch {
                                true => 25282,
                                false => 25283,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25284,
                                false => 25285,
                            },
                            false => Waterlogged switch {
                                true => 25286,
                                false => 25287,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25224 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25225 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25226 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25227 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25228 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25229 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25230 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25231 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25232 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25233 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25234 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25235 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25236 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25237 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25238 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25239 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25240 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25241 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25242 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25243 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25244 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25245 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25246 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25247 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25248 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25249 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25250 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25251 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25252 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25253 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25254 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25255 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25256 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25257 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25258 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25259 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25260 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25261 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25262 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25263 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25264 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25265 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25266 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25267 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25268 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25269 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25270 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25271 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25272 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25273 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25274 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25275 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25276 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25277 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25278 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25279 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25280 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25281 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25282 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25283 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25284 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25285 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25286 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25287 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HalfValue = HalfFromString(properties["half"].GetString()),
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }
}
