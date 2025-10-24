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
    public int ProtocolId => 978;
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
                    true => 23202,
                    false => 23203,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23204,
                    false => 23205,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23206,
                    false => 23207,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23208,
                    false => 23209,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23210,
                    false => 23211,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23212,
                    false => 23213,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23202 => new AmethystClusterBlock(Identifier, Cardinal.North, true),
            23203 => new AmethystClusterBlock(Identifier, Cardinal.North, false),
            23204 => new AmethystClusterBlock(Identifier, Cardinal.East, true),
            23205 => new AmethystClusterBlock(Identifier, Cardinal.East, false),
            23206 => new AmethystClusterBlock(Identifier, Cardinal.South, true),
            23207 => new AmethystClusterBlock(Identifier, Cardinal.South, false),
            23208 => new AmethystClusterBlock(Identifier, Cardinal.West, true),
            23209 => new AmethystClusterBlock(Identifier, Cardinal.West, false),
            23210 => new AmethystClusterBlock(Identifier, Cardinal.Up, true),
            23211 => new AmethystClusterBlock(Identifier, Cardinal.Up, false),
            23212 => new AmethystClusterBlock(Identifier, Cardinal.Down, true),
            23213 => new AmethystClusterBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
