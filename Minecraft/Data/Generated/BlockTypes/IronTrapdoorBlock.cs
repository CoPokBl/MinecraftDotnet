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
public record IronTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.iron_trapdoor", 5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:iron_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/iron_trapdoor");
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.PushPull, 6, "iron", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 14414];

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
                                true => 14414,
                                false => 14415,
                            },
                            false => Waterlogged switch {
                                true => 14416,
                                false => 14417,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14418,
                                false => 14419,
                            },
                            false => Waterlogged switch {
                                true => 14420,
                                false => 14421,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14422,
                                false => 14423,
                            },
                            false => Waterlogged switch {
                                true => 14424,
                                false => 14425,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14426,
                                false => 14427,
                            },
                            false => Waterlogged switch {
                                true => 14428,
                                false => 14429,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14430,
                                false => 14431,
                            },
                            false => Waterlogged switch {
                                true => 14432,
                                false => 14433,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14434,
                                false => 14435,
                            },
                            false => Waterlogged switch {
                                true => 14436,
                                false => 14437,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14438,
                                false => 14439,
                            },
                            false => Waterlogged switch {
                                true => 14440,
                                false => 14441,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14442,
                                false => 14443,
                            },
                            false => Waterlogged switch {
                                true => 14444,
                                false => 14445,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14446,
                                false => 14447,
                            },
                            false => Waterlogged switch {
                                true => 14448,
                                false => 14449,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14450,
                                false => 14451,
                            },
                            false => Waterlogged switch {
                                true => 14452,
                                false => 14453,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14454,
                                false => 14455,
                            },
                            false => Waterlogged switch {
                                true => 14456,
                                false => 14457,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14458,
                                false => 14459,
                            },
                            false => Waterlogged switch {
                                true => 14460,
                                false => 14461,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14462,
                                false => 14463,
                            },
                            false => Waterlogged switch {
                                true => 14464,
                                false => 14465,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14466,
                                false => 14467,
                            },
                            false => Waterlogged switch {
                                true => 14468,
                                false => 14469,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 14470,
                                false => 14471,
                            },
                            false => Waterlogged switch {
                                true => 14472,
                                false => 14473,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 14474,
                                false => 14475,
                            },
                            false => Waterlogged switch {
                                true => 14476,
                                false => 14477,
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
            14414 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            14415 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            14416 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            14417 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            14418 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            14419 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            14420 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            14421 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            14422 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            14423 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            14424 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            14425 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            14426 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            14427 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            14428 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            14429 => new IronTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            14430 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            14431 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            14432 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            14433 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            14434 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            14435 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            14436 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            14437 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            14438 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            14439 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            14440 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            14441 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            14442 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            14443 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            14444 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            14445 => new IronTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            14446 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            14447 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            14448 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            14449 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            14450 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            14451 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            14452 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            14453 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            14454 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            14455 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            14456 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            14457 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            14458 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            14459 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            14460 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            14461 => new IronTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            14462 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            14463 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            14464 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            14465 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            14466 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            14467 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            14468 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            14469 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            14470 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            14471 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            14472 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            14473 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            14474 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            14475 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            14476 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            14477 => new IronTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
