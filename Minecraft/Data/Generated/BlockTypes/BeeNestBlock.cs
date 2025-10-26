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
    public int ProtocolId => 909;
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
                    0 => 21566,
                    1 => 21567,
                    2 => 21568,
                    3 => 21569,
                    4 => 21570,
                    5 => 21571,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 21572,
                    1 => 21573,
                    2 => 21574,
                    3 => 21575,
                    4 => 21576,
                    5 => 21577,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 21578,
                    1 => 21579,
                    2 => 21580,
                    3 => 21581,
                    4 => 21582,
                    5 => 21583,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 21584,
                    1 => 21585,
                    2 => 21586,
                    3 => 21587,
                    4 => 21588,
                    5 => 21589,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21566 => new BeeNestBlock(Identifier, Direction.North, 0),
            21567 => new BeeNestBlock(Identifier, Direction.North, 1),
            21568 => new BeeNestBlock(Identifier, Direction.North, 2),
            21569 => new BeeNestBlock(Identifier, Direction.North, 3),
            21570 => new BeeNestBlock(Identifier, Direction.North, 4),
            21571 => new BeeNestBlock(Identifier, Direction.North, 5),
            21572 => new BeeNestBlock(Identifier, Direction.South, 0),
            21573 => new BeeNestBlock(Identifier, Direction.South, 1),
            21574 => new BeeNestBlock(Identifier, Direction.South, 2),
            21575 => new BeeNestBlock(Identifier, Direction.South, 3),
            21576 => new BeeNestBlock(Identifier, Direction.South, 4),
            21577 => new BeeNestBlock(Identifier, Direction.South, 5),
            21578 => new BeeNestBlock(Identifier, Direction.West, 0),
            21579 => new BeeNestBlock(Identifier, Direction.West, 1),
            21580 => new BeeNestBlock(Identifier, Direction.West, 2),
            21581 => new BeeNestBlock(Identifier, Direction.West, 3),
            21582 => new BeeNestBlock(Identifier, Direction.West, 4),
            21583 => new BeeNestBlock(Identifier, Direction.West, 5),
            21584 => new BeeNestBlock(Identifier, Direction.East, 0),
            21585 => new BeeNestBlock(Identifier, Direction.East, 1),
            21586 => new BeeNestBlock(Identifier, Direction.East, 2),
            21587 => new BeeNestBlock(Identifier, Direction.East, 3),
            21588 => new BeeNestBlock(Identifier, Direction.East, 4),
            21589 => new BeeNestBlock(Identifier, Direction.East, 5),
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
