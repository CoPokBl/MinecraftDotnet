using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SuspiciousSandBlock(Identifier Identifier, int Dusted) : IBlock {

    public Identifier Category => "minecraft:brushable";
    public int ProtocolId => 38;
    public double Hardness => 0.25;
    public double ExplosionResistance => 0.25;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "suspicious_sand";
    public Identifier? BlockEntity => "minecraft:brushable_block";
    public Identifier? Item => "minecraft:suspicious_sand";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.suspicious_sand";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Dusted switch {
                0 => 119,
                1 => 120,
                2 => 121,
                3 => 122,
                _ => throw new ArgumentOutOfRangeException(nameof(Dusted), Dusted, "Unknown value for property dusted.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            119 => new SuspiciousSandBlock(Identifier, 0),
            120 => new SuspiciousSandBlock(Identifier, 1),
            121 => new SuspiciousSandBlock(Identifier, 2),
            122 => new SuspiciousSandBlock(Identifier, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Dusted = int.Parse(properties["dusted"].GetString()),
        };
    }
    
}
