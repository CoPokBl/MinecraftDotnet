using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TwistingVinesBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:twisting_vines";
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
    public Identifier? Item => "minecraft:twisting_vines";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.9375, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.twisting_vines";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 21004,
                1 => 21005,
                2 => 21006,
                3 => 21007,
                4 => 21008,
                5 => 21009,
                6 => 21010,
                7 => 21011,
                8 => 21012,
                9 => 21013,
                10 => 21014,
                11 => 21015,
                12 => 21016,
                13 => 21017,
                14 => 21018,
                15 => 21019,
                16 => 21020,
                17 => 21021,
                18 => 21022,
                19 => 21023,
                20 => 21024,
                21 => 21025,
                22 => 21026,
                23 => 21027,
                24 => 21028,
                25 => 21029,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21004 => new TwistingVinesBlock(Identifier, 0),
            21005 => new TwistingVinesBlock(Identifier, 1),
            21006 => new TwistingVinesBlock(Identifier, 2),
            21007 => new TwistingVinesBlock(Identifier, 3),
            21008 => new TwistingVinesBlock(Identifier, 4),
            21009 => new TwistingVinesBlock(Identifier, 5),
            21010 => new TwistingVinesBlock(Identifier, 6),
            21011 => new TwistingVinesBlock(Identifier, 7),
            21012 => new TwistingVinesBlock(Identifier, 8),
            21013 => new TwistingVinesBlock(Identifier, 9),
            21014 => new TwistingVinesBlock(Identifier, 10),
            21015 => new TwistingVinesBlock(Identifier, 11),
            21016 => new TwistingVinesBlock(Identifier, 12),
            21017 => new TwistingVinesBlock(Identifier, 13),
            21018 => new TwistingVinesBlock(Identifier, 14),
            21019 => new TwistingVinesBlock(Identifier, 15),
            21020 => new TwistingVinesBlock(Identifier, 16),
            21021 => new TwistingVinesBlock(Identifier, 17),
            21022 => new TwistingVinesBlock(Identifier, 18),
            21023 => new TwistingVinesBlock(Identifier, 19),
            21024 => new TwistingVinesBlock(Identifier, 20),
            21025 => new TwistingVinesBlock(Identifier, 21),
            21026 => new TwistingVinesBlock(Identifier, 22),
            21027 => new TwistingVinesBlock(Identifier, 23),
            21028 => new TwistingVinesBlock(Identifier, 24),
            21029 => new TwistingVinesBlock(Identifier, 25),
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
