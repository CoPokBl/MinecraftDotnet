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
public record PoplarFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:poplar_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 22, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { PathfindableLand = false, PathfindableAir = false, CollisionShape = BlockShapes.S40, VisualShape = BlockShapes.S40, SupportShape = BlockShapes.S70 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S39, OcclusionShape = BlockShapes.S71 };
    private static readonly BlockStateInfo I3 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S71, VisualShape = BlockShapes.S40, SupportShape = BlockShapes.S70 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S72, OcclusionShape = BlockShapes.S73 };
    private static readonly BlockStateInfo I5 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S72, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S73, VisualShape = BlockShapes.S49, SupportShape = BlockShapes.S74 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S48, OcclusionShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I7 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S75, VisualShape = BlockShapes.S49, SupportShape = BlockShapes.S74 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3, I0, I0, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I7, I7, I4, I4, I5, I5, I6, I6, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 15587];

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

    public IBlock WithInWall(bool inWall) => this with { InWall = inWall };

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15587,
                            false => 15588,
                        },
                        false => Powered switch {
                            true => 15589,
                            false => 15590,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15591,
                            false => 15592,
                        },
                        false => Powered switch {
                            true => 15593,
                            false => 15594,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15595,
                            false => 15596,
                        },
                        false => Powered switch {
                            true => 15597,
                            false => 15598,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15599,
                            false => 15600,
                        },
                        false => Powered switch {
                            true => 15601,
                            false => 15602,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15603,
                            false => 15604,
                        },
                        false => Powered switch {
                            true => 15605,
                            false => 15606,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15607,
                            false => 15608,
                        },
                        false => Powered switch {
                            true => 15609,
                            false => 15610,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15611,
                            false => 15612,
                        },
                        false => Powered switch {
                            true => 15613,
                            false => 15614,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15615,
                            false => 15616,
                        },
                        false => Powered switch {
                            true => 15617,
                            false => 15618,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15587 => new PoplarFenceGateBlock(Identifier, Direction.North, true, true, true),
            15588 => new PoplarFenceGateBlock(Identifier, Direction.North, true, true, false),
            15589 => new PoplarFenceGateBlock(Identifier, Direction.North, true, false, true),
            15590 => new PoplarFenceGateBlock(Identifier, Direction.North, true, false, false),
            15591 => new PoplarFenceGateBlock(Identifier, Direction.North, false, true, true),
            15592 => new PoplarFenceGateBlock(Identifier, Direction.North, false, true, false),
            15593 => new PoplarFenceGateBlock(Identifier, Direction.North, false, false, true),
            15594 => new PoplarFenceGateBlock(Identifier, Direction.North, false, false, false),
            15595 => new PoplarFenceGateBlock(Identifier, Direction.South, true, true, true),
            15596 => new PoplarFenceGateBlock(Identifier, Direction.South, true, true, false),
            15597 => new PoplarFenceGateBlock(Identifier, Direction.South, true, false, true),
            15598 => new PoplarFenceGateBlock(Identifier, Direction.South, true, false, false),
            15599 => new PoplarFenceGateBlock(Identifier, Direction.South, false, true, true),
            15600 => new PoplarFenceGateBlock(Identifier, Direction.South, false, true, false),
            15601 => new PoplarFenceGateBlock(Identifier, Direction.South, false, false, true),
            15602 => new PoplarFenceGateBlock(Identifier, Direction.South, false, false, false),
            15603 => new PoplarFenceGateBlock(Identifier, Direction.West, true, true, true),
            15604 => new PoplarFenceGateBlock(Identifier, Direction.West, true, true, false),
            15605 => new PoplarFenceGateBlock(Identifier, Direction.West, true, false, true),
            15606 => new PoplarFenceGateBlock(Identifier, Direction.West, true, false, false),
            15607 => new PoplarFenceGateBlock(Identifier, Direction.West, false, true, true),
            15608 => new PoplarFenceGateBlock(Identifier, Direction.West, false, true, false),
            15609 => new PoplarFenceGateBlock(Identifier, Direction.West, false, false, true),
            15610 => new PoplarFenceGateBlock(Identifier, Direction.West, false, false, false),
            15611 => new PoplarFenceGateBlock(Identifier, Direction.East, true, true, true),
            15612 => new PoplarFenceGateBlock(Identifier, Direction.East, true, true, false),
            15613 => new PoplarFenceGateBlock(Identifier, Direction.East, true, false, true),
            15614 => new PoplarFenceGateBlock(Identifier, Direction.East, true, false, false),
            15615 => new PoplarFenceGateBlock(Identifier, Direction.East, false, true, true),
            15616 => new PoplarFenceGateBlock(Identifier, Direction.East, false, true, false),
            15617 => new PoplarFenceGateBlock(Identifier, Direction.East, false, false, true),
            15618 => new PoplarFenceGateBlock(Identifier, Direction.East, false, false, false),
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
