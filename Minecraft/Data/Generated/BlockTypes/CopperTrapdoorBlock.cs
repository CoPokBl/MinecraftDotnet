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
    public int ProtocolId => 1055;
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
                                true => 26333,
                                false => 26334,
                            },
                            false => Waterlogged switch {
                                true => 26335,
                                false => 26336,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26337,
                                false => 26338,
                            },
                            false => Waterlogged switch {
                                true => 26339,
                                false => 26340,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26341,
                                false => 26342,
                            },
                            false => Waterlogged switch {
                                true => 26343,
                                false => 26344,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26345,
                                false => 26346,
                            },
                            false => Waterlogged switch {
                                true => 26347,
                                false => 26348,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26349,
                                false => 26350,
                            },
                            false => Waterlogged switch {
                                true => 26351,
                                false => 26352,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26353,
                                false => 26354,
                            },
                            false => Waterlogged switch {
                                true => 26355,
                                false => 26356,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26357,
                                false => 26358,
                            },
                            false => Waterlogged switch {
                                true => 26359,
                                false => 26360,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26361,
                                false => 26362,
                            },
                            false => Waterlogged switch {
                                true => 26363,
                                false => 26364,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26365,
                                false => 26366,
                            },
                            false => Waterlogged switch {
                                true => 26367,
                                false => 26368,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26369,
                                false => 26370,
                            },
                            false => Waterlogged switch {
                                true => 26371,
                                false => 26372,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26373,
                                false => 26374,
                            },
                            false => Waterlogged switch {
                                true => 26375,
                                false => 26376,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26377,
                                false => 26378,
                            },
                            false => Waterlogged switch {
                                true => 26379,
                                false => 26380,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26381,
                                false => 26382,
                            },
                            false => Waterlogged switch {
                                true => 26383,
                                false => 26384,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26385,
                                false => 26386,
                            },
                            false => Waterlogged switch {
                                true => 26387,
                                false => 26388,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 26389,
                                false => 26390,
                            },
                            false => Waterlogged switch {
                                true => 26391,
                                false => 26392,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 26393,
                                false => 26394,
                            },
                            false => Waterlogged switch {
                                true => 26395,
                                false => 26396,
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
            26333 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            26334 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            26335 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            26336 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            26337 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            26338 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            26339 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            26340 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            26341 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            26342 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            26343 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            26344 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            26345 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            26346 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            26347 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            26348 => new CopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            26349 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            26350 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            26351 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            26352 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            26353 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            26354 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            26355 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            26356 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            26357 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            26358 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            26359 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            26360 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            26361 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            26362 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            26363 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            26364 => new CopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            26365 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            26366 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            26367 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            26368 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            26369 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            26370 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            26371 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            26372 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            26373 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            26374 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            26375 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            26376 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            26377 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            26378 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            26379 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            26380 => new CopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            26381 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            26382 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            26383 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            26384 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            26385 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            26386 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            26387 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            26388 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            26389 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            26390 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            26391 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            26392 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            26393 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            26394 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            26395 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            26396 => new CopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
