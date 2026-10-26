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
public record OakHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock, IAttached, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_hanging_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hanging_sign", "minecraft:oak_hanging_sign", BlockInfo.VanillaOnly, "minecraft:blocks/oak_hanging_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 13, "hanging_sign", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S76, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S76);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S78, SupportShape = BlockShapes.S78 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3, I0, I1, I2, I3, I2, I3, I2, I3, I4, I5, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 7503];

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7503,
                        false => 7504,
                    },
                    1 => Waterlogged switch {
                        true => 7505,
                        false => 7506,
                    },
                    2 => Waterlogged switch {
                        true => 7507,
                        false => 7508,
                    },
                    3 => Waterlogged switch {
                        true => 7509,
                        false => 7510,
                    },
                    4 => Waterlogged switch {
                        true => 7511,
                        false => 7512,
                    },
                    5 => Waterlogged switch {
                        true => 7513,
                        false => 7514,
                    },
                    6 => Waterlogged switch {
                        true => 7515,
                        false => 7516,
                    },
                    7 => Waterlogged switch {
                        true => 7517,
                        false => 7518,
                    },
                    8 => Waterlogged switch {
                        true => 7519,
                        false => 7520,
                    },
                    9 => Waterlogged switch {
                        true => 7521,
                        false => 7522,
                    },
                    10 => Waterlogged switch {
                        true => 7523,
                        false => 7524,
                    },
                    11 => Waterlogged switch {
                        true => 7525,
                        false => 7526,
                    },
                    12 => Waterlogged switch {
                        true => 7527,
                        false => 7528,
                    },
                    13 => Waterlogged switch {
                        true => 7529,
                        false => 7530,
                    },
                    14 => Waterlogged switch {
                        true => 7531,
                        false => 7532,
                    },
                    15 => Waterlogged switch {
                        true => 7533,
                        false => 7534,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 7535,
                        false => 7536,
                    },
                    1 => Waterlogged switch {
                        true => 7537,
                        false => 7538,
                    },
                    2 => Waterlogged switch {
                        true => 7539,
                        false => 7540,
                    },
                    3 => Waterlogged switch {
                        true => 7541,
                        false => 7542,
                    },
                    4 => Waterlogged switch {
                        true => 7543,
                        false => 7544,
                    },
                    5 => Waterlogged switch {
                        true => 7545,
                        false => 7546,
                    },
                    6 => Waterlogged switch {
                        true => 7547,
                        false => 7548,
                    },
                    7 => Waterlogged switch {
                        true => 7549,
                        false => 7550,
                    },
                    8 => Waterlogged switch {
                        true => 7551,
                        false => 7552,
                    },
                    9 => Waterlogged switch {
                        true => 7553,
                        false => 7554,
                    },
                    10 => Waterlogged switch {
                        true => 7555,
                        false => 7556,
                    },
                    11 => Waterlogged switch {
                        true => 7557,
                        false => 7558,
                    },
                    12 => Waterlogged switch {
                        true => 7559,
                        false => 7560,
                    },
                    13 => Waterlogged switch {
                        true => 7561,
                        false => 7562,
                    },
                    14 => Waterlogged switch {
                        true => 7563,
                        false => 7564,
                    },
                    15 => Waterlogged switch {
                        true => 7565,
                        false => 7566,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7503 => new OakHangingSignBlock(Identifier, true, 0, true),
            7504 => new OakHangingSignBlock(Identifier, true, 0, false),
            7505 => new OakHangingSignBlock(Identifier, true, 1, true),
            7506 => new OakHangingSignBlock(Identifier, true, 1, false),
            7507 => new OakHangingSignBlock(Identifier, true, 2, true),
            7508 => new OakHangingSignBlock(Identifier, true, 2, false),
            7509 => new OakHangingSignBlock(Identifier, true, 3, true),
            7510 => new OakHangingSignBlock(Identifier, true, 3, false),
            7511 => new OakHangingSignBlock(Identifier, true, 4, true),
            7512 => new OakHangingSignBlock(Identifier, true, 4, false),
            7513 => new OakHangingSignBlock(Identifier, true, 5, true),
            7514 => new OakHangingSignBlock(Identifier, true, 5, false),
            7515 => new OakHangingSignBlock(Identifier, true, 6, true),
            7516 => new OakHangingSignBlock(Identifier, true, 6, false),
            7517 => new OakHangingSignBlock(Identifier, true, 7, true),
            7518 => new OakHangingSignBlock(Identifier, true, 7, false),
            7519 => new OakHangingSignBlock(Identifier, true, 8, true),
            7520 => new OakHangingSignBlock(Identifier, true, 8, false),
            7521 => new OakHangingSignBlock(Identifier, true, 9, true),
            7522 => new OakHangingSignBlock(Identifier, true, 9, false),
            7523 => new OakHangingSignBlock(Identifier, true, 10, true),
            7524 => new OakHangingSignBlock(Identifier, true, 10, false),
            7525 => new OakHangingSignBlock(Identifier, true, 11, true),
            7526 => new OakHangingSignBlock(Identifier, true, 11, false),
            7527 => new OakHangingSignBlock(Identifier, true, 12, true),
            7528 => new OakHangingSignBlock(Identifier, true, 12, false),
            7529 => new OakHangingSignBlock(Identifier, true, 13, true),
            7530 => new OakHangingSignBlock(Identifier, true, 13, false),
            7531 => new OakHangingSignBlock(Identifier, true, 14, true),
            7532 => new OakHangingSignBlock(Identifier, true, 14, false),
            7533 => new OakHangingSignBlock(Identifier, true, 15, true),
            7534 => new OakHangingSignBlock(Identifier, true, 15, false),
            7535 => new OakHangingSignBlock(Identifier, false, 0, true),
            7536 => new OakHangingSignBlock(Identifier, false, 0, false),
            7537 => new OakHangingSignBlock(Identifier, false, 1, true),
            7538 => new OakHangingSignBlock(Identifier, false, 1, false),
            7539 => new OakHangingSignBlock(Identifier, false, 2, true),
            7540 => new OakHangingSignBlock(Identifier, false, 2, false),
            7541 => new OakHangingSignBlock(Identifier, false, 3, true),
            7542 => new OakHangingSignBlock(Identifier, false, 3, false),
            7543 => new OakHangingSignBlock(Identifier, false, 4, true),
            7544 => new OakHangingSignBlock(Identifier, false, 4, false),
            7545 => new OakHangingSignBlock(Identifier, false, 5, true),
            7546 => new OakHangingSignBlock(Identifier, false, 5, false),
            7547 => new OakHangingSignBlock(Identifier, false, 6, true),
            7548 => new OakHangingSignBlock(Identifier, false, 6, false),
            7549 => new OakHangingSignBlock(Identifier, false, 7, true),
            7550 => new OakHangingSignBlock(Identifier, false, 7, false),
            7551 => new OakHangingSignBlock(Identifier, false, 8, true),
            7552 => new OakHangingSignBlock(Identifier, false, 8, false),
            7553 => new OakHangingSignBlock(Identifier, false, 9, true),
            7554 => new OakHangingSignBlock(Identifier, false, 9, false),
            7555 => new OakHangingSignBlock(Identifier, false, 10, true),
            7556 => new OakHangingSignBlock(Identifier, false, 10, false),
            7557 => new OakHangingSignBlock(Identifier, false, 11, true),
            7558 => new OakHangingSignBlock(Identifier, false, 11, false),
            7559 => new OakHangingSignBlock(Identifier, false, 12, true),
            7560 => new OakHangingSignBlock(Identifier, false, 12, false),
            7561 => new OakHangingSignBlock(Identifier, false, 13, true),
            7562 => new OakHangingSignBlock(Identifier, false, 13, false),
            7563 => new OakHangingSignBlock(Identifier, false, 14, true),
            7564 => new OakHangingSignBlock(Identifier, false, 14, false),
            7565 => new OakHangingSignBlock(Identifier, false, 15, true),
            7566 => new OakHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
