using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakTrapdoorBlock(Identifier Identifier, Direction Facing, PaleOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:trapdoor";
    public int ProtocolId => 322;
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
    public Identifier? Item => "minecraft:pale_oak_trapdoor";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.1875, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7361,
                                false => 7362,
                            },
                            false => Waterlogged switch {
                                true => 7363,
                                false => 7364,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7365,
                                false => 7366,
                            },
                            false => Waterlogged switch {
                                true => 7367,
                                false => 7368,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7369,
                                false => 7370,
                            },
                            false => Waterlogged switch {
                                true => 7371,
                                false => 7372,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7373,
                                false => 7374,
                            },
                            false => Waterlogged switch {
                                true => 7375,
                                false => 7376,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7377,
                                false => 7378,
                            },
                            false => Waterlogged switch {
                                true => 7379,
                                false => 7380,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7381,
                                false => 7382,
                            },
                            false => Waterlogged switch {
                                true => 7383,
                                false => 7384,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7385,
                                false => 7386,
                            },
                            false => Waterlogged switch {
                                true => 7387,
                                false => 7388,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7389,
                                false => 7390,
                            },
                            false => Waterlogged switch {
                                true => 7391,
                                false => 7392,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7393,
                                false => 7394,
                            },
                            false => Waterlogged switch {
                                true => 7395,
                                false => 7396,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7397,
                                false => 7398,
                            },
                            false => Waterlogged switch {
                                true => 7399,
                                false => 7400,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7401,
                                false => 7402,
                            },
                            false => Waterlogged switch {
                                true => 7403,
                                false => 7404,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7405,
                                false => 7406,
                            },
                            false => Waterlogged switch {
                                true => 7407,
                                false => 7408,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7409,
                                false => 7410,
                            },
                            false => Waterlogged switch {
                                true => 7411,
                                false => 7412,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7413,
                                false => 7414,
                            },
                            false => Waterlogged switch {
                                true => 7415,
                                false => 7416,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7417,
                                false => 7418,
                            },
                            false => Waterlogged switch {
                                true => 7419,
                                false => 7420,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7421,
                                false => 7422,
                            },
                            false => Waterlogged switch {
                                true => 7423,
                                false => 7424,
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
            7361 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7362 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7363 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7364 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7365 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7366 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7367 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7368 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7369 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7370 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7371 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7372 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7373 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7374 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7375 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7376 => new PaleOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7377 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7378 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7379 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7380 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7381 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7382 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7383 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7384 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7385 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7386 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7387 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7388 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7389 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7390 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7391 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7392 => new PaleOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7393 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7394 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7395 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7396 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7397 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7398 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7399 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7400 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7401 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7402 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7403 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7404 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7405 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7406 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7407 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7408 => new PaleOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7409 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7410 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7411 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7412 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7413 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7414 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7415 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7416 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7417 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7418 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7419 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7420 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7421 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7422 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7423 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7424 => new PaleOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
