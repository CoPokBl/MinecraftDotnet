using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:candle", "block.minecraft.pink_candle", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pink_candle", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.1f, 3, 1, PushReaction.Destroy, 20, "candle", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S364, BlockShapes.S364, BlockShapes.S1, BlockShapes.S1, BlockShapes.S364);
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

    public BlockStateInfo StateInfo => States[StateId - 23208];

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
                        true => 23208,
                        false => 23209,
                    },
                    false => Waterlogged switch {
                        true => 23210,
                        false => 23211,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23212,
                        false => 23213,
                    },
                    false => Waterlogged switch {
                        true => 23214,
                        false => 23215,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23216,
                        false => 23217,
                    },
                    false => Waterlogged switch {
                        true => 23218,
                        false => 23219,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23220,
                        false => 23221,
                    },
                    false => Waterlogged switch {
                        true => 23222,
                        false => 23223,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23208 => new PinkCandleBlock(Identifier, 1, true, true),
            23209 => new PinkCandleBlock(Identifier, 1, true, false),
            23210 => new PinkCandleBlock(Identifier, 1, false, true),
            23211 => new PinkCandleBlock(Identifier, 1, false, false),
            23212 => new PinkCandleBlock(Identifier, 2, true, true),
            23213 => new PinkCandleBlock(Identifier, 2, true, false),
            23214 => new PinkCandleBlock(Identifier, 2, false, true),
            23215 => new PinkCandleBlock(Identifier, 2, false, false),
            23216 => new PinkCandleBlock(Identifier, 3, true, true),
            23217 => new PinkCandleBlock(Identifier, 3, true, false),
            23218 => new PinkCandleBlock(Identifier, 3, false, true),
            23219 => new PinkCandleBlock(Identifier, 3, false, false),
            23220 => new PinkCandleBlock(Identifier, 4, true, true),
            23221 => new PinkCandleBlock(Identifier, 4, true, false),
            23222 => new PinkCandleBlock(Identifier, 4, false, true),
            23223 => new PinkCandleBlock(Identifier, 4, false, false),
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
