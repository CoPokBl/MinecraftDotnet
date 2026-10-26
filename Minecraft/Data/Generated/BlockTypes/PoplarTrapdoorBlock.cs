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
public record PoplarTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:poplar_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 22, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9360];

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
                                true => 9360,
                                false => 9361,
                            },
                            false => Waterlogged switch {
                                true => 9362,
                                false => 9363,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9364,
                                false => 9365,
                            },
                            false => Waterlogged switch {
                                true => 9366,
                                false => 9367,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9368,
                                false => 9369,
                            },
                            false => Waterlogged switch {
                                true => 9370,
                                false => 9371,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9372,
                                false => 9373,
                            },
                            false => Waterlogged switch {
                                true => 9374,
                                false => 9375,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9376,
                                false => 9377,
                            },
                            false => Waterlogged switch {
                                true => 9378,
                                false => 9379,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9380,
                                false => 9381,
                            },
                            false => Waterlogged switch {
                                true => 9382,
                                false => 9383,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9384,
                                false => 9385,
                            },
                            false => Waterlogged switch {
                                true => 9386,
                                false => 9387,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9388,
                                false => 9389,
                            },
                            false => Waterlogged switch {
                                true => 9390,
                                false => 9391,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9392,
                                false => 9393,
                            },
                            false => Waterlogged switch {
                                true => 9394,
                                false => 9395,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9396,
                                false => 9397,
                            },
                            false => Waterlogged switch {
                                true => 9398,
                                false => 9399,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9400,
                                false => 9401,
                            },
                            false => Waterlogged switch {
                                true => 9402,
                                false => 9403,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9404,
                                false => 9405,
                            },
                            false => Waterlogged switch {
                                true => 9406,
                                false => 9407,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9408,
                                false => 9409,
                            },
                            false => Waterlogged switch {
                                true => 9410,
                                false => 9411,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9412,
                                false => 9413,
                            },
                            false => Waterlogged switch {
                                true => 9414,
                                false => 9415,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9416,
                                false => 9417,
                            },
                            false => Waterlogged switch {
                                true => 9418,
                                false => 9419,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9420,
                                false => 9421,
                            },
                            false => Waterlogged switch {
                                true => 9422,
                                false => 9423,
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
            9360 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9361 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9362 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9363 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9364 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9365 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9366 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9367 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9368 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9369 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9370 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9371 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9372 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9373 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9374 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9375 => new PoplarTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9376 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9377 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9378 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9379 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9380 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9381 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9382 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9383 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9384 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9385 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9386 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9387 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9388 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9389 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9390 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9391 => new PoplarTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9392 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9393 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9394 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9395 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9396 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9397 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9398 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9399 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9400 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9401 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9402 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9403 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9404 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9405 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9406 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9407 => new PoplarTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9408 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9409 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9410 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9411 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9412 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9413 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9414 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9415 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9416 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9417 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9418 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9419 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9420 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9421 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9422 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9423 => new PoplarTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
