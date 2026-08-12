using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonTrapdoorBlock(Identifier Identifier, Direction Facing, CrimsonTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.crimson_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 53, "nether_wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S112, CollisionShape = BlockShapes.S112, VisualShape = BlockShapes.S112 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S113, CollisionShape = BlockShapes.S113, VisualShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S20, CollisionShape = BlockShapes.S20, VisualShape = BlockShapes.S20 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S19, CollisionShape = BlockShapes.S19, VisualShape = BlockShapes.S19 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S17, CollisionShape = BlockShapes.S17, VisualShape = BlockShapes.S17 };
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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
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
                    Half.Bottom => Open switch {
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
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21114 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            21115 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            21116 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            21117 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            21118 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            21119 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            21120 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            21121 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            21122 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            21123 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            21124 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            21125 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            21126 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            21127 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            21128 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            21129 => new CrimsonTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            21130 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            21131 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            21132 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            21133 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            21134 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            21135 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            21136 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            21137 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            21138 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            21139 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            21140 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            21141 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            21142 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            21143 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            21144 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            21145 => new CrimsonTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            21146 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            21147 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            21148 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            21149 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            21150 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            21151 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            21152 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            21153 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            21154 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            21155 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            21156 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            21157 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            21158 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            21159 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            21160 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            21161 => new CrimsonTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            21162 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            21163 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            21164 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            21165 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            21166 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            21167 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            21168 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            21169 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            21170 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            21171 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            21172 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            21173 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            21174 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            21175 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            21176 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            21177 => new CrimsonTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HalfValue = properties.Contains("half") ? HalfFromString(properties["half"].GetString()) : HalfValue,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(HalfToName(HalfValue))),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Half {
        Top,
        Bottom,
    }

    public static Half HalfFromString(string value) {
        return value switch {
            "top" => Half.Top,
            "bottom" => Half.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Half.")
        };
    }

    public static string HalfToName(Half value) {
        return value switch {
            Half.Top => "top",
            Half.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Half value.")
        };
    }
}
