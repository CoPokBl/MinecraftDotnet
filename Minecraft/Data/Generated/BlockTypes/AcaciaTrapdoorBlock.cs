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
    private static readonly BlockInfo Data = new("block.minecraft.acacia_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9040];

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
                                true => 9040,
                                false => 9041,
                            },
                            false => Waterlogged switch {
                                true => 9042,
                                false => 9043,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9044,
                                false => 9045,
                            },
                            false => Waterlogged switch {
                                true => 9046,
                                false => 9047,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9048,
                                false => 9049,
                            },
                            false => Waterlogged switch {
                                true => 9050,
                                false => 9051,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9052,
                                false => 9053,
                            },
                            false => Waterlogged switch {
                                true => 9054,
                                false => 9055,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9056,
                                false => 9057,
                            },
                            false => Waterlogged switch {
                                true => 9058,
                                false => 9059,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9060,
                                false => 9061,
                            },
                            false => Waterlogged switch {
                                true => 9062,
                                false => 9063,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9064,
                                false => 9065,
                            },
                            false => Waterlogged switch {
                                true => 9066,
                                false => 9067,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9068,
                                false => 9069,
                            },
                            false => Waterlogged switch {
                                true => 9070,
                                false => 9071,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9072,
                                false => 9073,
                            },
                            false => Waterlogged switch {
                                true => 9074,
                                false => 9075,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9076,
                                false => 9077,
                            },
                            false => Waterlogged switch {
                                true => 9078,
                                false => 9079,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9080,
                                false => 9081,
                            },
                            false => Waterlogged switch {
                                true => 9082,
                                false => 9083,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9084,
                                false => 9085,
                            },
                            false => Waterlogged switch {
                                true => 9086,
                                false => 9087,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9088,
                                false => 9089,
                            },
                            false => Waterlogged switch {
                                true => 9090,
                                false => 9091,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9092,
                                false => 9093,
                            },
                            false => Waterlogged switch {
                                true => 9094,
                                false => 9095,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9096,
                                false => 9097,
                            },
                            false => Waterlogged switch {
                                true => 9098,
                                false => 9099,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9100,
                                false => 9101,
                            },
                            false => Waterlogged switch {
                                true => 9102,
                                false => 9103,
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
            9040 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9041 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9042 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9043 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9044 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9045 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9046 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9047 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9048 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9049 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9050 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9051 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9052 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9053 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9054 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9055 => new AcaciaTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9056 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9057 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9058 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9059 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9060 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9061 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9062 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9063 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9064 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9065 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9066 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9067 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9068 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9069 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9070 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9071 => new AcaciaTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9072 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9073 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9074 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9075 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9076 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9077 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9078 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9079 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9080 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9081 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9082 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9083 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9084 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9085 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9086 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9087 => new AcaciaTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9088 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9089 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9090 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9091 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9092 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9093 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9094 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9095 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9096 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9097 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9098 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9099 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9100 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9101 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9102 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9103 => new AcaciaTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
