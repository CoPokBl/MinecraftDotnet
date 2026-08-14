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
public record WaxedWeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.waxed_weathered_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_weathered_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_weathered_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29392];

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
                                true => 29392,
                                false => 29393,
                            },
                            false => Waterlogged switch {
                                true => 29394,
                                false => 29395,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29396,
                                false => 29397,
                            },
                            false => Waterlogged switch {
                                true => 29398,
                                false => 29399,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29400,
                                false => 29401,
                            },
                            false => Waterlogged switch {
                                true => 29402,
                                false => 29403,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29404,
                                false => 29405,
                            },
                            false => Waterlogged switch {
                                true => 29406,
                                false => 29407,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29408,
                                false => 29409,
                            },
                            false => Waterlogged switch {
                                true => 29410,
                                false => 29411,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29412,
                                false => 29413,
                            },
                            false => Waterlogged switch {
                                true => 29414,
                                false => 29415,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29416,
                                false => 29417,
                            },
                            false => Waterlogged switch {
                                true => 29418,
                                false => 29419,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29420,
                                false => 29421,
                            },
                            false => Waterlogged switch {
                                true => 29422,
                                false => 29423,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29424,
                                false => 29425,
                            },
                            false => Waterlogged switch {
                                true => 29426,
                                false => 29427,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29428,
                                false => 29429,
                            },
                            false => Waterlogged switch {
                                true => 29430,
                                false => 29431,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29432,
                                false => 29433,
                            },
                            false => Waterlogged switch {
                                true => 29434,
                                false => 29435,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29436,
                                false => 29437,
                            },
                            false => Waterlogged switch {
                                true => 29438,
                                false => 29439,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29440,
                                false => 29441,
                            },
                            false => Waterlogged switch {
                                true => 29442,
                                false => 29443,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29444,
                                false => 29445,
                            },
                            false => Waterlogged switch {
                                true => 29446,
                                false => 29447,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29448,
                                false => 29449,
                            },
                            false => Waterlogged switch {
                                true => 29450,
                                false => 29451,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29452,
                                false => 29453,
                            },
                            false => Waterlogged switch {
                                true => 29454,
                                false => 29455,
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
            29392 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            29393 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            29394 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            29395 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            29396 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            29397 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            29398 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            29399 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            29400 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            29401 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            29402 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            29403 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            29404 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            29405 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            29406 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            29407 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            29408 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            29409 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            29410 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            29411 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            29412 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            29413 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            29414 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            29415 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            29416 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            29417 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            29418 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            29419 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            29420 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            29421 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            29422 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            29423 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            29424 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            29425 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            29426 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            29427 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            29428 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            29429 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            29430 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            29431 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            29432 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            29433 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            29434 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            29435 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            29436 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            29437 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            29438 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            29439 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            29440 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            29441 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            29442 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            29443 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            29444 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            29445 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            29446 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            29447 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            29448 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            29449 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            29450 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            29451 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            29452 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            29453 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            29454 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            29455 => new WaxedWeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
