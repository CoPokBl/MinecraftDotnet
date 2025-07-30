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
    public int ProtocolId => 840;
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
                0 => 19693,
                1 => 19694,
                2 => 19695,
                3 => 19696,
                4 => 19697,
                5 => 19698,
                6 => 19699,
                7 => 19700,
                8 => 19701,
                9 => 19702,
                10 => 19703,
                11 => 19704,
                12 => 19705,
                13 => 19706,
                14 => 19707,
                15 => 19708,
                16 => 19709,
                17 => 19710,
                18 => 19711,
                19 => 19712,
                20 => 19713,
                21 => 19714,
                22 => 19715,
                23 => 19716,
                24 => 19717,
                25 => 19718,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19693 => new TwistingVinesBlock(Identifier, 0),
            19694 => new TwistingVinesBlock(Identifier, 1),
            19695 => new TwistingVinesBlock(Identifier, 2),
            19696 => new TwistingVinesBlock(Identifier, 3),
            19697 => new TwistingVinesBlock(Identifier, 4),
            19698 => new TwistingVinesBlock(Identifier, 5),
            19699 => new TwistingVinesBlock(Identifier, 6),
            19700 => new TwistingVinesBlock(Identifier, 7),
            19701 => new TwistingVinesBlock(Identifier, 8),
            19702 => new TwistingVinesBlock(Identifier, 9),
            19703 => new TwistingVinesBlock(Identifier, 10),
            19704 => new TwistingVinesBlock(Identifier, 11),
            19705 => new TwistingVinesBlock(Identifier, 12),
            19706 => new TwistingVinesBlock(Identifier, 13),
            19707 => new TwistingVinesBlock(Identifier, 14),
            19708 => new TwistingVinesBlock(Identifier, 15),
            19709 => new TwistingVinesBlock(Identifier, 16),
            19710 => new TwistingVinesBlock(Identifier, 17),
            19711 => new TwistingVinesBlock(Identifier, 18),
            19712 => new TwistingVinesBlock(Identifier, 19),
            19713 => new TwistingVinesBlock(Identifier, 20),
            19714 => new TwistingVinesBlock(Identifier, 21),
            19715 => new TwistingVinesBlock(Identifier, 22),
            19716 => new TwistingVinesBlock(Identifier, 23),
            19717 => new TwistingVinesBlock(Identifier, 24),
            19718 => new TwistingVinesBlock(Identifier, 25),
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
