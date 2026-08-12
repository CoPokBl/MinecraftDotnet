using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CreakingHeartBlock(Identifier Identifier, Axis Axis, CreakingHeartBlock.CreakingHeartState CreakingHeartStateValue, bool Natural) : IBlock {
    public Identifier Category => "minecraft:creaking_heart";
    public double Hardness => 10;
    public double ExplosionResistance => 10;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "creaking_heart";
    public Identifier? BlockEntity => "minecraft:creaking_heart";
    public Identifier? Item => "minecraft:creaking_heart";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.creaking_heart";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3889,
                        false => 3890,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3891,
                        false => 3892,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3893,
                        false => 3894,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Y => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3895,
                        false => 3896,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3897,
                        false => 3898,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3899,
                        false => 3900,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Z => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3901,
                        false => 3902,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3903,
                        false => 3904,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3905,
                        false => 3906,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3889 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, true),
            3890 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, false),
            3891 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, true),
            3892 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, false),
            3893 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, true),
            3894 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, false),
            3895 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, true),
            3896 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, false),
            3897 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, true),
            3898 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, false),
            3899 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, true),
            3900 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, false),
            3901 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, true),
            3902 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, false),
            3903 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, true),
            3904 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, false),
            3905 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, true),
            3906 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.Contains("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            CreakingHeartStateValue = properties.Contains("creaking_heart_state") ? CreakingHeartStateFromString(properties["creaking_heart_state"].GetString()) : CreakingHeartStateValue,
            Natural = properties.Contains("natural") ? properties["natural"].GetString() == "true" : Natural,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("axis", new StringTag(Axis.ToName())),
            ("creaking_heart_state", new StringTag(CreakingHeartStateToName(CreakingHeartStateValue))),
            ("natural", new StringTag(Natural.ToString().ToLower()))
        );
    }
    
    public enum CreakingHeartState {
        Uprooted,
        Dormant,
        Awake,
    }

    public static CreakingHeartState CreakingHeartStateFromString(string value) {
        return value switch {
            "uprooted" => CreakingHeartState.Uprooted,
            "dormant" => CreakingHeartState.Dormant,
            "awake" => CreakingHeartState.Awake,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for CreakingHeartState.")
        };
    }

    public static string CreakingHeartStateToName(CreakingHeartState value) {
        return value switch {
            CreakingHeartState.Uprooted => "uprooted",
            CreakingHeartState.Dormant => "dormant",
            CreakingHeartState.Awake => "awake",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CreakingHeartState value.")
        };
    }
}
