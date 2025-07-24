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
    public int ProtocolId => 871;
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
                    0 => 20457,
                    1 => 20458,
                    2 => 20459,
                    3 => 20460,
                    4 => 20461,
                    5 => 20462,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 20463,
                    1 => 20464,
                    2 => 20465,
                    3 => 20466,
                    4 => 20467,
                    5 => 20468,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 20469,
                    1 => 20470,
                    2 => 20471,
                    3 => 20472,
                    4 => 20473,
                    5 => 20474,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 20475,
                    1 => 20476,
                    2 => 20477,
                    3 => 20478,
                    4 => 20479,
                    5 => 20480,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20457 => new BeeNestBlock(Identifier, Direction.North, 0),
            20458 => new BeeNestBlock(Identifier, Direction.North, 1),
            20459 => new BeeNestBlock(Identifier, Direction.North, 2),
            20460 => new BeeNestBlock(Identifier, Direction.North, 3),
            20461 => new BeeNestBlock(Identifier, Direction.North, 4),
            20462 => new BeeNestBlock(Identifier, Direction.North, 5),
            20463 => new BeeNestBlock(Identifier, Direction.South, 0),
            20464 => new BeeNestBlock(Identifier, Direction.South, 1),
            20465 => new BeeNestBlock(Identifier, Direction.South, 2),
            20466 => new BeeNestBlock(Identifier, Direction.South, 3),
            20467 => new BeeNestBlock(Identifier, Direction.South, 4),
            20468 => new BeeNestBlock(Identifier, Direction.South, 5),
            20469 => new BeeNestBlock(Identifier, Direction.West, 0),
            20470 => new BeeNestBlock(Identifier, Direction.West, 1),
            20471 => new BeeNestBlock(Identifier, Direction.West, 2),
            20472 => new BeeNestBlock(Identifier, Direction.West, 3),
            20473 => new BeeNestBlock(Identifier, Direction.West, 4),
            20474 => new BeeNestBlock(Identifier, Direction.West, 5),
            20475 => new BeeNestBlock(Identifier, Direction.East, 0),
            20476 => new BeeNestBlock(Identifier, Direction.East, 1),
            20477 => new BeeNestBlock(Identifier, Direction.East, 2),
            20478 => new BeeNestBlock(Identifier, Direction.East, 3),
            20479 => new BeeNestBlock(Identifier, Direction.East, 4),
            20480 => new BeeNestBlock(Identifier, Direction.East, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            HoneyLevel = int.Parse(properties["honey_level"].GetString()),
        };
    }
    
}
