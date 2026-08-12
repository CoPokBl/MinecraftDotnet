using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
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
    public Identifier? Item => "minecraft:waxed_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.waxed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29264,
                                false => 29265,
                            },
                            false => Waterlogged switch {
                                true => 29266,
                                false => 29267,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29268,
                                false => 29269,
                            },
                            false => Waterlogged switch {
                                true => 29270,
                                false => 29271,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29272,
                                false => 29273,
                            },
                            false => Waterlogged switch {
                                true => 29274,
                                false => 29275,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29276,
                                false => 29277,
                            },
                            false => Waterlogged switch {
                                true => 29278,
                                false => 29279,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29280,
                                false => 29281,
                            },
                            false => Waterlogged switch {
                                true => 29282,
                                false => 29283,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29284,
                                false => 29285,
                            },
                            false => Waterlogged switch {
                                true => 29286,
                                false => 29287,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29288,
                                false => 29289,
                            },
                            false => Waterlogged switch {
                                true => 29290,
                                false => 29291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29292,
                                false => 29293,
                            },
                            false => Waterlogged switch {
                                true => 29294,
                                false => 29295,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29296,
                                false => 29297,
                            },
                            false => Waterlogged switch {
                                true => 29298,
                                false => 29299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29300,
                                false => 29301,
                            },
                            false => Waterlogged switch {
                                true => 29302,
                                false => 29303,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29304,
                                false => 29305,
                            },
                            false => Waterlogged switch {
                                true => 29306,
                                false => 29307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29308,
                                false => 29309,
                            },
                            false => Waterlogged switch {
                                true => 29310,
                                false => 29311,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29312,
                                false => 29313,
                            },
                            false => Waterlogged switch {
                                true => 29314,
                                false => 29315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29316,
                                false => 29317,
                            },
                            false => Waterlogged switch {
                                true => 29318,
                                false => 29319,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29320,
                                false => 29321,
                            },
                            false => Waterlogged switch {
                                true => 29322,
                                false => 29323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29324,
                                false => 29325,
                            },
                            false => Waterlogged switch {
                                true => 29326,
                                false => 29327,
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
            29264 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29265 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29266 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29267 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29268 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29269 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29270 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29271 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29272 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29273 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29274 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29275 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29276 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29277 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29278 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29279 => new WaxedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29280 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29281 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29282 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29283 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29284 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29285 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29286 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29287 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29288 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29289 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29290 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29291 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29292 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29293 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29294 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29295 => new WaxedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29296 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29297 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29298 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29299 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29300 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29301 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29302 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29303 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29304 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29305 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29306 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29307 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29308 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29309 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29310 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29311 => new WaxedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29312 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29313 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29314 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29315 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29316 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29317 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29318 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29319 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29320 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29321 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29322 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29323 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29324 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29325 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29326 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29327 => new WaxedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
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
