using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CarrotsBlock(Identifier Identifier, int Age) : IBlock {

    public Identifier Category => "minecraft:carrot";
    public int ProtocolId => 409;
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
    public string SoundType => "crop";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:carrot";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.carrots";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 9380,
                1 => 9381,
                2 => 9382,
                3 => 9383,
                4 => 9384,
                5 => 9385,
                6 => 9386,
                7 => 9387,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9380 => new CarrotsBlock(Identifier, 0),
            9381 => new CarrotsBlock(Identifier, 1),
            9382 => new CarrotsBlock(Identifier, 2),
            9383 => new CarrotsBlock(Identifier, 3),
            9384 => new CarrotsBlock(Identifier, 4),
            9385 => new CarrotsBlock(Identifier, 5),
            9386 => new CarrotsBlock(Identifier, 6),
            9387 => new CarrotsBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
