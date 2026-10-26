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
public record BirchTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.birch_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/birch_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 2, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 8912];

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
                                true => 8912,
                                false => 8913,
                            },
                            false => Waterlogged switch {
                                true => 8914,
                                false => 8915,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8916,
                                false => 8917,
                            },
                            false => Waterlogged switch {
                                true => 8918,
                                false => 8919,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8920,
                                false => 8921,
                            },
                            false => Waterlogged switch {
                                true => 8922,
                                false => 8923,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8924,
                                false => 8925,
                            },
                            false => Waterlogged switch {
                                true => 8926,
                                false => 8927,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8928,
                                false => 8929,
                            },
                            false => Waterlogged switch {
                                true => 8930,
                                false => 8931,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8932,
                                false => 8933,
                            },
                            false => Waterlogged switch {
                                true => 8934,
                                false => 8935,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8936,
                                false => 8937,
                            },
                            false => Waterlogged switch {
                                true => 8938,
                                false => 8939,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8940,
                                false => 8941,
                            },
                            false => Waterlogged switch {
                                true => 8942,
                                false => 8943,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8944,
                                false => 8945,
                            },
                            false => Waterlogged switch {
                                true => 8946,
                                false => 8947,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8948,
                                false => 8949,
                            },
                            false => Waterlogged switch {
                                true => 8950,
                                false => 8951,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8952,
                                false => 8953,
                            },
                            false => Waterlogged switch {
                                true => 8954,
                                false => 8955,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8956,
                                false => 8957,
                            },
                            false => Waterlogged switch {
                                true => 8958,
                                false => 8959,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8960,
                                false => 8961,
                            },
                            false => Waterlogged switch {
                                true => 8962,
                                false => 8963,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8964,
                                false => 8965,
                            },
                            false => Waterlogged switch {
                                true => 8966,
                                false => 8967,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 8968,
                                false => 8969,
                            },
                            false => Waterlogged switch {
                                true => 8970,
                                false => 8971,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 8972,
                                false => 8973,
                            },
                            false => Waterlogged switch {
                                true => 8974,
                                false => 8975,
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
            8912 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            8913 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            8914 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            8915 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            8916 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            8917 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            8918 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            8919 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            8920 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            8921 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            8922 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            8923 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            8924 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            8925 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            8926 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            8927 => new BirchTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            8928 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            8929 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            8930 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            8931 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            8932 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            8933 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            8934 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            8935 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            8936 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            8937 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            8938 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            8939 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            8940 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            8941 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            8942 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            8943 => new BirchTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            8944 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            8945 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            8946 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            8947 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            8948 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            8949 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            8950 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            8951 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            8952 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            8953 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            8954 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            8955 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            8956 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            8957 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            8958 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            8959 => new BirchTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            8960 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            8961 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            8962 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            8963 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            8964 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            8965 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            8966 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            8967 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            8968 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            8969 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            8970 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            8971 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            8972 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            8973 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            8974 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            8975 => new BirchTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
