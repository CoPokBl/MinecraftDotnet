using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 541;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:banner";
    public Identifier? Item => "minecraft:purple_banner";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.purple_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11808,
                1 => 11809,
                2 => 11810,
                3 => 11811,
                4 => 11812,
                5 => 11813,
                6 => 11814,
                7 => 11815,
                8 => 11816,
                9 => 11817,
                10 => 11818,
                11 => 11819,
                12 => 11820,
                13 => 11821,
                14 => 11822,
                15 => 11823,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11808 => new PurpleBannerBlock(Identifier, 0),
            11809 => new PurpleBannerBlock(Identifier, 1),
            11810 => new PurpleBannerBlock(Identifier, 2),
            11811 => new PurpleBannerBlock(Identifier, 3),
            11812 => new PurpleBannerBlock(Identifier, 4),
            11813 => new PurpleBannerBlock(Identifier, 5),
            11814 => new PurpleBannerBlock(Identifier, 6),
            11815 => new PurpleBannerBlock(Identifier, 7),
            11816 => new PurpleBannerBlock(Identifier, 8),
            11817 => new PurpleBannerBlock(Identifier, 9),
            11818 => new PurpleBannerBlock(Identifier, 10),
            11819 => new PurpleBannerBlock(Identifier, 11),
            11820 => new PurpleBannerBlock(Identifier, 12),
            11821 => new PurpleBannerBlock(Identifier, 13),
            11822 => new PurpleBannerBlock(Identifier, 14),
            11823 => new PurpleBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
