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
    private static readonly BlockInfo Data = new("minecraft:trial_spawner", "block.minecraft.trial_spawner", 50f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:trial_spawner", "minecraft:trial_spawner", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(50f, 0, 1, PushReaction.Normal, 11, "trial_spawner", NoteBlockInstrument.Basedrum, false, false, false, true, false, false, false, false, true, true, false, false, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 4 };
    private static readonly BlockStateInfo I2 = I0 with { LightEmission = 8 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I2, I0, I0, I1, I2, I2, I2, I0
    ];

    public BlockStateInfo StateInfo => States[StateId - 32150];

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
