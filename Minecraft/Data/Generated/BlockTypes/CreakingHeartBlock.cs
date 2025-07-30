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
    public int ProtocolId => 186;
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
                        true => 2920,
                        false => 2921,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 2922,
                        false => 2923,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 2924,
                        false => 2925,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Y => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 2926,
                        false => 2927,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 2928,
                        false => 2929,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 2930,
                        false => 2931,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Z => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 2932,
                        false => 2933,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 2934,
                        false => 2935,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 2936,
                        false => 2937,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2920 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, true),
            2921 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, false),
            2922 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, true),
            2923 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, false),
            2924 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, true),
            2925 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, false),
            2926 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, true),
            2927 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, false),
            2928 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, true),
            2929 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, false),
            2930 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, true),
            2931 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, false),
            2932 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, true),
            2933 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, false),
            2934 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, true),
            2935 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, false),
            2936 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, true),
            2937 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = AxisExtensions.FromString(properties["axis"].GetString()),
            CreakingHeartStateValue = CreakingHeartStateFromString(properties["creaking_heart_state"].GetString()),
            Natural = properties["natural"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("axis", Axis.ToName()),
            new StringTag("creaking_heart_state", CreakingHeartStateToName(CreakingHeartStateValue)),
            new StringTag("natural", Natural.ToString().ToLower())
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
