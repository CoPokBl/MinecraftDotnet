using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record VaultBlock(Identifier Identifier, Direction Facing, bool Ominous, VaultBlock.VaultState VaultStateValue) : IBlock {

    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27710,
                        VaultState.Active => 27711,
                        VaultState.Unlocking => 27712,
                        VaultState.Ejecting => 27713,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27714,
                        VaultState.Active => 27715,
                        VaultState.Unlocking => 27716,
                        VaultState.Ejecting => 27717,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.South => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27718,
                        VaultState.Active => 27719,
                        VaultState.Unlocking => 27720,
                        VaultState.Ejecting => 27721,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27722,
                        VaultState.Active => 27723,
                        VaultState.Unlocking => 27724,
                        VaultState.Ejecting => 27725,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.West => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27726,
                        VaultState.Active => 27727,
                        VaultState.Unlocking => 27728,
                        VaultState.Ejecting => 27729,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27730,
                        VaultState.Active => 27731,
                        VaultState.Unlocking => 27732,
                        VaultState.Ejecting => 27733,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                Direction.East => Ominous switch {
                    true => VaultStateValue switch {
                        VaultState.Inactive => 27734,
                        VaultState.Active => 27735,
                        VaultState.Unlocking => 27736,
                        VaultState.Ejecting => 27737,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                    false => VaultStateValue switch {
                        VaultState.Inactive => 27738,
                        VaultState.Active => 27739,
                        VaultState.Unlocking => 27740,
                        VaultState.Ejecting => 27741,
                        _ => throw new ArgumentOutOfRangeException(nameof(VaultStateValue), VaultStateValue, "Unknown value for property vault_state.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27710 => new VaultBlock(Identifier, Direction.North, true, VaultState.Inactive),
            27711 => new VaultBlock(Identifier, Direction.North, true, VaultState.Active),
            27712 => new VaultBlock(Identifier, Direction.North, true, VaultState.Unlocking),
            27713 => new VaultBlock(Identifier, Direction.North, true, VaultState.Ejecting),
            27714 => new VaultBlock(Identifier, Direction.North, false, VaultState.Inactive),
            27715 => new VaultBlock(Identifier, Direction.North, false, VaultState.Active),
            27716 => new VaultBlock(Identifier, Direction.North, false, VaultState.Unlocking),
            27717 => new VaultBlock(Identifier, Direction.North, false, VaultState.Ejecting),
            27718 => new VaultBlock(Identifier, Direction.South, true, VaultState.Inactive),
            27719 => new VaultBlock(Identifier, Direction.South, true, VaultState.Active),
            27720 => new VaultBlock(Identifier, Direction.South, true, VaultState.Unlocking),
            27721 => new VaultBlock(Identifier, Direction.South, true, VaultState.Ejecting),
            27722 => new VaultBlock(Identifier, Direction.South, false, VaultState.Inactive),
            27723 => new VaultBlock(Identifier, Direction.South, false, VaultState.Active),
            27724 => new VaultBlock(Identifier, Direction.South, false, VaultState.Unlocking),
            27725 => new VaultBlock(Identifier, Direction.South, false, VaultState.Ejecting),
            27726 => new VaultBlock(Identifier, Direction.West, true, VaultState.Inactive),
            27727 => new VaultBlock(Identifier, Direction.West, true, VaultState.Active),
            27728 => new VaultBlock(Identifier, Direction.West, true, VaultState.Unlocking),
            27729 => new VaultBlock(Identifier, Direction.West, true, VaultState.Ejecting),
            27730 => new VaultBlock(Identifier, Direction.West, false, VaultState.Inactive),
            27731 => new VaultBlock(Identifier, Direction.West, false, VaultState.Active),
            27732 => new VaultBlock(Identifier, Direction.West, false, VaultState.Unlocking),
            27733 => new VaultBlock(Identifier, Direction.West, false, VaultState.Ejecting),
            27734 => new VaultBlock(Identifier, Direction.East, true, VaultState.Inactive),
            27735 => new VaultBlock(Identifier, Direction.East, true, VaultState.Active),
            27736 => new VaultBlock(Identifier, Direction.East, true, VaultState.Unlocking),
            27737 => new VaultBlock(Identifier, Direction.East, true, VaultState.Ejecting),
            27738 => new VaultBlock(Identifier, Direction.East, false, VaultState.Inactive),
            27739 => new VaultBlock(Identifier, Direction.East, false, VaultState.Active),
            27740 => new VaultBlock(Identifier, Direction.East, false, VaultState.Unlocking),
            27741 => new VaultBlock(Identifier, Direction.East, false, VaultState.Ejecting),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Ominous = properties["ominous"].GetString() == "true",
            VaultStateValue = VaultStateFromString(properties["vault_state"].GetString()),
        };
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
}
