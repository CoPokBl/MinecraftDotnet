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
public record MangroveTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 28, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9296];

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
                                true => 9296,
                                false => 9297,
                            },
                            false => Waterlogged switch {
                                true => 9298,
                                false => 9299,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9300,
                                false => 9301,
                            },
                            false => Waterlogged switch {
                                true => 9302,
                                false => 9303,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9304,
                                false => 9305,
                            },
                            false => Waterlogged switch {
                                true => 9306,
                                false => 9307,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9308,
                                false => 9309,
                            },
                            false => Waterlogged switch {
                                true => 9310,
                                false => 9311,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9312,
                                false => 9313,
                            },
                            false => Waterlogged switch {
                                true => 9314,
                                false => 9315,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9316,
                                false => 9317,
                            },
                            false => Waterlogged switch {
                                true => 9318,
                                false => 9319,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9320,
                                false => 9321,
                            },
                            false => Waterlogged switch {
                                true => 9322,
                                false => 9323,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9324,
                                false => 9325,
                            },
                            false => Waterlogged switch {
                                true => 9326,
                                false => 9327,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9328,
                                false => 9329,
                            },
                            false => Waterlogged switch {
                                true => 9330,
                                false => 9331,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9332,
                                false => 9333,
                            },
                            false => Waterlogged switch {
                                true => 9334,
                                false => 9335,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9336,
                                false => 9337,
                            },
                            false => Waterlogged switch {
                                true => 9338,
                                false => 9339,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9340,
                                false => 9341,
                            },
                            false => Waterlogged switch {
                                true => 9342,
                                false => 9343,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9344,
                                false => 9345,
                            },
                            false => Waterlogged switch {
                                true => 9346,
                                false => 9347,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9348,
                                false => 9349,
                            },
                            false => Waterlogged switch {
                                true => 9350,
                                false => 9351,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9352,
                                false => 9353,
                            },
                            false => Waterlogged switch {
                                true => 9354,
                                false => 9355,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9356,
                                false => 9357,
                            },
                            false => Waterlogged switch {
                                true => 9358,
                                false => 9359,
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
            9296 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9297 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9298 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9299 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9300 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9301 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9302 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9303 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9304 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9305 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9306 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9307 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9308 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9309 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9310 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9311 => new MangroveTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9312 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9313 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9314 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9315 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9316 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9317 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9318 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9319 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9320 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9321 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9322 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9323 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9324 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9325 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9326 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9327 => new MangroveTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9328 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9329 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9330 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9331 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9332 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9333 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9334 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9335 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9336 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9337 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9338 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9339 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9340 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9341 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9342 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9343 => new MangroveTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9344 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9345 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9346 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9347 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9348 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9349 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9350 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9351 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9352 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9353 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9354 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9355 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9356 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9357 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9358 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9359 => new MangroveTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
