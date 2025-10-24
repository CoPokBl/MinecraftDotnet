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
    public int ProtocolId => 471;
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
                        true => 11061,
                        false => 11062,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11063,
                        false => 11064,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.South => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11065,
                        false => 11066,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11067,
                        false => 11068,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.West => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11069,
                        false => 11070,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11071,
                        false => 11072,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.East => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11073,
                        false => 11074,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11075,
                        false => 11076,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11061 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, true),
            11062 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, false),
            11063 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, true),
            11064 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, false),
            11065 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, true),
            11066 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, false),
            11067 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, true),
            11068 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, false),
            11069 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, true),
            11070 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, false),
            11071 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, true),
            11072 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, false),
            11073 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, true),
            11074 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, false),
            11075 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, true),
            11076 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            ModeValue = properties.ChildrenMap.ContainsKey("mode") ? ModeFromString(properties["mode"].GetString()) : ModeValue,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("mode", ModeToName(ModeValue)),
            new StringTag("powered", Powered.ToString().ToLower())
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
