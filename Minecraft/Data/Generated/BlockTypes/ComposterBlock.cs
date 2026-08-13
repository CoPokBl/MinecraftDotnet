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
    private static readonly BlockInfo Data = new("minecraft:composter", "block.minecraft.composter", 0.6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:composter", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.6f, 0, 0, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S496, BlockShapes.S496, BlockShapes.S79, BlockShapes.S496, BlockShapes.S496, BlockShapes.S496);
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

    public BlockStateInfo StateInfo => States[StateId - 21743];

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


    public uint StateId {
        get {
            return Level switch {
                0 => 21743,
                1 => 21744,
                2 => 21745,
                3 => 21746,
                4 => 21747,
                5 => 21748,
                6 => 21749,
                7 => 21750,
                8 => 21751,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21743 => new ComposterBlock(Identifier, 0),
            21744 => new ComposterBlock(Identifier, 1),
            21745 => new ComposterBlock(Identifier, 2),
            21746 => new ComposterBlock(Identifier, 3),
            21747 => new ComposterBlock(Identifier, 4),
            21748 => new ComposterBlock(Identifier, 5),
            21749 => new ComposterBlock(Identifier, 6),
            21750 => new ComposterBlock(Identifier, 7),
            21751 => new ComposterBlock(Identifier, 8),
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
