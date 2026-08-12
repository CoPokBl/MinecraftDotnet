using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.mangrove_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 28, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 13708];

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
                            true => 13708,
                            false => 13709,
                        },
                        false => Powered switch {
                            true => 13710,
                            false => 13711,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13712,
                            false => 13713,
                        },
                        false => Powered switch {
                            true => 13714,
                            false => 13715,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13716,
                            false => 13717,
                        },
                        false => Powered switch {
                            true => 13718,
                            false => 13719,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13720,
                            false => 13721,
                        },
                        false => Powered switch {
                            true => 13722,
                            false => 13723,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13724,
                            false => 13725,
                        },
                        false => Powered switch {
                            true => 13726,
                            false => 13727,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13728,
                            false => 13729,
                        },
                        false => Powered switch {
                            true => 13730,
                            false => 13731,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13732,
                            false => 13733,
                        },
                        false => Powered switch {
                            true => 13734,
                            false => 13735,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13736,
                            false => 13737,
                        },
                        false => Powered switch {
                            true => 13738,
                            false => 13739,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13708 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, true),
            13709 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, false),
            13710 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, true),
            13711 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, false),
            13712 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, true),
            13713 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, false),
            13714 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, true),
            13715 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, false),
            13716 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, true),
            13717 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, false),
            13718 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, true),
            13719 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, false),
            13720 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, true),
            13721 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, false),
            13722 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, true),
            13723 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, false),
            13724 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, true),
            13725 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, false),
            13726 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, true),
            13727 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, false),
            13728 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, true),
            13729 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, false),
            13730 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, true),
            13731 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, false),
            13732 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, true),
            13733 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, false),
            13734 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, true),
            13735 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, false),
            13736 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, true),
            13737 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, false),
            13738 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, true),
            13739 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, false),
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
