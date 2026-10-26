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
public record PaleOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 14, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 15523];

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
                            true => 15523,
                            false => 15524,
                        },
                        false => Powered switch {
                            true => 15525,
                            false => 15526,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15527,
                            false => 15528,
                        },
                        false => Powered switch {
                            true => 15529,
                            false => 15530,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15531,
                            false => 15532,
                        },
                        false => Powered switch {
                            true => 15533,
                            false => 15534,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15535,
                            false => 15536,
                        },
                        false => Powered switch {
                            true => 15537,
                            false => 15538,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15539,
                            false => 15540,
                        },
                        false => Powered switch {
                            true => 15541,
                            false => 15542,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15543,
                            false => 15544,
                        },
                        false => Powered switch {
                            true => 15545,
                            false => 15546,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15547,
                            false => 15548,
                        },
                        false => Powered switch {
                            true => 15549,
                            false => 15550,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15551,
                            false => 15552,
                        },
                        false => Powered switch {
                            true => 15553,
                            false => 15554,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15523 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            15524 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            15525 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            15526 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            15527 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            15528 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            15529 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            15530 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            15531 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            15532 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            15533 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            15534 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            15535 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            15536 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            15537 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            15538 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            15539 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            15540 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            15541 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            15542 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            15543 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            15544 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            15545 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            15546 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            15547 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            15548 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            15549 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            15550 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            15551 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            15552 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            15553 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            15554 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
