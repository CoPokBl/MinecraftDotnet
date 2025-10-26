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
    public int ProtocolId => 281;
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
                0 => 6746,
                1 => 6747,
                2 => 6748,
                3 => 6749,
                4 => 6750,
                5 => 6751,
                6 => 6752,
                7 => 6753,
                8 => 6754,
                9 => 6755,
                10 => 6756,
                11 => 6757,
                12 => 6758,
                13 => 6759,
                14 => 6760,
                15 => 6761,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6746 => new SugarCaneBlock(Identifier, 0),
            6747 => new SugarCaneBlock(Identifier, 1),
            6748 => new SugarCaneBlock(Identifier, 2),
            6749 => new SugarCaneBlock(Identifier, 3),
            6750 => new SugarCaneBlock(Identifier, 4),
            6751 => new SugarCaneBlock(Identifier, 5),
            6752 => new SugarCaneBlock(Identifier, 6),
            6753 => new SugarCaneBlock(Identifier, 7),
            6754 => new SugarCaneBlock(Identifier, 8),
            6755 => new SugarCaneBlock(Identifier, 9),
            6756 => new SugarCaneBlock(Identifier, 10),
            6757 => new SugarCaneBlock(Identifier, 11),
            6758 => new SugarCaneBlock(Identifier, 12),
            6759 => new SugarCaneBlock(Identifier, 13),
            6760 => new SugarCaneBlock(Identifier, 14),
            6761 => new SugarCaneBlock(Identifier, 15),
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
