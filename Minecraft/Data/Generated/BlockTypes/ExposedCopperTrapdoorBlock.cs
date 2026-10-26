using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.exposed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/exposed_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 44, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, true, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S114, CollisionShape = BlockShapes.S114, VisualShape = BlockShapes.S114, SupportShape = BlockShapes.S114 };
    private static readonly BlockStateInfo I4 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableLand = false, PathfindableWater = false, PathfindableAir = false, Fluid = null, BlockShape = BlockShapes.S115, CollisionShape = BlockShapes.S115, VisualShape = BlockShapes.S115, SupportShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20, SupportShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19, SupportShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17, SupportShape = BlockShapes.S17 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I4, I5, I4, I5, I6, I7, I6, I7, I2, I3, I2, I3, I6, I7, I6, I7, I4, I5, I4, I5, I8, I9, I8, I9, I2, I3, I2, I3, I8, I9, I8, I9, I4, I5, I4, I5, I10, I11, I10, I11, I2, I3, I2, I3, I10, I11, I10, I11, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 32429];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(TopBottom half) => this with { Half = half };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32429,
                                false => 32430,
                            },
                            false => Waterlogged switch {
                                true => 32431,
                                false => 32432,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32433,
                                false => 32434,
                            },
                            false => Waterlogged switch {
                                true => 32435,
                                false => 32436,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32437,
                                false => 32438,
                            },
                            false => Waterlogged switch {
                                true => 32439,
                                false => 32440,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32441,
                                false => 32442,
                            },
                            false => Waterlogged switch {
                                true => 32443,
                                false => 32444,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32445,
                                false => 32446,
                            },
                            false => Waterlogged switch {
                                true => 32447,
                                false => 32448,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32449,
                                false => 32450,
                            },
                            false => Waterlogged switch {
                                true => 32451,
                                false => 32452,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32453,
                                false => 32454,
                            },
                            false => Waterlogged switch {
                                true => 32455,
                                false => 32456,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32457,
                                false => 32458,
                            },
                            false => Waterlogged switch {
                                true => 32459,
                                false => 32460,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32461,
                                false => 32462,
                            },
                            false => Waterlogged switch {
                                true => 32463,
                                false => 32464,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32465,
                                false => 32466,
                            },
                            false => Waterlogged switch {
                                true => 32467,
                                false => 32468,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32469,
                                false => 32470,
                            },
                            false => Waterlogged switch {
                                true => 32471,
                                false => 32472,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32473,
                                false => 32474,
                            },
                            false => Waterlogged switch {
                                true => 32475,
                                false => 32476,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32477,
                                false => 32478,
                            },
                            false => Waterlogged switch {
                                true => 32479,
                                false => 32480,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32481,
                                false => 32482,
                            },
                            false => Waterlogged switch {
                                true => 32483,
                                false => 32484,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32485,
                                false => 32486,
                            },
                            false => Waterlogged switch {
                                true => 32487,
                                false => 32488,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32489,
                                false => 32490,
                            },
                            false => Waterlogged switch {
                                true => 32491,
                                false => 32492,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32429 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32430 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32431 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32432 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32433 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32434 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32435 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32436 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32437 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32438 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32439 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32440 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32441 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32442 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32443 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32444 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32445 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32446 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32447 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32448 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32449 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32450 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32451 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32452 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32453 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32454 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32455 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32456 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32457 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32458 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32459 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32460 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32461 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32462 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32463 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32464 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32465 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32466 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32467 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32468 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32469 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32470 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32471 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32472 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32473 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32474 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32475 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32476 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32477 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32478 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32479 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32480 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32481 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32482 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32483 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32484 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32485 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32486 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32487 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32488 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32489 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32490 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32491 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32492 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? TopBottomExtensions.FromString(properties["half"].GetString()) : Half,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
