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
public record SpruceFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.spruce_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 13484];

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

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13484,
                            false => 13485,
                        },
                        false => Powered switch {
                            true => 13486,
                            false => 13487,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13488,
                            false => 13489,
                        },
                        false => Powered switch {
                            true => 13490,
                            false => 13491,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13492,
                            false => 13493,
                        },
                        false => Powered switch {
                            true => 13494,
                            false => 13495,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13496,
                            false => 13497,
                        },
                        false => Powered switch {
                            true => 13498,
                            false => 13499,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13500,
                            false => 13501,
                        },
                        false => Powered switch {
                            true => 13502,
                            false => 13503,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13504,
                            false => 13505,
                        },
                        false => Powered switch {
                            true => 13506,
                            false => 13507,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13508,
                            false => 13509,
                        },
                        false => Powered switch {
                            true => 13510,
                            false => 13511,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13512,
                            false => 13513,
                        },
                        false => Powered switch {
                            true => 13514,
                            false => 13515,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13484 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, true),
            13485 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, false),
            13486 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, true),
            13487 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, false),
            13488 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, true),
            13489 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, false),
            13490 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, true),
            13491 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, false),
            13492 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, true),
            13493 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, false),
            13494 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, true),
            13495 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, false),
            13496 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, true),
            13497 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, false),
            13498 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, true),
            13499 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, false),
            13500 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, true),
            13501 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, false),
            13502 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, true),
            13503 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, false),
            13504 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, true),
            13505 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, false),
            13506 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, true),
            13507 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, false),
            13508 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, true),
            13509 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, false),
            13510 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, true),
            13511 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, false),
            13512 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, true),
            13513 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, false),
            13514 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, true),
            13515 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, false),
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
