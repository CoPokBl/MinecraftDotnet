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
public record CactusBlock(Identifier Identifier, int Age) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:cactus", "block.minecraft.cactus", 0.4f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cactus", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.4f, 0, 0, PushReaction.Destroy, 7, "wool", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, true, false, false, true, false, false, false, [], null, BlockShapes.S401, BlockShapes.S402, BlockShapes.S1, BlockShapes.S401, BlockShapes.S402, BlockShapes.S402);

    public BlockStateInfo StateInfo => I0;

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
                0 => 6929,
                1 => 6930,
                2 => 6931,
                3 => 6932,
                4 => 6933,
                5 => 6934,
                6 => 6935,
                7 => 6936,
                8 => 6937,
                9 => 6938,
                10 => 6939,
                11 => 6940,
                12 => 6941,
                13 => 6942,
                14 => 6943,
                15 => 6944,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6929 => new CactusBlock(Identifier, 0),
            6930 => new CactusBlock(Identifier, 1),
            6931 => new CactusBlock(Identifier, 2),
            6932 => new CactusBlock(Identifier, 3),
            6933 => new CactusBlock(Identifier, 4),
            6934 => new CactusBlock(Identifier, 5),
            6935 => new CactusBlock(Identifier, 6),
            6936 => new CactusBlock(Identifier, 7),
            6937 => new CactusBlock(Identifier, 8),
            6938 => new CactusBlock(Identifier, 9),
            6939 => new CactusBlock(Identifier, 10),
            6940 => new CactusBlock(Identifier, 11),
            6941 => new CactusBlock(Identifier, 12),
            6942 => new CactusBlock(Identifier, 13),
            6943 => new CactusBlock(Identifier, 14),
            6944 => new CactusBlock(Identifier, 15),
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
