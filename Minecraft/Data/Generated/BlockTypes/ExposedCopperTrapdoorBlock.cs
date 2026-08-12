using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperTrapdoorBlock(Identifier Identifier, Direction Facing, ExposedCopperTrapdoorBlock.Half HalfValue, bool Open, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_trapdoor", "block.minecraft.exposed_copper_trapdoor", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_copper_trapdoor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 44, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S18, BlockShapes.S18, BlockShapes.S1, BlockShapes.S1, BlockShapes.S18);
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

    public BlockStateInfo StateInfo => States[StateId - 29072];

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
                                true => 29072,
                                false => 29073,
                            },
                            false => Waterlogged switch {
                                true => 29074,
                                false => 29075,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29076,
                                false => 29077,
                            },
                            false => Waterlogged switch {
                                true => 29078,
                                false => 29079,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29080,
                                false => 29081,
                            },
                            false => Waterlogged switch {
                                true => 29082,
                                false => 29083,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29084,
                                false => 29085,
                            },
                            false => Waterlogged switch {
                                true => 29086,
                                false => 29087,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.South => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29088,
                                false => 29089,
                            },
                            false => Waterlogged switch {
                                true => 29090,
                                false => 29091,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29092,
                                false => 29093,
                            },
                            false => Waterlogged switch {
                                true => 29094,
                                false => 29095,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29096,
                                false => 29097,
                            },
                            false => Waterlogged switch {
                                true => 29098,
                                false => 29099,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29100,
                                false => 29101,
                            },
                            false => Waterlogged switch {
                                true => 29102,
                                false => 29103,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.West => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29104,
                                false => 29105,
                            },
                            false => Waterlogged switch {
                                true => 29106,
                                false => 29107,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29108,
                                false => 29109,
                            },
                            false => Waterlogged switch {
                                true => 29110,
                                false => 29111,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29112,
                                false => 29113,
                            },
                            false => Waterlogged switch {
                                true => 29114,
                                false => 29115,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29116,
                                false => 29117,
                            },
                            false => Waterlogged switch {
                                true => 29118,
                                false => 29119,
                            },
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(HalfValue), HalfValue, "Unknown value for property half.")
                },
                Direction.East => HalfValue switch {
                    Half.Top => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29120,
                                false => 29121,
                            },
                            false => Waterlogged switch {
                                true => 29122,
                                false => 29123,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29124,
                                false => 29125,
                            },
                            false => Waterlogged switch {
                                true => 29126,
                                false => 29127,
                            },
                        },
                    },
                    Half.Bottom => Open switch {
                        true => Powered switch {
                            true => Waterlogged switch {
                                true => 29128,
                                false => 29129,
                            },
                            false => Waterlogged switch {
                                true => 29130,
                                false => 29131,
                            },
                        },
                        false => Powered switch {
                            true => Waterlogged switch {
                                true => 29132,
                                false => 29133,
                            },
                            false => Waterlogged switch {
                                true => 29134,
                                false => 29135,
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
            29072 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, true),
            29073 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, true, false),
            29074 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, true),
            29075 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, true, false, false),
            29076 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, true),
            29077 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, true, false),
            29078 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, true),
            29079 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Top, false, false, false),
            29080 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, true),
            29081 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, true, false),
            29082 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, true),
            29083 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, true, false, false),
            29084 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, true),
            29085 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, true, false),
            29086 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, true),
            29087 => new ExposedCopperTrapdoorBlock(Identifier, Direction.North, Half.Bottom, false, false, false),
            29088 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, true),
            29089 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, true, false),
            29090 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, true),
            29091 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, true, false, false),
            29092 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, true),
            29093 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, true, false),
            29094 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, true),
            29095 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Top, false, false, false),
            29096 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, true),
            29097 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, true, false),
            29098 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, true),
            29099 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, true, false, false),
            29100 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, true),
            29101 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, true, false),
            29102 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, true),
            29103 => new ExposedCopperTrapdoorBlock(Identifier, Direction.South, Half.Bottom, false, false, false),
            29104 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, true),
            29105 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, true, false),
            29106 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, true),
            29107 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, true, false, false),
            29108 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, true),
            29109 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, true, false),
            29110 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, true),
            29111 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Top, false, false, false),
            29112 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, true),
            29113 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, true, false),
            29114 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, true),
            29115 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, true, false, false),
            29116 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, true),
            29117 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, true, false),
            29118 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, true),
            29119 => new ExposedCopperTrapdoorBlock(Identifier, Direction.West, Half.Bottom, false, false, false),
            29120 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, true),
            29121 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, true, false),
            29122 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, true),
            29123 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, true, false, false),
            29124 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, true),
            29125 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, true, false),
            29126 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, true),
            29127 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Top, false, false, false),
            29128 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, true),
            29129 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, true, false),
            29130 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, true),
            29131 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, true, false, false),
            29132 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, true),
            29133 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, true, false),
            29134 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, true),
            29135 => new ExposedCopperTrapdoorBlock(Identifier, Direction.East, Half.Bottom, false, false, false),
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
