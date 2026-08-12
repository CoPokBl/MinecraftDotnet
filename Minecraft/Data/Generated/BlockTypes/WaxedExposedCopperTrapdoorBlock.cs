using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_trapdoor";
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
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_trapdoor";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29328,
                                false => 29329,
                            },
                            false => Waterlogged switch {
                                true => 29330,
                                false => 29331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29332,
                                false => 29333,
                            },
                            false => Waterlogged switch {
                                true => 29334,
                                false => 29335,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29336,
                                false => 29337,
                            },
                            false => Waterlogged switch {
                                true => 29338,
                                false => 29339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29340,
                                false => 29341,
                            },
                            false => Waterlogged switch {
                                true => 29342,
                                false => 29343,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29344,
                                false => 29345,
                            },
                            false => Waterlogged switch {
                                true => 29346,
                                false => 29347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29348,
                                false => 29349,
                            },
                            false => Waterlogged switch {
                                true => 29350,
                                false => 29351,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29352,
                                false => 29353,
                            },
                            false => Waterlogged switch {
                                true => 29354,
                                false => 29355,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29356,
                                false => 29357,
                            },
                            false => Waterlogged switch {
                                true => 29358,
                                false => 29359,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29360,
                                false => 29361,
                            },
                            false => Waterlogged switch {
                                true => 29362,
                                false => 29363,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29364,
                                false => 29365,
                            },
                            false => Waterlogged switch {
                                true => 29366,
                                false => 29367,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29368,
                                false => 29369,
                            },
                            false => Waterlogged switch {
                                true => 29370,
                                false => 29371,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29372,
                                false => 29373,
                            },
                            false => Waterlogged switch {
                                true => 29374,
                                false => 29375,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29376,
                                false => 29377,
                            },
                            false => Waterlogged switch {
                                true => 29378,
                                false => 29379,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29380,
                                false => 29381,
                            },
                            false => Waterlogged switch {
                                true => 29382,
                                false => 29383,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29384,
                                false => 29385,
                            },
                            false => Waterlogged switch {
                                true => 29386,
                                false => 29387,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29388,
                                false => 29389,
                            },
                            false => Waterlogged switch {
                                true => 29390,
                                false => 29391,
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
            29328 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29329 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29330 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29331 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29332 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29333 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29334 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29335 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29336 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29337 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29338 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29339 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29340 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29341 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29342 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29343 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29344 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29345 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29346 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29347 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29348 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29349 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29350 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29351 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29352 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29353 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29354 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29355 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29356 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29357 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29358 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29359 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29360 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29361 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29362 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29363 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29364 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29365 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29366 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29367 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29368 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29369 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29370 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29371 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29372 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29373 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29374 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29375 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29376 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29377 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29378 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29379 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29380 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29381 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29382 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29383 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29384 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29385 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29386 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29387 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29388 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29389 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29390 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29391 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
