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
    private static readonly BlockInfo Data = new("block.minecraft.twisting_vines", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:twisting_vines", BlockInfo.VanillaOnly, "minecraft:blocks/twisting_vines");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 23, "weeping_vines", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S945, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 24361];

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
                0 => 24361,
                1 => 24362,
                2 => 24363,
                3 => 24364,
                4 => 24365,
                5 => 24366,
                6 => 24367,
                7 => 24368,
                8 => 24369,
                9 => 24370,
                10 => 24371,
                11 => 24372,
                12 => 24373,
                13 => 24374,
                14 => 24375,
                15 => 24376,
                16 => 24377,
                17 => 24378,
                18 => 24379,
                19 => 24380,
                20 => 24381,
                21 => 24382,
                22 => 24383,
                23 => 24384,
                24 => 24385,
                25 => 24386,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24361 => new TwistingVinesBlock(Identifier, 0),
            24362 => new TwistingVinesBlock(Identifier, 1),
            24363 => new TwistingVinesBlock(Identifier, 2),
            24364 => new TwistingVinesBlock(Identifier, 3),
            24365 => new TwistingVinesBlock(Identifier, 4),
            24366 => new TwistingVinesBlock(Identifier, 5),
            24367 => new TwistingVinesBlock(Identifier, 6),
            24368 => new TwistingVinesBlock(Identifier, 7),
            24369 => new TwistingVinesBlock(Identifier, 8),
            24370 => new TwistingVinesBlock(Identifier, 9),
            24371 => new TwistingVinesBlock(Identifier, 10),
            24372 => new TwistingVinesBlock(Identifier, 11),
            24373 => new TwistingVinesBlock(Identifier, 12),
            24374 => new TwistingVinesBlock(Identifier, 13),
            24375 => new TwistingVinesBlock(Identifier, 14),
            24376 => new TwistingVinesBlock(Identifier, 15),
            24377 => new TwistingVinesBlock(Identifier, 16),
            24378 => new TwistingVinesBlock(Identifier, 17),
            24379 => new TwistingVinesBlock(Identifier, 18),
            24380 => new TwistingVinesBlock(Identifier, 19),
            24381 => new TwistingVinesBlock(Identifier, 20),
            24382 => new TwistingVinesBlock(Identifier, 21),
            24383 => new TwistingVinesBlock(Identifier, 22),
            24384 => new TwistingVinesBlock(Identifier, 23),
            24385 => new TwistingVinesBlock(Identifier, 24),
            24386 => new TwistingVinesBlock(Identifier, 25),
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
