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
public record FarmlandBlock(Identifier Identifier, int Moisture) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.farmland", 0.6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:farmland", BlockInfo.VanillaOnly, "minecraft:blocks/farmland");
    private static readonly BlockStateInfo I0 = new(0.6f, 0, 0, PushReaction.PushPull, 10, "gravel", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, false, true, true, true, false, true, false, false, false, [], null, BlockShapes.S522, BlockShapes.S522, BlockShapes.S1, BlockShapes.S522, BlockShapes.S522, BlockShapes.S522);

    public BlockStateInfo StateInfo => I0;

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
            return Moisture switch {
                0 => 6875,
                1 => 6876,
                2 => 6877,
                3 => 6878,
                4 => 6879,
                5 => 6880,
                6 => 6881,
                7 => 6882,
                _ => throw new ArgumentOutOfRangeException(nameof(Moisture), Moisture, "Unknown value for property moisture.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6875 => new FarmlandBlock(Identifier, 0),
            6876 => new FarmlandBlock(Identifier, 1),
            6877 => new FarmlandBlock(Identifier, 2),
            6878 => new FarmlandBlock(Identifier, 3),
            6879 => new FarmlandBlock(Identifier, 4),
            6880 => new FarmlandBlock(Identifier, 5),
            6881 => new FarmlandBlock(Identifier, 6),
            6882 => new FarmlandBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Moisture = properties.Contains("moisture") ? int.Parse(properties["moisture"].GetString()) : Moisture,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("moisture", new StringTag(Moisture.ToString()))
        );
    }
    
}
