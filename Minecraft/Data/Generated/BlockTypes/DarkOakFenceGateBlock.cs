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
public record DarkOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 26, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 15491];

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
                            true => 15491,
                            false => 15492,
                        },
                        false => Powered switch {
                            true => 15493,
                            false => 15494,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15495,
                            false => 15496,
                        },
                        false => Powered switch {
                            true => 15497,
                            false => 15498,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15499,
                            false => 15500,
                        },
                        false => Powered switch {
                            true => 15501,
                            false => 15502,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15503,
                            false => 15504,
                        },
                        false => Powered switch {
                            true => 15505,
                            false => 15506,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15507,
                            false => 15508,
                        },
                        false => Powered switch {
                            true => 15509,
                            false => 15510,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15511,
                            false => 15512,
                        },
                        false => Powered switch {
                            true => 15513,
                            false => 15514,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15515,
                            false => 15516,
                        },
                        false => Powered switch {
                            true => 15517,
                            false => 15518,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15519,
                            false => 15520,
                        },
                        false => Powered switch {
                            true => 15521,
                            false => 15522,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15491 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            15492 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            15493 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            15494 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            15495 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            15496 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            15497 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            15498 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            15499 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            15500 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            15501 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            15502 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            15503 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            15504 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            15505 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            15506 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            15507 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            15508 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            15509 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            15510 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            15511 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            15512 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            15513 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            15514 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            15515 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            15516 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            15517 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            15518 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            15519 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            15520 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            15521 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            15522 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
