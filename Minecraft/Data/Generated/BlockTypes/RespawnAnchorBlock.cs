using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RespawnAnchorBlock(Identifier Identifier, int Charges) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:respawn_anchor", "block.minecraft.respawn_anchor", 1200f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:respawn_anchor", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(50f, 0, 15, PushReaction.Normal, 29, "stone", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, true, false, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 3 };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 7 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 11 };
    private static readonly BlockStateInfo I4 = I0 with { LightEmission = 15, ValidSpawnFor = [] };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4
    ];

    public BlockStateInfo StateInfo => States[StateId - 21821];

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
            return Charges switch {
                0 => 21821,
                1 => 21822,
                2 => 21823,
                3 => 21824,
                4 => 21825,
                _ => throw new ArgumentOutOfRangeException(nameof(Charges), Charges, "Unknown value for property charges.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21821 => new RespawnAnchorBlock(Identifier, 0),
            21822 => new RespawnAnchorBlock(Identifier, 1),
            21823 => new RespawnAnchorBlock(Identifier, 2),
            21824 => new RespawnAnchorBlock(Identifier, 3),
            21825 => new RespawnAnchorBlock(Identifier, 4),
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
