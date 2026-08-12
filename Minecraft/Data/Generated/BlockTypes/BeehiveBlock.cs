using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BeehiveBlock(Identifier Identifier, Direction Facing, int HoneyLevel) : IBlock {
    public Identifier Category => "minecraft:beehive";
    public double Hardness => 0.6;
    public double ExplosionResistance => 0.6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:beehive";
    public Identifier? Item => "minecraft:beehive";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.beehive";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HoneyLevel switch {
                    0 => 21792,
                    1 => 21793,
                    2 => 21794,
                    3 => 21795,
                    4 => 21796,
                    5 => 21797,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 21798,
                    1 => 21799,
                    2 => 21800,
                    3 => 21801,
                    4 => 21802,
                    5 => 21803,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 21804,
                    1 => 21805,
                    2 => 21806,
                    3 => 21807,
                    4 => 21808,
                    5 => 21809,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 21810,
                    1 => 21811,
                    2 => 21812,
                    3 => 21813,
                    4 => 21814,
                    5 => 21815,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21792 => new BeehiveBlock(Identifier, Direction.North, 0),
            21793 => new BeehiveBlock(Identifier, Direction.North, 1),
            21794 => new BeehiveBlock(Identifier, Direction.North, 2),
            21795 => new BeehiveBlock(Identifier, Direction.North, 3),
            21796 => new BeehiveBlock(Identifier, Direction.North, 4),
            21797 => new BeehiveBlock(Identifier, Direction.North, 5),
            21798 => new BeehiveBlock(Identifier, Direction.South, 0),
            21799 => new BeehiveBlock(Identifier, Direction.South, 1),
            21800 => new BeehiveBlock(Identifier, Direction.South, 2),
            21801 => new BeehiveBlock(Identifier, Direction.South, 3),
            21802 => new BeehiveBlock(Identifier, Direction.South, 4),
            21803 => new BeehiveBlock(Identifier, Direction.South, 5),
            21804 => new BeehiveBlock(Identifier, Direction.West, 0),
            21805 => new BeehiveBlock(Identifier, Direction.West, 1),
            21806 => new BeehiveBlock(Identifier, Direction.West, 2),
            21807 => new BeehiveBlock(Identifier, Direction.West, 3),
            21808 => new BeehiveBlock(Identifier, Direction.West, 4),
            21809 => new BeehiveBlock(Identifier, Direction.West, 5),
            21810 => new BeehiveBlock(Identifier, Direction.East, 0),
            21811 => new BeehiveBlock(Identifier, Direction.East, 1),
            21812 => new BeehiveBlock(Identifier, Direction.East, 2),
            21813 => new BeehiveBlock(Identifier, Direction.East, 3),
            21814 => new BeehiveBlock(Identifier, Direction.East, 4),
            21815 => new BeehiveBlock(Identifier, Direction.East, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HoneyLevel = properties.Contains("honey_level") ? int.Parse(properties["honey_level"].GetString()) : HoneyLevel,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("honey_level", new StringTag(HoneyLevel.ToString()))
        );
    }
    
}
