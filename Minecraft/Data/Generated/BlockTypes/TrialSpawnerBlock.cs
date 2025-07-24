using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TrialSpawnerBlock(Identifier Identifier, bool Ominous, TrialSpawnerBlock.TrialSpawnerState TrialSpawnerStateValue) : IBlock {

    public Identifier Category => "minecraft:trial_spawner";
    public int ProtocolId => 1094;
    public double Hardness => 50;
    public double ExplosionResistance => 50;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "trial_spawner";
    public Identifier? BlockEntity => "minecraft:trial_spawner";
    public Identifier? Item => "minecraft:trial_spawner";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.trial_spawner";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Ominous switch {
                true => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 27730,
                    TrialSpawnerState.WaitingForPlayers => 27731,
                    TrialSpawnerState.Active => 27732,
                    TrialSpawnerState.WaitingForRewardEjection => 27733,
                    TrialSpawnerState.EjectingReward => 27734,
                    TrialSpawnerState.Cooldown => 27735,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
                false => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 27736,
                    TrialSpawnerState.WaitingForPlayers => 27737,
                    TrialSpawnerState.Active => 27738,
                    TrialSpawnerState.WaitingForRewardEjection => 27739,
                    TrialSpawnerState.EjectingReward => 27740,
                    TrialSpawnerState.Cooldown => 27741,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27730 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Inactive),
            27731 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForPlayers),
            27732 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Active),
            27733 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForRewardEjection),
            27734 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.EjectingReward),
            27735 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Cooldown),
            27736 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Inactive),
            27737 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForPlayers),
            27738 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Active),
            27739 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForRewardEjection),
            27740 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.EjectingReward),
            27741 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Cooldown),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Ominous = properties["ominous"].GetString() == "true",
            TrialSpawnerStateValue = TrialSpawnerStateFromString(properties["trial_spawner_state"].GetString()),
        };
    }
    
    public enum TrialSpawnerState {
        Inactive,
        WaitingForPlayers,
        Active,
        WaitingForRewardEjection,
        EjectingReward,
        Cooldown,
    }

    public static TrialSpawnerState TrialSpawnerStateFromString(string value) {
        return value switch {
            "inactive" => TrialSpawnerState.Inactive,
            "waiting_for_players" => TrialSpawnerState.WaitingForPlayers,
            "active" => TrialSpawnerState.Active,
            "waiting_for_reward_ejection" => TrialSpawnerState.WaitingForRewardEjection,
            "ejecting_reward" => TrialSpawnerState.EjectingReward,
            "cooldown" => TrialSpawnerState.Cooldown,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for TrialSpawnerState.")
        };
    }
}
