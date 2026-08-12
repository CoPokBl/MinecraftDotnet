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
                0 => 21743,
                1 => 21744,
                2 => 21745,
                3 => 21746,
                4 => 21747,
                5 => 21748,
                6 => 21749,
                7 => 21750,
                8 => 21751,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21743 => new ComposterBlock(Identifier, 0),
            21744 => new ComposterBlock(Identifier, 1),
            21745 => new ComposterBlock(Identifier, 2),
            21746 => new ComposterBlock(Identifier, 3),
            21747 => new ComposterBlock(Identifier, 4),
            21748 => new ComposterBlock(Identifier, 5),
            21749 => new ComposterBlock(Identifier, 6),
            21750 => new ComposterBlock(Identifier, 7),
            21751 => new ComposterBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = properties.Contains("level") ? int.Parse(properties["level"].GetString()) : Level,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("level", new StringTag(Level.ToString()))
        );
    }
    
}
