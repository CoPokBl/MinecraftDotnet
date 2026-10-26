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
public record RedCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock, IStackable, ILit, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.red_candle", 0.1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:red_candle", BlockInfo.VanillaOnly, "minecraft:blocks/red_candle");
    private static readonly BlockStateInfo I0 = new(0.1f, 3, 1, PushReaction.Popped, 28, "candle", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S366, BlockShapes.S366, BlockShapes.S1, BlockShapes.S1, BlockShapes.S366, BlockShapes.S366);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 6, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 6, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 0, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S367, CollisionShape = BlockShapes.S367, VisualShape = BlockShapes.S367, SupportShape = BlockShapes.S367 };
    private static readonly BlockStateInfo I8 = I0 with { LightEmission = 9, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I9 = I0 with { LightEmission = 9, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I10 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I11 = I0 with { LightEmission = 0, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S368, CollisionShape = BlockShapes.S368, VisualShape = BlockShapes.S368, SupportShape = BlockShapes.S368 };
    private static readonly BlockStateInfo I12 = I0 with { LightEmission = 12, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I13 = I0 with { LightEmission = 12, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I14 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo I15 = I0 with { LightEmission = 0, LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S369, CollisionShape = BlockShapes.S369, VisualShape = BlockShapes.S369, SupportShape = BlockShapes.S369 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15
    ];

    public BlockStateInfo StateInfo => States[StateId - 26693];

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
                        true => 26693,
                        false => 26694,
                    },
                    false => Waterlogged switch {
                        true => 26695,
                        false => 26696,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 26697,
                        false => 26698,
                    },
                    false => Waterlogged switch {
                        true => 26699,
                        false => 26700,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 26701,
                        false => 26702,
                    },
                    false => Waterlogged switch {
                        true => 26703,
                        false => 26704,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 26705,
                        false => 26706,
                    },
                    false => Waterlogged switch {
                        true => 26707,
                        false => 26708,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26693 => new RedCandleBlock(Identifier, 1, true, true),
            26694 => new RedCandleBlock(Identifier, 1, true, false),
            26695 => new RedCandleBlock(Identifier, 1, false, true),
            26696 => new RedCandleBlock(Identifier, 1, false, false),
            26697 => new RedCandleBlock(Identifier, 2, true, true),
            26698 => new RedCandleBlock(Identifier, 2, true, false),
            26699 => new RedCandleBlock(Identifier, 2, false, true),
            26700 => new RedCandleBlock(Identifier, 2, false, false),
            26701 => new RedCandleBlock(Identifier, 3, true, true),
            26702 => new RedCandleBlock(Identifier, 3, true, false),
            26703 => new RedCandleBlock(Identifier, 3, false, true),
            26704 => new RedCandleBlock(Identifier, 3, false, false),
            26705 => new RedCandleBlock(Identifier, 4, true, true),
            26706 => new RedCandleBlock(Identifier, 4, true, false),
            26707 => new RedCandleBlock(Identifier, 4, false, true),
            26708 => new RedCandleBlock(Identifier, 4, false, false),
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
