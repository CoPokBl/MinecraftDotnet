using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SnowBlock(Identifier Identifier, int Layers) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:snow_layer", "block.minecraft.snow", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:snow", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 0, PushReaction.Destroy, 8, "snow", NoteBlockInstrument.Harp, true, true, true, false, false, false, false, true, false, false, false, true, false, false, true, [], null, BlockShapes.S122, BlockShapes.S1, BlockShapes.S1, BlockShapes.S122, BlockShapes.S122);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S331, CollisionShape = BlockShapes.S122, OcclusionShape = BlockShapes.S331, VisualShape = BlockShapes.S331 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S332, CollisionShape = BlockShapes.S331, OcclusionShape = BlockShapes.S332, VisualShape = BlockShapes.S332 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S332, OcclusionShape = BlockShapes.S87, VisualShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S921, CollisionShape = BlockShapes.S87, OcclusionShape = BlockShapes.S921, VisualShape = BlockShapes.S921 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S522, CollisionShape = BlockShapes.S921, OcclusionShape = BlockShapes.S522, VisualShape = BlockShapes.S522 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S653, CollisionShape = BlockShapes.S522, OcclusionShape = BlockShapes.S653, VisualShape = BlockShapes.S653 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 15, ViewBlocking = true, ValidSpawnFor = null, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S653, OcclusionShape = BlockShapes.S77, VisualShape = BlockShapes.S77 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 6919];

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
            return Layers switch {
                1 => 6919,
                2 => 6920,
                3 => 6921,
                4 => 6922,
                5 => 6923,
                6 => 6924,
                7 => 6925,
                8 => 6926,
                _ => throw new ArgumentOutOfRangeException(nameof(Layers), Layers, "Unknown value for property layers.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6919 => new SnowBlock(Identifier, 1),
            6920 => new SnowBlock(Identifier, 2),
            6921 => new SnowBlock(Identifier, 3),
            6922 => new SnowBlock(Identifier, 4),
            6923 => new SnowBlock(Identifier, 5),
            6924 => new SnowBlock(Identifier, 6),
            6925 => new SnowBlock(Identifier, 7),
            6926 => new SnowBlock(Identifier, 8),
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
