using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakTrapdoorBlock(Identifier Identifier, Direction Facing, DarkOakTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.dark_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 26, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7498];

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
                                true => 7498,
                                false => 7499,
                            },
                            false => Waterlogged switch {
                                true => 7500,
                                false => 7501,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7502,
                                false => 7503,
                            },
                            false => Waterlogged switch {
                                true => 7504,
                                false => 7505,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7506,
                                false => 7507,
                            },
                            false => Waterlogged switch {
                                true => 7508,
                                false => 7509,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7510,
                                false => 7511,
                            },
                            false => Waterlogged switch {
                                true => 7512,
                                false => 7513,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7514,
                                false => 7515,
                            },
                            false => Waterlogged switch {
                                true => 7516,
                                false => 7517,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7518,
                                false => 7519,
                            },
                            false => Waterlogged switch {
                                true => 7520,
                                false => 7521,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7522,
                                false => 7523,
                            },
                            false => Waterlogged switch {
                                true => 7524,
                                false => 7525,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7526,
                                false => 7527,
                            },
                            false => Waterlogged switch {
                                true => 7528,
                                false => 7529,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7530,
                                false => 7531,
                            },
                            false => Waterlogged switch {
                                true => 7532,
                                false => 7533,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7534,
                                false => 7535,
                            },
                            false => Waterlogged switch {
                                true => 7536,
                                false => 7537,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7538,
                                false => 7539,
                            },
                            false => Waterlogged switch {
                                true => 7540,
                                false => 7541,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7542,
                                false => 7543,
                            },
                            false => Waterlogged switch {
                                true => 7544,
                                false => 7545,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7546,
                                false => 7547,
                            },
                            false => Waterlogged switch {
                                true => 7548,
                                false => 7549,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7550,
                                false => 7551,
                            },
                            false => Waterlogged switch {
                                true => 7552,
                                false => 7553,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7554,
                                false => 7555,
                            },
                            false => Waterlogged switch {
                                true => 7556,
                                false => 7557,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7558,
                                false => 7559,
                            },
                            false => Waterlogged switch {
                                true => 7560,
                                false => 7561,
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
            7498 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7499 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7500 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7501 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7502 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7503 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7504 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7505 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7506 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7507 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7508 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7509 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7510 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7511 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7512 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7513 => new DarkOakTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7514 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7515 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7516 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7517 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7518 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7519 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7520 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7521 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7522 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7523 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7524 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7525 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7526 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7527 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7528 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7529 => new DarkOakTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7530 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7531 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7532 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7533 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7534 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7535 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7536 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7537 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7538 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7539 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7540 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7541 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7542 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7543 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7544 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7545 => new DarkOakTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7546 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7547 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7548 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7549 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7550 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7551 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7552 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7553 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7554 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7555 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7556 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7557 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7558 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7559 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7560 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7561 => new DarkOakTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
