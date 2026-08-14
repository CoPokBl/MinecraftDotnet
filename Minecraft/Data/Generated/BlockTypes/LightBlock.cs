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
    private static readonly BlockInfo Data = new("minecraft:light", "block.minecraft.light", 3600000.8f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:light", BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 1, PushReaction.Normal, 12, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 1 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 1, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 2 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 2, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 3 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 3, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I8 = I0 with { LightEmission = 4 };
    private static readonly BlockStateInfo I9 = I0 with { LightEmission = 4, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I10 = I0 with { LightEmission = 5 };
    private static readonly BlockStateInfo I11 = I0 with { LightEmission = 5, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I12 = I0 with { LightEmission = 6 };
    private static readonly BlockStateInfo I13 = I0 with { LightEmission = 6, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I14 = I0 with { LightEmission = 7 };
    private static readonly BlockStateInfo I15 = I0 with { LightEmission = 7, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I16 = I0 with { LightEmission = 8 };
    private static readonly BlockStateInfo I17 = I0 with { LightEmission = 8, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I18 = I0 with { LightEmission = 9 };
    private static readonly BlockStateInfo I19 = I0 with { LightEmission = 9, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I20 = I0 with { LightEmission = 10 };
    private static readonly BlockStateInfo I21 = I0 with { LightEmission = 10, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I22 = I0 with { LightEmission = 11 };
    private static readonly BlockStateInfo I23 = I0 with { LightEmission = 11, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I24 = I0 with { LightEmission = 12 };
    private static readonly BlockStateInfo I25 = I0 with { LightEmission = 12, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I26 = I0 with { LightEmission = 13 };
    private static readonly BlockStateInfo I27 = I0 with { LightEmission = 13, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I28 = I0 with { LightEmission = 14 };
    private static readonly BlockStateInfo I29 = I0 with { LightEmission = 14, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo I30 = I0 with { LightEmission = 15 };
    private static readonly BlockStateInfo I31 = I0 with { LightEmission = 15, LightDampening = 0, MapColorId = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31
    ];

    public BlockStateInfo StateInfo => States[StateId - 12535];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Level switch {
                0 => Waterlogged switch {
                    true => 12535,
                    false => 12536,
                },
                1 => Waterlogged switch {
                    true => 12537,
                    false => 12538,
                },
                2 => Waterlogged switch {
                    true => 12539,
                    false => 12540,
                },
                3 => Waterlogged switch {
                    true => 12541,
                    false => 12542,
                },
                4 => Waterlogged switch {
                    true => 12543,
                    false => 12544,
                },
                5 => Waterlogged switch {
                    true => 12545,
                    false => 12546,
                },
                6 => Waterlogged switch {
                    true => 12547,
                    false => 12548,
                },
                7 => Waterlogged switch {
                    true => 12549,
                    false => 12550,
                },
                8 => Waterlogged switch {
                    true => 12551,
                    false => 12552,
                },
                9 => Waterlogged switch {
                    true => 12553,
                    false => 12554,
                },
                10 => Waterlogged switch {
                    true => 12555,
                    false => 12556,
                },
                11 => Waterlogged switch {
                    true => 12557,
                    false => 12558,
                },
                12 => Waterlogged switch {
                    true => 12559,
                    false => 12560,
                },
                13 => Waterlogged switch {
                    true => 12561,
                    false => 12562,
                },
                14 => Waterlogged switch {
                    true => 12563,
                    false => 12564,
                },
                15 => Waterlogged switch {
                    true => 12565,
                    false => 12566,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12535 => new LightBlock(Identifier, 0, true),
            12536 => new LightBlock(Identifier, 0, false),
            12537 => new LightBlock(Identifier, 1, true),
            12538 => new LightBlock(Identifier, 1, false),
            12539 => new LightBlock(Identifier, 2, true),
            12540 => new LightBlock(Identifier, 2, false),
            12541 => new LightBlock(Identifier, 3, true),
            12542 => new LightBlock(Identifier, 3, false),
            12543 => new LightBlock(Identifier, 4, true),
            12544 => new LightBlock(Identifier, 4, false),
            12545 => new LightBlock(Identifier, 5, true),
            12546 => new LightBlock(Identifier, 5, false),
            12547 => new LightBlock(Identifier, 6, true),
            12548 => new LightBlock(Identifier, 6, false),
            12549 => new LightBlock(Identifier, 7, true),
            12550 => new LightBlock(Identifier, 7, false),
            12551 => new LightBlock(Identifier, 8, true),
            12552 => new LightBlock(Identifier, 8, false),
            12553 => new LightBlock(Identifier, 9, true),
            12554 => new LightBlock(Identifier, 9, false),
            12555 => new LightBlock(Identifier, 10, true),
            12556 => new LightBlock(Identifier, 10, false),
            12557 => new LightBlock(Identifier, 11, true),
            12558 => new LightBlock(Identifier, 11, false),
            12559 => new LightBlock(Identifier, 12, true),
            12560 => new LightBlock(Identifier, 12, false),
            12561 => new LightBlock(Identifier, 13, true),
            12562 => new LightBlock(Identifier, 13, false),
            12563 => new LightBlock(Identifier, 14, true),
            12564 => new LightBlock(Identifier, 14, false),
            12565 => new LightBlock(Identifier, 15, true),
            12566 => new LightBlock(Identifier, 15, false),
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
