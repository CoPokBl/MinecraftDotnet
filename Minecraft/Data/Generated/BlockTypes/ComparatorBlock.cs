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
                        true => 9984,
                        false => 9985,
                    },
                    Mode.Subtract => Powered switch {
                        true => 9986,
                        false => 9987,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.South => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 9988,
                        false => 9989,
                    },
                    Mode.Subtract => Powered switch {
                        true => 9990,
                        false => 9991,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.West => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 9992,
                        false => 9993,
                    },
                    Mode.Subtract => Powered switch {
                        true => 9994,
                        false => 9995,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.East => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 9996,
                        false => 9997,
                    },
                    Mode.Subtract => Powered switch {
                        true => 9998,
                        false => 9999,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9984 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, true),
            9985 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, false),
            9986 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, true),
            9987 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, false),
            9988 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, true),
            9989 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, false),
            9990 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, true),
            9991 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, false),
            9992 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, true),
            9993 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, false),
            9994 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, true),
            9995 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, false),
            9996 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, true),
            9997 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, false),
            9998 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, true),
            9999 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            ModeValue = ModeFromString(properties["mode"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
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
}
