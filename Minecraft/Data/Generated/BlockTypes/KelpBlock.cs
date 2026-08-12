using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record KelpBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:kelp";
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
    public string SoundType => "wet_grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:kelp";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 12;
    public string TranslationKey => "block.minecraft.kelp";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 15062,
                1 => 15063,
                2 => 15064,
                3 => 15065,
                4 => 15066,
                5 => 15067,
                6 => 15068,
                7 => 15069,
                8 => 15070,
                9 => 15071,
                10 => 15072,
                11 => 15073,
                12 => 15074,
                13 => 15075,
                14 => 15076,
                15 => 15077,
                16 => 15078,
                17 => 15079,
                18 => 15080,
                19 => 15081,
                20 => 15082,
                21 => 15083,
                22 => 15084,
                23 => 15085,
                24 => 15086,
                25 => 15087,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15062 => new KelpBlock(Identifier, 0),
            15063 => new KelpBlock(Identifier, 1),
            15064 => new KelpBlock(Identifier, 2),
            15065 => new KelpBlock(Identifier, 3),
            15066 => new KelpBlock(Identifier, 4),
            15067 => new KelpBlock(Identifier, 5),
            15068 => new KelpBlock(Identifier, 6),
            15069 => new KelpBlock(Identifier, 7),
            15070 => new KelpBlock(Identifier, 8),
            15071 => new KelpBlock(Identifier, 9),
            15072 => new KelpBlock(Identifier, 10),
            15073 => new KelpBlock(Identifier, 11),
            15074 => new KelpBlock(Identifier, 12),
            15075 => new KelpBlock(Identifier, 13),
            15076 => new KelpBlock(Identifier, 14),
            15077 => new KelpBlock(Identifier, 15),
            15078 => new KelpBlock(Identifier, 16),
            15079 => new KelpBlock(Identifier, 17),
            15080 => new KelpBlock(Identifier, 18),
            15081 => new KelpBlock(Identifier, 19),
            15082 => new KelpBlock(Identifier, 20),
            15083 => new KelpBlock(Identifier, 21),
            15084 => new KelpBlock(Identifier, 22),
            15085 => new KelpBlock(Identifier, 23),
            15086 => new KelpBlock(Identifier, 24),
            15087 => new KelpBlock(Identifier, 25),
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
