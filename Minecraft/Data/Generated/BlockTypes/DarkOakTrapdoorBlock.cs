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
public record DarkOakTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.dark_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 26, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
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
                    TopBottom.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7498 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7499 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7500 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7501 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7502 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7503 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7504 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7505 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7506 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7507 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7508 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7509 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7510 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7511 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7512 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7513 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7514 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7515 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7516 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7517 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7518 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7519 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7520 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7521 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7522 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7523 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7524 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7525 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7526 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7527 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7528 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7529 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7530 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7531 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7532 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7533 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7534 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7535 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7536 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7537 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7538 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7539 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7540 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7541 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7542 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7543 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7544 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7545 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7546 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7547 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7548 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7549 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7550 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7551 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7552 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7553 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7554 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7555 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7556 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7557 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7558 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7559 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7560 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7561 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
