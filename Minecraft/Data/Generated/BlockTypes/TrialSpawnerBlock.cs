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
                    TrialSpawnerState.Inactive => 32150,
                    TrialSpawnerState.WaitingForPlayers => 32151,
                    TrialSpawnerState.Active => 32152,
                    TrialSpawnerState.WaitingForRewardEjection => 32153,
                    TrialSpawnerState.EjectingReward => 32154,
                    TrialSpawnerState.Cooldown => 32155,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
                false => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 32156,
                    TrialSpawnerState.WaitingForPlayers => 32157,
                    TrialSpawnerState.Active => 32158,
                    TrialSpawnerState.WaitingForRewardEjection => 32159,
                    TrialSpawnerState.EjectingReward => 32160,
                    TrialSpawnerState.Cooldown => 32161,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32150 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Inactive),
            32151 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForPlayers),
            32152 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Active),
            32153 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForRewardEjection),
            32154 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.EjectingReward),
            32155 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Cooldown),
            32156 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Inactive),
            32157 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForPlayers),
            32158 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Active),
            32159 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForRewardEjection),
            32160 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.EjectingReward),
            32161 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Cooldown),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Ominous = properties.Contains("ominous") ? properties["ominous"].GetString() == "true" : Ominous,
            TrialSpawnerStateValue = properties.Contains("trial_spawner_state") ? TrialSpawnerStateFromString(properties["trial_spawner_state"].GetString()) : TrialSpawnerStateValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("ominous", new StringTag(Ominous.ToString().ToLower())),
            ("trial_spawner_state", new StringTag(TrialSpawnerStateToName(TrialSpawnerStateValue)))
        );
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

    public static string TrialSpawnerStateToName(TrialSpawnerState value) {
        return value switch {
            TrialSpawnerState.Inactive => "inactive",
            TrialSpawnerState.WaitingForPlayers => "waiting_for_players",
            TrialSpawnerState.Active => "active",
            TrialSpawnerState.WaitingForRewardEjection => "waiting_for_reward_ejection",
            TrialSpawnerState.EjectingReward => "ejecting_reward",
            TrialSpawnerState.Cooldown => "cooldown",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TrialSpawnerState value.")
        };
    }
}
