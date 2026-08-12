using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BirchTrapdoorBlock(Identifier Identifier, Direction Facing, BirchTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:trapdoor", "block.minecraft.birch_trapdoor", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 2, "wood", NoteBlockInstrument.Bass, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 7242];

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
                                true => 7242,
                                false => 7243,
                            },
                            false => Waterlogged switch {
                                true => 7244,
                                false => 7245,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7246,
                                false => 7247,
                            },
                            false => Waterlogged switch {
                                true => 7248,
                                false => 7249,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7250,
                                false => 7251,
                            },
                            false => Waterlogged switch {
                                true => 7252,
                                false => 7253,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7254,
                                false => 7255,
                            },
                            false => Waterlogged switch {
                                true => 7256,
                                false => 7257,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7258,
                                false => 7259,
                            },
                            false => Waterlogged switch {
                                true => 7260,
                                false => 7261,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7262,
                                false => 7263,
                            },
                            false => Waterlogged switch {
                                true => 7264,
                                false => 7265,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7266,
                                false => 7267,
                            },
                            false => Waterlogged switch {
                                true => 7268,
                                false => 7269,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7270,
                                false => 7271,
                            },
                            false => Waterlogged switch {
                                true => 7272,
                                false => 7273,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7274,
                                false => 7275,
                            },
                            false => Waterlogged switch {
                                true => 7276,
                                false => 7277,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7278,
                                false => 7279,
                            },
                            false => Waterlogged switch {
                                true => 7280,
                                false => 7281,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7282,
                                false => 7283,
                            },
                            false => Waterlogged switch {
                                true => 7284,
                                false => 7285,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7286,
                                false => 7287,
                            },
                            false => Waterlogged switch {
                                true => 7288,
                                false => 7289,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7290,
                                false => 7291,
                            },
                            false => Waterlogged switch {
                                true => 7292,
                                false => 7293,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7294,
                                false => 7295,
                            },
                            false => Waterlogged switch {
                                true => 7296,
                                false => 7297,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 7298,
                                false => 7299,
                            },
                            false => Waterlogged switch {
                                true => 7300,
                                false => 7301,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 7302,
                                false => 7303,
                            },
                            false => Waterlogged switch {
                                true => 7304,
                                false => 7305,
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
            7242 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            7243 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            7244 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            7245 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            7246 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            7247 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            7248 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            7249 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            7250 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            7251 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            7252 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            7253 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            7254 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            7255 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            7256 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            7257 => new BirchTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            7258 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            7259 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            7260 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            7261 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            7262 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            7263 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            7264 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            7265 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            7266 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            7267 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            7268 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            7269 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            7270 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            7271 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            7272 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            7273 => new BirchTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            7274 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            7275 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            7276 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            7277 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            7278 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            7279 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            7280 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            7281 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            7282 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            7283 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            7284 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            7285 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            7286 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            7287 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            7288 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            7289 => new BirchTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            7290 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            7291 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            7292 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            7293 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            7294 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            7295 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            7296 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            7297 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            7298 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            7299 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            7300 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            7301 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            7302 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            7303 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            7304 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            7305 => new BirchTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
