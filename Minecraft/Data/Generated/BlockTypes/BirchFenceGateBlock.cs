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
public record BirchFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IInWall, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.birch_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:birch_fence_gate", BlockInfo.VanillaOnly, "minecraft:blocks/birch_fence_gate");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 2, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 13516];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                            true => 13516,
                            false => 13517,
                        },
                        false => Powered switch {
                            true => 13518,
                            false => 13519,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13520,
                            false => 13521,
                        },
                        false => Powered switch {
                            true => 13522,
                            false => 13523,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13524,
                            false => 13525,
                        },
                        false => Powered switch {
                            true => 13526,
                            false => 13527,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13528,
                            false => 13529,
                        },
                        false => Powered switch {
                            true => 13530,
                            false => 13531,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13532,
                            false => 13533,
                        },
                        false => Powered switch {
                            true => 13534,
                            false => 13535,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13536,
                            false => 13537,
                        },
                        false => Powered switch {
                            true => 13538,
                            false => 13539,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13540,
                            false => 13541,
                        },
                        false => Powered switch {
                            true => 13542,
                            false => 13543,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13544,
                            false => 13545,
                        },
                        false => Powered switch {
                            true => 13546,
                            false => 13547,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13516 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, true),
            13517 => new BirchFenceGateBlock(Identifier, Direction.North, true, true, false),
            13518 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, true),
            13519 => new BirchFenceGateBlock(Identifier, Direction.North, true, false, false),
            13520 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, true),
            13521 => new BirchFenceGateBlock(Identifier, Direction.North, false, true, false),
            13522 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, true),
            13523 => new BirchFenceGateBlock(Identifier, Direction.North, false, false, false),
            13524 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, true),
            13525 => new BirchFenceGateBlock(Identifier, Direction.South, true, true, false),
            13526 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, true),
            13527 => new BirchFenceGateBlock(Identifier, Direction.South, true, false, false),
            13528 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, true),
            13529 => new BirchFenceGateBlock(Identifier, Direction.South, false, true, false),
            13530 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, true),
            13531 => new BirchFenceGateBlock(Identifier, Direction.South, false, false, false),
            13532 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, true),
            13533 => new BirchFenceGateBlock(Identifier, Direction.West, true, true, false),
            13534 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, true),
            13535 => new BirchFenceGateBlock(Identifier, Direction.West, true, false, false),
            13536 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, true),
            13537 => new BirchFenceGateBlock(Identifier, Direction.West, false, true, false),
            13538 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, true),
            13539 => new BirchFenceGateBlock(Identifier, Direction.West, false, false, false),
            13540 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, true),
            13541 => new BirchFenceGateBlock(Identifier, Direction.East, true, true, false),
            13542 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, true),
            13543 => new BirchFenceGateBlock(Identifier, Direction.East, true, false, false),
            13544 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, true),
            13545 => new BirchFenceGateBlock(Identifier, Direction.East, false, true, false),
            13546 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, true),
            13547 => new BirchFenceGateBlock(Identifier, Direction.East, false, false, false),
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
