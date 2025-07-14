using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AmethystClusterBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:amethyst_cluster";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 5;
    public bool Replaceable => false;
    public string SoundType => "amethyst_cluster";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:amethyst_cluster";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.4375, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.4375, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.4375, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.amethyst_cluster";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 22093,
                    false => 22094,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22095,
                    false => 22096,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22097,
                    false => 22098,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22099,
                    false => 22100,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22101,
                    false => 22102,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22103,
                    false => 22104,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22093 => new AmethystClusterBlock(Identifier, Cardinal.North, true),
            22094 => new AmethystClusterBlock(Identifier, Cardinal.North, false),
            22095 => new AmethystClusterBlock(Identifier, Cardinal.East, true),
            22096 => new AmethystClusterBlock(Identifier, Cardinal.East, false),
            22097 => new AmethystClusterBlock(Identifier, Cardinal.South, true),
            22098 => new AmethystClusterBlock(Identifier, Cardinal.South, false),
            22099 => new AmethystClusterBlock(Identifier, Cardinal.West, true),
            22100 => new AmethystClusterBlock(Identifier, Cardinal.West, false),
            22101 => new AmethystClusterBlock(Identifier, Cardinal.Up, true),
            22102 => new AmethystClusterBlock(Identifier, Cardinal.Up, false),
            22103 => new AmethystClusterBlock(Identifier, Cardinal.Down, true),
            22104 => new AmethystClusterBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
