using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record IronTrapdoorBlock(Identifier Identifier, Direction Facing, IronTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 494;
    public double Hardness => 5;
    public double ExplosionResistance => 5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:iron_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.iron_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11288,
                                false => 11289,
                            },
                            false => Waterlogged switch {
                                true => 11290,
                                false => 11291,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11292,
                                false => 11293,
                            },
                            false => Waterlogged switch {
                                true => 11294,
                                false => 11295,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11296,
                                false => 11297,
                            },
                            false => Waterlogged switch {
                                true => 11298,
                                false => 11299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11300,
                                false => 11301,
                            },
                            false => Waterlogged switch {
                                true => 11302,
                                false => 11303,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11304,
                                false => 11305,
                            },
                            false => Waterlogged switch {
                                true => 11306,
                                false => 11307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11308,
                                false => 11309,
                            },
                            false => Waterlogged switch {
                                true => 11310,
                                false => 11311,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11312,
                                false => 11313,
                            },
                            false => Waterlogged switch {
                                true => 11314,
                                false => 11315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11316,
                                false => 11317,
                            },
                            false => Waterlogged switch {
                                true => 11318,
                                false => 11319,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11320,
                                false => 11321,
                            },
                            false => Waterlogged switch {
                                true => 11322,
                                false => 11323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11324,
                                false => 11325,
                            },
                            false => Waterlogged switch {
                                true => 11326,
                                false => 11327,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11328,
                                false => 11329,
                            },
                            false => Waterlogged switch {
                                true => 11330,
                                false => 11331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11332,
                                false => 11333,
                            },
                            false => Waterlogged switch {
                                true => 11334,
                                false => 11335,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11336,
                                false => 11337,
                            },
                            false => Waterlogged switch {
                                true => 11338,
                                false => 11339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11340,
                                false => 11341,
                            },
                            false => Waterlogged switch {
                                true => 11342,
                                false => 11343,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 11344,
                                false => 11345,
                            },
                            false => Waterlogged switch {
                                true => 11346,
                                false => 11347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 11348,
                                false => 11349,
                            },
                            false => Waterlogged switch {
                                true => 11350,
                                false => 11351,
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
            11288 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            11289 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            11290 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            11291 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            11292 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            11293 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            11294 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            11295 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            11296 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            11297 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            11298 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            11299 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            11300 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            11301 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            11302 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            11303 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            11304 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            11305 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            11306 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            11307 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            11308 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            11309 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            11310 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            11311 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            11312 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            11313 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            11314 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            11315 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            11316 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            11317 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            11318 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            11319 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            11320 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            11321 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            11322 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            11323 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            11324 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            11325 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            11326 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            11327 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            11328 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            11329 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            11330 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            11331 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            11332 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            11333 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            11334 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            11335 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            11336 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            11337 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            11338 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            11339 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            11340 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            11341 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            11342 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            11343 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            11344 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            11345 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            11346 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            11347 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            11348 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            11349 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            11350 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            11351 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.ChildrenMap.ContainsKey("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
