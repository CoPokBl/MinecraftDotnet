using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, WaxedWeatheredCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.waxed_weathered_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_weathered_copper_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I4, I5, I4, I5, I6, I7, I6, I7, I2, I3, I2, I3, I6, I7, I6, I7, I4, I5, I4, I5, I8, I9, I8, I9, I2, I3, I2, I3, I8, I9, I8, I9, I4, I5, I4, I5, I10, I11, I10, I11, I2, I3, I2, I3, I10, I11, I10, I11, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 29392];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29392,
                                false => 29393,
                            },
                            false => Waterlogged switch {
                                true => 29394,
                                false => 29395,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29396,
                                false => 29397,
                            },
                            false => Waterlogged switch {
                                true => 29398,
                                false => 29399,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29400,
                                false => 29401,
                            },
                            false => Waterlogged switch {
                                true => 29402,
                                false => 29403,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29404,
                                false => 29405,
                            },
                            false => Waterlogged switch {
                                true => 29406,
                                false => 29407,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29408,
                                false => 29409,
                            },
                            false => Waterlogged switch {
                                true => 29410,
                                false => 29411,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29412,
                                false => 29413,
                            },
                            false => Waterlogged switch {
                                true => 29414,
                                false => 29415,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29416,
                                false => 29417,
                            },
                            false => Waterlogged switch {
                                true => 29418,
                                false => 29419,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29420,
                                false => 29421,
                            },
                            false => Waterlogged switch {
                                true => 29422,
                                false => 29423,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29424,
                                false => 29425,
                            },
                            false => Waterlogged switch {
                                true => 29426,
                                false => 29427,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29428,
                                false => 29429,
                            },
                            false => Waterlogged switch {
                                true => 29430,
                                false => 29431,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29432,
                                false => 29433,
                            },
                            false => Waterlogged switch {
                                true => 29434,
                                false => 29435,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29436,
                                false => 29437,
                            },
                            false => Waterlogged switch {
                                true => 29438,
                                false => 29439,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29440,
                                false => 29441,
                            },
                            false => Waterlogged switch {
                                true => 29442,
                                false => 29443,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29444,
                                false => 29445,
                            },
                            false => Waterlogged switch {
                                true => 29446,
                                false => 29447,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29448,
                                false => 29449,
                            },
                            false => Waterlogged switch {
                                true => 29450,
                                false => 29451,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29452,
                                false => 29453,
                            },
                            false => Waterlogged switch {
                                true => 29454,
                                false => 29455,
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
            29392 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29393 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29394 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29395 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29396 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29397 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29398 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29399 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29400 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29401 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29402 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29403 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29404 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29405 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29406 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29407 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29408 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29409 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29410 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29411 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29412 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29413 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29414 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29415 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29416 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29417 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29418 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29419 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29420 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29421 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29422 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29423 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29424 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29425 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29426 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29427 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29428 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29429 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29430 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29431 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29432 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29433 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29434 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29435 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29436 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29437 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29438 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29439 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29440 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29441 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29442 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29443 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29444 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29445 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29446 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29447 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29448 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29449 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29450 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29451 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29452 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29453 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29454 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29455 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
