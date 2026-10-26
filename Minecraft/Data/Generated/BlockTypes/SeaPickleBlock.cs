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
public record SeaPickleBlock(Identifier Identifier, int Pickles, bool Waterlogged) : IBlock, IStackable, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.sea_pickle", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:sea_pickle", BlockInfo.VanillaOnly, "minecraft:blocks/sea_pickle");
    private static readonly BlockStateInfo I0 = new(0f, 6, 1, PushReaction.Popped, 27, "slime_block", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S912, BlockShapes.S912, BlockShapes.S1, BlockShapes.S1, BlockShapes.S912, BlockShapes.S912);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 9, BlockShape = BlockShapes.S913, CollisionShape = BlockShapes.S913, VisualShape = BlockShapes.S913, SupportShape = BlockShapes.S913 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S913, CollisionShape = BlockShapes.S913, VisualShape = BlockShapes.S913, SupportShape = BlockShapes.S913 };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 12, BlockShape = BlockShapes.S914, CollisionShape = BlockShapes.S914, VisualShape = BlockShapes.S914, SupportShape = BlockShapes.S914 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S914, CollisionShape = BlockShapes.S914, VisualShape = BlockShapes.S914, SupportShape = BlockShapes.S914 };
    private static readonly BlockStateInfo I6 = I0 with { LightEmission = 15, BlockShape = BlockShapes.S915, CollisionShape = BlockShapes.S915, VisualShape = BlockShapes.S915, SupportShape = BlockShapes.S915 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 0, LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S915, CollisionShape = BlockShapes.S915, VisualShape = BlockShapes.S915, SupportShape = BlockShapes.S915 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 18624];

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

    public int Count => Pickles;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { Pickles = count };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Pickles switch {
                1 => Waterlogged switch {
                    true => 18624,
                    false => 18625,
                },
                2 => Waterlogged switch {
                    true => 18626,
                    false => 18627,
                },
                3 => Waterlogged switch {
                    true => 18628,
                    false => 18629,
                },
                4 => Waterlogged switch {
                    true => 18630,
                    false => 18631,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Pickles), Pickles, "Unknown value for property pickles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            18624 => new SeaPickleBlock(Identifier, 1, true),
            18625 => new SeaPickleBlock(Identifier, 1, false),
            18626 => new SeaPickleBlock(Identifier, 2, true),
            18627 => new SeaPickleBlock(Identifier, 2, false),
            18628 => new SeaPickleBlock(Identifier, 3, true),
            18629 => new SeaPickleBlock(Identifier, 3, false),
            18630 => new SeaPickleBlock(Identifier, 4, true),
            18631 => new SeaPickleBlock(Identifier, 4, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Pickles = properties.Contains("pickles") ? int.Parse(properties["pickles"].GetString()) : Pickles,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("pickles", new StringTag(Pickles.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
