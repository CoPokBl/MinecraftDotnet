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
public record CherryTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 36, "cherry_wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9104];

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
                                true => 9104,
                                false => 9105,
                            },
                            false => Waterlogged switch {
                                true => 9106,
                                false => 9107,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9108,
                                false => 9109,
                            },
                            false => Waterlogged switch {
                                true => 9110,
                                false => 9111,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9112,
                                false => 9113,
                            },
                            false => Waterlogged switch {
                                true => 9114,
                                false => 9115,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9116,
                                false => 9117,
                            },
                            false => Waterlogged switch {
                                true => 9118,
                                false => 9119,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9120,
                                false => 9121,
                            },
                            false => Waterlogged switch {
                                true => 9122,
                                false => 9123,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9124,
                                false => 9125,
                            },
                            false => Waterlogged switch {
                                true => 9126,
                                false => 9127,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9128,
                                false => 9129,
                            },
                            false => Waterlogged switch {
                                true => 9130,
                                false => 9131,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9132,
                                false => 9133,
                            },
                            false => Waterlogged switch {
                                true => 9134,
                                false => 9135,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9136,
                                false => 9137,
                            },
                            false => Waterlogged switch {
                                true => 9138,
                                false => 9139,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9140,
                                false => 9141,
                            },
                            false => Waterlogged switch {
                                true => 9142,
                                false => 9143,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9144,
                                false => 9145,
                            },
                            false => Waterlogged switch {
                                true => 9146,
                                false => 9147,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9148,
                                false => 9149,
                            },
                            false => Waterlogged switch {
                                true => 9150,
                                false => 9151,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9152,
                                false => 9153,
                            },
                            false => Waterlogged switch {
                                true => 9154,
                                false => 9155,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9156,
                                false => 9157,
                            },
                            false => Waterlogged switch {
                                true => 9158,
                                false => 9159,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9160,
                                false => 9161,
                            },
                            false => Waterlogged switch {
                                true => 9162,
                                false => 9163,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9164,
                                false => 9165,
                            },
                            false => Waterlogged switch {
                                true => 9166,
                                false => 9167,
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
            9104 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9105 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9106 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9107 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9108 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9109 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9110 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9111 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9112 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9113 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9114 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9115 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9116 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9117 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9118 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9119 => new CherryTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9120 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9121 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9122 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9123 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9124 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9125 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9126 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9127 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9128 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9129 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9130 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9131 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9132 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9133 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9134 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9135 => new CherryTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9136 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9137 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9138 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9139 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9140 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9141 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9142 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9143 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9144 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9145 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9146 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9147 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9148 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9149 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9150 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9151 => new CherryTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9152 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9153 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9154 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9155 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9156 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9157 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9158 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9159 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9160 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9161 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9162 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9163 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9164 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9165 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9166 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9167 => new CherryTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
