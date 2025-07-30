using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MelonStemBlock(Identifier Identifier, int Age) : IBlock {

    public Identifier Category => "minecraft:stem";
    public int ProtocolId => 334;
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
    public Identifier? Item => "minecraft:melon_seeds";
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
    public string TranslationKey => "block.minecraft.melon_stem";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 7072,
                1 => 7073,
                2 => 7074,
                3 => 7075,
                4 => 7076,
                5 => 7077,
                6 => 7078,
                7 => 7079,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7072 => new MelonStemBlock(Identifier, 0),
            7073 => new MelonStemBlock(Identifier, 1),
            7074 => new MelonStemBlock(Identifier, 2),
            7075 => new MelonStemBlock(Identifier, 3),
            7076 => new MelonStemBlock(Identifier, 4),
            7077 => new MelonStemBlock(Identifier, 5),
            7078 => new MelonStemBlock(Identifier, 6),
            7079 => new MelonStemBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString())
        );
    }
    
}
