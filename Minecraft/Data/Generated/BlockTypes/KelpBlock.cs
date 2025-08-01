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
    public int ProtocolId => 710;
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
                0 => 13783,
                1 => 13784,
                2 => 13785,
                3 => 13786,
                4 => 13787,
                5 => 13788,
                6 => 13789,
                7 => 13790,
                8 => 13791,
                9 => 13792,
                10 => 13793,
                11 => 13794,
                12 => 13795,
                13 => 13796,
                14 => 13797,
                15 => 13798,
                16 => 13799,
                17 => 13800,
                18 => 13801,
                19 => 13802,
                20 => 13803,
                21 => 13804,
                22 => 13805,
                23 => 13806,
                24 => 13807,
                25 => 13808,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13783 => new KelpBlock(Identifier, 0),
            13784 => new KelpBlock(Identifier, 1),
            13785 => new KelpBlock(Identifier, 2),
            13786 => new KelpBlock(Identifier, 3),
            13787 => new KelpBlock(Identifier, 4),
            13788 => new KelpBlock(Identifier, 5),
            13789 => new KelpBlock(Identifier, 6),
            13790 => new KelpBlock(Identifier, 7),
            13791 => new KelpBlock(Identifier, 8),
            13792 => new KelpBlock(Identifier, 9),
            13793 => new KelpBlock(Identifier, 10),
            13794 => new KelpBlock(Identifier, 11),
            13795 => new KelpBlock(Identifier, 12),
            13796 => new KelpBlock(Identifier, 13),
            13797 => new KelpBlock(Identifier, 14),
            13798 => new KelpBlock(Identifier, 15),
            13799 => new KelpBlock(Identifier, 16),
            13800 => new KelpBlock(Identifier, 17),
            13801 => new KelpBlock(Identifier, 18),
            13802 => new KelpBlock(Identifier, 19),
            13803 => new KelpBlock(Identifier, 20),
            13804 => new KelpBlock(Identifier, 21),
            13805 => new KelpBlock(Identifier, 22),
            13806 => new KelpBlock(Identifier, 23),
            13807 => new KelpBlock(Identifier, 24),
            13808 => new KelpBlock(Identifier, 25),
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
