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
    public int ProtocolId => 740;
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
                0 => 14860,
                1 => 14861,
                2 => 14862,
                3 => 14863,
                4 => 14864,
                5 => 14865,
                6 => 14866,
                7 => 14867,
                8 => 14868,
                9 => 14869,
                10 => 14870,
                11 => 14871,
                12 => 14872,
                13 => 14873,
                14 => 14874,
                15 => 14875,
                16 => 14876,
                17 => 14877,
                18 => 14878,
                19 => 14879,
                20 => 14880,
                21 => 14881,
                22 => 14882,
                23 => 14883,
                24 => 14884,
                25 => 14885,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14860 => new KelpBlock(Identifier, 0),
            14861 => new KelpBlock(Identifier, 1),
            14862 => new KelpBlock(Identifier, 2),
            14863 => new KelpBlock(Identifier, 3),
            14864 => new KelpBlock(Identifier, 4),
            14865 => new KelpBlock(Identifier, 5),
            14866 => new KelpBlock(Identifier, 6),
            14867 => new KelpBlock(Identifier, 7),
            14868 => new KelpBlock(Identifier, 8),
            14869 => new KelpBlock(Identifier, 9),
            14870 => new KelpBlock(Identifier, 10),
            14871 => new KelpBlock(Identifier, 11),
            14872 => new KelpBlock(Identifier, 12),
            14873 => new KelpBlock(Identifier, 13),
            14874 => new KelpBlock(Identifier, 14),
            14875 => new KelpBlock(Identifier, 15),
            14876 => new KelpBlock(Identifier, 16),
            14877 => new KelpBlock(Identifier, 17),
            14878 => new KelpBlock(Identifier, 18),
            14879 => new KelpBlock(Identifier, 19),
            14880 => new KelpBlock(Identifier, 20),
            14881 => new KelpBlock(Identifier, 21),
            14882 => new KelpBlock(Identifier, 22),
            14883 => new KelpBlock(Identifier, 23),
            14884 => new KelpBlock(Identifier, 24),
            14885 => new KelpBlock(Identifier, 25),
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
