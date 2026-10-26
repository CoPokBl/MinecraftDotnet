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
public record CherryFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.cherry_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cherry_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 36, "cherry_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 15459];

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
                            true => 15459,
                            false => 15460,
                        },
                        false => Powered switch {
                            true => 15461,
                            false => 15462,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15463,
                            false => 15464,
                        },
                        false => Powered switch {
                            true => 15465,
                            false => 15466,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15467,
                            false => 15468,
                        },
                        false => Powered switch {
                            true => 15469,
                            false => 15470,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15471,
                            false => 15472,
                        },
                        false => Powered switch {
                            true => 15473,
                            false => 15474,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15475,
                            false => 15476,
                        },
                        false => Powered switch {
                            true => 15477,
                            false => 15478,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15479,
                            false => 15480,
                        },
                        false => Powered switch {
                            true => 15481,
                            false => 15482,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15483,
                            false => 15484,
                        },
                        false => Powered switch {
                            true => 15485,
                            false => 15486,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15487,
                            false => 15488,
                        },
                        false => Powered switch {
                            true => 15489,
                            false => 15490,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15459 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, true),
            15460 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, false),
            15461 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, true),
            15462 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, false),
            15463 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, true),
            15464 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, false),
            15465 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, true),
            15466 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, false),
            15467 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, true),
            15468 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, false),
            15469 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, true),
            15470 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, false),
            15471 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, true),
            15472 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, false),
            15473 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, true),
            15474 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, false),
            15475 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, true),
            15476 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, false),
            15477 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, true),
            15478 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, false),
            15479 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, true),
            15480 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, false),
            15481 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, true),
            15482 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, false),
            15483 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, true),
            15484 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, false),
            15485 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, true),
            15486 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, false),
            15487 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, true),
            15488 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, false),
            15489 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, true),
            15490 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, false),
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
