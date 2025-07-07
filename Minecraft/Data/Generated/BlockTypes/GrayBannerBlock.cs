using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayBannerBlock(Identifier Identifier, int Rotation) : IBlock {

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
    public Identifier? Item => "minecraft:gray_banner";
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
    public string TranslationKey => "block.minecraft.gray_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11760,
                1 => 11761,
                2 => 11762,
                3 => 11763,
                4 => 11764,
                5 => 11765,
                6 => 11766,
                7 => 11767,
                8 => 11768,
                9 => 11769,
                10 => 11770,
                11 => 11771,
                12 => 11772,
                13 => 11773,
                14 => 11774,
                15 => 11775,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11760 => new GrayBannerBlock(Identifier, 0),
            11761 => new GrayBannerBlock(Identifier, 1),
            11762 => new GrayBannerBlock(Identifier, 2),
            11763 => new GrayBannerBlock(Identifier, 3),
            11764 => new GrayBannerBlock(Identifier, 4),
            11765 => new GrayBannerBlock(Identifier, 5),
            11766 => new GrayBannerBlock(Identifier, 6),
            11767 => new GrayBannerBlock(Identifier, 7),
            11768 => new GrayBannerBlock(Identifier, 8),
            11769 => new GrayBannerBlock(Identifier, 9),
            11770 => new GrayBannerBlock(Identifier, 10),
            11771 => new GrayBannerBlock(Identifier, 11),
            11772 => new GrayBannerBlock(Identifier, 12),
            11773 => new GrayBannerBlock(Identifier, 13),
            11774 => new GrayBannerBlock(Identifier, 14),
            11775 => new GrayBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
