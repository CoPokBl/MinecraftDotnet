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
public record MangrovePropaguleBlock(Identifier Identifier, int Age, bool Hanging, int Stage, bool Waterlogged) : IBlock, IAged, IHanging, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_propagule", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.Xz, 0.25f, 0f, null, "minecraft:mangrove_propagule", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_propagule") { ShapeOffsets = BlockShapeOffsets.Block };
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 7, "grass", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S640, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S387 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S387 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S641 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S641 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S642 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S642 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S643 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S643 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I2, I3, I2, I3, I6, I7, I6, I7, I2, I3, I2, I3, I8, I9, I8, I9, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 46];

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

    public IBlock WithAge(int age) => this with { Age = age };

    public IBlock WithHanging(bool hanging) => this with { Hanging = hanging };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Age switch {
                0 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 46,
                            false => 47,
                        },
                        1 => Waterlogged switch {
                            true => 48,
                            false => 49,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 50,
                            false => 51,
                        },
                        1 => Waterlogged switch {
                            true => 52,
                            false => 53,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                1 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 54,
                            false => 55,
                        },
                        1 => Waterlogged switch {
                            true => 56,
                            false => 57,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 58,
                            false => 59,
                        },
                        1 => Waterlogged switch {
                            true => 60,
                            false => 61,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                2 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 62,
                            false => 63,
                        },
                        1 => Waterlogged switch {
                            true => 64,
                            false => 65,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 66,
                            false => 67,
                        },
                        1 => Waterlogged switch {
                            true => 68,
                            false => 69,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                3 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 70,
                            false => 71,
                        },
                        1 => Waterlogged switch {
                            true => 72,
                            false => 73,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 74,
                            false => 75,
                        },
                        1 => Waterlogged switch {
                            true => 76,
                            false => 77,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                },
                4 => Hanging switch {
                    true => Stage switch {
                        0 => Waterlogged switch {
                            true => 78,
                            false => 79,
                        },
                        1 => Waterlogged switch {
                            true => 80,
                            false => 81,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    false => Stage switch {
                        0 => Waterlogged switch {
                            true => 82,
                            false => 83,
                        },
                        1 => Waterlogged switch {
                            true => 84,
                            false => 85,
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
            46 => new MangrovePropaguleBlock(Identifier, 0, true, 0, true),
            47 => new MangrovePropaguleBlock(Identifier, 0, true, 0, false),
            48 => new MangrovePropaguleBlock(Identifier, 0, true, 1, true),
            49 => new MangrovePropaguleBlock(Identifier, 0, true, 1, false),
            50 => new MangrovePropaguleBlock(Identifier, 0, false, 0, true),
            51 => new MangrovePropaguleBlock(Identifier, 0, false, 0, false),
            52 => new MangrovePropaguleBlock(Identifier, 0, false, 1, true),
            53 => new MangrovePropaguleBlock(Identifier, 0, false, 1, false),
            54 => new MangrovePropaguleBlock(Identifier, 1, true, 0, true),
            55 => new MangrovePropaguleBlock(Identifier, 1, true, 0, false),
            56 => new MangrovePropaguleBlock(Identifier, 1, true, 1, true),
            57 => new MangrovePropaguleBlock(Identifier, 1, true, 1, false),
            58 => new MangrovePropaguleBlock(Identifier, 1, false, 0, true),
            59 => new MangrovePropaguleBlock(Identifier, 1, false, 0, false),
            60 => new MangrovePropaguleBlock(Identifier, 1, false, 1, true),
            61 => new MangrovePropaguleBlock(Identifier, 1, false, 1, false),
            62 => new MangrovePropaguleBlock(Identifier, 2, true, 0, true),
            63 => new MangrovePropaguleBlock(Identifier, 2, true, 0, false),
            64 => new MangrovePropaguleBlock(Identifier, 2, true, 1, true),
            65 => new MangrovePropaguleBlock(Identifier, 2, true, 1, false),
            66 => new MangrovePropaguleBlock(Identifier, 2, false, 0, true),
            67 => new MangrovePropaguleBlock(Identifier, 2, false, 0, false),
            68 => new MangrovePropaguleBlock(Identifier, 2, false, 1, true),
            69 => new MangrovePropaguleBlock(Identifier, 2, false, 1, false),
            70 => new MangrovePropaguleBlock(Identifier, 3, true, 0, true),
            71 => new MangrovePropaguleBlock(Identifier, 3, true, 0, false),
            72 => new MangrovePropaguleBlock(Identifier, 3, true, 1, true),
            73 => new MangrovePropaguleBlock(Identifier, 3, true, 1, false),
            74 => new MangrovePropaguleBlock(Identifier, 3, false, 0, true),
            75 => new MangrovePropaguleBlock(Identifier, 3, false, 0, false),
            76 => new MangrovePropaguleBlock(Identifier, 3, false, 1, true),
            77 => new MangrovePropaguleBlock(Identifier, 3, false, 1, false),
            78 => new MangrovePropaguleBlock(Identifier, 4, true, 0, true),
            79 => new MangrovePropaguleBlock(Identifier, 4, true, 0, false),
            80 => new MangrovePropaguleBlock(Identifier, 4, true, 1, true),
            81 => new MangrovePropaguleBlock(Identifier, 4, true, 1, false),
            82 => new MangrovePropaguleBlock(Identifier, 4, false, 0, true),
            83 => new MangrovePropaguleBlock(Identifier, 4, false, 0, false),
            84 => new MangrovePropaguleBlock(Identifier, 4, false, 1, true),
            85 => new MangrovePropaguleBlock(Identifier, 4, false, 1, false),
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
