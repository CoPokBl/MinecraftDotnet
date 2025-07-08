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
                    0 => 20425,
                    1 => 20426,
                    2 => 20427,
                    3 => 20428,
                    4 => 20429,
                    5 => 20430,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 20431,
                    1 => 20432,
                    2 => 20433,
                    3 => 20434,
                    4 => 20435,
                    5 => 20436,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 20437,
                    1 => 20438,
                    2 => 20439,
                    3 => 20440,
                    4 => 20441,
                    5 => 20442,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 20443,
                    1 => 20444,
                    2 => 20445,
                    3 => 20446,
                    4 => 20447,
                    5 => 20448,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20425 => new BeeNestBlock(Identifier, Direction.North, 0),
            20426 => new BeeNestBlock(Identifier, Direction.North, 1),
            20427 => new BeeNestBlock(Identifier, Direction.North, 2),
            20428 => new BeeNestBlock(Identifier, Direction.North, 3),
            20429 => new BeeNestBlock(Identifier, Direction.North, 4),
            20430 => new BeeNestBlock(Identifier, Direction.North, 5),
            20431 => new BeeNestBlock(Identifier, Direction.South, 0),
            20432 => new BeeNestBlock(Identifier, Direction.South, 1),
            20433 => new BeeNestBlock(Identifier, Direction.South, 2),
            20434 => new BeeNestBlock(Identifier, Direction.South, 3),
            20435 => new BeeNestBlock(Identifier, Direction.South, 4),
            20436 => new BeeNestBlock(Identifier, Direction.South, 5),
            20437 => new BeeNestBlock(Identifier, Direction.West, 0),
            20438 => new BeeNestBlock(Identifier, Direction.West, 1),
            20439 => new BeeNestBlock(Identifier, Direction.West, 2),
            20440 => new BeeNestBlock(Identifier, Direction.West, 3),
            20441 => new BeeNestBlock(Identifier, Direction.West, 4),
            20442 => new BeeNestBlock(Identifier, Direction.West, 5),
            20443 => new BeeNestBlock(Identifier, Direction.East, 0),
            20444 => new BeeNestBlock(Identifier, Direction.East, 1),
            20445 => new BeeNestBlock(Identifier, Direction.East, 2),
            20446 => new BeeNestBlock(Identifier, Direction.East, 3),
            20447 => new BeeNestBlock(Identifier, Direction.East, 4),
            20448 => new BeeNestBlock(Identifier, Direction.East, 5),
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
