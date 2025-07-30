using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CactusBlock(Identifier Identifier, int Age) : IBlock {

    public Identifier Category => "minecraft:cactus";
    public int ProtocolId => 266;
    public double Hardness => 0.4;
    public double ExplosionResistance => 0.4;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wool";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cactus";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.9375, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.9375, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.cactus";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Age switch {
                0 => 5960,
                1 => 5961,
                2 => 5962,
                3 => 5963,
                4 => 5964,
                5 => 5965,
                6 => 5966,
                7 => 5967,
                8 => 5968,
                9 => 5969,
                10 => 5970,
                11 => 5971,
                12 => 5972,
                13 => 5973,
                14 => 5974,
                15 => 5975,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5960 => new CactusBlock(Identifier, 0),
            5961 => new CactusBlock(Identifier, 1),
            5962 => new CactusBlock(Identifier, 2),
            5963 => new CactusBlock(Identifier, 3),
            5964 => new CactusBlock(Identifier, 4),
            5965 => new CactusBlock(Identifier, 5),
            5966 => new CactusBlock(Identifier, 6),
            5967 => new CactusBlock(Identifier, 7),
            5968 => new CactusBlock(Identifier, 8),
            5969 => new CactusBlock(Identifier, 9),
            5970 => new CactusBlock(Identifier, 10),
            5971 => new CactusBlock(Identifier, 11),
            5972 => new CactusBlock(Identifier, 12),
            5973 => new CactusBlock(Identifier, 13),
            5974 => new CactusBlock(Identifier, 14),
            5975 => new CactusBlock(Identifier, 15),
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
