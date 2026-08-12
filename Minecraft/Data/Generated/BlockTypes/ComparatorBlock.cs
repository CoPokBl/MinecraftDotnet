using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ComparatorBlock(Identifier Identifier, Direction Facing, ComparatorBlock.Mode ModeValue, bool Powered) : IBlock {
    public Identifier Category => "minecraft:comparator";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:comparator";
    public Identifier? Item => "minecraft:comparator";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.comparator";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11263,
                        false => 11264,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11265,
                        false => 11266,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.South => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11267,
                        false => 11268,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11269,
                        false => 11270,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.West => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11271,
                        false => 11272,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11273,
                        false => 11274,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.East => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11275,
                        false => 11276,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11277,
                        false => 11278,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11263 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, true),
            11264 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, false),
            11265 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, true),
            11266 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, false),
            11267 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, true),
            11268 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, false),
            11269 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, true),
            11270 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, false),
            11271 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, true),
            11272 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, false),
            11273 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, true),
            11274 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, false),
            11275 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, true),
            11276 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, false),
            11277 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, true),
            11278 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            ModeValue = properties.Contains("mode") ? ModeFromString(properties["mode"].GetString()) : ModeValue,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("mode", new StringTag(ModeToName(ModeValue))),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
    public enum Mode {
        Compare,
        Subtract,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "compare" => Mode.Compare,
            "subtract" => Mode.Subtract,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }

    public static string ModeToName(Mode value) {
        return value switch {
            Mode.Compare => "compare",
            Mode.Subtract => "subtract",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Mode value.")
        };
    }
}
