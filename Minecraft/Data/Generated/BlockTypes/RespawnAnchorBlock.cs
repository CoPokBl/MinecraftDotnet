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
public record RespawnAnchorBlock(Identifier Identifier, int Charges) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.respawn_anchor", 1200f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:respawn_anchor", BlockInfo.VanillaOnly, "minecraft:blocks/respawn_anchor");
    private static readonly BlockStateInfo I0 = new(50f, 0, 15, PushReaction.Immoveable, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 3 };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 7 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 11 };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 15, ValidSpawnFor = [] };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4
    ];

    public BlockStateInfo StateInfo => States[StateId - 25178];

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
            return Charges switch {
                0 => 25178,
                1 => 25179,
                2 => 25180,
                3 => 25181,
                4 => 25182,
                _ => throw new ArgumentOutOfRangeException(nameof(Charges), Charges, "Unknown value for property charges.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25178 => new RespawnAnchorBlock(Identifier, 0),
            25179 => new RespawnAnchorBlock(Identifier, 1),
            25180 => new RespawnAnchorBlock(Identifier, 2),
            25181 => new RespawnAnchorBlock(Identifier, 3),
            25182 => new RespawnAnchorBlock(Identifier, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Charges = properties.Contains("charges") ? int.Parse(properties["charges"].GetString()) : Charges,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("charges", new StringTag(Charges.ToString()))
        );
    }
    
}
