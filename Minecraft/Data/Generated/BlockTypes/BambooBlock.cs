using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooBlock(Identifier Identifier, int Age, BambooBlock.Leaves LeavesValue, int Stage) : IBlock {

    public Identifier Category => "minecraft:bamboo_stalk";
    public int ProtocolId => 760;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "bamboo";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:bamboo";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.4375, 1.0, 0.4375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.15625, 0.0, 0.15625] -> [0.34375, 1.0, 0.34375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.15625, 0.0, 0.15625] -> [0.34375, 1.0, 0.34375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.bamboo";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Age switch {
                0 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 14000,
                        1 => 14001,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 14002,
                        1 => 14003,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 14004,
                        1 => 14005,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                1 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 14006,
                        1 => 14007,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 14008,
                        1 => 14009,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 14010,
                        1 => 14011,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14000 => new BambooBlock(Identifier, 0, Leaves.None, 0),
            14001 => new BambooBlock(Identifier, 0, Leaves.None, 1),
            14002 => new BambooBlock(Identifier, 0, Leaves.Small, 0),
            14003 => new BambooBlock(Identifier, 0, Leaves.Small, 1),
            14004 => new BambooBlock(Identifier, 0, Leaves.Large, 0),
            14005 => new BambooBlock(Identifier, 0, Leaves.Large, 1),
            14006 => new BambooBlock(Identifier, 1, Leaves.None, 0),
            14007 => new BambooBlock(Identifier, 1, Leaves.None, 1),
            14008 => new BambooBlock(Identifier, 1, Leaves.Small, 0),
            14009 => new BambooBlock(Identifier, 1, Leaves.Small, 1),
            14010 => new BambooBlock(Identifier, 1, Leaves.Large, 0),
            14011 => new BambooBlock(Identifier, 1, Leaves.Large, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
            LeavesValue = LeavesFromString(properties["leaves"].GetString()),
            Stage = int.Parse(properties["stage"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("age", Age.ToString()),
            new StringTag("leaves", LeavesToName(LeavesValue)),
            new StringTag("stage", Stage.ToString())
        );
    }
    
    public enum Leaves {
        None,
        Small,
        Large,
    }

    public static Leaves LeavesFromString(string value) {
        return value switch {
            "none" => Leaves.None,
            "small" => Leaves.Small,
            "large" => Leaves.Large,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Leaves.")
        };
    }

    public static string LeavesToName(Leaves value) {
        return value switch {
            Leaves.None => "none",
            Leaves.Small => "small",
            Leaves.Large => "large",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Leaves value.")
        };
    }
}
