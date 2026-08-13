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
public record CaveVinesBlock(Identifier Identifier, int Age, bool Berries) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:cave_vines", "block.minecraft.cave_vines", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:glow_berries", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 14, 0, PushReaction.Destroy, 7, "cave_vines", NoteBlockInstrument.Harp, true, false, false, false, true, false, false, false, false, false, false, true, false, false, true, true, false, true, [], null, BlockShapes.S401, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, RandomlyTicking = false };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 30249];

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
                0 => Berries switch {
                    true => 30249,
                    false => 30250,
                },
                1 => Berries switch {
                    true => 30251,
                    false => 30252,
                },
                2 => Berries switch {
                    true => 30253,
                    false => 30254,
                },
                3 => Berries switch {
                    true => 30255,
                    false => 30256,
                },
                4 => Berries switch {
                    true => 30257,
                    false => 30258,
                },
                5 => Berries switch {
                    true => 30259,
                    false => 30260,
                },
                6 => Berries switch {
                    true => 30261,
                    false => 30262,
                },
                7 => Berries switch {
                    true => 30263,
                    false => 30264,
                },
                8 => Berries switch {
                    true => 30265,
                    false => 30266,
                },
                9 => Berries switch {
                    true => 30267,
                    false => 30268,
                },
                10 => Berries switch {
                    true => 30269,
                    false => 30270,
                },
                11 => Berries switch {
                    true => 30271,
                    false => 30272,
                },
                12 => Berries switch {
                    true => 30273,
                    false => 30274,
                },
                13 => Berries switch {
                    true => 30275,
                    false => 30276,
                },
                14 => Berries switch {
                    true => 30277,
                    false => 30278,
                },
                15 => Berries switch {
                    true => 30279,
                    false => 30280,
                },
                16 => Berries switch {
                    true => 30281,
                    false => 30282,
                },
                17 => Berries switch {
                    true => 30283,
                    false => 30284,
                },
                18 => Berries switch {
                    true => 30285,
                    false => 30286,
                },
                19 => Berries switch {
                    true => 30287,
                    false => 30288,
                },
                20 => Berries switch {
                    true => 30289,
                    false => 30290,
                },
                21 => Berries switch {
                    true => 30291,
                    false => 30292,
                },
                22 => Berries switch {
                    true => 30293,
                    false => 30294,
                },
                23 => Berries switch {
                    true => 30295,
                    false => 30296,
                },
                24 => Berries switch {
                    true => 30297,
                    false => 30298,
                },
                25 => Berries switch {
                    true => 30299,
                    false => 30300,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30249 => new CaveVinesBlock(Identifier, 0, true),
            30250 => new CaveVinesBlock(Identifier, 0, false),
            30251 => new CaveVinesBlock(Identifier, 1, true),
            30252 => new CaveVinesBlock(Identifier, 1, false),
            30253 => new CaveVinesBlock(Identifier, 2, true),
            30254 => new CaveVinesBlock(Identifier, 2, false),
            30255 => new CaveVinesBlock(Identifier, 3, true),
            30256 => new CaveVinesBlock(Identifier, 3, false),
            30257 => new CaveVinesBlock(Identifier, 4, true),
            30258 => new CaveVinesBlock(Identifier, 4, false),
            30259 => new CaveVinesBlock(Identifier, 5, true),
            30260 => new CaveVinesBlock(Identifier, 5, false),
            30261 => new CaveVinesBlock(Identifier, 6, true),
            30262 => new CaveVinesBlock(Identifier, 6, false),
            30263 => new CaveVinesBlock(Identifier, 7, true),
            30264 => new CaveVinesBlock(Identifier, 7, false),
            30265 => new CaveVinesBlock(Identifier, 8, true),
            30266 => new CaveVinesBlock(Identifier, 8, false),
            30267 => new CaveVinesBlock(Identifier, 9, true),
            30268 => new CaveVinesBlock(Identifier, 9, false),
            30269 => new CaveVinesBlock(Identifier, 10, true),
            30270 => new CaveVinesBlock(Identifier, 10, false),
            30271 => new CaveVinesBlock(Identifier, 11, true),
            30272 => new CaveVinesBlock(Identifier, 11, false),
            30273 => new CaveVinesBlock(Identifier, 12, true),
            30274 => new CaveVinesBlock(Identifier, 12, false),
            30275 => new CaveVinesBlock(Identifier, 13, true),
            30276 => new CaveVinesBlock(Identifier, 13, false),
            30277 => new CaveVinesBlock(Identifier, 14, true),
            30278 => new CaveVinesBlock(Identifier, 14, false),
            30279 => new CaveVinesBlock(Identifier, 15, true),
            30280 => new CaveVinesBlock(Identifier, 15, false),
            30281 => new CaveVinesBlock(Identifier, 16, true),
            30282 => new CaveVinesBlock(Identifier, 16, false),
            30283 => new CaveVinesBlock(Identifier, 17, true),
            30284 => new CaveVinesBlock(Identifier, 17, false),
            30285 => new CaveVinesBlock(Identifier, 18, true),
            30286 => new CaveVinesBlock(Identifier, 18, false),
            30287 => new CaveVinesBlock(Identifier, 19, true),
            30288 => new CaveVinesBlock(Identifier, 19, false),
            30289 => new CaveVinesBlock(Identifier, 20, true),
            30290 => new CaveVinesBlock(Identifier, 20, false),
            30291 => new CaveVinesBlock(Identifier, 21, true),
            30292 => new CaveVinesBlock(Identifier, 21, false),
            30293 => new CaveVinesBlock(Identifier, 22, true),
            30294 => new CaveVinesBlock(Identifier, 22, false),
            30295 => new CaveVinesBlock(Identifier, 23, true),
            30296 => new CaveVinesBlock(Identifier, 23, false),
            30297 => new CaveVinesBlock(Identifier, 24, true),
            30298 => new CaveVinesBlock(Identifier, 24, false),
            30299 => new CaveVinesBlock(Identifier, 25, true),
            30300 => new CaveVinesBlock(Identifier, 25, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Berries = properties.Contains("berries") ? properties["berries"].GetString() == "true" : Berries,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("berries", new StringTag(Berries.ToString().ToLower()))
        );
    }
    
}
