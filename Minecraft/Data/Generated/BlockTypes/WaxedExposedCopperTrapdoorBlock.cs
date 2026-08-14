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
public record WaxedExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.waxed_exposed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_exposed_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_exposed_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 44, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29328];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29328 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29329 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29330 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29331 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29332 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29333 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29334 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29335 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29336 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29337 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29338 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29339 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29340 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29341 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29342 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29343 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29344 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29345 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29346 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29347 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29348 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29349 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29350 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29351 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29352 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29353 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29354 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29355 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29356 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29357 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29358 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29359 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29360 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29361 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29362 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29363 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29364 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29365 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29366 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29367 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29368 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29369 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29370 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29371 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29372 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29373 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29374 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29375 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29376 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29377 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29378 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29379 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29380 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29381 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29382 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29383 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29384 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29385 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29386 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29387 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29388 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29389 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29390 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29391 => new WaxedExposedCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
