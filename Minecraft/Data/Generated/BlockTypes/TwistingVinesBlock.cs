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
public record TwistingVinesBlock(Identifier Identifier, int Age) : IBlock, IAged {
    private static readonly BlockInfo Data = new("minecraft:twisting_vines", "block.minecraft.twisting_vines", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:twisting_vines", BlockInfo.VanillaOnly, "minecraft:blocks/twisting_vines");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 23, "weeping_vines", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, true, false, true, [], null, BlockShapes.S932, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 21004];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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

    public IBlock WithAge(int age) => this with { Age = age };


    public uint StateId {
        get {
            return Age switch {
                0 => 21004,
                1 => 21005,
                2 => 21006,
                3 => 21007,
                4 => 21008,
                5 => 21009,
                6 => 21010,
                7 => 21011,
                8 => 21012,
                9 => 21013,
                10 => 21014,
                11 => 21015,
                12 => 21016,
                13 => 21017,
                14 => 21018,
                15 => 21019,
                16 => 21020,
                17 => 21021,
                18 => 21022,
                19 => 21023,
                20 => 21024,
                21 => 21025,
                22 => 21026,
                23 => 21027,
                24 => 21028,
                25 => 21029,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21004 => new TwistingVinesBlock(Identifier, 0),
            21005 => new TwistingVinesBlock(Identifier, 1),
            21006 => new TwistingVinesBlock(Identifier, 2),
            21007 => new TwistingVinesBlock(Identifier, 3),
            21008 => new TwistingVinesBlock(Identifier, 4),
            21009 => new TwistingVinesBlock(Identifier, 5),
            21010 => new TwistingVinesBlock(Identifier, 6),
            21011 => new TwistingVinesBlock(Identifier, 7),
            21012 => new TwistingVinesBlock(Identifier, 8),
            21013 => new TwistingVinesBlock(Identifier, 9),
            21014 => new TwistingVinesBlock(Identifier, 10),
            21015 => new TwistingVinesBlock(Identifier, 11),
            21016 => new TwistingVinesBlock(Identifier, 12),
            21017 => new TwistingVinesBlock(Identifier, 13),
            21018 => new TwistingVinesBlock(Identifier, 14),
            21019 => new TwistingVinesBlock(Identifier, 15),
            21020 => new TwistingVinesBlock(Identifier, 16),
            21021 => new TwistingVinesBlock(Identifier, 17),
            21022 => new TwistingVinesBlock(Identifier, 18),
            21023 => new TwistingVinesBlock(Identifier, 19),
            21024 => new TwistingVinesBlock(Identifier, 20),
            21025 => new TwistingVinesBlock(Identifier, 21),
            21026 => new TwistingVinesBlock(Identifier, 22),
            21027 => new TwistingVinesBlock(Identifier, 23),
            21028 => new TwistingVinesBlock(Identifier, 24),
            21029 => new TwistingVinesBlock(Identifier, 25),
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
