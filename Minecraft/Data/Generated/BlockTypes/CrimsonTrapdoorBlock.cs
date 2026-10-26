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
public record CrimsonTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.crimson_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 53, "nether_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 24471];

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
                                true => 24471,
                                false => 24472,
                            },
                            false => Waterlogged switch {
                                true => 24473,
                                false => 24474,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24475,
                                false => 24476,
                            },
                            false => Waterlogged switch {
                                true => 24477,
                                false => 24478,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24479,
                                false => 24480,
                            },
                            false => Waterlogged switch {
                                true => 24481,
                                false => 24482,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24483,
                                false => 24484,
                            },
                            false => Waterlogged switch {
                                true => 24485,
                                false => 24486,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24487,
                                false => 24488,
                            },
                            false => Waterlogged switch {
                                true => 24489,
                                false => 24490,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24491,
                                false => 24492,
                            },
                            false => Waterlogged switch {
                                true => 24493,
                                false => 24494,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24495,
                                false => 24496,
                            },
                            false => Waterlogged switch {
                                true => 24497,
                                false => 24498,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24499,
                                false => 24500,
                            },
                            false => Waterlogged switch {
                                true => 24501,
                                false => 24502,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24503,
                                false => 24504,
                            },
                            false => Waterlogged switch {
                                true => 24505,
                                false => 24506,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24507,
                                false => 24508,
                            },
                            false => Waterlogged switch {
                                true => 24509,
                                false => 24510,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24511,
                                false => 24512,
                            },
                            false => Waterlogged switch {
                                true => 24513,
                                false => 24514,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24515,
                                false => 24516,
                            },
                            false => Waterlogged switch {
                                true => 24517,
                                false => 24518,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24519,
                                false => 24520,
                            },
                            false => Waterlogged switch {
                                true => 24521,
                                false => 24522,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24523,
                                false => 24524,
                            },
                            false => Waterlogged switch {
                                true => 24525,
                                false => 24526,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 24527,
                                false => 24528,
                            },
                            false => Waterlogged switch {
                                true => 24529,
                                false => 24530,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 24531,
                                false => 24532,
                            },
                            false => Waterlogged switch {
                                true => 24533,
                                false => 24534,
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
            24471 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            24472 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            24473 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            24474 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            24475 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            24476 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            24477 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            24478 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            24479 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            24480 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            24481 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            24482 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            24483 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            24484 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            24485 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            24486 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            24487 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            24488 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            24489 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            24490 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            24491 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            24492 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            24493 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            24494 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            24495 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            24496 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            24497 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            24498 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            24499 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            24500 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            24501 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            24502 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            24503 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            24504 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            24505 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            24506 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            24507 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            24508 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            24509 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            24510 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            24511 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            24512 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            24513 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            24514 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            24515 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            24516 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            24517 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            24518 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            24519 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            24520 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            24521 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            24522 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            24523 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            24524 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            24525 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            24526 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            24527 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            24528 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            24529 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            24530 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            24531 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            24532 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            24533 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            24534 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
