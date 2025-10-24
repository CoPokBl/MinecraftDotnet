using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FarmlandBlock(Identifier Identifier, int Moisture) : IBlock {
    public Identifier Category => "minecraft:farm";
    public int ProtocolId => 207;
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
    public string SoundType => "gravel";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:farmland";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.9375, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.9375, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.9375, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.9375, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.farmland";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Moisture switch {
                0 => 5118,
                1 => 5119,
                2 => 5120,
                3 => 5121,
                4 => 5122,
                5 => 5123,
                6 => 5124,
                7 => 5125,
                _ => throw new ArgumentOutOfRangeException(nameof(Moisture), Moisture, "Unknown value for property moisture.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5118 => new FarmlandBlock(Identifier, 0),
            5119 => new FarmlandBlock(Identifier, 1),
            5120 => new FarmlandBlock(Identifier, 2),
            5121 => new FarmlandBlock(Identifier, 3),
            5122 => new FarmlandBlock(Identifier, 4),
            5123 => new FarmlandBlock(Identifier, 5),
            5124 => new FarmlandBlock(Identifier, 6),
            5125 => new FarmlandBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Moisture = properties.ChildrenMap.ContainsKey("moisture") ? int.Parse(properties["moisture"].GetString()) : Moisture,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("moisture", Moisture.ToString())
        );
    }
    
}
