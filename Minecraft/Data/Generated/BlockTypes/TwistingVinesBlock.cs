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
    public int ProtocolId => 878;
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
                0 => 20802,
                1 => 20803,
                2 => 20804,
                3 => 20805,
                4 => 20806,
                5 => 20807,
                6 => 20808,
                7 => 20809,
                8 => 20810,
                9 => 20811,
                10 => 20812,
                11 => 20813,
                12 => 20814,
                13 => 20815,
                14 => 20816,
                15 => 20817,
                16 => 20818,
                17 => 20819,
                18 => 20820,
                19 => 20821,
                20 => 20822,
                21 => 20823,
                22 => 20824,
                23 => 20825,
                24 => 20826,
                25 => 20827,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20802 => new TwistingVinesBlock(Identifier, 0),
            20803 => new TwistingVinesBlock(Identifier, 1),
            20804 => new TwistingVinesBlock(Identifier, 2),
            20805 => new TwistingVinesBlock(Identifier, 3),
            20806 => new TwistingVinesBlock(Identifier, 4),
            20807 => new TwistingVinesBlock(Identifier, 5),
            20808 => new TwistingVinesBlock(Identifier, 6),
            20809 => new TwistingVinesBlock(Identifier, 7),
            20810 => new TwistingVinesBlock(Identifier, 8),
            20811 => new TwistingVinesBlock(Identifier, 9),
            20812 => new TwistingVinesBlock(Identifier, 10),
            20813 => new TwistingVinesBlock(Identifier, 11),
            20814 => new TwistingVinesBlock(Identifier, 12),
            20815 => new TwistingVinesBlock(Identifier, 13),
            20816 => new TwistingVinesBlock(Identifier, 14),
            20817 => new TwistingVinesBlock(Identifier, 15),
            20818 => new TwistingVinesBlock(Identifier, 16),
            20819 => new TwistingVinesBlock(Identifier, 17),
            20820 => new TwistingVinesBlock(Identifier, 18),
            20821 => new TwistingVinesBlock(Identifier, 19),
            20822 => new TwistingVinesBlock(Identifier, 20),
            20823 => new TwistingVinesBlock(Identifier, 21),
            20824 => new TwistingVinesBlock(Identifier, 22),
            20825 => new TwistingVinesBlock(Identifier, 23),
            20826 => new TwistingVinesBlock(Identifier, 24),
            20827 => new TwistingVinesBlock(Identifier, 25),
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
