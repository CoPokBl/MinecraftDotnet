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
    public int ProtocolId => 1155;
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
                    TrialSpawnerState.Inactive => 29455,
                    TrialSpawnerState.WaitingForPlayers => 29456,
                    TrialSpawnerState.Active => 29457,
                    TrialSpawnerState.WaitingForRewardEjection => 29458,
                    TrialSpawnerState.EjectingReward => 29459,
                    TrialSpawnerState.Cooldown => 29460,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
                false => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 29461,
                    TrialSpawnerState.WaitingForPlayers => 29462,
                    TrialSpawnerState.Active => 29463,
                    TrialSpawnerState.WaitingForRewardEjection => 29464,
                    TrialSpawnerState.EjectingReward => 29465,
                    TrialSpawnerState.Cooldown => 29466,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29455 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Inactive),
            29456 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForPlayers),
            29457 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Active),
            29458 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForRewardEjection),
            29459 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.EjectingReward),
            29460 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Cooldown),
            29461 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Inactive),
            29462 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForPlayers),
            29463 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Active),
            29464 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForRewardEjection),
            29465 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.EjectingReward),
            29466 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Cooldown),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Ominous = properties.ChildrenMap.ContainsKey("ominous") ? properties["ominous"].GetString() == "true" : Ominous,
            TrialSpawnerStateValue = properties.ChildrenMap.ContainsKey("trial_spawner_state") ? TrialSpawnerStateFromString(properties["trial_spawner_state"].GetString()) : TrialSpawnerStateValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("ominous", Ominous.ToString().ToLower()),
            new StringTag("trial_spawner_state", TrialSpawnerStateToName(TrialSpawnerStateValue))
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
