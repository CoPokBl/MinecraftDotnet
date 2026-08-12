using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.acacia_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 15, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { CollisionShape = BlockShapes.S40, VisualShape = BlockShapes.S40 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S39, OcclusionShape = BlockShapes.S70 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S70, VisualShape = BlockShapes.S40 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S71, OcclusionShape = BlockShapes.S72 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S71, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S72, VisualShape = BlockShapes.S49 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S48, OcclusionShape = BlockShapes.S73 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S73, VisualShape = BlockShapes.S49 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3, I0, I0, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I7, I7, I4, I4, I5, I5, I6, I6, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 13580];

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
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13580,
                            false => 13581,
                        },
                        false => Powered switch {
                            true => 13582,
                            false => 13583,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13584,
                            false => 13585,
                        },
                        false => Powered switch {
                            true => 13586,
                            false => 13587,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13588,
                            false => 13589,
                        },
                        false => Powered switch {
                            true => 13590,
                            false => 13591,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13592,
                            false => 13593,
                        },
                        false => Powered switch {
                            true => 13594,
                            false => 13595,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13596,
                            false => 13597,
                        },
                        false => Powered switch {
                            true => 13598,
                            false => 13599,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13600,
                            false => 13601,
                        },
                        false => Powered switch {
                            true => 13602,
                            false => 13603,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13604,
                            false => 13605,
                        },
                        false => Powered switch {
                            true => 13606,
                            false => 13607,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13608,
                            false => 13609,
                        },
                        false => Powered switch {
                            true => 13610,
                            false => 13611,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13580 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, true),
            13581 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, false),
            13582 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, true),
            13583 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, false),
            13584 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, true),
            13585 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, false),
            13586 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, true),
            13587 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, false),
            13588 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, true),
            13589 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, false),
            13590 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, true),
            13591 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, false),
            13592 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, true),
            13593 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, false),
            13594 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, true),
            13595 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, false),
            13596 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, true),
            13597 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, false),
            13598 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, true),
            13599 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, false),
            13600 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, true),
            13601 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, false),
            13602 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, true),
            13603 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, false),
            13604 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, true),
            13605 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, false),
            13606 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, true),
            13607 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, false),
            13608 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, true),
            13609 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, false),
            13610 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, true),
            13611 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.Contains("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("in_wall", new StringTag(InWall.ToString().ToLower())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
