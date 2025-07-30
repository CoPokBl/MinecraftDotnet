using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, ExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:weathering_copper_trap_door";
    public int ProtocolId => 1018;
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
    public Identifier? Item => "minecraft:exposed_copper_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.exposed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25288,
                                false => 25289,
                            },
                            false => Waterlogged switch {
                                true => 25290,
                                false => 25291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25292,
                                false => 25293,
                            },
                            false => Waterlogged switch {
                                true => 25294,
                                false => 25295,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25296,
                                false => 25297,
                            },
                            false => Waterlogged switch {
                                true => 25298,
                                false => 25299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25300,
                                false => 25301,
                            },
                            false => Waterlogged switch {
                                true => 25302,
                                false => 25303,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25304,
                                false => 25305,
                            },
                            false => Waterlogged switch {
                                true => 25306,
                                false => 25307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25308,
                                false => 25309,
                            },
                            false => Waterlogged switch {
                                true => 25310,
                                false => 25311,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25312,
                                false => 25313,
                            },
                            false => Waterlogged switch {
                                true => 25314,
                                false => 25315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25316,
                                false => 25317,
                            },
                            false => Waterlogged switch {
                                true => 25318,
                                false => 25319,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25320,
                                false => 25321,
                            },
                            false => Waterlogged switch {
                                true => 25322,
                                false => 25323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25324,
                                false => 25325,
                            },
                            false => Waterlogged switch {
                                true => 25326,
                                false => 25327,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25328,
                                false => 25329,
                            },
                            false => Waterlogged switch {
                                true => 25330,
                                false => 25331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25332,
                                false => 25333,
                            },
                            false => Waterlogged switch {
                                true => 25334,
                                false => 25335,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25336,
                                false => 25337,
                            },
                            false => Waterlogged switch {
                                true => 25338,
                                false => 25339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25340,
                                false => 25341,
                            },
                            false => Waterlogged switch {
                                true => 25342,
                                false => 25343,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 25344,
                                false => 25345,
                            },
                            false => Waterlogged switch {
                                true => 25346,
                                false => 25347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 25348,
                                false => 25349,
                            },
                            false => Waterlogged switch {
                                true => 25350,
                                false => 25351,
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
            25288 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25289 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25290 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25291 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25292 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25293 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25294 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25295 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25296 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25297 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25298 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25299 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25300 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25301 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25302 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25303 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25304 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25305 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25306 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25307 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25308 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25309 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25310 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25311 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25312 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25313 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25314 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25315 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25316 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25317 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25318 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25319 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25320 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25321 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25322 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25323 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25324 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25325 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25326 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25327 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25328 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25329 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25330 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25331 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25332 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25333 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25334 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25335 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25336 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25337 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25338 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25339 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25340 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25341 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25342 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25343 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25344 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25345 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25346 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25347 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25348 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25349 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25350 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25351 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
