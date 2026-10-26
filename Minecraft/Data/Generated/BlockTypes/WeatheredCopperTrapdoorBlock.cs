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
public record WeatheredCopperTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.weathered_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_copper_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/weathered_copper_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 56, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, true, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 32493];

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
                                true => 32493,
                                false => 32494,
                            },
                            false => Waterlogged switch {
                                true => 32495,
                                false => 32496,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32497,
                                false => 32498,
                            },
                            false => Waterlogged switch {
                                true => 32499,
                                false => 32500,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32501,
                                false => 32502,
                            },
                            false => Waterlogged switch {
                                true => 32503,
                                false => 32504,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32505,
                                false => 32506,
                            },
                            false => Waterlogged switch {
                                true => 32507,
                                false => 32508,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32509,
                                false => 32510,
                            },
                            false => Waterlogged switch {
                                true => 32511,
                                false => 32512,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32513,
                                false => 32514,
                            },
                            false => Waterlogged switch {
                                true => 32515,
                                false => 32516,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32517,
                                false => 32518,
                            },
                            false => Waterlogged switch {
                                true => 32519,
                                false => 32520,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32521,
                                false => 32522,
                            },
                            false => Waterlogged switch {
                                true => 32523,
                                false => 32524,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32525,
                                false => 32526,
                            },
                            false => Waterlogged switch {
                                true => 32527,
                                false => 32528,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32529,
                                false => 32530,
                            },
                            false => Waterlogged switch {
                                true => 32531,
                                false => 32532,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32533,
                                false => 32534,
                            },
                            false => Waterlogged switch {
                                true => 32535,
                                false => 32536,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32537,
                                false => 32538,
                            },
                            false => Waterlogged switch {
                                true => 32539,
                                false => 32540,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32541,
                                false => 32542,
                            },
                            false => Waterlogged switch {
                                true => 32543,
                                false => 32544,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32545,
                                false => 32546,
                            },
                            false => Waterlogged switch {
                                true => 32547,
                                false => 32548,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 32549,
                                false => 32550,
                            },
                            false => Waterlogged switch {
                                true => 32551,
                                false => 32552,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 32553,
                                false => 32554,
                            },
                            false => Waterlogged switch {
                                true => 32555,
                                false => 32556,
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
            32493 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            32494 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            32495 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            32496 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            32497 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            32498 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            32499 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            32500 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            32501 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            32502 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            32503 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            32504 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            32505 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            32506 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            32507 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            32508 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            32509 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            32510 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            32511 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            32512 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            32513 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            32514 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            32515 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            32516 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            32517 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            32518 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            32519 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            32520 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            32521 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            32522 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            32523 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            32524 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            32525 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            32526 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            32527 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            32528 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            32529 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            32530 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            32531 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            32532 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            32533 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            32534 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            32535 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            32536 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            32537 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            32538 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            32539 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            32540 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            32541 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            32542 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            32543 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            32544 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            32545 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            32546 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            32547 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            32548 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            32549 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            32550 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            32551 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            32552 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            32553 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            32554 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            32555 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            32556 => new WeatheredCopperTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
