using Minecraft.Schemas;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: 2025-07-03
public record TrialSpawnerBlock(Identifier Identifier, bool Ominous, TrialSpawnerBlock.TrialSpawnerState TrialSpawnerStateValue) : IBlock {

    public uint StateId {
        get {
            return Ominous switch {
                true => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 27698,
                    TrialSpawnerState.WaitingForPlayers => 27699,
                    TrialSpawnerState.Active => 27700,
                    TrialSpawnerState.WaitingForRewardEjection => 27701,
                    TrialSpawnerState.EjectingReward => 27702,
                    TrialSpawnerState.Cooldown => 27703,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
                false => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 27704,
                    TrialSpawnerState.WaitingForPlayers => 27705,
                    TrialSpawnerState.Active => 27706,
                    TrialSpawnerState.WaitingForRewardEjection => 27707,
                    TrialSpawnerState.EjectingReward => 27708,
                    TrialSpawnerState.Cooldown => 27709,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
            };
        }
    }
    
    public IBlock GetState(uint state) {
        return state switch {
            27698 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Inactive),
            27699 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForPlayers),
            27700 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Active),
            27701 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForRewardEjection),
            27702 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.EjectingReward),
            27703 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Cooldown),
            27704 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Inactive),
            27705 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForPlayers),
            27706 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Active),
            27707 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForRewardEjection),
            27708 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.EjectingReward),
            27709 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Cooldown),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
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
}
