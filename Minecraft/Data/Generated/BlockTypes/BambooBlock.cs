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
                        0 => 15279,
                        1 => 15280,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15281,
                        1 => 15282,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15283,
                        1 => 15284,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                1 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 15285,
                        1 => 15286,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15287,
                        1 => 15288,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15289,
                        1 => 15290,
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
            15279 => new BambooBlock(Identifier, 0, Leaves.None, 0),
            15280 => new BambooBlock(Identifier, 0, Leaves.None, 1),
            15281 => new BambooBlock(Identifier, 0, Leaves.Small, 0),
            15282 => new BambooBlock(Identifier, 0, Leaves.Small, 1),
            15283 => new BambooBlock(Identifier, 0, Leaves.Large, 0),
            15284 => new BambooBlock(Identifier, 0, Leaves.Large, 1),
            15285 => new BambooBlock(Identifier, 1, Leaves.None, 0),
            15286 => new BambooBlock(Identifier, 1, Leaves.None, 1),
            15287 => new BambooBlock(Identifier, 1, Leaves.Small, 0),
            15288 => new BambooBlock(Identifier, 1, Leaves.Small, 1),
            15289 => new BambooBlock(Identifier, 1, Leaves.Large, 0),
            15290 => new BambooBlock(Identifier, 1, Leaves.Large, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            LeavesValue = properties.Contains("leaves") ? LeavesFromString(properties["leaves"].GetString()) : LeavesValue,
            Stage = properties.Contains("stage") ? int.Parse(properties["stage"].GetString()) : Stage,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("leaves", new StringTag(LeavesToName(LeavesValue))),
            ("stage", new StringTag(Stage.ToString()))
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
