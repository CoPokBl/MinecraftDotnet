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
                0 => 6929,
                1 => 6930,
                2 => 6931,
                3 => 6932,
                4 => 6933,
                5 => 6934,
                6 => 6935,
                7 => 6936,
                8 => 6937,
                9 => 6938,
                10 => 6939,
                11 => 6940,
                12 => 6941,
                13 => 6942,
                14 => 6943,
                15 => 6944,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6929 => new CactusBlock(Identifier, 0),
            6930 => new CactusBlock(Identifier, 1),
            6931 => new CactusBlock(Identifier, 2),
            6932 => new CactusBlock(Identifier, 3),
            6933 => new CactusBlock(Identifier, 4),
            6934 => new CactusBlock(Identifier, 5),
            6935 => new CactusBlock(Identifier, 6),
            6936 => new CactusBlock(Identifier, 7),
            6937 => new CactusBlock(Identifier, 8),
            6938 => new CactusBlock(Identifier, 9),
            6939 => new CactusBlock(Identifier, 10),
            6940 => new CactusBlock(Identifier, 11),
            6941 => new CactusBlock(Identifier, 12),
            6942 => new CactusBlock(Identifier, 13),
            6943 => new CactusBlock(Identifier, 14),
            6944 => new CactusBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString()))
        );
    }
    
}
