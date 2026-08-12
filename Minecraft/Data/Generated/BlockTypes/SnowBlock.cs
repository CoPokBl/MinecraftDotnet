using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SnowBlock(Identifier Identifier, int Layers) : IBlock {
    public Identifier Category => "minecraft:snow_layer";
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => true;
    public string SoundType => "snow";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:snow";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 8;
    public string TranslationKey => "block.minecraft.snow";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Layers switch {
                1 => 6919,
                2 => 6920,
                3 => 6921,
                4 => 6922,
                5 => 6923,
                6 => 6924,
                7 => 6925,
                8 => 6926,
                _ => throw new ArgumentOutOfRangeException(nameof(Layers), Layers, "Unknown value for property layers.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6919 => new SnowBlock(Identifier, 1),
            6920 => new SnowBlock(Identifier, 2),
            6921 => new SnowBlock(Identifier, 3),
            6922 => new SnowBlock(Identifier, 4),
            6923 => new SnowBlock(Identifier, 5),
            6924 => new SnowBlock(Identifier, 6),
            6925 => new SnowBlock(Identifier, 7),
            6926 => new SnowBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Layers = properties.Contains("layers") ? int.Parse(properties["layers"].GetString()) : Layers,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("layers", new StringTag(Layers.ToString()))
        );
    }
    
}
