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
    public int ProtocolId => 876;
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
                0 => 20775,
                1 => 20776,
                2 => 20777,
                3 => 20778,
                4 => 20779,
                5 => 20780,
                6 => 20781,
                7 => 20782,
                8 => 20783,
                9 => 20784,
                10 => 20785,
                11 => 20786,
                12 => 20787,
                13 => 20788,
                14 => 20789,
                15 => 20790,
                16 => 20791,
                17 => 20792,
                18 => 20793,
                19 => 20794,
                20 => 20795,
                21 => 20796,
                22 => 20797,
                23 => 20798,
                24 => 20799,
                25 => 20800,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20775 => new WeepingVinesBlock(Identifier, 0),
            20776 => new WeepingVinesBlock(Identifier, 1),
            20777 => new WeepingVinesBlock(Identifier, 2),
            20778 => new WeepingVinesBlock(Identifier, 3),
            20779 => new WeepingVinesBlock(Identifier, 4),
            20780 => new WeepingVinesBlock(Identifier, 5),
            20781 => new WeepingVinesBlock(Identifier, 6),
            20782 => new WeepingVinesBlock(Identifier, 7),
            20783 => new WeepingVinesBlock(Identifier, 8),
            20784 => new WeepingVinesBlock(Identifier, 9),
            20785 => new WeepingVinesBlock(Identifier, 10),
            20786 => new WeepingVinesBlock(Identifier, 11),
            20787 => new WeepingVinesBlock(Identifier, 12),
            20788 => new WeepingVinesBlock(Identifier, 13),
            20789 => new WeepingVinesBlock(Identifier, 14),
            20790 => new WeepingVinesBlock(Identifier, 15),
            20791 => new WeepingVinesBlock(Identifier, 16),
            20792 => new WeepingVinesBlock(Identifier, 17),
            20793 => new WeepingVinesBlock(Identifier, 18),
            20794 => new WeepingVinesBlock(Identifier, 19),
            20795 => new WeepingVinesBlock(Identifier, 20),
            20796 => new WeepingVinesBlock(Identifier, 21),
            20797 => new WeepingVinesBlock(Identifier, 22),
            20798 => new WeepingVinesBlock(Identifier, 23),
            20799 => new WeepingVinesBlock(Identifier, 24),
            20800 => new WeepingVinesBlock(Identifier, 25),
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
