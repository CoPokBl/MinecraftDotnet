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
                Direction.South => HalfValue switch {
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
                Direction.West => HalfValue switch {
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
                Direction.East => HalfValue switch {
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
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25256 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            25257 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            25258 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            25259 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            25260 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            25261 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            25262 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            25263 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            25264 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            25265 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            25266 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            25267 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            25268 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            25269 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            25270 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            25271 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            25272 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            25273 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            25274 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            25275 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            25276 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            25277 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            25278 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            25279 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            25280 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            25281 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            25282 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            25283 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            25284 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            25285 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            25286 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            25287 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            25288 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            25289 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            25290 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            25291 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            25292 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            25293 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            25294 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            25295 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            25296 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            25297 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            25298 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            25299 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            25300 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            25301 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            25302 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            25303 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            25304 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            25305 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            25306 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            25307 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            25308 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            25309 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            25310 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            25311 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            25312 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            25313 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            25314 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            25315 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            25316 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            25317 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            25318 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            25319 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
