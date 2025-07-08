using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public Identifier Category => "minecraft:banner";
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
    public Identifier? Item => "minecraft:yellow_banner";
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
    public string TranslationKey => "block.minecraft.yellow_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11712,
                1 => 11713,
                2 => 11714,
                3 => 11715,
                4 => 11716,
                5 => 11717,
                6 => 11718,
                7 => 11719,
                8 => 11720,
                9 => 11721,
                10 => 11722,
                11 => 11723,
                12 => 11724,
                13 => 11725,
                14 => 11726,
                15 => 11727,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11712 => new YellowBannerBlock(Identifier, 0),
            11713 => new YellowBannerBlock(Identifier, 1),
            11714 => new YellowBannerBlock(Identifier, 2),
            11715 => new YellowBannerBlock(Identifier, 3),
            11716 => new YellowBannerBlock(Identifier, 4),
            11717 => new YellowBannerBlock(Identifier, 5),
            11718 => new YellowBannerBlock(Identifier, 6),
            11719 => new YellowBannerBlock(Identifier, 7),
            11720 => new YellowBannerBlock(Identifier, 8),
            11721 => new YellowBannerBlock(Identifier, 9),
            11722 => new YellowBannerBlock(Identifier, 10),
            11723 => new YellowBannerBlock(Identifier, 11),
            11724 => new YellowBannerBlock(Identifier, 12),
            11725 => new YellowBannerBlock(Identifier, 13),
            11726 => new YellowBannerBlock(Identifier, 14),
            11727 => new YellowBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
