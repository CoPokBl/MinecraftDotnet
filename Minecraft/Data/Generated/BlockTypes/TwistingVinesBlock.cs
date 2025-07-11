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
                0 => 19661,
                1 => 19662,
                2 => 19663,
                3 => 19664,
                4 => 19665,
                5 => 19666,
                6 => 19667,
                7 => 19668,
                8 => 19669,
                9 => 19670,
                10 => 19671,
                11 => 19672,
                12 => 19673,
                13 => 19674,
                14 => 19675,
                15 => 19676,
                16 => 19677,
                17 => 19678,
                18 => 19679,
                19 => 19680,
                20 => 19681,
                21 => 19682,
                22 => 19683,
                23 => 19684,
                24 => 19685,
                25 => 19686,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19661 => new TwistingVinesBlock(Identifier, 0),
            19662 => new TwistingVinesBlock(Identifier, 1),
            19663 => new TwistingVinesBlock(Identifier, 2),
            19664 => new TwistingVinesBlock(Identifier, 3),
            19665 => new TwistingVinesBlock(Identifier, 4),
            19666 => new TwistingVinesBlock(Identifier, 5),
            19667 => new TwistingVinesBlock(Identifier, 6),
            19668 => new TwistingVinesBlock(Identifier, 7),
            19669 => new TwistingVinesBlock(Identifier, 8),
            19670 => new TwistingVinesBlock(Identifier, 9),
            19671 => new TwistingVinesBlock(Identifier, 10),
            19672 => new TwistingVinesBlock(Identifier, 11),
            19673 => new TwistingVinesBlock(Identifier, 12),
            19674 => new TwistingVinesBlock(Identifier, 13),
            19675 => new TwistingVinesBlock(Identifier, 14),
            19676 => new TwistingVinesBlock(Identifier, 15),
            19677 => new TwistingVinesBlock(Identifier, 16),
            19678 => new TwistingVinesBlock(Identifier, 17),
            19679 => new TwistingVinesBlock(Identifier, 18),
            19680 => new TwistingVinesBlock(Identifier, 19),
            19681 => new TwistingVinesBlock(Identifier, 20),
            19682 => new TwistingVinesBlock(Identifier, 21),
            19683 => new TwistingVinesBlock(Identifier, 22),
            19684 => new TwistingVinesBlock(Identifier, 23),
            19685 => new TwistingVinesBlock(Identifier, 24),
            19686 => new TwistingVinesBlock(Identifier, 25),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = int.Parse(properties["age"].GetString()),
        };
    }
    
}
