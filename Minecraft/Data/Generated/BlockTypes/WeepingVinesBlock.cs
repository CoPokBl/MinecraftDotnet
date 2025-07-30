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
    public int ProtocolId => 838;
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
                0 => 19666,
                1 => 19667,
                2 => 19668,
                3 => 19669,
                4 => 19670,
                5 => 19671,
                6 => 19672,
                7 => 19673,
                8 => 19674,
                9 => 19675,
                10 => 19676,
                11 => 19677,
                12 => 19678,
                13 => 19679,
                14 => 19680,
                15 => 19681,
                16 => 19682,
                17 => 19683,
                18 => 19684,
                19 => 19685,
                20 => 19686,
                21 => 19687,
                22 => 19688,
                23 => 19689,
                24 => 19690,
                25 => 19691,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19666 => new WeepingVinesBlock(Identifier, 0),
            19667 => new WeepingVinesBlock(Identifier, 1),
            19668 => new WeepingVinesBlock(Identifier, 2),
            19669 => new WeepingVinesBlock(Identifier, 3),
            19670 => new WeepingVinesBlock(Identifier, 4),
            19671 => new WeepingVinesBlock(Identifier, 5),
            19672 => new WeepingVinesBlock(Identifier, 6),
            19673 => new WeepingVinesBlock(Identifier, 7),
            19674 => new WeepingVinesBlock(Identifier, 8),
            19675 => new WeepingVinesBlock(Identifier, 9),
            19676 => new WeepingVinesBlock(Identifier, 10),
            19677 => new WeepingVinesBlock(Identifier, 11),
            19678 => new WeepingVinesBlock(Identifier, 12),
            19679 => new WeepingVinesBlock(Identifier, 13),
            19680 => new WeepingVinesBlock(Identifier, 14),
            19681 => new WeepingVinesBlock(Identifier, 15),
            19682 => new WeepingVinesBlock(Identifier, 16),
            19683 => new WeepingVinesBlock(Identifier, 17),
            19684 => new WeepingVinesBlock(Identifier, 18),
            19685 => new WeepingVinesBlock(Identifier, 19),
            19686 => new WeepingVinesBlock(Identifier, 20),
            19687 => new WeepingVinesBlock(Identifier, 21),
            19688 => new WeepingVinesBlock(Identifier, 22),
            19689 => new WeepingVinesBlock(Identifier, 23),
            19690 => new WeepingVinesBlock(Identifier, 24),
            19691 => new WeepingVinesBlock(Identifier, 25),
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
