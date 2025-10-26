using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record VaultBlock(Identifier Identifier, Direction Facing, bool Ominous, VaultBlock.VaultState VaultStateValue) : IBlock {
    public Identifier Category => "minecraft:vault";
    public int ProtocolId => 1156;
    public double Hardness => 50;
    public double ExplosionResistance => 50;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 6;
    public bool Replaceable => false;
    public string SoundType => "vault";
    public Identifier? BlockEntity => "minecraft:vault";
    public Identifier? Item => "minecraft:vault";
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
    public string TranslationKey => "block.minecraft.vault";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 29467,
                        VaultState.Active => 29468,
                        VaultState.Unlocking => 29469,
                        VaultState.Ejecting => 29470,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 29471,
                        VaultState.Active => 29472,
                        VaultState.Unlocking => 29473,
                        VaultState.Ejecting => 29474,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.South => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 29475,
                        VaultState.Active => 29476,
                        VaultState.Unlocking => 29477,
                        VaultState.Ejecting => 29478,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 29479,
                        VaultState.Active => 29480,
                        VaultState.Unlocking => 29481,
                        VaultState.Ejecting => 29482,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.West => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 29483,
                        VaultState.Active => 29484,
                        VaultState.Unlocking => 29485,
                        VaultState.Ejecting => 29486,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 29487,
                        VaultState.Active => 29488,
                        VaultState.Unlocking => 29489,
                        VaultState.Ejecting => 29490,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.East => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 29491,
                        VaultState.Active => 29492,
                        VaultState.Unlocking => 29493,
                        VaultState.Ejecting => 29494,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 29495,
                        VaultState.Active => 29496,
                        VaultState.Unlocking => 29497,
                        VaultState.Ejecting => 29498,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29467 => new VaultBlock(Identifier, Direction.North, true, VaultState.Inactive),
            29468 => new VaultBlock(Identifier, Direction.North, true, VaultState.Active),
            29469 => new VaultBlock(Identifier, Direction.North, true, VaultState.Unlocking),
            29470 => new VaultBlock(Identifier, Direction.North, true, VaultState.Ejecting),
            29471 => new VaultBlock(Identifier, Direction.North, false, VaultState.Inactive),
            29472 => new VaultBlock(Identifier, Direction.North, false, VaultState.Active),
            29473 => new VaultBlock(Identifier, Direction.North, false, VaultState.Unlocking),
            29474 => new VaultBlock(Identifier, Direction.North, false, VaultState.Ejecting),
            29475 => new VaultBlock(Identifier, Direction.South, true, VaultState.Inactive),
            29476 => new VaultBlock(Identifier, Direction.South, true, VaultState.Active),
            29477 => new VaultBlock(Identifier, Direction.South, true, VaultState.Unlocking),
            29478 => new VaultBlock(Identifier, Direction.South, true, VaultState.Ejecting),
            29479 => new VaultBlock(Identifier, Direction.South, false, VaultState.Inactive),
            29480 => new VaultBlock(Identifier, Direction.South, false, VaultState.Active),
            29481 => new VaultBlock(Identifier, Direction.South, false, VaultState.Unlocking),
            29482 => new VaultBlock(Identifier, Direction.South, false, VaultState.Ejecting),
            29483 => new VaultBlock(Identifier, Direction.West, true, VaultState.Inactive),
            29484 => new VaultBlock(Identifier, Direction.West, true, VaultState.Active),
            29485 => new VaultBlock(Identifier, Direction.West, true, VaultState.Unlocking),
            29486 => new VaultBlock(Identifier, Direction.West, true, VaultState.Ejecting),
            29487 => new VaultBlock(Identifier, Direction.West, false, VaultState.Inactive),
            29488 => new VaultBlock(Identifier, Direction.West, false, VaultState.Active),
            29489 => new VaultBlock(Identifier, Direction.West, false, VaultState.Unlocking),
            29490 => new VaultBlock(Identifier, Direction.West, false, VaultState.Ejecting),
            29491 => new VaultBlock(Identifier, Direction.East, true, VaultState.Inactive),
            29492 => new VaultBlock(Identifier, Direction.East, true, VaultState.Active),
            29493 => new VaultBlock(Identifier, Direction.East, true, VaultState.Unlocking),
            29494 => new VaultBlock(Identifier, Direction.East, true, VaultState.Ejecting),
            29495 => new VaultBlock(Identifier, Direction.East, false, VaultState.Inactive),
            29496 => new VaultBlock(Identifier, Direction.East, false, VaultState.Active),
            29497 => new VaultBlock(Identifier, Direction.East, false, VaultState.Unlocking),
            29498 => new VaultBlock(Identifier, Direction.East, false, VaultState.Ejecting),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Ominous = properties.ChildrenMap.ContainsKey("ominous") ? properties["ominous"].GetString() == "true" : Ominous,
            VaultStateValue = properties.ChildrenMap.ContainsKey("vault_state") ? VaultStateFromString(properties["vault_state"].GetString()) : VaultStateValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("ominous", Ominous.ToString().ToLower()),
            new StringTag("vault_state", VaultStateToName(VaultStateValue))
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
