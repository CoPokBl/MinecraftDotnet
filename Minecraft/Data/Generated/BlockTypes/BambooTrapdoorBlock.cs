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
public record BambooTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 18, "bamboo_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9424];

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
                                true => 9424,
                                false => 9425,
                            },
                            false => Waterlogged switch {
                                true => 9426,
                                false => 9427,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9428,
                                false => 9429,
                            },
                            false => Waterlogged switch {
                                true => 9430,
                                false => 9431,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9432,
                                false => 9433,
                            },
                            false => Waterlogged switch {
                                true => 9434,
                                false => 9435,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9436,
                                false => 9437,
                            },
                            false => Waterlogged switch {
                                true => 9438,
                                false => 9439,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9440,
                                false => 9441,
                            },
                            false => Waterlogged switch {
                                true => 9442,
                                false => 9443,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9444,
                                false => 9445,
                            },
                            false => Waterlogged switch {
                                true => 9446,
                                false => 9447,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9448,
                                false => 9449,
                            },
                            false => Waterlogged switch {
                                true => 9450,
                                false => 9451,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9452,
                                false => 9453,
                            },
                            false => Waterlogged switch {
                                true => 9454,
                                false => 9455,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9456,
                                false => 9457,
                            },
                            false => Waterlogged switch {
                                true => 9458,
                                false => 9459,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9460,
                                false => 9461,
                            },
                            false => Waterlogged switch {
                                true => 9462,
                                false => 9463,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9464,
                                false => 9465,
                            },
                            false => Waterlogged switch {
                                true => 9466,
                                false => 9467,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9468,
                                false => 9469,
                            },
                            false => Waterlogged switch {
                                true => 9470,
                                false => 9471,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9472,
                                false => 9473,
                            },
                            false => Waterlogged switch {
                                true => 9474,
                                false => 9475,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9476,
                                false => 9477,
                            },
                            false => Waterlogged switch {
                                true => 9478,
                                false => 9479,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9480,
                                false => 9481,
                            },
                            false => Waterlogged switch {
                                true => 9482,
                                false => 9483,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9484,
                                false => 9485,
                            },
                            false => Waterlogged switch {
                                true => 9486,
                                false => 9487,
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
            9424 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9425 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9426 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9427 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9428 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9429 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9430 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9431 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9432 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9433 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9434 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9435 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9436 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9437 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9438 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9439 => new BambooTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9440 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9441 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9442 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9443 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9444 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9445 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9446 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9447 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9448 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9449 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9450 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9451 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9452 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9453 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9454 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9455 => new BambooTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9456 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9457 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9458 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9459 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9460 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9461 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9462 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9463 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9464 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9465 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9466 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9467 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9468 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9469 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9470 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9471 => new BambooTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9472 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9473 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9474 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9475 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9476 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9477 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9478 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9479 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9480 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9481 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9482 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9483 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9484 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9485 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9486 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9487 => new BambooTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
