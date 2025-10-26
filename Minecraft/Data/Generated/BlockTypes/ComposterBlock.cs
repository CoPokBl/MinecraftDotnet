using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ComposterBlock(Identifier Identifier, int Level) : IBlock {
    public Identifier Category => "minecraft:composter";
    public int ProtocolId => 907;
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
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:composter";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.0, 0.125, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.125, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.125, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.125, 0.125] -> [1.0, 1.0, 0.875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.0, 0.125, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.125, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.125, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.125, 0.125] -> [1.0, 1.0, 0.875]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.0, 0.125, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.125, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.125, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.125, 0.125] -> [1.0, 1.0, 0.875]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0], AABB[0.0, 0.125, 0.0] -> [0.125, 1.0, 1.0], AABB[0.125, 0.125, 0.0] -> [1.0, 1.0, 0.125], AABB[0.125, 0.125, 0.875] -> [1.0, 1.0, 1.0], AABB[0.875, 0.125, 0.125] -> [1.0, 1.0, 0.875]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.composter";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Level switch {
                0 => 21541,
                1 => 21542,
                2 => 21543,
                3 => 21544,
                4 => 21545,
                5 => 21546,
                6 => 21547,
                7 => 21548,
                8 => 21549,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21541 => new ComposterBlock(Identifier, 0),
            21542 => new ComposterBlock(Identifier, 1),
            21543 => new ComposterBlock(Identifier, 2),
            21544 => new ComposterBlock(Identifier, 3),
            21545 => new ComposterBlock(Identifier, 4),
            21546 => new ComposterBlock(Identifier, 5),
            21547 => new ComposterBlock(Identifier, 6),
            21548 => new ComposterBlock(Identifier, 7),
            21549 => new ComposterBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.ChildrenMap.ContainsKey("level") ? int.Parse(properties["level"].GetString()) : Level,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("level", Level.ToString())
        );
    }
    
}
