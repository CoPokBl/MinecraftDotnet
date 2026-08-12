using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LavaBlock(Identifier Identifier, int Level) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:liquid", "block.minecraft.lava", 100f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(100f, 15, 1, PushReaction.Destroy, 4, "empty", NoteBlockInstrument.Harp, false, false, false, false, false, false, true, true, false, false, false, true, false, false, true, [], "minecraft:lava", BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Fluid = "minecraft:flowing_lava" };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 102];

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
            return Level switch {
                0 => 102,
                1 => 103,
                2 => 104,
                3 => 105,
                4 => 106,
                5 => 107,
                6 => 108,
                7 => 109,
                8 => 110,
                9 => 111,
                10 => 112,
                11 => 113,
                12 => 114,
                13 => 115,
                14 => 116,
                15 => 117,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            102 => new LavaBlock(Identifier, 0),
            103 => new LavaBlock(Identifier, 1),
            104 => new LavaBlock(Identifier, 2),
            105 => new LavaBlock(Identifier, 3),
            106 => new LavaBlock(Identifier, 4),
            107 => new LavaBlock(Identifier, 5),
            108 => new LavaBlock(Identifier, 6),
            109 => new LavaBlock(Identifier, 7),
            110 => new LavaBlock(Identifier, 8),
            111 => new LavaBlock(Identifier, 9),
            112 => new LavaBlock(Identifier, 10),
            113 => new LavaBlock(Identifier, 11),
            114 => new LavaBlock(Identifier, 12),
            115 => new LavaBlock(Identifier, 13),
            116 => new LavaBlock(Identifier, 14),
            117 => new LavaBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.Contains("level") ? int.Parse(properties["level"].GetString()) : Level,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("level", new StringTag(Level.ToString()))
        );
    }
    
}
