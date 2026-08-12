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
    public Identifier Category => "minecraft:potent_sulfur";
    public double Hardness => 1.5;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "potent_sulfur";
    public Identifier? BlockEntity => "minecraft:potent_sulfur";
    public Identifier? Item => "minecraft:potent_sulfur";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 30;
    public string TranslationKey => "block.minecraft.potent_sulfur";
    public bool CanRespawnIn => false;


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
