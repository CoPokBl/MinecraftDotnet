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
    public int ProtocolId => 790;
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
                        0 => 15077,
                        1 => 15078,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15079,
                        1 => 15080,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15081,
                        1 => 15082,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                1 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 15083,
                        1 => 15084,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15085,
                        1 => 15086,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15087,
                        1 => 15088,
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
            15077 => new BambooBlock(Identifier, 0, Leaves.None, 0),
            15078 => new BambooBlock(Identifier, 0, Leaves.None, 1),
            15079 => new BambooBlock(Identifier, 0, Leaves.Small, 0),
            15080 => new BambooBlock(Identifier, 0, Leaves.Small, 1),
            15081 => new BambooBlock(Identifier, 0, Leaves.Large, 0),
            15082 => new BambooBlock(Identifier, 0, Leaves.Large, 1),
            15083 => new BambooBlock(Identifier, 1, Leaves.None, 0),
            15084 => new BambooBlock(Identifier, 1, Leaves.None, 1),
            15085 => new BambooBlock(Identifier, 1, Leaves.Small, 0),
            15086 => new BambooBlock(Identifier, 1, Leaves.Small, 1),
            15087 => new BambooBlock(Identifier, 1, Leaves.Large, 0),
            15088 => new BambooBlock(Identifier, 1, Leaves.Large, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.ChildrenMap.ContainsKey("age") ? int.Parse(properties["age"].GetString()) : Age,
            LeavesValue = properties.ChildrenMap.ContainsKey("leaves") ? LeavesFromString(properties["leaves"].GetString()) : LeavesValue,
            Stage = properties.ChildrenMap.ContainsKey("stage") ? int.Parse(properties["stage"].GetString()) : Stage,
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
