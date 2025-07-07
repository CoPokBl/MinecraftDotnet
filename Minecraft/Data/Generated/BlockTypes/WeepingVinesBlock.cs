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
                0 => 19634,
                1 => 19635,
                2 => 19636,
                3 => 19637,
                4 => 19638,
                5 => 19639,
                6 => 19640,
                7 => 19641,
                8 => 19642,
                9 => 19643,
                10 => 19644,
                11 => 19645,
                12 => 19646,
                13 => 19647,
                14 => 19648,
                15 => 19649,
                16 => 19650,
                17 => 19651,
                18 => 19652,
                19 => 19653,
                20 => 19654,
                21 => 19655,
                22 => 19656,
                23 => 19657,
                24 => 19658,
                25 => 19659,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19634 => new WeepingVinesBlock(Identifier, 0),
            19635 => new WeepingVinesBlock(Identifier, 1),
            19636 => new WeepingVinesBlock(Identifier, 2),
            19637 => new WeepingVinesBlock(Identifier, 3),
            19638 => new WeepingVinesBlock(Identifier, 4),
            19639 => new WeepingVinesBlock(Identifier, 5),
            19640 => new WeepingVinesBlock(Identifier, 6),
            19641 => new WeepingVinesBlock(Identifier, 7),
            19642 => new WeepingVinesBlock(Identifier, 8),
            19643 => new WeepingVinesBlock(Identifier, 9),
            19644 => new WeepingVinesBlock(Identifier, 10),
            19645 => new WeepingVinesBlock(Identifier, 11),
            19646 => new WeepingVinesBlock(Identifier, 12),
            19647 => new WeepingVinesBlock(Identifier, 13),
            19648 => new WeepingVinesBlock(Identifier, 14),
            19649 => new WeepingVinesBlock(Identifier, 15),
            19650 => new WeepingVinesBlock(Identifier, 16),
            19651 => new WeepingVinesBlock(Identifier, 17),
            19652 => new WeepingVinesBlock(Identifier, 18),
            19653 => new WeepingVinesBlock(Identifier, 19),
            19654 => new WeepingVinesBlock(Identifier, 20),
            19655 => new WeepingVinesBlock(Identifier, 21),
            19656 => new WeepingVinesBlock(Identifier, 22),
            19657 => new WeepingVinesBlock(Identifier, 23),
            19658 => new WeepingVinesBlock(Identifier, 24),
            19659 => new WeepingVinesBlock(Identifier, 25),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
