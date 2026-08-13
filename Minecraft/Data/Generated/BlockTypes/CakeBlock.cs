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
public record CakeBlock(Identifier Identifier, int Bites) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:cake", "block.minecraft.cake", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cake", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Destroy, 0, "wool", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S404, BlockShapes.S404, BlockShapes.S1, BlockShapes.S404, BlockShapes.S404, BlockShapes.S404);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S405, CollisionShape = BlockShapes.S405, OcclusionShape = BlockShapes.S405, VisualShape = BlockShapes.S405, SupportShape = BlockShapes.S405 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S406, CollisionShape = BlockShapes.S406, OcclusionShape = BlockShapes.S406, VisualShape = BlockShapes.S406, SupportShape = BlockShapes.S406 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S407, CollisionShape = BlockShapes.S407, OcclusionShape = BlockShapes.S407, VisualShape = BlockShapes.S407, SupportShape = BlockShapes.S407 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S408, CollisionShape = BlockShapes.S408, OcclusionShape = BlockShapes.S408, VisualShape = BlockShapes.S408, SupportShape = BlockShapes.S408 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S409, CollisionShape = BlockShapes.S409, OcclusionShape = BlockShapes.S409, VisualShape = BlockShapes.S409, SupportShape = BlockShapes.S409 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S410, CollisionShape = BlockShapes.S410, OcclusionShape = BlockShapes.S410, VisualShape = BlockShapes.S410, SupportShape = BlockShapes.S410 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6
    ];

    public BlockStateInfo StateInfo => States[StateId - 7027];

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
            return Bites switch {
                0 => 7027,
                1 => 7028,
                2 => 7029,
                3 => 7030,
                4 => 7031,
                5 => 7032,
                6 => 7033,
                _ => throw new ArgumentOutOfRangeException(nameof(Bites), Bites, "Unknown value for property bites.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7027 => new CakeBlock(Identifier, 0),
            7028 => new CakeBlock(Identifier, 1),
            7029 => new CakeBlock(Identifier, 2),
            7030 => new CakeBlock(Identifier, 3),
            7031 => new CakeBlock(Identifier, 4),
            7032 => new CakeBlock(Identifier, 5),
            7033 => new CakeBlock(Identifier, 6),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bites = properties.Contains("bites") ? int.Parse(properties["bites"].GetString()) : Bites,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bites", new StringTag(Bites.ToString()))
        );
    }
    
}
