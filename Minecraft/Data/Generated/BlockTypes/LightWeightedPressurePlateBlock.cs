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
public record LightWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.light_weighted_pressure_plate", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:light_weighted_pressure_plate", BlockInfo.VanillaOnly, "minecraft:blocks/light_weighted_pressure_plate");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 30, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, true, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S81, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S80 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 12998];

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
            return Power switch {
                0 => 12998,
                1 => 12999,
                2 => 13000,
                3 => 13001,
                4 => 13002,
                5 => 13003,
                6 => 13004,
                7 => 13005,
                8 => 13006,
                9 => 13007,
                10 => 13008,
                11 => 13009,
                12 => 13010,
                13 => 13011,
                14 => 13012,
                15 => 13013,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12998 => new LightWeightedPressurePlateBlock(Identifier, 0),
            12999 => new LightWeightedPressurePlateBlock(Identifier, 1),
            13000 => new LightWeightedPressurePlateBlock(Identifier, 2),
            13001 => new LightWeightedPressurePlateBlock(Identifier, 3),
            13002 => new LightWeightedPressurePlateBlock(Identifier, 4),
            13003 => new LightWeightedPressurePlateBlock(Identifier, 5),
            13004 => new LightWeightedPressurePlateBlock(Identifier, 6),
            13005 => new LightWeightedPressurePlateBlock(Identifier, 7),
            13006 => new LightWeightedPressurePlateBlock(Identifier, 8),
            13007 => new LightWeightedPressurePlateBlock(Identifier, 9),
            13008 => new LightWeightedPressurePlateBlock(Identifier, 10),
            13009 => new LightWeightedPressurePlateBlock(Identifier, 11),
            13010 => new LightWeightedPressurePlateBlock(Identifier, 12),
            13011 => new LightWeightedPressurePlateBlock(Identifier, 13),
            13012 => new LightWeightedPressurePlateBlock(Identifier, 14),
            13013 => new LightWeightedPressurePlateBlock(Identifier, 15),
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
