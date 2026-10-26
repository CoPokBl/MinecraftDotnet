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
public record DarkOakTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_trapdoor", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_trapdoor", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_trapdoor");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 26, "wood", NoteBlockInstrument.Bass, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 9168];

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
                                true => 9168,
                                false => 9169,
                            },
                            false => Waterlogged switch {
                                true => 9170,
                                false => 9171,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9172,
                                false => 9173,
                            },
                            false => Waterlogged switch {
                                true => 9174,
                                false => 9175,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9176,
                                false => 9177,
                            },
                            false => Waterlogged switch {
                                true => 9178,
                                false => 9179,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9180,
                                false => 9181,
                            },
                            false => Waterlogged switch {
                                true => 9182,
                                false => 9183,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9184,
                                false => 9185,
                            },
                            false => Waterlogged switch {
                                true => 9186,
                                false => 9187,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9188,
                                false => 9189,
                            },
                            false => Waterlogged switch {
                                true => 9190,
                                false => 9191,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9192,
                                false => 9193,
                            },
                            false => Waterlogged switch {
                                true => 9194,
                                false => 9195,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9196,
                                false => 9197,
                            },
                            false => Waterlogged switch {
                                true => 9198,
                                false => 9199,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9200,
                                false => 9201,
                            },
                            false => Waterlogged switch {
                                true => 9202,
                                false => 9203,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9204,
                                false => 9205,
                            },
                            false => Waterlogged switch {
                                true => 9206,
                                false => 9207,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9208,
                                false => 9209,
                            },
                            false => Waterlogged switch {
                                true => 9210,
                                false => 9211,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9212,
                                false => 9213,
                            },
                            false => Waterlogged switch {
                                true => 9214,
                                false => 9215,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9216,
                                false => 9217,
                            },
                            false => Waterlogged switch {
                                true => 9218,
                                false => 9219,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9220,
                                false => 9221,
                            },
                            false => Waterlogged switch {
                                true => 9222,
                                false => 9223,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 9224,
                                false => 9225,
                            },
                            false => Waterlogged switch {
                                true => 9226,
                                false => 9227,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 9228,
                                false => 9229,
                            },
                            false => Waterlogged switch {
                                true => 9230,
                                false => 9231,
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
            9168 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            9169 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            9170 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            9171 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            9172 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            9173 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            9174 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            9175 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            9176 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            9177 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            9178 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            9179 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            9180 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            9181 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            9182 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            9183 => new DarkOakTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            9184 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            9185 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            9186 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            9187 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            9188 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            9189 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            9190 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            9191 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            9192 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            9193 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            9194 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            9195 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            9196 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            9197 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            9198 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            9199 => new DarkOakTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            9200 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            9201 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            9202 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            9203 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            9204 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            9205 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            9206 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            9207 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            9208 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            9209 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            9210 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            9211 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            9212 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            9213 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            9214 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            9215 => new DarkOakTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            9216 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            9217 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            9218 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            9219 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            9220 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            9221 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            9222 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            9223 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            9224 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            9225 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            9226 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            9227 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            9228 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            9229 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            9230 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            9231 => new DarkOakTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
