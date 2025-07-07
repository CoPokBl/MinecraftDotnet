using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayBannerBlock(Identifier Identifier, int Rotation) : IBlock {

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
    public Identifier? Item => "minecraft:light_gray_banner";
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
    public string TranslationKey => "block.minecraft.light_gray_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11776,
                1 => 11777,
                2 => 11778,
                3 => 11779,
                4 => 11780,
                5 => 11781,
                6 => 11782,
                7 => 11783,
                8 => 11784,
                9 => 11785,
                10 => 11786,
                11 => 11787,
                12 => 11788,
                13 => 11789,
                14 => 11790,
                15 => 11791,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11776 => new LightGrayBannerBlock(Identifier, 0),
            11777 => new LightGrayBannerBlock(Identifier, 1),
            11778 => new LightGrayBannerBlock(Identifier, 2),
            11779 => new LightGrayBannerBlock(Identifier, 3),
            11780 => new LightGrayBannerBlock(Identifier, 4),
            11781 => new LightGrayBannerBlock(Identifier, 5),
            11782 => new LightGrayBannerBlock(Identifier, 6),
            11783 => new LightGrayBannerBlock(Identifier, 7),
            11784 => new LightGrayBannerBlock(Identifier, 8),
            11785 => new LightGrayBannerBlock(Identifier, 9),
            11786 => new LightGrayBannerBlock(Identifier, 10),
            11787 => new LightGrayBannerBlock(Identifier, 11),
            11788 => new LightGrayBannerBlock(Identifier, 12),
            11789 => new LightGrayBannerBlock(Identifier, 13),
            11790 => new LightGrayBannerBlock(Identifier, 14),
            11791 => new LightGrayBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
