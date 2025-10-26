using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PumpkinStemBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:stem";
    public int ProtocolId => 363;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "hard_crop";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pumpkin_seeds";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.125, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.pumpkin_stem";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 8141,
                1 => 8142,
                2 => 8143,
                3 => 8144,
                4 => 8145,
                5 => 8146,
                6 => 8147,
                7 => 8148,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8141 => new PumpkinStemBlock(Identifier, 0),
            8142 => new PumpkinStemBlock(Identifier, 1),
            8143 => new PumpkinStemBlock(Identifier, 2),
            8144 => new PumpkinStemBlock(Identifier, 3),
            8145 => new PumpkinStemBlock(Identifier, 4),
            8146 => new PumpkinStemBlock(Identifier, 5),
            8147 => new PumpkinStemBlock(Identifier, 6),
            8148 => new PumpkinStemBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.ChildrenMap.ContainsKey("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString())
        );
    }
    
}
