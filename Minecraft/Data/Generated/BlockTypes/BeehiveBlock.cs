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
    public int ProtocolId => 910;
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
                    0 => 21590,
                    1 => 21591,
                    2 => 21592,
                    3 => 21593,
                    4 => 21594,
                    5 => 21595,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 21596,
                    1 => 21597,
                    2 => 21598,
                    3 => 21599,
                    4 => 21600,
                    5 => 21601,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 21602,
                    1 => 21603,
                    2 => 21604,
                    3 => 21605,
                    4 => 21606,
                    5 => 21607,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 21608,
                    1 => 21609,
                    2 => 21610,
                    3 => 21611,
                    4 => 21612,
                    5 => 21613,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21590 => new BeehiveBlock(Identifier, Direction.North, 0),
            21591 => new BeehiveBlock(Identifier, Direction.North, 1),
            21592 => new BeehiveBlock(Identifier, Direction.North, 2),
            21593 => new BeehiveBlock(Identifier, Direction.North, 3),
            21594 => new BeehiveBlock(Identifier, Direction.North, 4),
            21595 => new BeehiveBlock(Identifier, Direction.North, 5),
            21596 => new BeehiveBlock(Identifier, Direction.South, 0),
            21597 => new BeehiveBlock(Identifier, Direction.South, 1),
            21598 => new BeehiveBlock(Identifier, Direction.South, 2),
            21599 => new BeehiveBlock(Identifier, Direction.South, 3),
            21600 => new BeehiveBlock(Identifier, Direction.South, 4),
            21601 => new BeehiveBlock(Identifier, Direction.South, 5),
            21602 => new BeehiveBlock(Identifier, Direction.West, 0),
            21603 => new BeehiveBlock(Identifier, Direction.West, 1),
            21604 => new BeehiveBlock(Identifier, Direction.West, 2),
            21605 => new BeehiveBlock(Identifier, Direction.West, 3),
            21606 => new BeehiveBlock(Identifier, Direction.West, 4),
            21607 => new BeehiveBlock(Identifier, Direction.West, 5),
            21608 => new BeehiveBlock(Identifier, Direction.East, 0),
            21609 => new BeehiveBlock(Identifier, Direction.East, 1),
            21610 => new BeehiveBlock(Identifier, Direction.East, 2),
            21611 => new BeehiveBlock(Identifier, Direction.East, 3),
            21612 => new BeehiveBlock(Identifier, Direction.East, 4),
            21613 => new BeehiveBlock(Identifier, Direction.East, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HoneyLevel = properties.ChildrenMap.ContainsKey("honey_level") ? int.Parse(properties["honey_level"].GetString()) : HoneyLevel,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("honey_level", HoneyLevel.ToString())
        );
    }
    
}
