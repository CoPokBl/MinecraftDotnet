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
    public int ProtocolId => 524;
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
                                true => 12365,
                                false => 12366,
                            },
                            false => Waterlogged switch {
                                true => 12367,
                                false => 12368,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12369,
                                false => 12370,
                            },
                            false => Waterlogged switch {
                                true => 12371,
                                false => 12372,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12373,
                                false => 12374,
                            },
                            false => Waterlogged switch {
                                true => 12375,
                                false => 12376,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12377,
                                false => 12378,
                            },
                            false => Waterlogged switch {
                                true => 12379,
                                false => 12380,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12381,
                                false => 12382,
                            },
                            false => Waterlogged switch {
                                true => 12383,
                                false => 12384,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12385,
                                false => 12386,
                            },
                            false => Waterlogged switch {
                                true => 12387,
                                false => 12388,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12389,
                                false => 12390,
                            },
                            false => Waterlogged switch {
                                true => 12391,
                                false => 12392,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12393,
                                false => 12394,
                            },
                            false => Waterlogged switch {
                                true => 12395,
                                false => 12396,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12397,
                                false => 12398,
                            },
                            false => Waterlogged switch {
                                true => 12399,
                                false => 12400,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12401,
                                false => 12402,
                            },
                            false => Waterlogged switch {
                                true => 12403,
                                false => 12404,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12405,
                                false => 12406,
                            },
                            false => Waterlogged switch {
                                true => 12407,
                                false => 12408,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12409,
                                false => 12410,
                            },
                            false => Waterlogged switch {
                                true => 12411,
                                false => 12412,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12413,
                                false => 12414,
                            },
                            false => Waterlogged switch {
                                true => 12415,
                                false => 12416,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12417,
                                false => 12418,
                            },
                            false => Waterlogged switch {
                                true => 12419,
                                false => 12420,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 12421,
                                false => 12422,
                            },
                            false => Waterlogged switch {
                                true => 12423,
                                false => 12424,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 12425,
                                false => 12426,
                            },
                            false => Waterlogged switch {
                                true => 12427,
                                false => 12428,
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
            12365 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            12366 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            12367 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            12368 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            12369 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            12370 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            12371 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            12372 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            12373 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            12374 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            12375 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            12376 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            12377 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            12378 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            12379 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            12380 => new IronTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            12381 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            12382 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            12383 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            12384 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            12385 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            12386 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            12387 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            12388 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            12389 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            12390 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            12391 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            12392 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            12393 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            12394 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            12395 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            12396 => new IronTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            12397 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            12398 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            12399 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            12400 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            12401 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            12402 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            12403 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            12404 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            12405 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            12406 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            12407 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            12408 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            12409 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            12410 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            12411 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            12412 => new IronTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            12413 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            12414 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            12415 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            12416 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            12417 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            12418 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            12419 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            12420 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            12421 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            12422 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            12423 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            12424 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            12425 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            12426 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            12427 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            12428 => new IronTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
