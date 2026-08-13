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
public record WeepingVinesBlock(Identifier Identifier, int Age) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weeping_vines", "block.minecraft.weeping_vines", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weeping_vines", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 35, "weeping_vines", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, false, true, [], null, BlockShapes.S933, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 20977];

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


    public uint StateId {
        get {
            return Age switch {
                0 => 20977,
                1 => 20978,
                2 => 20979,
                3 => 20980,
                4 => 20981,
                5 => 20982,
                6 => 20983,
                7 => 20984,
                8 => 20985,
                9 => 20986,
                10 => 20987,
                11 => 20988,
                12 => 20989,
                13 => 20990,
                14 => 20991,
                15 => 20992,
                16 => 20993,
                17 => 20994,
                18 => 20995,
                19 => 20996,
                20 => 20997,
                21 => 20998,
                22 => 20999,
                23 => 21000,
                24 => 21001,
                25 => 21002,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20977 => new WeepingVinesBlock(Identifier, 0),
            20978 => new WeepingVinesBlock(Identifier, 1),
            20979 => new WeepingVinesBlock(Identifier, 2),
            20980 => new WeepingVinesBlock(Identifier, 3),
            20981 => new WeepingVinesBlock(Identifier, 4),
            20982 => new WeepingVinesBlock(Identifier, 5),
            20983 => new WeepingVinesBlock(Identifier, 6),
            20984 => new WeepingVinesBlock(Identifier, 7),
            20985 => new WeepingVinesBlock(Identifier, 8),
            20986 => new WeepingVinesBlock(Identifier, 9),
            20987 => new WeepingVinesBlock(Identifier, 10),
            20988 => new WeepingVinesBlock(Identifier, 11),
            20989 => new WeepingVinesBlock(Identifier, 12),
            20990 => new WeepingVinesBlock(Identifier, 13),
            20991 => new WeepingVinesBlock(Identifier, 14),
            20992 => new WeepingVinesBlock(Identifier, 15),
            20993 => new WeepingVinesBlock(Identifier, 16),
            20994 => new WeepingVinesBlock(Identifier, 17),
            20995 => new WeepingVinesBlock(Identifier, 18),
            20996 => new WeepingVinesBlock(Identifier, 19),
            20997 => new WeepingVinesBlock(Identifier, 20),
            20998 => new WeepingVinesBlock(Identifier, 21),
            20999 => new WeepingVinesBlock(Identifier, 22),
            21000 => new WeepingVinesBlock(Identifier, 23),
            21001 => new WeepingVinesBlock(Identifier, 24),
            21002 => new WeepingVinesBlock(Identifier, 25),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString()))
        );
    }
    
}
