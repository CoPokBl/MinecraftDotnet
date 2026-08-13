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
public record CherryTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.cherry_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 36, "cherry_wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7434];

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
                                true => 7434,
                                false => 7435,
                            },
                            false => Waterlogged switch {
                                true => 7436,
                                false => 7437,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7438,
                                false => 7439,
                            },
                            false => Waterlogged switch {
                                true => 7440,
                                false => 7441,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7442,
                                false => 7443,
                            },
                            false => Waterlogged switch {
                                true => 7444,
                                false => 7445,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7446,
                                false => 7447,
                            },
                            false => Waterlogged switch {
                                true => 7448,
                                false => 7449,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7450,
                                false => 7451,
                            },
                            false => Waterlogged switch {
                                true => 7452,
                                false => 7453,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7454,
                                false => 7455,
                            },
                            false => Waterlogged switch {
                                true => 7456,
                                false => 7457,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7458,
                                false => 7459,
                            },
                            false => Waterlogged switch {
                                true => 7460,
                                false => 7461,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7462,
                                false => 7463,
                            },
                            false => Waterlogged switch {
                                true => 7464,
                                false => 7465,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7466,
                                false => 7467,
                            },
                            false => Waterlogged switch {
                                true => 7468,
                                false => 7469,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7470,
                                false => 7471,
                            },
                            false => Waterlogged switch {
                                true => 7472,
                                false => 7473,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7474,
                                false => 7475,
                            },
                            false => Waterlogged switch {
                                true => 7476,
                                false => 7477,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7478,
                                false => 7479,
                            },
                            false => Waterlogged switch {
                                true => 7480,
                                false => 7481,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7482,
                                false => 7483,
                            },
                            false => Waterlogged switch {
                                true => 7484,
                                false => 7485,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7486,
                                false => 7487,
                            },
                            false => Waterlogged switch {
                                true => 7488,
                                false => 7489,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7490,
                                false => 7491,
                            },
                            false => Waterlogged switch {
                                true => 7492,
                                false => 7493,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7494,
                                false => 7495,
                            },
                            false => Waterlogged switch {
                                true => 7496,
                                false => 7497,
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
            7434 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7435 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7436 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7437 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7438 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7439 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7440 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7441 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7442 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7443 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7444 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7445 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7446 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7447 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7448 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7449 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7450 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7451 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7452 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7453 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7454 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7455 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7456 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7457 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7458 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7459 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7460 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7461 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7462 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7463 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7464 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7465 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7466 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7467 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7468 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7469 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7470 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7471 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7472 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7473 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7474 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7475 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7476 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7477 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7478 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7479 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7480 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7481 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7482 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7483 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7484 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7485 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7486 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7487 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7488 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7489 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7490 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7491 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7492 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7493 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7494 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7495 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7496 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7497 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
