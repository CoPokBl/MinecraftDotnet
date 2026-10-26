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
public record TrialSpawnerBlock(Identifier Identifier, bool Ominous, TrialSpawnerBlock.TrialSpawnerState TrialSpawnerStateValue) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.trial_spawner", 50f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:trial_spawner", "minecraft:trial_spawner", BlockInfo.VanillaOnly, "minecraft:blocks/trial_spawner");
    private static readonly BlockStateInfo I0 = new(50f, 0, 1, PushReaction.PushPull, 11, "trial_spawner", NoteBlockInstrument.Basedrum, false, false, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 4 };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 8 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I2, I0, I0, I1, I2, I2, I2, I0
    ];

    public BlockStateInfo StateInfo => States[StateId - 35507];

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
            return Ominous switch {
                true => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 35507,
                    TrialSpawnerState.WaitingForPlayers => 35508,
                    TrialSpawnerState.Active => 35509,
                    TrialSpawnerState.WaitingForRewardEjection => 35510,
                    TrialSpawnerState.EjectingReward => 35511,
                    TrialSpawnerState.Cooldown => 35512,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
                false => TrialSpawnerStateValue switch {
                    TrialSpawnerState.Inactive => 35513,
                    TrialSpawnerState.WaitingForPlayers => 35514,
                    TrialSpawnerState.Active => 35515,
                    TrialSpawnerState.WaitingForRewardEjection => 35516,
                    TrialSpawnerState.EjectingReward => 35517,
                    TrialSpawnerState.Cooldown => 35518,
                    _ => throw new ArgumentOutOfRangeException(nameof(TrialSpawnerStateValue), TrialSpawnerStateValue, "Unknown value for property trial_spawner_state.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            35507 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Inactive),
            35508 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForPlayers),
            35509 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Active),
            35510 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.WaitingForRewardEjection),
            35511 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.EjectingReward),
            35512 => new TrialSpawnerBlock(Identifier, true, TrialSpawnerState.Cooldown),
            35513 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Inactive),
            35514 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForPlayers),
            35515 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Active),
            35516 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.WaitingForRewardEjection),
            35517 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.EjectingReward),
            35518 => new TrialSpawnerBlock(Identifier, false, TrialSpawnerState.Cooldown),
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
