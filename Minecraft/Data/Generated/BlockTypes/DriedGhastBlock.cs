using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DriedGhastBlock(Identifier Identifier, Direction Facing, int Hydration, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:dried_ghast", "block.minecraft.dried_ghast", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dried_ghast", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Normal, 21, "dried_ghast", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S521, BlockShapes.S521, BlockShapes.S1, BlockShapes.S1, BlockShapes.S521);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 15105];

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
                Direction.North => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15105,
                        false => 15106,
                    },
                    1 => Waterlogged switch {
                        true => 15107,
                        false => 15108,
                    },
                    2 => Waterlogged switch {
                        true => 15109,
                        false => 15110,
                    },
                    3 => Waterlogged switch {
                        true => 15111,
                        false => 15112,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.South => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15113,
                        false => 15114,
                    },
                    1 => Waterlogged switch {
                        true => 15115,
                        false => 15116,
                    },
                    2 => Waterlogged switch {
                        true => 15117,
                        false => 15118,
                    },
                    3 => Waterlogged switch {
                        true => 15119,
                        false => 15120,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.West => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15121,
                        false => 15122,
                    },
                    1 => Waterlogged switch {
                        true => 15123,
                        false => 15124,
                    },
                    2 => Waterlogged switch {
                        true => 15125,
                        false => 15126,
                    },
                    3 => Waterlogged switch {
                        true => 15127,
                        false => 15128,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.East => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15129,
                        false => 15130,
                    },
                    1 => Waterlogged switch {
                        true => 15131,
                        false => 15132,
                    },
                    2 => Waterlogged switch {
                        true => 15133,
                        false => 15134,
                    },
                    3 => Waterlogged switch {
                        true => 15135,
                        false => 15136,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15105 => new DriedGhastBlock(Identifier, Direction.North, 0, true),
            15106 => new DriedGhastBlock(Identifier, Direction.North, 0, false),
            15107 => new DriedGhastBlock(Identifier, Direction.North, 1, true),
            15108 => new DriedGhastBlock(Identifier, Direction.North, 1, false),
            15109 => new DriedGhastBlock(Identifier, Direction.North, 2, true),
            15110 => new DriedGhastBlock(Identifier, Direction.North, 2, false),
            15111 => new DriedGhastBlock(Identifier, Direction.North, 3, true),
            15112 => new DriedGhastBlock(Identifier, Direction.North, 3, false),
            15113 => new DriedGhastBlock(Identifier, Direction.South, 0, true),
            15114 => new DriedGhastBlock(Identifier, Direction.South, 0, false),
            15115 => new DriedGhastBlock(Identifier, Direction.South, 1, true),
            15116 => new DriedGhastBlock(Identifier, Direction.South, 1, false),
            15117 => new DriedGhastBlock(Identifier, Direction.South, 2, true),
            15118 => new DriedGhastBlock(Identifier, Direction.South, 2, false),
            15119 => new DriedGhastBlock(Identifier, Direction.South, 3, true),
            15120 => new DriedGhastBlock(Identifier, Direction.South, 3, false),
            15121 => new DriedGhastBlock(Identifier, Direction.West, 0, true),
            15122 => new DriedGhastBlock(Identifier, Direction.West, 0, false),
            15123 => new DriedGhastBlock(Identifier, Direction.West, 1, true),
            15124 => new DriedGhastBlock(Identifier, Direction.West, 1, false),
            15125 => new DriedGhastBlock(Identifier, Direction.West, 2, true),
            15126 => new DriedGhastBlock(Identifier, Direction.West, 2, false),
            15127 => new DriedGhastBlock(Identifier, Direction.West, 3, true),
            15128 => new DriedGhastBlock(Identifier, Direction.West, 3, false),
            15129 => new DriedGhastBlock(Identifier, Direction.East, 0, true),
            15130 => new DriedGhastBlock(Identifier, Direction.East, 0, false),
            15131 => new DriedGhastBlock(Identifier, Direction.East, 1, true),
            15132 => new DriedGhastBlock(Identifier, Direction.East, 1, false),
            15133 => new DriedGhastBlock(Identifier, Direction.East, 2, true),
            15134 => new DriedGhastBlock(Identifier, Direction.East, 2, false),
            15135 => new DriedGhastBlock(Identifier, Direction.East, 3, true),
            15136 => new DriedGhastBlock(Identifier, Direction.East, 3, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Hydration = properties.Contains("hydration") ? int.Parse(properties["hydration"].GetString()) : Hydration,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("hydration", new StringTag(Hydration.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
