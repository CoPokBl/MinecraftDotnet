using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangrovePropaguleBlock(Identifier Identifier, int Age, bool Hanging, int Stage, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:mangrove_propagule", "block.minecraft.mangrove_propagule", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.Xz, 0.25f, 0f, null, "minecraft:mangrove_propagule", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 7, "grass", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S637, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S385 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S385 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S638 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S638 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S639 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S639 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S640 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S640 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I2, I3, I2, I3, I6, I7, I6, I7, I2, I3, I2, I3, I8, I9, I8, I9, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 45];

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
            return Age switch {
                0 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 45,
                            false => 46,
                        },
                        1 => Waterlogged switch {
                            true => 47,
                            false => 48,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 49,
                            false => 50,
                        },
                        1 => Waterlogged switch {
                            true => 51,
                            false => 52,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                1 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 53,
                            false => 54,
                        },
                        1 => Waterlogged switch {
                            true => 55,
                            false => 56,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 57,
                            false => 58,
                        },
                        1 => Waterlogged switch {
                            true => 59,
                            false => 60,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                2 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 61,
                            false => 62,
                        },
                        1 => Waterlogged switch {
                            true => 63,
                            false => 64,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 65,
                            false => 66,
                        },
                        1 => Waterlogged switch {
                            true => 67,
                            false => 68,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                3 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 69,
                            false => 70,
                        },
                        1 => Waterlogged switch {
                            true => 71,
                            false => 72,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 73,
                            false => 74,
                        },
                        1 => Waterlogged switch {
                            true => 75,
                            false => 76,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                4 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 77,
                            false => 78,
                        },
                        1 => Waterlogged switch {
                            true => 79,
                            false => 80,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 81,
                            false => 82,
                        },
                        1 => Waterlogged switch {
                            true => 83,
                            false => 84,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            45 => new MangrovePropaguleBlock(Identifier, 0, true, 0, true),
            46 => new MangrovePropaguleBlock(Identifier, 0, true, 0, false),
            47 => new MangrovePropaguleBlock(Identifier, 0, true, 1, true),
            48 => new MangrovePropaguleBlock(Identifier, 0, true, 1, false),
            49 => new MangrovePropaguleBlock(Identifier, 0, false, 0, true),
            50 => new MangrovePropaguleBlock(Identifier, 0, false, 0, false),
            51 => new MangrovePropaguleBlock(Identifier, 0, false, 1, true),
            52 => new MangrovePropaguleBlock(Identifier, 0, false, 1, false),
            53 => new MangrovePropaguleBlock(Identifier, 1, true, 0, true),
            54 => new MangrovePropaguleBlock(Identifier, 1, true, 0, false),
            55 => new MangrovePropaguleBlock(Identifier, 1, true, 1, true),
            56 => new MangrovePropaguleBlock(Identifier, 1, true, 1, false),
            57 => new MangrovePropaguleBlock(Identifier, 1, false, 0, true),
            58 => new MangrovePropaguleBlock(Identifier, 1, false, 0, false),
            59 => new MangrovePropaguleBlock(Identifier, 1, false, 1, true),
            60 => new MangrovePropaguleBlock(Identifier, 1, false, 1, false),
            61 => new MangrovePropaguleBlock(Identifier, 2, true, 0, true),
            62 => new MangrovePropaguleBlock(Identifier, 2, true, 0, false),
            63 => new MangrovePropaguleBlock(Identifier, 2, true, 1, true),
            64 => new MangrovePropaguleBlock(Identifier, 2, true, 1, false),
            65 => new MangrovePropaguleBlock(Identifier, 2, false, 0, true),
            66 => new MangrovePropaguleBlock(Identifier, 2, false, 0, false),
            67 => new MangrovePropaguleBlock(Identifier, 2, false, 1, true),
            68 => new MangrovePropaguleBlock(Identifier, 2, false, 1, false),
            69 => new MangrovePropaguleBlock(Identifier, 3, true, 0, true),
            70 => new MangrovePropaguleBlock(Identifier, 3, true, 0, false),
            71 => new MangrovePropaguleBlock(Identifier, 3, true, 1, true),
            72 => new MangrovePropaguleBlock(Identifier, 3, true, 1, false),
            73 => new MangrovePropaguleBlock(Identifier, 3, false, 0, true),
            74 => new MangrovePropaguleBlock(Identifier, 3, false, 0, false),
            75 => new MangrovePropaguleBlock(Identifier, 3, false, 1, true),
            76 => new MangrovePropaguleBlock(Identifier, 3, false, 1, false),
            77 => new MangrovePropaguleBlock(Identifier, 4, true, 0, true),
            78 => new MangrovePropaguleBlock(Identifier, 4, true, 0, false),
            79 => new MangrovePropaguleBlock(Identifier, 4, true, 1, true),
            80 => new MangrovePropaguleBlock(Identifier, 4, true, 1, false),
            81 => new MangrovePropaguleBlock(Identifier, 4, false, 0, true),
            82 => new MangrovePropaguleBlock(Identifier, 4, false, 0, false),
            83 => new MangrovePropaguleBlock(Identifier, 4, false, 1, true),
            84 => new MangrovePropaguleBlock(Identifier, 4, false, 1, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Hanging = properties.Contains("hanging") ? properties["hanging"].GetString() == "true" : Hanging,
            Stage = properties.Contains("stage") ? int.Parse(properties["stage"].GetString()) : Stage,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("hanging", new StringTag(Hanging.ToString().ToLower())),
            ("stage", new StringTag(Stage.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
