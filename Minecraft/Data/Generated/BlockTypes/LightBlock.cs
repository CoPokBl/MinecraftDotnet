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
public record LightBlock(Identifier Identifier, int Level, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.light", 3600000.8f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:light", BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 1, PushReaction.PushPull, 12, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 1 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 1, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 2 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 2, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 3 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 3, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I8 = I0 with { LightEmission = 4 };
    private static readonly BlockStateInfo I9 = I0 with { LightEmission = 4, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I10 = I0 with { LightEmission = 5 };
    private static readonly BlockStateInfo I11 = I0 with { LightEmission = 5, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I12 = I0 with { LightEmission = 6 };
    private static readonly BlockStateInfo I13 = I0 with { LightEmission = 6, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I14 = I0 with { LightEmission = 7 };
    private static readonly BlockStateInfo I15 = I0 with { LightEmission = 7, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I16 = I0 with { LightEmission = 8 };
    private static readonly BlockStateInfo I17 = I0 with { LightEmission = 8, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I18 = I0 with { LightEmission = 9 };
    private static readonly BlockStateInfo I19 = I0 with { LightEmission = 9, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I20 = I0 with { LightEmission = 10 };
    private static readonly BlockStateInfo I21 = I0 with { LightEmission = 10, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I22 = I0 with { LightEmission = 11 };
    private static readonly BlockStateInfo I23 = I0 with { LightEmission = 11, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I24 = I0 with { LightEmission = 12 };
    private static readonly BlockStateInfo I25 = I0 with { LightEmission = 12, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I26 = I0 with { LightEmission = 13 };
    private static readonly BlockStateInfo I27 = I0 with { LightEmission = 13, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I28 = I0 with { LightEmission = 14 };
    private static readonly BlockStateInfo I29 = I0 with { LightEmission = 14, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I30 = I0 with { LightEmission = 15 };
    private static readonly BlockStateInfo I31 = I0 with { LightEmission = 15, LightDampening = 0, MapColorId = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 14382];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Level switch {
                0 => Waterlogged switch {
                    true => 14382,
                    false => 14383,
                },
                1 => Waterlogged switch {
                    true => 14384,
                    false => 14385,
                },
                2 => Waterlogged switch {
                    true => 14386,
                    false => 14387,
                },
                3 => Waterlogged switch {
                    true => 14388,
                    false => 14389,
                },
                4 => Waterlogged switch {
                    true => 14390,
                    false => 14391,
                },
                5 => Waterlogged switch {
                    true => 14392,
                    false => 14393,
                },
                6 => Waterlogged switch {
                    true => 14394,
                    false => 14395,
                },
                7 => Waterlogged switch {
                    true => 14396,
                    false => 14397,
                },
                8 => Waterlogged switch {
                    true => 14398,
                    false => 14399,
                },
                9 => Waterlogged switch {
                    true => 14400,
                    false => 14401,
                },
                10 => Waterlogged switch {
                    true => 14402,
                    false => 14403,
                },
                11 => Waterlogged switch {
                    true => 14404,
                    false => 14405,
                },
                12 => Waterlogged switch {
                    true => 14406,
                    false => 14407,
                },
                13 => Waterlogged switch {
                    true => 14408,
                    false => 14409,
                },
                14 => Waterlogged switch {
                    true => 14410,
                    false => 14411,
                },
                15 => Waterlogged switch {
                    true => 14412,
                    false => 14413,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14382 => new LightBlock(Identifier, 0, true),
            14383 => new LightBlock(Identifier, 0, false),
            14384 => new LightBlock(Identifier, 1, true),
            14385 => new LightBlock(Identifier, 1, false),
            14386 => new LightBlock(Identifier, 2, true),
            14387 => new LightBlock(Identifier, 2, false),
            14388 => new LightBlock(Identifier, 3, true),
            14389 => new LightBlock(Identifier, 3, false),
            14390 => new LightBlock(Identifier, 4, true),
            14391 => new LightBlock(Identifier, 4, false),
            14392 => new LightBlock(Identifier, 5, true),
            14393 => new LightBlock(Identifier, 5, false),
            14394 => new LightBlock(Identifier, 6, true),
            14395 => new LightBlock(Identifier, 6, false),
            14396 => new LightBlock(Identifier, 7, true),
            14397 => new LightBlock(Identifier, 7, false),
            14398 => new LightBlock(Identifier, 8, true),
            14399 => new LightBlock(Identifier, 8, false),
            14400 => new LightBlock(Identifier, 9, true),
            14401 => new LightBlock(Identifier, 9, false),
            14402 => new LightBlock(Identifier, 10, true),
            14403 => new LightBlock(Identifier, 10, false),
            14404 => new LightBlock(Identifier, 11, true),
            14405 => new LightBlock(Identifier, 11, false),
            14406 => new LightBlock(Identifier, 12, true),
            14407 => new LightBlock(Identifier, 12, false),
            14408 => new LightBlock(Identifier, 13, true),
            14409 => new LightBlock(Identifier, 13, false),
            14410 => new LightBlock(Identifier, 14, true),
            14411 => new LightBlock(Identifier, 14, false),
            14412 => new LightBlock(Identifier, 15, true),
            14413 => new LightBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.Contains("level") ? int.Parse(properties["level"].GetString()) : Level,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("level", new StringTag(Level.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
