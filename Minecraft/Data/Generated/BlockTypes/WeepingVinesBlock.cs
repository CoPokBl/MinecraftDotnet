using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeepingVinesBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:weeping_vines";
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
    public string SoundType => "weeping_vines";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:weeping_vines";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.5625, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 35;
    public string TranslationKey => "block.minecraft.weeping_vines";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 20977,
                1 => 20978,
                2 => 20979,
                3 => 20980,
                4 => 20981,
                5 => 20982,
                6 => 20983,
                7 => 20984,
                8 => 20985,
                9 => 20986,
                10 => 20987,
                11 => 20988,
                12 => 20989,
                13 => 20990,
                14 => 20991,
                15 => 20992,
                16 => 20993,
                17 => 20994,
                18 => 20995,
                19 => 20996,
                20 => 20997,
                21 => 20998,
                22 => 20999,
                23 => 21000,
                24 => 21001,
                25 => 21002,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20977 => new WeepingVinesBlock(Identifier, 0),
            20978 => new WeepingVinesBlock(Identifier, 1),
            20979 => new WeepingVinesBlock(Identifier, 2),
            20980 => new WeepingVinesBlock(Identifier, 3),
            20981 => new WeepingVinesBlock(Identifier, 4),
            20982 => new WeepingVinesBlock(Identifier, 5),
            20983 => new WeepingVinesBlock(Identifier, 6),
            20984 => new WeepingVinesBlock(Identifier, 7),
            20985 => new WeepingVinesBlock(Identifier, 8),
            20986 => new WeepingVinesBlock(Identifier, 9),
            20987 => new WeepingVinesBlock(Identifier, 10),
            20988 => new WeepingVinesBlock(Identifier, 11),
            20989 => new WeepingVinesBlock(Identifier, 12),
            20990 => new WeepingVinesBlock(Identifier, 13),
            20991 => new WeepingVinesBlock(Identifier, 14),
            20992 => new WeepingVinesBlock(Identifier, 15),
            20993 => new WeepingVinesBlock(Identifier, 16),
            20994 => new WeepingVinesBlock(Identifier, 17),
            20995 => new WeepingVinesBlock(Identifier, 18),
            20996 => new WeepingVinesBlock(Identifier, 19),
            20997 => new WeepingVinesBlock(Identifier, 20),
            20998 => new WeepingVinesBlock(Identifier, 21),
            20999 => new WeepingVinesBlock(Identifier, 22),
            21000 => new WeepingVinesBlock(Identifier, 23),
            21001 => new WeepingVinesBlock(Identifier, 24),
            21002 => new WeepingVinesBlock(Identifier, 25),
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
