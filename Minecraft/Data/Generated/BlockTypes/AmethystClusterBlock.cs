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
                    true => 22061,
                    false => 22062,
                },
                Cardinal.East => Waterlogged switch {
                    true => 22063,
                    false => 22064,
                },
                Cardinal.South => Waterlogged switch {
                    true => 22065,
                    false => 22066,
                },
                Cardinal.West => Waterlogged switch {
                    true => 22067,
                    false => 22068,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 22069,
                    false => 22070,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 22071,
                    false => 22072,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22061 => new AmethystClusterBlock(Identifier, Cardinal.North, true),
            22062 => new AmethystClusterBlock(Identifier, Cardinal.North, false),
            22063 => new AmethystClusterBlock(Identifier, Cardinal.East, true),
            22064 => new AmethystClusterBlock(Identifier, Cardinal.East, false),
            22065 => new AmethystClusterBlock(Identifier, Cardinal.South, true),
            22066 => new AmethystClusterBlock(Identifier, Cardinal.South, false),
            22067 => new AmethystClusterBlock(Identifier, Cardinal.West, true),
            22068 => new AmethystClusterBlock(Identifier, Cardinal.West, false),
            22069 => new AmethystClusterBlock(Identifier, Cardinal.Up, true),
            22070 => new AmethystClusterBlock(Identifier, Cardinal.Up, false),
            22071 => new AmethystClusterBlock(Identifier, Cardinal.Down, true),
            22072 => new AmethystClusterBlock(Identifier, Cardinal.Down, false),
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
