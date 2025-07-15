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
                    0 => 20481,
                    1 => 20482,
                    2 => 20483,
                    3 => 20484,
                    4 => 20485,
                    5 => 20486,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 20487,
                    1 => 20488,
                    2 => 20489,
                    3 => 20490,
                    4 => 20491,
                    5 => 20492,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 20493,
                    1 => 20494,
                    2 => 20495,
                    3 => 20496,
                    4 => 20497,
                    5 => 20498,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 20499,
                    1 => 20500,
                    2 => 20501,
                    3 => 20502,
                    4 => 20503,
                    5 => 20504,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20481 => new BeehiveBlock(Identifier, Direction.North, 0),
            20482 => new BeehiveBlock(Identifier, Direction.North, 1),
            20483 => new BeehiveBlock(Identifier, Direction.North, 2),
            20484 => new BeehiveBlock(Identifier, Direction.North, 3),
            20485 => new BeehiveBlock(Identifier, Direction.North, 4),
            20486 => new BeehiveBlock(Identifier, Direction.North, 5),
            20487 => new BeehiveBlock(Identifier, Direction.South, 0),
            20488 => new BeehiveBlock(Identifier, Direction.South, 1),
            20489 => new BeehiveBlock(Identifier, Direction.South, 2),
            20490 => new BeehiveBlock(Identifier, Direction.South, 3),
            20491 => new BeehiveBlock(Identifier, Direction.South, 4),
            20492 => new BeehiveBlock(Identifier, Direction.South, 5),
            20493 => new BeehiveBlock(Identifier, Direction.West, 0),
            20494 => new BeehiveBlock(Identifier, Direction.West, 1),
            20495 => new BeehiveBlock(Identifier, Direction.West, 2),
            20496 => new BeehiveBlock(Identifier, Direction.West, 3),
            20497 => new BeehiveBlock(Identifier, Direction.West, 4),
            20498 => new BeehiveBlock(Identifier, Direction.West, 5),
            20499 => new BeehiveBlock(Identifier, Direction.East, 0),
            20500 => new BeehiveBlock(Identifier, Direction.East, 1),
            20501 => new BeehiveBlock(Identifier, Direction.East, 2),
            20502 => new BeehiveBlock(Identifier, Direction.East, 3),
            20503 => new BeehiveBlock(Identifier, Direction.East, 4),
            20504 => new BeehiveBlock(Identifier, Direction.East, 5),
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
