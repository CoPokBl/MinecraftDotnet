using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DamagedAnvilBlock(Identifier Identifier, Direction Facing) : IBlock {

    public Identifier Category => "minecraft:anvil";
    public int ProtocolId => 437;
    public double Hardness => 5;
    public double ExplosionResistance => 1200;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "anvil";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:damaged_anvil";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.25, 0.875], AABB[0.25, 0.25, 0.1875] -> [0.75, 0.3125, 0.8125], AABB[0.375, 0.3125, 0.25] -> [0.625, 1.0, 0.75], AABB[0.1875, 0.625, 0.0] -> [0.375, 1.0, 1.0], AABB[0.375, 0.625, 0.0] -> [0.8125, 1.0, 0.25], AABB[0.375, 0.625, 0.75] -> [0.8125, 1.0, 1.0], AABB[0.625, 0.625, 0.25] -> [0.8125, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.25, 0.875], AABB[0.25, 0.25, 0.1875] -> [0.75, 0.3125, 0.8125], AABB[0.375, 0.3125, 0.25] -> [0.625, 1.0, 0.75], AABB[0.1875, 0.625, 0.0] -> [0.375, 1.0, 1.0], AABB[0.375, 0.625, 0.0] -> [0.8125, 1.0, 0.25], AABB[0.375, 0.625, 0.75] -> [0.8125, 1.0, 1.0], AABB[0.625, 0.625, 0.25] -> [0.8125, 1.0, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.25, 0.875], AABB[0.25, 0.25, 0.1875] -> [0.75, 0.3125, 0.8125], AABB[0.375, 0.3125, 0.25] -> [0.625, 1.0, 0.75], AABB[0.1875, 0.625, 0.0] -> [0.375, 1.0, 1.0], AABB[0.375, 0.625, 0.0] -> [0.8125, 1.0, 0.25], AABB[0.375, 0.625, 0.75] -> [0.8125, 1.0, 1.0], AABB[0.625, 0.625, 0.25] -> [0.8125, 1.0, 0.75]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.25, 0.875], AABB[0.25, 0.25, 0.1875] -> [0.75, 0.3125, 0.8125], AABB[0.375, 0.3125, 0.25] -> [0.625, 1.0, 0.75], AABB[0.1875, 0.625, 0.0] -> [0.375, 1.0, 1.0], AABB[0.375, 0.625, 0.0] -> [0.8125, 1.0, 0.25], AABB[0.375, 0.625, 0.75] -> [0.8125, 1.0, 1.0], AABB[0.625, 0.625, 0.25] -> [0.8125, 1.0, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.damaged_anvil";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => 9924,
                Direction.South => 9925,
                Direction.West => 9926,
                Direction.East => 9927,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9924 => new DamagedAnvilBlock(Identifier, Direction.North),
            9925 => new DamagedAnvilBlock(Identifier, Direction.South),
            9926 => new DamagedAnvilBlock(Identifier, Direction.West),
            9927 => new DamagedAnvilBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
