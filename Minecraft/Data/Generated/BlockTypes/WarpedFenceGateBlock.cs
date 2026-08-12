using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.warped_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 56, "nether_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 21274];

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
                            true => 21274,
                            false => 21275,
                        },
                        false => Powered switch {
                            true => 21276,
                            false => 21277,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21278,
                            false => 21279,
                        },
                        false => Powered switch {
                            true => 21280,
                            false => 21281,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21282,
                            false => 21283,
                        },
                        false => Powered switch {
                            true => 21284,
                            false => 21285,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21286,
                            false => 21287,
                        },
                        false => Powered switch {
                            true => 21288,
                            false => 21289,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21290,
                            false => 21291,
                        },
                        false => Powered switch {
                            true => 21292,
                            false => 21293,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21294,
                            false => 21295,
                        },
                        false => Powered switch {
                            true => 21296,
                            false => 21297,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21298,
                            false => 21299,
                        },
                        false => Powered switch {
                            true => 21300,
                            false => 21301,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21302,
                            false => 21303,
                        },
                        false => Powered switch {
                            true => 21304,
                            false => 21305,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21274 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, true),
            21275 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, false),
            21276 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, true),
            21277 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, false),
            21278 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, true),
            21279 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, false),
            21280 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, true),
            21281 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, false),
            21282 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, true),
            21283 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, false),
            21284 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, true),
            21285 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, false),
            21286 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, true),
            21287 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, false),
            21288 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, true),
            21289 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, false),
            21290 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, true),
            21291 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, false),
            21292 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, true),
            21293 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, false),
            21294 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, true),
            21295 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, false),
            21296 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, true),
            21297 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, false),
            21298 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, true),
            21299 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, false),
            21300 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, true),
            21301 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, false),
            21302 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, true),
            21303 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, false),
            21304 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, true),
            21305 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, false),
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
