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
public record CopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, true, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 32365];

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
                                true => 32365,
                                false => 32366,
                            },
                            false => Waterlogged switch {
                                true => 32367,
                                false => 32368,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32369,
                                false => 32370,
                            },
                            false => Waterlogged switch {
                                true => 32371,
                                false => 32372,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32373,
                                false => 32374,
                            },
                            false => Waterlogged switch {
                                true => 32375,
                                false => 32376,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32377,
                                false => 32378,
                            },
                            false => Waterlogged switch {
                                true => 32379,
                                false => 32380,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32381,
                                false => 32382,
                            },
                            false => Waterlogged switch {
                                true => 32383,
                                false => 32384,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32385,
                                false => 32386,
                            },
                            false => Waterlogged switch {
                                true => 32387,
                                false => 32388,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32389,
                                false => 32390,
                            },
                            false => Waterlogged switch {
                                true => 32391,
                                false => 32392,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32393,
                                false => 32394,
                            },
                            false => Waterlogged switch {
                                true => 32395,
                                false => 32396,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32397,
                                false => 32398,
                            },
                            false => Waterlogged switch {
                                true => 32399,
                                false => 32400,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32401,
                                false => 32402,
                            },
                            false => Waterlogged switch {
                                true => 32403,
                                false => 32404,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32405,
                                false => 32406,
                            },
                            false => Waterlogged switch {
                                true => 32407,
                                false => 32408,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32409,
                                false => 32410,
                            },
                            false => Waterlogged switch {
                                true => 32411,
                                false => 32412,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32413,
                                false => 32414,
                            },
                            false => Waterlogged switch {
                                true => 32415,
                                false => 32416,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32417,
                                false => 32418,
                            },
                            false => Waterlogged switch {
                                true => 32419,
                                false => 32420,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32421,
                                false => 32422,
                            },
                            false => Waterlogged switch {
                                true => 32423,
                                false => 32424,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32425,
                                false => 32426,
                            },
                            false => Waterlogged switch {
                                true => 32427,
                                false => 32428,
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
            32365 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32366 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32367 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32368 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32369 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32370 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32371 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32372 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32373 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32374 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32375 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32376 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32377 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32378 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32379 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32380 => new CopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32381 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32382 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32383 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32384 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32385 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32386 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32387 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32388 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32389 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32390 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32391 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32392 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32393 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32394 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32395 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32396 => new CopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32397 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32398 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32399 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32400 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32401 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32402 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32403 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32404 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32405 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32406 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32407 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32408 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32409 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32410 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32411 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32412 => new CopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32413 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32414 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32415 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32416 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32417 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32418 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32419 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32420 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32421 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32422 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32423 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32424 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32425 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32426 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32427 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32428 => new CopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
