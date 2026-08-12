using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BeeNestBlock(Identifier Identifier, Direction Facing, int HoneyLevel) : IBlock {
    public Identifier Category => "minecraft:beehive";
    public double Hardness => 0.3;
    public double ExplosionResistance => 0.3;
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
    public Identifier? Item => "minecraft:bee_nest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.bee_nest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HoneyLevel switch {
                    0 => 21768,
                    1 => 21769,
                    2 => 21770,
                    3 => 21771,
                    4 => 21772,
                    5 => 21773,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 21774,
                    1 => 21775,
                    2 => 21776,
                    3 => 21777,
                    4 => 21778,
                    5 => 21779,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 21780,
                    1 => 21781,
                    2 => 21782,
                    3 => 21783,
                    4 => 21784,
                    5 => 21785,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 21786,
                    1 => 21787,
                    2 => 21788,
                    3 => 21789,
                    4 => 21790,
                    5 => 21791,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21768 => new BeeNestBlock(Identifier, Direction.North, 0),
            21769 => new BeeNestBlock(Identifier, Direction.North, 1),
            21770 => new BeeNestBlock(Identifier, Direction.North, 2),
            21771 => new BeeNestBlock(Identifier, Direction.North, 3),
            21772 => new BeeNestBlock(Identifier, Direction.North, 4),
            21773 => new BeeNestBlock(Identifier, Direction.North, 5),
            21774 => new BeeNestBlock(Identifier, Direction.South, 0),
            21775 => new BeeNestBlock(Identifier, Direction.South, 1),
            21776 => new BeeNestBlock(Identifier, Direction.South, 2),
            21777 => new BeeNestBlock(Identifier, Direction.South, 3),
            21778 => new BeeNestBlock(Identifier, Direction.South, 4),
            21779 => new BeeNestBlock(Identifier, Direction.South, 5),
            21780 => new BeeNestBlock(Identifier, Direction.West, 0),
            21781 => new BeeNestBlock(Identifier, Direction.West, 1),
            21782 => new BeeNestBlock(Identifier, Direction.West, 2),
            21783 => new BeeNestBlock(Identifier, Direction.West, 3),
            21784 => new BeeNestBlock(Identifier, Direction.West, 4),
            21785 => new BeeNestBlock(Identifier, Direction.West, 5),
            21786 => new BeeNestBlock(Identifier, Direction.East, 0),
            21787 => new BeeNestBlock(Identifier, Direction.East, 1),
            21788 => new BeeNestBlock(Identifier, Direction.East, 2),
            21789 => new BeeNestBlock(Identifier, Direction.East, 3),
            21790 => new BeeNestBlock(Identifier, Direction.East, 4),
            21791 => new BeeNestBlock(Identifier, Direction.East, 5),
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
