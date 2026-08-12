using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.crimson_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:crimson_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 53, "nether_wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 21242];

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
                            true => 21242,
                            false => 21243,
                        },
                        false => Powered switch {
                            true => 21244,
                            false => 21245,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21246,
                            false => 21247,
                        },
                        false => Powered switch {
                            true => 21248,
                            false => 21249,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21250,
                            false => 21251,
                        },
                        false => Powered switch {
                            true => 21252,
                            false => 21253,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21254,
                            false => 21255,
                        },
                        false => Powered switch {
                            true => 21256,
                            false => 21257,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21258,
                            false => 21259,
                        },
                        false => Powered switch {
                            true => 21260,
                            false => 21261,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21262,
                            false => 21263,
                        },
                        false => Powered switch {
                            true => 21264,
                            false => 21265,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21266,
                            false => 21267,
                        },
                        false => Powered switch {
                            true => 21268,
                            false => 21269,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21270,
                            false => 21271,
                        },
                        false => Powered switch {
                            true => 21272,
                            false => 21273,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21242 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, true),
            21243 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, false),
            21244 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, true),
            21245 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, false),
            21246 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, true),
            21247 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, false),
            21248 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, true),
            21249 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, false),
            21250 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, true),
            21251 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, false),
            21252 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, true),
            21253 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, false),
            21254 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, true),
            21255 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, false),
            21256 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, true),
            21257 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, false),
            21258 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, true),
            21259 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, false),
            21260 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, true),
            21261 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, false),
            21262 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, true),
            21263 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, false),
            21264 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, true),
            21265 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, false),
            21266 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, true),
            21267 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, false),
            21268 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, true),
            21269 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, false),
            21270 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, true),
            21271 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, false),
            21272 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, true),
            21273 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, false),
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
