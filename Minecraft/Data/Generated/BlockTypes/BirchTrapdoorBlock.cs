using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchTrapdoorBlock(Identifier Identifier, Direction Facing, BirchTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 303;
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:birch_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.birch_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6268,
                                false => 6269,
                            },
                            false => Waterlogged switch {
                                true => 6270,
                                false => 6271,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6272,
                                false => 6273,
                            },
                            false => Waterlogged switch {
                                true => 6274,
                                false => 6275,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6276,
                                false => 6277,
                            },
                            false => Waterlogged switch {
                                true => 6278,
                                false => 6279,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6280,
                                false => 6281,
                            },
                            false => Waterlogged switch {
                                true => 6282,
                                false => 6283,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6284,
                                false => 6285,
                            },
                            false => Waterlogged switch {
                                true => 6286,
                                false => 6287,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6288,
                                false => 6289,
                            },
                            false => Waterlogged switch {
                                true => 6290,
                                false => 6291,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6292,
                                false => 6293,
                            },
                            false => Waterlogged switch {
                                true => 6294,
                                false => 6295,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6296,
                                false => 6297,
                            },
                            false => Waterlogged switch {
                                true => 6298,
                                false => 6299,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6300,
                                false => 6301,
                            },
                            false => Waterlogged switch {
                                true => 6302,
                                false => 6303,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6304,
                                false => 6305,
                            },
                            false => Waterlogged switch {
                                true => 6306,
                                false => 6307,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6308,
                                false => 6309,
                            },
                            false => Waterlogged switch {
                                true => 6310,
                                false => 6311,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6312,
                                false => 6313,
                            },
                            false => Waterlogged switch {
                                true => 6314,
                                false => 6315,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6316,
                                false => 6317,
                            },
                            false => Waterlogged switch {
                                true => 6318,
                                false => 6319,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6320,
                                false => 6321,
                            },
                            false => Waterlogged switch {
                                true => 6322,
                                false => 6323,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6324,
                                false => 6325,
                            },
                            false => Waterlogged switch {
                                true => 6326,
                                false => 6327,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6328,
                                false => 6329,
                            },
                            false => Waterlogged switch {
                                true => 6330,
                                false => 6331,
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
            6268 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6269 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6270 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6271 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6272 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6273 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6274 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6275 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6276 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6277 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6278 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6279 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6280 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6281 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6282 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6283 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6284 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6285 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6286 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6287 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6288 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6289 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6290 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6291 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6292 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6293 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6294 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6295 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6296 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6297 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6298 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6299 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6300 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6301 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6302 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6303 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6304 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6305 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6306 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6307 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6308 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6309 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6310 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6311 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6312 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6313 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6314 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6315 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6316 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6317 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6318 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6319 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6320 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6321 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6322 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6323 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6324 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6325 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6326 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6327 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6328 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6329 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6330 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6331 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", HalfToName(HalfValue)),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
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

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
