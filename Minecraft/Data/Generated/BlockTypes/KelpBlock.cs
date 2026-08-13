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
public record KelpBlock(Identifier Identifier, int Age) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:kelp", "block.minecraft.kelp", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:kelp", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 12, "wet_grass", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S413, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 15062];

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
                0 => 15062,
                1 => 15063,
                2 => 15064,
                3 => 15065,
                4 => 15066,
                5 => 15067,
                6 => 15068,
                7 => 15069,
                8 => 15070,
                9 => 15071,
                10 => 15072,
                11 => 15073,
                12 => 15074,
                13 => 15075,
                14 => 15076,
                15 => 15077,
                16 => 15078,
                17 => 15079,
                18 => 15080,
                19 => 15081,
                20 => 15082,
                21 => 15083,
                22 => 15084,
                23 => 15085,
                24 => 15086,
                25 => 15087,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15062 => new KelpBlock(Identifier, 0),
            15063 => new KelpBlock(Identifier, 1),
            15064 => new KelpBlock(Identifier, 2),
            15065 => new KelpBlock(Identifier, 3),
            15066 => new KelpBlock(Identifier, 4),
            15067 => new KelpBlock(Identifier, 5),
            15068 => new KelpBlock(Identifier, 6),
            15069 => new KelpBlock(Identifier, 7),
            15070 => new KelpBlock(Identifier, 8),
            15071 => new KelpBlock(Identifier, 9),
            15072 => new KelpBlock(Identifier, 10),
            15073 => new KelpBlock(Identifier, 11),
            15074 => new KelpBlock(Identifier, 12),
            15075 => new KelpBlock(Identifier, 13),
            15076 => new KelpBlock(Identifier, 14),
            15077 => new KelpBlock(Identifier, 15),
            15078 => new KelpBlock(Identifier, 16),
            15079 => new KelpBlock(Identifier, 17),
            15080 => new KelpBlock(Identifier, 18),
            15081 => new KelpBlock(Identifier, 19),
            15082 => new KelpBlock(Identifier, 20),
            15083 => new KelpBlock(Identifier, 21),
            15084 => new KelpBlock(Identifier, 22),
            15085 => new KelpBlock(Identifier, 23),
            15086 => new KelpBlock(Identifier, 24),
            15087 => new KelpBlock(Identifier, 25),
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
