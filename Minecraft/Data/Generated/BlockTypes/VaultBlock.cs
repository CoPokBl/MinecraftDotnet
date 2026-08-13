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
    private static readonly BlockInfo Data = new("minecraft:vault", "block.minecraft.vault", 50f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:vault", "minecraft:vault", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(50f, 6, 1, PushReaction.Normal, 11, "vault", NoteBlockInstrument.Basedrum, false, false, false, true, false, false, false, false, true, true, false, false, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 12 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1, I0, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 32162];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 32162,
                        VaultState.Active => 32163,
                        VaultState.Unlocking => 32164,
                        VaultState.Ejecting => 32165,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 32166,
                        VaultState.Active => 32167,
                        VaultState.Unlocking => 32168,
                        VaultState.Ejecting => 32169,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.South => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 32170,
                        VaultState.Active => 32171,
                        VaultState.Unlocking => 32172,
                        VaultState.Ejecting => 32173,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 32174,
                        VaultState.Active => 32175,
                        VaultState.Unlocking => 32176,
                        VaultState.Ejecting => 32177,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.West => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 32178,
                        VaultState.Active => 32179,
                        VaultState.Unlocking => 32180,
                        VaultState.Ejecting => 32181,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 32182,
                        VaultState.Active => 32183,
                        VaultState.Unlocking => 32184,
                        VaultState.Ejecting => 32185,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.East => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 32186,
                        VaultState.Active => 32187,
                        VaultState.Unlocking => 32188,
                        VaultState.Ejecting => 32189,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 32190,
                        VaultState.Active => 32191,
                        VaultState.Unlocking => 32192,
                        VaultState.Ejecting => 32193,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32162 => new VaultBlock(Identifier, Direction.North, true, VaultState.Inactive),
            32163 => new VaultBlock(Identifier, Direction.North, true, VaultState.Active),
            32164 => new VaultBlock(Identifier, Direction.North, true, VaultState.Unlocking),
            32165 => new VaultBlock(Identifier, Direction.North, true, VaultState.Ejecting),
            32166 => new VaultBlock(Identifier, Direction.North, false, VaultState.Inactive),
            32167 => new VaultBlock(Identifier, Direction.North, false, VaultState.Active),
            32168 => new VaultBlock(Identifier, Direction.North, false, VaultState.Unlocking),
            32169 => new VaultBlock(Identifier, Direction.North, false, VaultState.Ejecting),
            32170 => new VaultBlock(Identifier, Direction.South, true, VaultState.Inactive),
            32171 => new VaultBlock(Identifier, Direction.South, true, VaultState.Active),
            32172 => new VaultBlock(Identifier, Direction.South, true, VaultState.Unlocking),
            32173 => new VaultBlock(Identifier, Direction.South, true, VaultState.Ejecting),
            32174 => new VaultBlock(Identifier, Direction.South, false, VaultState.Inactive),
            32175 => new VaultBlock(Identifier, Direction.South, false, VaultState.Active),
            32176 => new VaultBlock(Identifier, Direction.South, false, VaultState.Unlocking),
            32177 => new VaultBlock(Identifier, Direction.South, false, VaultState.Ejecting),
            32178 => new VaultBlock(Identifier, Direction.West, true, VaultState.Inactive),
            32179 => new VaultBlock(Identifier, Direction.West, true, VaultState.Active),
            32180 => new VaultBlock(Identifier, Direction.West, true, VaultState.Unlocking),
            32181 => new VaultBlock(Identifier, Direction.West, true, VaultState.Ejecting),
            32182 => new VaultBlock(Identifier, Direction.West, false, VaultState.Inactive),
            32183 => new VaultBlock(Identifier, Direction.West, false, VaultState.Active),
            32184 => new VaultBlock(Identifier, Direction.West, false, VaultState.Unlocking),
            32185 => new VaultBlock(Identifier, Direction.West, false, VaultState.Ejecting),
            32186 => new VaultBlock(Identifier, Direction.East, true, VaultState.Inactive),
            32187 => new VaultBlock(Identifier, Direction.East, true, VaultState.Active),
            32188 => new VaultBlock(Identifier, Direction.East, true, VaultState.Unlocking),
            32189 => new VaultBlock(Identifier, Direction.East, true, VaultState.Ejecting),
            32190 => new VaultBlock(Identifier, Direction.East, false, VaultState.Inactive),
            32191 => new VaultBlock(Identifier, Direction.East, false, VaultState.Active),
            32192 => new VaultBlock(Identifier, Direction.East, false, VaultState.Unlocking),
            32193 => new VaultBlock(Identifier, Direction.East, false, VaultState.Ejecting),
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
