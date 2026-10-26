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
public record ComposterBlock(Identifier Identifier, int Level) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.composter", 0.6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:composter", BlockInfo.VanillaOnly, "minecraft:blocks/composter");
    private static readonly BlockStateInfo I0 = new(0.6f, 0, 0, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S496, BlockShapes.S496, BlockShapes.S79, BlockShapes.S496, BlockShapes.S496, BlockShapes.S496);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S497, OcclusionShape = BlockShapes.S497 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S498, OcclusionShape = BlockShapes.S498 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S499, OcclusionShape = BlockShapes.S499 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S500, OcclusionShape = BlockShapes.S500 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S501, OcclusionShape = BlockShapes.S501 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S502, OcclusionShape = BlockShapes.S502 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S503, OcclusionShape = BlockShapes.S503 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 25100];

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


    public uint StateId {
        get {
            return Level switch {
                0 => 25100,
                1 => 25101,
                2 => 25102,
                3 => 25103,
                4 => 25104,
                5 => 25105,
                6 => 25106,
                7 => 25107,
                8 => 25108,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25100 => new ComposterBlock(Identifier, 0),
            25101 => new ComposterBlock(Identifier, 1),
            25102 => new ComposterBlock(Identifier, 2),
            25103 => new ComposterBlock(Identifier, 3),
            25104 => new ComposterBlock(Identifier, 4),
            25105 => new ComposterBlock(Identifier, 5),
            25106 => new ComposterBlock(Identifier, 6),
            25107 => new ComposterBlock(Identifier, 7),
            25108 => new ComposterBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.Contains("level") ? int.Parse(properties["level"].GetString()) : Level,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("level", new StringTag(Level.ToString()))
        );
    }
    
}
