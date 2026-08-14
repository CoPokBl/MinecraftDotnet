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
public record MagentaCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock, IStackable, ILit, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:candle", "block.minecraft.magenta_candle", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:magenta_candle", BlockInfo.VanillaOnly, "minecraft:blocks/magenta_candle");
    private static readonly BlockStateInfo I0 = new(0.1f, 3, 1, PushReaction.Destroy, 16, "candle", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S366, BlockShapes.S366, BlockShapes.S1, BlockShapes.S1, BlockShapes.S366, BlockShapes.S366);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 6, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 6, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I8 = I0 with { LightEmission = 9, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I9 = I0 with { LightEmission = 9, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I10 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I11 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I12 = I0 with { LightEmission = 12, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I13 = I0 with { LightEmission = 12, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I14 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I15 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15
    ];

    public BlockStateInfo StateInfo => States[StateId - 23144];

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

    public int Count => Candles;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { Candles = count };

    public IBlock WithLit(bool lit) => this with { Lit = lit };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23144,
                        false => 23145,
                    },
                    false => Waterlogged switch {
                        true => 23146,
                        false => 23147,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23148,
                        false => 23149,
                    },
                    false => Waterlogged switch {
                        true => 23150,
                        false => 23151,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23152,
                        false => 23153,
                    },
                    false => Waterlogged switch {
                        true => 23154,
                        false => 23155,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23156,
                        false => 23157,
                    },
                    false => Waterlogged switch {
                        true => 23158,
                        false => 23159,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23144 => new MagentaCandleBlock(Identifier, 1, true, true),
            23145 => new MagentaCandleBlock(Identifier, 1, true, false),
            23146 => new MagentaCandleBlock(Identifier, 1, false, true),
            23147 => new MagentaCandleBlock(Identifier, 1, false, false),
            23148 => new MagentaCandleBlock(Identifier, 2, true, true),
            23149 => new MagentaCandleBlock(Identifier, 2, true, false),
            23150 => new MagentaCandleBlock(Identifier, 2, false, true),
            23151 => new MagentaCandleBlock(Identifier, 2, false, false),
            23152 => new MagentaCandleBlock(Identifier, 3, true, true),
            23153 => new MagentaCandleBlock(Identifier, 3, true, false),
            23154 => new MagentaCandleBlock(Identifier, 3, false, true),
            23155 => new MagentaCandleBlock(Identifier, 3, false, false),
            23156 => new MagentaCandleBlock(Identifier, 4, true, true),
            23157 => new MagentaCandleBlock(Identifier, 4, true, false),
            23158 => new MagentaCandleBlock(Identifier, 4, false, true),
            23159 => new MagentaCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = properties.Contains("candles") ? int.Parse(properties["candles"].GetString()) : Candles,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("candles", new StringTag(Candles.ToString())),
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
