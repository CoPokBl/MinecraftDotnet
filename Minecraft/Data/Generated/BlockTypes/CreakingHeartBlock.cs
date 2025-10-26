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
    public int ProtocolId => 198;
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
                        true => 3688,
                        false => 3689,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3690,
                        false => 3691,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3692,
                        false => 3693,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Y => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3694,
                        false => 3695,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3696,
                        false => 3697,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3698,
                        false => 3699,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                Axis.Z => CreakingHeartStateValue switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3700,
                        false => 3701,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3702,
                        false => 3703,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3704,
                        false => 3705,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartStateValue), CreakingHeartStateValue, "Unknown value for property creaking_heart_state.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3688 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, true),
            3689 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, false),
            3690 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, true),
            3691 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, false),
            3692 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, true),
            3693 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, false),
            3694 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, true),
            3695 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, false),
            3696 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, true),
            3697 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, false),
            3698 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, true),
            3699 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, false),
            3700 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, true),
            3701 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, false),
            3702 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, true),
            3703 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, false),
            3704 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, true),
            3705 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.ChildrenMap.ContainsKey("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            CreakingHeartStateValue = properties.ChildrenMap.ContainsKey("creaking_heart_state") ? CreakingHeartStateFromString(properties["creaking_heart_state"].GetString()) : CreakingHeartStateValue,
            Natural = properties.ChildrenMap.ContainsKey("natural") ? properties["natural"].GetString() == "true" : Natural,
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
