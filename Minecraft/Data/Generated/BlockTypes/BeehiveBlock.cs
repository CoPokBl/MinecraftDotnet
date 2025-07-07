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
                    0 => 20449,
                    1 => 20450,
                    2 => 20451,
                    3 => 20452,
                    4 => 20453,
                    5 => 20454,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 20455,
                    1 => 20456,
                    2 => 20457,
                    3 => 20458,
                    4 => 20459,
                    5 => 20460,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 20461,
                    1 => 20462,
                    2 => 20463,
                    3 => 20464,
                    4 => 20465,
                    5 => 20466,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 20467,
                    1 => 20468,
                    2 => 20469,
                    3 => 20470,
                    4 => 20471,
                    5 => 20472,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20449 => new BeehiveBlock(Identifier, Direction.North, 0),
            20450 => new BeehiveBlock(Identifier, Direction.North, 1),
            20451 => new BeehiveBlock(Identifier, Direction.North, 2),
            20452 => new BeehiveBlock(Identifier, Direction.North, 3),
            20453 => new BeehiveBlock(Identifier, Direction.North, 4),
            20454 => new BeehiveBlock(Identifier, Direction.North, 5),
            20455 => new BeehiveBlock(Identifier, Direction.South, 0),
            20456 => new BeehiveBlock(Identifier, Direction.South, 1),
            20457 => new BeehiveBlock(Identifier, Direction.South, 2),
            20458 => new BeehiveBlock(Identifier, Direction.South, 3),
            20459 => new BeehiveBlock(Identifier, Direction.South, 4),
            20460 => new BeehiveBlock(Identifier, Direction.South, 5),
            20461 => new BeehiveBlock(Identifier, Direction.West, 0),
            20462 => new BeehiveBlock(Identifier, Direction.West, 1),
            20463 => new BeehiveBlock(Identifier, Direction.West, 2),
            20464 => new BeehiveBlock(Identifier, Direction.West, 3),
            20465 => new BeehiveBlock(Identifier, Direction.West, 4),
            20466 => new BeehiveBlock(Identifier, Direction.West, 5),
            20467 => new BeehiveBlock(Identifier, Direction.East, 0),
            20468 => new BeehiveBlock(Identifier, Direction.East, 1),
            20469 => new BeehiveBlock(Identifier, Direction.East, 2),
            20470 => new BeehiveBlock(Identifier, Direction.East, 3),
            20471 => new BeehiveBlock(Identifier, Direction.East, 4),
            20472 => new BeehiveBlock(Identifier, Direction.East, 5),
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
