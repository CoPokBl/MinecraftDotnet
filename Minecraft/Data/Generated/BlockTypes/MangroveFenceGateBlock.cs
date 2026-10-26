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
public record MangroveFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 28, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 15555];

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
                            true => 15555,
                            false => 15556,
                        },
                        false => Powered switch {
                            true => 15557,
                            false => 15558,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15559,
                            false => 15560,
                        },
                        false => Powered switch {
                            true => 15561,
                            false => 15562,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15563,
                            false => 15564,
                        },
                        false => Powered switch {
                            true => 15565,
                            false => 15566,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15567,
                            false => 15568,
                        },
                        false => Powered switch {
                            true => 15569,
                            false => 15570,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15571,
                            false => 15572,
                        },
                        false => Powered switch {
                            true => 15573,
                            false => 15574,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15575,
                            false => 15576,
                        },
                        false => Powered switch {
                            true => 15577,
                            false => 15578,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15579,
                            false => 15580,
                        },
                        false => Powered switch {
                            true => 15581,
                            false => 15582,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15583,
                            false => 15584,
                        },
                        false => Powered switch {
                            true => 15585,
                            false => 15586,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15555 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, true),
            15556 => new MangroveFenceGateBlock(Identifier, Direction.North, true, true, false),
            15557 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, true),
            15558 => new MangroveFenceGateBlock(Identifier, Direction.North, true, false, false),
            15559 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, true),
            15560 => new MangroveFenceGateBlock(Identifier, Direction.North, false, true, false),
            15561 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, true),
            15562 => new MangroveFenceGateBlock(Identifier, Direction.North, false, false, false),
            15563 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, true),
            15564 => new MangroveFenceGateBlock(Identifier, Direction.South, true, true, false),
            15565 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, true),
            15566 => new MangroveFenceGateBlock(Identifier, Direction.South, true, false, false),
            15567 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, true),
            15568 => new MangroveFenceGateBlock(Identifier, Direction.South, false, true, false),
            15569 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, true),
            15570 => new MangroveFenceGateBlock(Identifier, Direction.South, false, false, false),
            15571 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, true),
            15572 => new MangroveFenceGateBlock(Identifier, Direction.West, true, true, false),
            15573 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, true),
            15574 => new MangroveFenceGateBlock(Identifier, Direction.West, true, false, false),
            15575 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, true),
            15576 => new MangroveFenceGateBlock(Identifier, Direction.West, false, true, false),
            15577 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, true),
            15578 => new MangroveFenceGateBlock(Identifier, Direction.West, false, false, false),
            15579 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, true),
            15580 => new MangroveFenceGateBlock(Identifier, Direction.East, true, true, false),
            15581 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, true),
            15582 => new MangroveFenceGateBlock(Identifier, Direction.East, true, false, false),
            15583 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, true),
            15584 => new MangroveFenceGateBlock(Identifier, Direction.East, false, true, false),
            15585 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, true),
            15586 => new MangroveFenceGateBlock(Identifier, Direction.East, false, false, false),
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
