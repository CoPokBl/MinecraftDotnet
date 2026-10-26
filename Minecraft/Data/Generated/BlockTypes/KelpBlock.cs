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
public record KelpBlock(Identifier Identifier, int Age) : IBlock, IAged {
    private static readonly BlockInfo Data = new("block.minecraft.kelp", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:kelp", BlockInfo.VanillaOnly, "minecraft:blocks/kelp");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 12, "wet_grass", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S413, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 18419];

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

    public IBlock WithAge(int age) => this with { Age = age };


    public uint StateId {
        get {
            return Age switch {
                0 => 18419,
                1 => 18420,
                2 => 18421,
                3 => 18422,
                4 => 18423,
                5 => 18424,
                6 => 18425,
                7 => 18426,
                8 => 18427,
                9 => 18428,
                10 => 18429,
                11 => 18430,
                12 => 18431,
                13 => 18432,
                14 => 18433,
                15 => 18434,
                16 => 18435,
                17 => 18436,
                18 => 18437,
                19 => 18438,
                20 => 18439,
                21 => 18440,
                22 => 18441,
                23 => 18442,
                24 => 18443,
                25 => 18444,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            18419 => new KelpBlock(Identifier, 0),
            18420 => new KelpBlock(Identifier, 1),
            18421 => new KelpBlock(Identifier, 2),
            18422 => new KelpBlock(Identifier, 3),
            18423 => new KelpBlock(Identifier, 4),
            18424 => new KelpBlock(Identifier, 5),
            18425 => new KelpBlock(Identifier, 6),
            18426 => new KelpBlock(Identifier, 7),
            18427 => new KelpBlock(Identifier, 8),
            18428 => new KelpBlock(Identifier, 9),
            18429 => new KelpBlock(Identifier, 10),
            18430 => new KelpBlock(Identifier, 11),
            18431 => new KelpBlock(Identifier, 12),
            18432 => new KelpBlock(Identifier, 13),
            18433 => new KelpBlock(Identifier, 14),
            18434 => new KelpBlock(Identifier, 15),
            18435 => new KelpBlock(Identifier, 16),
            18436 => new KelpBlock(Identifier, 17),
            18437 => new KelpBlock(Identifier, 18),
            18438 => new KelpBlock(Identifier, 19),
            18439 => new KelpBlock(Identifier, 20),
            18440 => new KelpBlock(Identifier, 21),
            18441 => new KelpBlock(Identifier, 22),
            18442 => new KelpBlock(Identifier, 23),
            18443 => new KelpBlock(Identifier, 24),
            18444 => new KelpBlock(Identifier, 25),
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
