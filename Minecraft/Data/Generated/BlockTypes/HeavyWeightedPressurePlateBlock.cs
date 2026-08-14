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
public record HeavyWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weighted_pressure_plate", "block.minecraft.heavy_weighted_pressure_plate", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:heavy_weighted_pressure_plate", BlockInfo.VanillaOnly, "minecraft:blocks/heavy_weighted_pressure_plate");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Destroy, 6, "iron", NoteBlockInstrument.Harp, true, false, false, true, false, false, false, false, true, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S81, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S80 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 11247];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
            return Power switch {
                0 => 11247,
                1 => 11248,
                2 => 11249,
                3 => 11250,
                4 => 11251,
                5 => 11252,
                6 => 11253,
                7 => 11254,
                8 => 11255,
                9 => 11256,
                10 => 11257,
                11 => 11258,
                12 => 11259,
                13 => 11260,
                14 => 11261,
                15 => 11262,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11247 => new HeavyWeightedPressurePlateBlock(Identifier, 0),
            11248 => new HeavyWeightedPressurePlateBlock(Identifier, 1),
            11249 => new HeavyWeightedPressurePlateBlock(Identifier, 2),
            11250 => new HeavyWeightedPressurePlateBlock(Identifier, 3),
            11251 => new HeavyWeightedPressurePlateBlock(Identifier, 4),
            11252 => new HeavyWeightedPressurePlateBlock(Identifier, 5),
            11253 => new HeavyWeightedPressurePlateBlock(Identifier, 6),
            11254 => new HeavyWeightedPressurePlateBlock(Identifier, 7),
            11255 => new HeavyWeightedPressurePlateBlock(Identifier, 8),
            11256 => new HeavyWeightedPressurePlateBlock(Identifier, 9),
            11257 => new HeavyWeightedPressurePlateBlock(Identifier, 10),
            11258 => new HeavyWeightedPressurePlateBlock(Identifier, 11),
            11259 => new HeavyWeightedPressurePlateBlock(Identifier, 12),
            11260 => new HeavyWeightedPressurePlateBlock(Identifier, 13),
            11261 => new HeavyWeightedPressurePlateBlock(Identifier, 14),
            11262 => new HeavyWeightedPressurePlateBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("power", new StringTag(Power.ToString()))
        );
    }
    
}
