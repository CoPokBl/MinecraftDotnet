using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PotentSulfurBlock(Identifier Identifier, PotentSulfurBlock.PotentSulfurState PotentSulfurStateValue) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:potent_sulfur", "block.minecraft.potent_sulfur", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:potent_sulfur", "minecraft:potent_sulfur", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 15, PushReaction.Normal, 30, "potent_sulfur", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, true, false, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);

    public BlockStateInfo StateInfo => I0;

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
            return PotentSulfurStateValue switch {
                PotentSulfurState.Dry => 24688,
                PotentSulfurState.Wet => 24689,
                PotentSulfurState.Dormant => 24690,
                PotentSulfurState.Erupting => 24691,
                PotentSulfurState.Continuous => 24692,
                _ => throw new ArgumentOutOfRangeException(nameof(PotentSulfurStateValue), PotentSulfurStateValue, "Unknown value for property potent_sulfur_state.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24688 => new PotentSulfurBlock(Identifier, PotentSulfurState.Dry),
            24689 => new PotentSulfurBlock(Identifier, PotentSulfurState.Wet),
            24690 => new PotentSulfurBlock(Identifier, PotentSulfurState.Dormant),
            24691 => new PotentSulfurBlock(Identifier, PotentSulfurState.Erupting),
            24692 => new PotentSulfurBlock(Identifier, PotentSulfurState.Continuous),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            PotentSulfurStateValue = properties.Contains("potent_sulfur_state") ? PotentSulfurStateFromString(properties["potent_sulfur_state"].GetString()) : PotentSulfurStateValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("potent_sulfur_state", new StringTag(PotentSulfurStateToName(PotentSulfurStateValue)))
        );
    }
    
    public enum PotentSulfurState {
        Dry,
        Wet,
        Dormant,
        Erupting,
        Continuous,
    }

    public static PotentSulfurState PotentSulfurStateFromString(string value) {
        return value switch {
            "dry" => PotentSulfurState.Dry,
            "wet" => PotentSulfurState.Wet,
            "dormant" => PotentSulfurState.Dormant,
            "erupting" => PotentSulfurState.Erupting,
            "continuous" => PotentSulfurState.Continuous,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for PotentSulfurState.")
        };
    }

    public static string PotentSulfurStateToName(PotentSulfurState value) {
        return value switch {
            PotentSulfurState.Dry => "dry",
            PotentSulfurState.Wet => "wet",
            PotentSulfurState.Dormant => "dormant",
            PotentSulfurState.Erupting => "erupting",
            PotentSulfurState.Continuous => "continuous",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PotentSulfurState value.")
        };
    }
}
