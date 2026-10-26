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
public record WeepingVinesBlock(Identifier Identifier, int Age) : IBlock, IAged {
    private static readonly BlockInfo Data = new("block.minecraft.weeping_vines", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weeping_vines", BlockInfo.VanillaOnly, "minecraft:blocks/weeping_vines");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 35, "weeping_vines", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S946, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 24334];

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
                0 => 24334,
                1 => 24335,
                2 => 24336,
                3 => 24337,
                4 => 24338,
                5 => 24339,
                6 => 24340,
                7 => 24341,
                8 => 24342,
                9 => 24343,
                10 => 24344,
                11 => 24345,
                12 => 24346,
                13 => 24347,
                14 => 24348,
                15 => 24349,
                16 => 24350,
                17 => 24351,
                18 => 24352,
                19 => 24353,
                20 => 24354,
                21 => 24355,
                22 => 24356,
                23 => 24357,
                24 => 24358,
                25 => 24359,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24334 => new WeepingVinesBlock(Identifier, 0),
            24335 => new WeepingVinesBlock(Identifier, 1),
            24336 => new WeepingVinesBlock(Identifier, 2),
            24337 => new WeepingVinesBlock(Identifier, 3),
            24338 => new WeepingVinesBlock(Identifier, 4),
            24339 => new WeepingVinesBlock(Identifier, 5),
            24340 => new WeepingVinesBlock(Identifier, 6),
            24341 => new WeepingVinesBlock(Identifier, 7),
            24342 => new WeepingVinesBlock(Identifier, 8),
            24343 => new WeepingVinesBlock(Identifier, 9),
            24344 => new WeepingVinesBlock(Identifier, 10),
            24345 => new WeepingVinesBlock(Identifier, 11),
            24346 => new WeepingVinesBlock(Identifier, 12),
            24347 => new WeepingVinesBlock(Identifier, 13),
            24348 => new WeepingVinesBlock(Identifier, 14),
            24349 => new WeepingVinesBlock(Identifier, 15),
            24350 => new WeepingVinesBlock(Identifier, 16),
            24351 => new WeepingVinesBlock(Identifier, 17),
            24352 => new WeepingVinesBlock(Identifier, 18),
            24353 => new WeepingVinesBlock(Identifier, 19),
            24354 => new WeepingVinesBlock(Identifier, 20),
            24355 => new WeepingVinesBlock(Identifier, 21),
            24356 => new WeepingVinesBlock(Identifier, 22),
            24357 => new WeepingVinesBlock(Identifier, 23),
            24358 => new WeepingVinesBlock(Identifier, 24),
            24359 => new WeepingVinesBlock(Identifier, 25),
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
