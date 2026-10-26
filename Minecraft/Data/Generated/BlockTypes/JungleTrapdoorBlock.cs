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
    private static readonly BlockInfo Data = new("block.minecraft.jungle_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:jungle_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 10, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 8976];

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
                                true => 8976,
                                false => 8977,
                            },
                            false => Waterlogged switch {
                                true => 8978,
                                false => 8979,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8980,
                                false => 8981,
                            },
                            false => Waterlogged switch {
                                true => 8982,
                                false => 8983,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8984,
                                false => 8985,
                            },
                            false => Waterlogged switch {
                                true => 8986,
                                false => 8987,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8988,
                                false => 8989,
                            },
                            false => Waterlogged switch {
                                true => 8990,
                                false => 8991,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8992,
                                false => 8993,
                            },
                            false => Waterlogged switch {
                                true => 8994,
                                false => 8995,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8996,
                                false => 8997,
                            },
                            false => Waterlogged switch {
                                true => 8998,
                                false => 8999,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9000,
                                false => 9001,
                            },
                            false => Waterlogged switch {
                                true => 9002,
                                false => 9003,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9004,
                                false => 9005,
                            },
                            false => Waterlogged switch {
                                true => 9006,
                                false => 9007,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9008,
                                false => 9009,
                            },
                            false => Waterlogged switch {
                                true => 9010,
                                false => 9011,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9012,
                                false => 9013,
                            },
                            false => Waterlogged switch {
                                true => 9014,
                                false => 9015,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9016,
                                false => 9017,
                            },
                            false => Waterlogged switch {
                                true => 9018,
                                false => 9019,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9020,
                                false => 9021,
                            },
                            false => Waterlogged switch {
                                true => 9022,
                                false => 9023,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9024,
                                false => 9025,
                            },
                            false => Waterlogged switch {
                                true => 9026,
                                false => 9027,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9028,
                                false => 9029,
                            },
                            false => Waterlogged switch {
                                true => 9030,
                                false => 9031,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9032,
                                false => 9033,
                            },
                            false => Waterlogged switch {
                                true => 9034,
                                false => 9035,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9036,
                                false => 9037,
                            },
                            false => Waterlogged switch {
                                true => 9038,
                                false => 9039,
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
            8976 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            8977 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            8978 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            8979 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            8980 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            8981 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            8982 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            8983 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            8984 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            8985 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            8986 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            8987 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            8988 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            8989 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            8990 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            8991 => new JungleTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            8992 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            8993 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            8994 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            8995 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            8996 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            8997 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            8998 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            8999 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9000 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9001 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9002 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9003 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9004 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9005 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9006 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9007 => new JungleTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9008 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9009 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9010 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9011 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9012 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9013 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9014 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9015 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9016 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9017 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9018 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9019 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9020 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9021 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9022 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9023 => new JungleTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9024 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9025 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9026 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9027 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9028 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9029 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9030 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9031 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9032 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9033 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9034 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9035 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9036 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9037 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9038 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9039 => new JungleTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
