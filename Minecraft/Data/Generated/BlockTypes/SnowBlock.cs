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
public record SnowBlock(Identifier Identifier, int Layers) : IBlock, IStackable {
    private static readonly BlockInfo Data = new("block.minecraft.snow", 0.1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:snow", BlockInfo.VanillaOnly, "minecraft:blocks/snow");
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 0, PushReaction.Popped, 8, "snow", NoteBlockInstrument.Harp, true, true, true, false, false, false, true, false, false, false, true, false, false, false, true, true, false, false, [], null, BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S124, BlockShapes.S124, BlockShapes.S124);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S333, CollisionShape = BlockShapes.S124, OcclusionShape = BlockShapes.S333, VisualShape = BlockShapes.S333, SupportShape = BlockShapes.S333 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S334, CollisionShape = BlockShapes.S333, OcclusionShape = BlockShapes.S334, VisualShape = BlockShapes.S334, SupportShape = BlockShapes.S334 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S334, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89, SupportShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { PathfindableLand = false, BlockShape = BlockShapes.S932, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S932, VisualShape = BlockShapes.S932, SupportShape = BlockShapes.S932 };
    private static readonly BlockStateInfo I5 = I0 with { PathfindableLand = false, BlockShape = BlockShapes.S525, CollisionShape = BlockShapes.S932, OcclusionShape = BlockShapes.S525, VisualShape = BlockShapes.S525, SupportShape = BlockShapes.S525 };
    private static readonly BlockStateInfo I6 = I0 with { PathfindableLand = false, BlockShape = BlockShapes.S656, CollisionShape = BlockShapes.S525, OcclusionShape = BlockShapes.S656, VisualShape = BlockShapes.S656, SupportShape = BlockShapes.S656 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 15, ViewBlocking = true, PathfindableLand = false, ValidSpawnFor = null, BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S656, OcclusionShape = BlockShapes.S79, VisualShape = BlockShapes.S79, SupportShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 8589];

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

    public int Count => Layers;

    public int MaxCount => 8;

    public IBlock WithCount(int count) => this with { Layers = count };


    public uint StateId {
        get {
            return Layers switch {
                1 => 8589,
                2 => 8590,
                3 => 8591,
                4 => 8592,
                5 => 8593,
                6 => 8594,
                7 => 8595,
                8 => 8596,
                _ => throw new ArgumentOutOfRangeException(nameof(Layers), Layers, "Unknown value for property layers.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8589 => new SnowBlock(Identifier, 1),
            8590 => new SnowBlock(Identifier, 2),
            8591 => new SnowBlock(Identifier, 3),
            8592 => new SnowBlock(Identifier, 4),
            8593 => new SnowBlock(Identifier, 5),
            8594 => new SnowBlock(Identifier, 6),
            8595 => new SnowBlock(Identifier, 7),
            8596 => new SnowBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Layers = properties.Contains("layers") ? int.Parse(properties["layers"].GetString()) : Layers,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("layers", new StringTag(Layers.ToString()))
        );
    }
    
}
