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
                0 => 13055,
                1 => 13056,
                2 => 13057,
                3 => 13058,
                4 => 13059,
                5 => 13060,
                6 => 13061,
                7 => 13062,
                8 => 13063,
                9 => 13064,
                10 => 13065,
                11 => 13066,
                12 => 13067,
                13 => 13068,
                14 => 13069,
                15 => 13070,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13055 => new LightGrayBannerBlock(Identifier, 0),
            13056 => new LightGrayBannerBlock(Identifier, 1),
            13057 => new LightGrayBannerBlock(Identifier, 2),
            13058 => new LightGrayBannerBlock(Identifier, 3),
            13059 => new LightGrayBannerBlock(Identifier, 4),
            13060 => new LightGrayBannerBlock(Identifier, 5),
            13061 => new LightGrayBannerBlock(Identifier, 6),
            13062 => new LightGrayBannerBlock(Identifier, 7),
            13063 => new LightGrayBannerBlock(Identifier, 8),
            13064 => new LightGrayBannerBlock(Identifier, 9),
            13065 => new LightGrayBannerBlock(Identifier, 10),
            13066 => new LightGrayBannerBlock(Identifier, 11),
            13067 => new LightGrayBannerBlock(Identifier, 12),
            13068 => new LightGrayBannerBlock(Identifier, 13),
            13069 => new LightGrayBannerBlock(Identifier, 14),
            13070 => new LightGrayBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString()))
        );
    }
    
}
