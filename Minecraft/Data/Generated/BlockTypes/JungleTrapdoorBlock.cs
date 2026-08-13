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
public record JungleTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.jungle_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:jungle_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 10, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7306];

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
                                true => 7306,
                                false => 7307,
                            },
                            false => Waterlogged switch {
                                true => 7308,
                                false => 7309,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7310,
                                false => 7311,
                            },
                            false => Waterlogged switch {
                                true => 7312,
                                false => 7313,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7314,
                                false => 7315,
                            },
                            false => Waterlogged switch {
                                true => 7316,
                                false => 7317,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7318,
                                false => 7319,
                            },
                            false => Waterlogged switch {
                                true => 7320,
                                false => 7321,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7322,
                                false => 7323,
                            },
                            false => Waterlogged switch {
                                true => 7324,
                                false => 7325,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7326,
                                false => 7327,
                            },
                            false => Waterlogged switch {
                                true => 7328,
                                false => 7329,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7330,
                                false => 7331,
                            },
                            false => Waterlogged switch {
                                true => 7332,
                                false => 7333,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7334,
                                false => 7335,
                            },
                            false => Waterlogged switch {
                                true => 7336,
                                false => 7337,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7338,
                                false => 7339,
                            },
                            false => Waterlogged switch {
                                true => 7340,
                                false => 7341,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7342,
                                false => 7343,
                            },
                            false => Waterlogged switch {
                                true => 7344,
                                false => 7345,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7346,
                                false => 7347,
                            },
                            false => Waterlogged switch {
                                true => 7348,
                                false => 7349,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7350,
                                false => 7351,
                            },
                            false => Waterlogged switch {
                                true => 7352,
                                false => 7353,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7354,
                                false => 7355,
                            },
                            false => Waterlogged switch {
                                true => 7356,
                                false => 7357,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7358,
                                false => 7359,
                            },
                            false => Waterlogged switch {
                                true => 7360,
                                false => 7361,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7362,
                                false => 7363,
                            },
                            false => Waterlogged switch {
                                true => 7364,
                                false => 7365,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7366,
                                false => 7367,
                            },
                            false => Waterlogged switch {
                                true => 7368,
                                false => 7369,
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
            7306 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            7307 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            7308 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            7309 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            7310 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            7311 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            7312 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            7313 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            7314 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            7315 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            7316 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            7317 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            7318 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            7319 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            7320 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            7321 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            7322 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            7323 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            7324 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            7325 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            7326 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            7327 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            7328 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            7329 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            7330 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            7331 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            7332 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            7333 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            7334 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            7335 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            7336 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            7337 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            7338 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            7339 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            7340 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            7341 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            7342 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            7343 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            7344 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            7345 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            7346 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            7347 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            7348 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            7349 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            7350 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            7351 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            7352 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            7353 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            7354 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            7355 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            7356 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            7357 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            7358 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            7359 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            7360 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            7361 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            7362 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            7363 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            7364 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            7365 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            7366 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            7367 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            7368 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            7369 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
