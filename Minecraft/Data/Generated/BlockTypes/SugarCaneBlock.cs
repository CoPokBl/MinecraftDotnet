using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SugarCaneBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:sugar_cane";
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
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:sugar_cane";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 1.0, 0.875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.sugar_cane";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 6947,
                1 => 6948,
                2 => 6949,
                3 => 6950,
                4 => 6951,
                5 => 6952,
                6 => 6953,
                7 => 6954,
                8 => 6955,
                9 => 6956,
                10 => 6957,
                11 => 6958,
                12 => 6959,
                13 => 6960,
                14 => 6961,
                15 => 6962,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6947 => new SugarCaneBlock(Identifier, 0),
            6948 => new SugarCaneBlock(Identifier, 1),
            6949 => new SugarCaneBlock(Identifier, 2),
            6950 => new SugarCaneBlock(Identifier, 3),
            6951 => new SugarCaneBlock(Identifier, 4),
            6952 => new SugarCaneBlock(Identifier, 5),
            6953 => new SugarCaneBlock(Identifier, 6),
            6954 => new SugarCaneBlock(Identifier, 7),
            6955 => new SugarCaneBlock(Identifier, 8),
            6956 => new SugarCaneBlock(Identifier, 9),
            6957 => new SugarCaneBlock(Identifier, 10),
            6958 => new SugarCaneBlock(Identifier, 11),
            6959 => new SugarCaneBlock(Identifier, 12),
            6960 => new SugarCaneBlock(Identifier, 13),
            6961 => new SugarCaneBlock(Identifier, 14),
            6962 => new SugarCaneBlock(Identifier, 15),
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
