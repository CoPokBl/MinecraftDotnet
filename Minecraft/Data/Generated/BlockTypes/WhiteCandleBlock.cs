using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:candle", "block.minecraft.white_candle", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:white_candle", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.1f, 3, 1, PushReaction.Destroy, 3, "candle", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S364, BlockShapes.S364, BlockShapes.S1, BlockShapes.S1, BlockShapes.S364);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 6, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 6, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I8 = I0 with { LightEmission = 9, BlockShape = BlockShapes.S366, CollisionShape = BlockShapes.S366, VisualShape = BlockShapes.S366 };
    private static readonly BlockStateInfo I9 = I0 with { LightEmission = 9, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S366, CollisionShape = BlockShapes.S366, VisualShape = BlockShapes.S366 };
    private static readonly BlockStateInfo I10 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S366, CollisionShape = BlockShapes.S366, VisualShape = BlockShapes.S366 };
    private static readonly BlockStateInfo I11 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S366, CollisionShape = BlockShapes.S366, VisualShape = BlockShapes.S366 };
    private static readonly BlockStateInfo I12 = I0 with { LightEmission = 12, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I13 = I0 with { LightEmission = 12, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I14 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I15 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15
    ];

    public BlockStateInfo StateInfo => States[StateId - 23112];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23112,
                        false => 23113,
                    },
                    false => Waterlogged switch {
                        true => 23114,
                        false => 23115,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23116,
                        false => 23117,
                    },
                    false => Waterlogged switch {
                        true => 23118,
                        false => 23119,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23120,
                        false => 23121,
                    },
                    false => Waterlogged switch {
                        true => 23122,
                        false => 23123,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23124,
                        false => 23125,
                    },
                    false => Waterlogged switch {
                        true => 23126,
                        false => 23127,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23112 => new WhiteCandleBlock(Identifier, 1, true, true),
            23113 => new WhiteCandleBlock(Identifier, 1, true, false),
            23114 => new WhiteCandleBlock(Identifier, 1, false, true),
            23115 => new WhiteCandleBlock(Identifier, 1, false, false),
            23116 => new WhiteCandleBlock(Identifier, 2, true, true),
            23117 => new WhiteCandleBlock(Identifier, 2, true, false),
            23118 => new WhiteCandleBlock(Identifier, 2, false, true),
            23119 => new WhiteCandleBlock(Identifier, 2, false, false),
            23120 => new WhiteCandleBlock(Identifier, 3, true, true),
            23121 => new WhiteCandleBlock(Identifier, 3, true, false),
            23122 => new WhiteCandleBlock(Identifier, 3, false, true),
            23123 => new WhiteCandleBlock(Identifier, 3, false, false),
            23124 => new WhiteCandleBlock(Identifier, 4, true, true),
            23125 => new WhiteCandleBlock(Identifier, 4, true, false),
            23126 => new WhiteCandleBlock(Identifier, 4, false, true),
            23127 => new WhiteCandleBlock(Identifier, 4, false, false),
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
