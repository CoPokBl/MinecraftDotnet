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
public record CrimsonTrapdoorBlock(Identifier Identifier, Direction Facing, TopBottom Half, bool Open, bool Powered, bool Waterlogged) : IBlock, IHorizontalFacing, IHalved, IOpenable, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.crimson_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 53, "nether_wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 21114];

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
                                true => 21114,
                                false => 21115,
                            },
                            false => Waterlogged switch {
                                true => 21116,
                                false => 21117,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21118,
                                false => 21119,
                            },
                            false => Waterlogged switch {
                                true => 21120,
                                false => 21121,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21122,
                                false => 21123,
                            },
                            false => Waterlogged switch {
                                true => 21124,
                                false => 21125,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21126,
                                false => 21127,
                            },
                            false => Waterlogged switch {
                                true => 21128,
                                false => 21129,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21130,
                                false => 21131,
                            },
                            false => Waterlogged switch {
                                true => 21132,
                                false => 21133,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21134,
                                false => 21135,
                            },
                            false => Waterlogged switch {
                                true => 21136,
                                false => 21137,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21138,
                                false => 21139,
                            },
                            false => Waterlogged switch {
                                true => 21140,
                                false => 21141,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21142,
                                false => 21143,
                            },
                            false => Waterlogged switch {
                                true => 21144,
                                false => 21145,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21146,
                                false => 21147,
                            },
                            false => Waterlogged switch {
                                true => 21148,
                                false => 21149,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21150,
                                false => 21151,
                            },
                            false => Waterlogged switch {
                                true => 21152,
                                false => 21153,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21154,
                                false => 21155,
                            },
                            false => Waterlogged switch {
                                true => 21156,
                                false => 21157,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21158,
                                false => 21159,
                            },
                            false => Waterlogged switch {
                                true => 21160,
                                false => 21161,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    TopBottom.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21162,
                                false => 21163,
                            },
                            false => Waterlogged switch {
                                true => 21164,
                                false => 21165,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21166,
                                false => 21167,
                            },
                            false => Waterlogged switch {
                                true => 21168,
                                false => 21169,
                            },
                        },
                    },
                    TopBottom.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 21170,
                                false => 21171,
                            },
                            false => Waterlogged switch {
                                true => 21172,
                                false => 21173,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 21174,
                                false => 21175,
                            },
                            false => Waterlogged switch {
                                true => 21176,
                                false => 21177,
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
            21114 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, true),
            21115 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, true, false),
            21116 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, true),
            21117 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, true, false, false),
            21118 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, true),
            21119 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, true, false),
            21120 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, true),
            21121 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Top, false, false, false),
            21122 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, true),
            21123 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, true, false),
            21124 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, true),
            21125 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, true, false, false),
            21126 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, true),
            21127 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, true, false),
            21128 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, true),
            21129 => new CrimsonTrapdoorBlock(Identifier, Direction.North, TopBottom.Bottom, false, false, false),
            21130 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, true),
            21131 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, true, false),
            21132 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, true),
            21133 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, true, false, false),
            21134 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, true),
            21135 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, true, false),
            21136 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, true),
            21137 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Top, false, false, false),
            21138 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, true),
            21139 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, true, false),
            21140 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, true),
            21141 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, true, false, false),
            21142 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, true),
            21143 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, true, false),
            21144 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, true),
            21145 => new CrimsonTrapdoorBlock(Identifier, Direction.South, TopBottom.Bottom, false, false, false),
            21146 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, true),
            21147 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, true, false),
            21148 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, true),
            21149 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, true, false, false),
            21150 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, true),
            21151 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, true, false),
            21152 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, true),
            21153 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Top, false, false, false),
            21154 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, true),
            21155 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, true, false),
            21156 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, true),
            21157 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, true, false, false),
            21158 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, true),
            21159 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, true, false),
            21160 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, true),
            21161 => new CrimsonTrapdoorBlock(Identifier, Direction.West, TopBottom.Bottom, false, false, false),
            21162 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, true),
            21163 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, true, false),
            21164 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, true),
            21165 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, true, false, false),
            21166 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, true),
            21167 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, true, false),
            21168 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, true),
            21169 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Top, false, false, false),
            21170 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, true),
            21171 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, true, false),
            21172 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, true),
            21173 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, true, false, false),
            21174 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, true),
            21175 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, true, false),
            21176 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, true),
            21177 => new CrimsonTrapdoorBlock(Identifier, Direction.East, TopBottom.Bottom, false, false, false),
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
