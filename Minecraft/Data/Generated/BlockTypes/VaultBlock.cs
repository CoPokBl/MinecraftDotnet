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
    public int ProtocolId => 1095;
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
                        VaultState.Inactive => 27742,
                        VaultState.Active => 27743,
                        VaultState.Unlocking => 27744,
                        VaultState.Ejecting => 27745,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27746,
                        VaultState.Active => 27747,
                        VaultState.Unlocking => 27748,
                        VaultState.Ejecting => 27749,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.South => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27750,
                        VaultState.Active => 27751,
                        VaultState.Unlocking => 27752,
                        VaultState.Ejecting => 27753,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27754,
                        VaultState.Active => 27755,
                        VaultState.Unlocking => 27756,
                        VaultState.Ejecting => 27757,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.West => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27758,
                        VaultState.Active => 27759,
                        VaultState.Unlocking => 27760,
                        VaultState.Ejecting => 27761,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27762,
                        VaultState.Active => 27763,
                        VaultState.Unlocking => 27764,
                        VaultState.Ejecting => 27765,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.East => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27766,
                        VaultState.Active => 27767,
                        VaultState.Unlocking => 27768,
                        VaultState.Ejecting => 27769,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27770,
                        VaultState.Active => 27771,
                        VaultState.Unlocking => 27772,
                        VaultState.Ejecting => 27773,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27742 => new VaultBlock(Identifier, Direction.North, true, VaultState.Inactive),
            27743 => new VaultBlock(Identifier, Direction.North, true, VaultState.Active),
            27744 => new VaultBlock(Identifier, Direction.North, true, VaultState.Unlocking),
            27745 => new VaultBlock(Identifier, Direction.North, true, VaultState.Ejecting),
            27746 => new VaultBlock(Identifier, Direction.North, false, VaultState.Inactive),
            27747 => new VaultBlock(Identifier, Direction.North, false, VaultState.Active),
            27748 => new VaultBlock(Identifier, Direction.North, false, VaultState.Unlocking),
            27749 => new VaultBlock(Identifier, Direction.North, false, VaultState.Ejecting),
            27750 => new VaultBlock(Identifier, Direction.South, true, VaultState.Inactive),
            27751 => new VaultBlock(Identifier, Direction.South, true, VaultState.Active),
            27752 => new VaultBlock(Identifier, Direction.South, true, VaultState.Unlocking),
            27753 => new VaultBlock(Identifier, Direction.South, true, VaultState.Ejecting),
            27754 => new VaultBlock(Identifier, Direction.South, false, VaultState.Inactive),
            27755 => new VaultBlock(Identifier, Direction.South, false, VaultState.Active),
            27756 => new VaultBlock(Identifier, Direction.South, false, VaultState.Unlocking),
            27757 => new VaultBlock(Identifier, Direction.South, false, VaultState.Ejecting),
            27758 => new VaultBlock(Identifier, Direction.West, true, VaultState.Inactive),
            27759 => new VaultBlock(Identifier, Direction.West, true, VaultState.Active),
            27760 => new VaultBlock(Identifier, Direction.West, true, VaultState.Unlocking),
            27761 => new VaultBlock(Identifier, Direction.West, true, VaultState.Ejecting),
            27762 => new VaultBlock(Identifier, Direction.West, false, VaultState.Inactive),
            27763 => new VaultBlock(Identifier, Direction.West, false, VaultState.Active),
            27764 => new VaultBlock(Identifier, Direction.West, false, VaultState.Unlocking),
            27765 => new VaultBlock(Identifier, Direction.West, false, VaultState.Ejecting),
            27766 => new VaultBlock(Identifier, Direction.East, true, VaultState.Inactive),
            27767 => new VaultBlock(Identifier, Direction.East, true, VaultState.Active),
            27768 => new VaultBlock(Identifier, Direction.East, true, VaultState.Unlocking),
            27769 => new VaultBlock(Identifier, Direction.East, true, VaultState.Ejecting),
            27770 => new VaultBlock(Identifier, Direction.East, false, VaultState.Inactive),
            27771 => new VaultBlock(Identifier, Direction.East, false, VaultState.Active),
            27772 => new VaultBlock(Identifier, Direction.East, false, VaultState.Unlocking),
            27773 => new VaultBlock(Identifier, Direction.East, false, VaultState.Ejecting),
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
