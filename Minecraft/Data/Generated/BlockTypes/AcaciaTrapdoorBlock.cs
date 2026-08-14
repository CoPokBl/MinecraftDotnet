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
public record AcaciaTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.acacia_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7370];

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
                                true => 7370,
                                false => 7371,
                            },
                            false => Waterlogged switch {
                                true => 7372,
                                false => 7373,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7374,
                                false => 7375,
                            },
                            false => Waterlogged switch {
                                true => 7376,
                                false => 7377,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7378,
                                false => 7379,
                            },
                            false => Waterlogged switch {
                                true => 7380,
                                false => 7381,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7382,
                                false => 7383,
                            },
                            false => Waterlogged switch {
                                true => 7384,
                                false => 7385,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7386,
                                false => 7387,
                            },
                            false => Waterlogged switch {
                                true => 7388,
                                false => 7389,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7390,
                                false => 7391,
                            },
                            false => Waterlogged switch {
                                true => 7392,
                                false => 7393,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7394,
                                false => 7395,
                            },
                            false => Waterlogged switch {
                                true => 7396,
                                false => 7397,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7398,
                                false => 7399,
                            },
                            false => Waterlogged switch {
                                true => 7400,
                                false => 7401,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7402,
                                false => 7403,
                            },
                            false => Waterlogged switch {
                                true => 7404,
                                false => 7405,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7406,
                                false => 7407,
                            },
                            false => Waterlogged switch {
                                true => 7408,
                                false => 7409,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7410,
                                false => 7411,
                            },
                            false => Waterlogged switch {
                                true => 7412,
                                false => 7413,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7414,
                                false => 7415,
                            },
                            false => Waterlogged switch {
                                true => 7416,
                                false => 7417,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7418,
                                false => 7419,
                            },
                            false => Waterlogged switch {
                                true => 7420,
                                false => 7421,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7422,
                                false => 7423,
                            },
                            false => Waterlogged switch {
                                true => 7424,
                                false => 7425,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7426,
                                false => 7427,
                            },
                            false => Waterlogged switch {
                                true => 7428,
                                false => 7429,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7430,
                                false => 7431,
                            },
                            false => Waterlogged switch {
                                true => 7432,
                                false => 7433,
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
            7370 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7371 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7372 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7373 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7374 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7375 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7376 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7377 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7378 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7379 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7380 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7381 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7382 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7383 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7384 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7385 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7386 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7387 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7388 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7389 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7390 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7391 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7392 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7393 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7394 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7395 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7396 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7397 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7398 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7399 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7400 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7401 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7402 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7403 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7404 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7405 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7406 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7407 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7408 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7409 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7410 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7411 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7412 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7413 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7414 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7415 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7416 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7417 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7418 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7419 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7420 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7421 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7422 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7423 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7424 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7425 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7426 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7427 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7428 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7429 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7430 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7431 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7432 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7433 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
