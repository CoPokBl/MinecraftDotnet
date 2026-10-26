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
public record VaultBlock(Identifier Identifier, Direction Facing, bool Ominous, VaultBlock.VaultState VaultStateValue) : IBlock, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.vault", 50f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:vault", "minecraft:vault", BlockInfo.VanillaOnly, "minecraft:blocks/vault");
    private static readonly BlockStateInfo I0 = new(50f, 6, 1, PushReaction.PushPull, 11, "vault", NoteBlockInstrument.Basedrum, false, false, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 12 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 35519];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 35519,
                        VaultState.Active => 35520,
                        VaultState.Unlocking => 35521,
                        VaultState.Ejecting => 35522,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 35523,
                        VaultState.Active => 35524,
                        VaultState.Unlocking => 35525,
                        VaultState.Ejecting => 35526,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.South => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 35527,
                        VaultState.Active => 35528,
                        VaultState.Unlocking => 35529,
                        VaultState.Ejecting => 35530,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 35531,
                        VaultState.Active => 35532,
                        VaultState.Unlocking => 35533,
                        VaultState.Ejecting => 35534,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.West => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 35535,
                        VaultState.Active => 35536,
                        VaultState.Unlocking => 35537,
                        VaultState.Ejecting => 35538,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 35539,
                        VaultState.Active => 35540,
                        VaultState.Unlocking => 35541,
                        VaultState.Ejecting => 35542,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.East => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 35543,
                        VaultState.Active => 35544,
                        VaultState.Unlocking => 35545,
                        VaultState.Ejecting => 35546,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 35547,
                        VaultState.Active => 35548,
                        VaultState.Unlocking => 35549,
                        VaultState.Ejecting => 35550,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            35519 => new VaultBlock(Identifier, Direction.North, true, VaultState.Inactive),
            35520 => new VaultBlock(Identifier, Direction.North, true, VaultState.Active),
            35521 => new VaultBlock(Identifier, Direction.North, true, VaultState.Unlocking),
            35522 => new VaultBlock(Identifier, Direction.North, true, VaultState.Ejecting),
            35523 => new VaultBlock(Identifier, Direction.North, false, VaultState.Inactive),
            35524 => new VaultBlock(Identifier, Direction.North, false, VaultState.Active),
            35525 => new VaultBlock(Identifier, Direction.North, false, VaultState.Unlocking),
            35526 => new VaultBlock(Identifier, Direction.North, false, VaultState.Ejecting),
            35527 => new VaultBlock(Identifier, Direction.South, true, VaultState.Inactive),
            35528 => new VaultBlock(Identifier, Direction.South, true, VaultState.Active),
            35529 => new VaultBlock(Identifier, Direction.South, true, VaultState.Unlocking),
            35530 => new VaultBlock(Identifier, Direction.South, true, VaultState.Ejecting),
            35531 => new VaultBlock(Identifier, Direction.South, false, VaultState.Inactive),
            35532 => new VaultBlock(Identifier, Direction.South, false, VaultState.Active),
            35533 => new VaultBlock(Identifier, Direction.South, false, VaultState.Unlocking),
            35534 => new VaultBlock(Identifier, Direction.South, false, VaultState.Ejecting),
            35535 => new VaultBlock(Identifier, Direction.West, true, VaultState.Inactive),
            35536 => new VaultBlock(Identifier, Direction.West, true, VaultState.Active),
            35537 => new VaultBlock(Identifier, Direction.West, true, VaultState.Unlocking),
            35538 => new VaultBlock(Identifier, Direction.West, true, VaultState.Ejecting),
            35539 => new VaultBlock(Identifier, Direction.West, false, VaultState.Inactive),
            35540 => new VaultBlock(Identifier, Direction.West, false, VaultState.Active),
            35541 => new VaultBlock(Identifier, Direction.West, false, VaultState.Unlocking),
            35542 => new VaultBlock(Identifier, Direction.West, false, VaultState.Ejecting),
            35543 => new VaultBlock(Identifier, Direction.East, true, VaultState.Inactive),
            35544 => new VaultBlock(Identifier, Direction.East, true, VaultState.Active),
            35545 => new VaultBlock(Identifier, Direction.East, true, VaultState.Unlocking),
            35546 => new VaultBlock(Identifier, Direction.East, true, VaultState.Ejecting),
            35547 => new VaultBlock(Identifier, Direction.East, false, VaultState.Inactive),
            35548 => new VaultBlock(Identifier, Direction.East, false, VaultState.Active),
            35549 => new VaultBlock(Identifier, Direction.East, false, VaultState.Unlocking),
            35550 => new VaultBlock(Identifier, Direction.East, false, VaultState.Ejecting),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Ominous = properties.Contains("ominous") ? properties["ominous"].GetString() == "true" : Ominous,
            VaultStateValue = properties.Contains("vault_state") ? VaultStateFromString(properties["vault_state"].GetString()) : VaultStateValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("ominous", new StringTag(Ominous.ToString().ToLower())),
            ("vault_state", new StringTag(VaultStateToName(VaultStateValue)))
        );
    }
    
    public enum VaultState {
        Inactive,
        Active,
        Unlocking,
        Ejecting,
    }

    public static VaultState VaultStateFromString(string value) {
        return value switch {
            "inactive" => VaultState.Inactive,
            "active" => VaultState.Active,
            "unlocking" => VaultState.Unlocking,
            "ejecting" => VaultState.Ejecting,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for VaultState.")
        };
    }

    public static string VaultStateToName(VaultState value) {
        return value switch {
            VaultState.Inactive => "inactive",
            VaultState.Active => "active",
            VaultState.Unlocking => "unlocking",
            VaultState.Ejecting => "ejecting",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VaultState value.")
        };
    }
}
