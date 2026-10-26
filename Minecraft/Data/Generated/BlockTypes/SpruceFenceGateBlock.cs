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
public record SpruceFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_fence_gate", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.PushPull, 34, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 15331];

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
                            true => 15331,
                            false => 15332,
                        },
                        false => Powered switch {
                            true => 15333,
                            false => 15334,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15335,
                            false => 15336,
                        },
                        false => Powered switch {
                            true => 15337,
                            false => 15338,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15339,
                            false => 15340,
                        },
                        false => Powered switch {
                            true => 15341,
                            false => 15342,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15343,
                            false => 15344,
                        },
                        false => Powered switch {
                            true => 15345,
                            false => 15346,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15347,
                            false => 15348,
                        },
                        false => Powered switch {
                            true => 15349,
                            false => 15350,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15351,
                            false => 15352,
                        },
                        false => Powered switch {
                            true => 15353,
                            false => 15354,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 15355,
                            false => 15356,
                        },
                        false => Powered switch {
                            true => 15357,
                            false => 15358,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 15359,
                            false => 15360,
                        },
                        false => Powered switch {
                            true => 15361,
                            false => 15362,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15331 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, true),
            15332 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, false),
            15333 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, true),
            15334 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, false),
            15335 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, true),
            15336 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, false),
            15337 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, true),
            15338 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, false),
            15339 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, true),
            15340 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, false),
            15341 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, true),
            15342 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, false),
            15343 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, true),
            15344 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, false),
            15345 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, true),
            15346 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, false),
            15347 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, true),
            15348 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, false),
            15349 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, true),
            15350 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, false),
            15351 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, true),
            15352 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, false),
            15353 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, true),
            15354 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, false),
            15355 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, true),
            15356 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, false),
            15357 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, true),
            15358 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, false),
            15359 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, true),
            15360 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, false),
            15361 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, true),
            15362 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, false),
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
