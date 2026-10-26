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
public record OakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.oak_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oak_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/oak_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 10380];

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
                            true => 10380,
                            false => 10381,
                        },
                        false => Powered switch {
                            true => 10382,
                            false => 10383,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 10384,
                            false => 10385,
                        },
                        false => Powered switch {
                            true => 10386,
                            false => 10387,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 10388,
                            false => 10389,
                        },
                        false => Powered switch {
                            true => 10390,
                            false => 10391,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 10392,
                            false => 10393,
                        },
                        false => Powered switch {
                            true => 10394,
                            false => 10395,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 10396,
                            false => 10397,
                        },
                        false => Powered switch {
                            true => 10398,
                            false => 10399,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 10400,
                            false => 10401,
                        },
                        false => Powered switch {
                            true => 10402,
                            false => 10403,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 10404,
                            false => 10405,
                        },
                        false => Powered switch {
                            true => 10406,
                            false => 10407,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 10408,
                            false => 10409,
                        },
                        false => Powered switch {
                            true => 10410,
                            false => 10411,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10380 => new OakFenceGateBlock(Identifier, Direction.North, true, true, true),
            10381 => new OakFenceGateBlock(Identifier, Direction.North, true, true, false),
            10382 => new OakFenceGateBlock(Identifier, Direction.North, true, false, true),
            10383 => new OakFenceGateBlock(Identifier, Direction.North, true, false, false),
            10384 => new OakFenceGateBlock(Identifier, Direction.North, false, true, true),
            10385 => new OakFenceGateBlock(Identifier, Direction.North, false, true, false),
            10386 => new OakFenceGateBlock(Identifier, Direction.North, false, false, true),
            10387 => new OakFenceGateBlock(Identifier, Direction.North, false, false, false),
            10388 => new OakFenceGateBlock(Identifier, Direction.South, true, true, true),
            10389 => new OakFenceGateBlock(Identifier, Direction.South, true, true, false),
            10390 => new OakFenceGateBlock(Identifier, Direction.South, true, false, true),
            10391 => new OakFenceGateBlock(Identifier, Direction.South, true, false, false),
            10392 => new OakFenceGateBlock(Identifier, Direction.South, false, true, true),
            10393 => new OakFenceGateBlock(Identifier, Direction.South, false, true, false),
            10394 => new OakFenceGateBlock(Identifier, Direction.South, false, false, true),
            10395 => new OakFenceGateBlock(Identifier, Direction.South, false, false, false),
            10396 => new OakFenceGateBlock(Identifier, Direction.West, true, true, true),
            10397 => new OakFenceGateBlock(Identifier, Direction.West, true, true, false),
            10398 => new OakFenceGateBlock(Identifier, Direction.West, true, false, true),
            10399 => new OakFenceGateBlock(Identifier, Direction.West, true, false, false),
            10400 => new OakFenceGateBlock(Identifier, Direction.West, false, true, true),
            10401 => new OakFenceGateBlock(Identifier, Direction.West, false, true, false),
            10402 => new OakFenceGateBlock(Identifier, Direction.West, false, false, true),
            10403 => new OakFenceGateBlock(Identifier, Direction.West, false, false, false),
            10404 => new OakFenceGateBlock(Identifier, Direction.East, true, true, true),
            10405 => new OakFenceGateBlock(Identifier, Direction.East, true, true, false),
            10406 => new OakFenceGateBlock(Identifier, Direction.East, true, false, true),
            10407 => new OakFenceGateBlock(Identifier, Direction.East, true, false, false),
            10408 => new OakFenceGateBlock(Identifier, Direction.East, false, true, true),
            10409 => new OakFenceGateBlock(Identifier, Direction.East, false, true, false),
            10410 => new OakFenceGateBlock(Identifier, Direction.East, false, false, true),
            10411 => new OakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
