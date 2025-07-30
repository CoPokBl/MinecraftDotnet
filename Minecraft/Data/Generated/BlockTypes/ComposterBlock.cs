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
    public int ProtocolId => 869;
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
                0 => 20432,
                1 => 20433,
                2 => 20434,
                3 => 20435,
                4 => 20436,
                5 => 20437,
                6 => 20438,
                7 => 20439,
                8 => 20440,
                _ => throw new ArgumentOutOfRangeException(nameof(Level), Level, "Unknown value for property level.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20432 => new ComposterBlock(Identifier, 0),
            20433 => new ComposterBlock(Identifier, 1),
            20434 => new ComposterBlock(Identifier, 2),
            20435 => new ComposterBlock(Identifier, 3),
            20436 => new ComposterBlock(Identifier, 4),
            20437 => new ComposterBlock(Identifier, 5),
            20438 => new ComposterBlock(Identifier, 6),
            20439 => new ComposterBlock(Identifier, 7),
            20440 => new ComposterBlock(Identifier, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Level = int.Parse(properties["level"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("level", Level.ToString())
        );
    }
    
}
