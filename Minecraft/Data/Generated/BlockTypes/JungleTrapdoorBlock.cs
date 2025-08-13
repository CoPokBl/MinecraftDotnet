using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleTrapdoorBlock(Identifier Identifier, Direction Facing, JungleTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 304;
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
    public Identifier? Item => "minecraft:jungle_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6332,
                                false => 6333,
                            },
                            false => Waterlogged switch {
                                true => 6334,
                                false => 6335,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6336,
                                false => 6337,
                            },
                            false => Waterlogged switch {
                                true => 6338,
                                false => 6339,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6340,
                                false => 6341,
                            },
                            false => Waterlogged switch {
                                true => 6342,
                                false => 6343,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6344,
                                false => 6345,
                            },
                            false => Waterlogged switch {
                                true => 6346,
                                false => 6347,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6348,
                                false => 6349,
                            },
                            false => Waterlogged switch {
                                true => 6350,
                                false => 6351,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6352,
                                false => 6353,
                            },
                            false => Waterlogged switch {
                                true => 6354,
                                false => 6355,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6356,
                                false => 6357,
                            },
                            false => Waterlogged switch {
                                true => 6358,
                                false => 6359,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6360,
                                false => 6361,
                            },
                            false => Waterlogged switch {
                                true => 6362,
                                false => 6363,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6364,
                                false => 6365,
                            },
                            false => Waterlogged switch {
                                true => 6366,
                                false => 6367,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6368,
                                false => 6369,
                            },
                            false => Waterlogged switch {
                                true => 6370,
                                false => 6371,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6372,
                                false => 6373,
                            },
                            false => Waterlogged switch {
                                true => 6374,
                                false => 6375,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6376,
                                false => 6377,
                            },
                            false => Waterlogged switch {
                                true => 6378,
                                false => 6379,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6380,
                                false => 6381,
                            },
                            false => Waterlogged switch {
                                true => 6382,
                                false => 6383,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6384,
                                false => 6385,
                            },
                            false => Waterlogged switch {
                                true => 6386,
                                false => 6387,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 6388,
                                false => 6389,
                            },
                            false => Waterlogged switch {
                                true => 6390,
                                false => 6391,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 6392,
                                false => 6393,
                            },
                            false => Waterlogged switch {
                                true => 6394,
                                false => 6395,
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
            6332 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            6333 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            6334 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            6335 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            6336 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            6337 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            6338 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            6339 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            6340 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            6341 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            6342 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            6343 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            6344 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            6345 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            6346 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            6347 => new JungleTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            6348 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            6349 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            6350 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            6351 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            6352 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            6353 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            6354 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            6355 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            6356 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            6357 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            6358 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            6359 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            6360 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            6361 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            6362 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            6363 => new JungleTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            6364 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            6365 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            6366 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            6367 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            6368 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            6369 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            6370 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            6371 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            6372 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            6373 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            6374 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            6375 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            6376 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            6377 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            6378 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            6379 => new JungleTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            6380 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            6381 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            6382 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            6383 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            6384 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            6385 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            6386 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            6387 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            6388 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            6389 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            6390 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            6391 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            6392 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            6393 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            6394 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            6395 => new JungleTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
