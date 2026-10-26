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
public record LavaBlock(Identifier Identifier, int Level) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.lava", 100f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(100f, 15, 1, PushReaction.Popped, 4, "empty", NoteBlockInstrument.Harp, false, false, false, false, false, true, true, false, false, false, true, false, false, false, true, false, false, false, [], "minecraft:lava", BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { Fluid = "minecraft:flowing_lava" };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 105];

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


    public uint StateId {
        get {
            return Level switch {
                0 => 105,
                1 => 106,
                2 => 107,
                3 => 108,
                4 => 109,
                5 => 110,
                6 => 111,
                7 => 112,
                8 => 113,
                9 => 114,
                10 => 115,
                11 => 116,
                12 => 117,
                13 => 118,
                14 => 119,
                15 => 120,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            105 => new LavaBlock(Identifier, 0),
            106 => new LavaBlock(Identifier, 1),
            107 => new LavaBlock(Identifier, 2),
            108 => new LavaBlock(Identifier, 3),
            109 => new LavaBlock(Identifier, 4),
            110 => new LavaBlock(Identifier, 5),
            111 => new LavaBlock(Identifier, 6),
            112 => new LavaBlock(Identifier, 7),
            113 => new LavaBlock(Identifier, 8),
            114 => new LavaBlock(Identifier, 9),
            115 => new LavaBlock(Identifier, 10),
            116 => new LavaBlock(Identifier, 11),
            117 => new LavaBlock(Identifier, 12),
            118 => new LavaBlock(Identifier, 13),
            119 => new LavaBlock(Identifier, 14),
            120 => new LavaBlock(Identifier, 15),
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
