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
                0 => 5978,
                1 => 5979,
                2 => 5980,
                3 => 5981,
                4 => 5982,
                5 => 5983,
                6 => 5984,
                7 => 5985,
                8 => 5986,
                9 => 5987,
                10 => 5988,
                11 => 5989,
                12 => 5990,
                13 => 5991,
                14 => 5992,
                15 => 5993,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5978 => new SugarCaneBlock(Identifier, 0),
            5979 => new SugarCaneBlock(Identifier, 1),
            5980 => new SugarCaneBlock(Identifier, 2),
            5981 => new SugarCaneBlock(Identifier, 3),
            5982 => new SugarCaneBlock(Identifier, 4),
            5983 => new SugarCaneBlock(Identifier, 5),
            5984 => new SugarCaneBlock(Identifier, 6),
            5985 => new SugarCaneBlock(Identifier, 7),
            5986 => new SugarCaneBlock(Identifier, 8),
            5987 => new SugarCaneBlock(Identifier, 9),
            5988 => new SugarCaneBlock(Identifier, 10),
            5989 => new SugarCaneBlock(Identifier, 11),
            5990 => new SugarCaneBlock(Identifier, 12),
            5991 => new SugarCaneBlock(Identifier, 13),
            5992 => new SugarCaneBlock(Identifier, 14),
            5993 => new SugarCaneBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
