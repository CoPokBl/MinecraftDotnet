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
                0 => 13039,
                1 => 13040,
                2 => 13041,
                3 => 13042,
                4 => 13043,
                5 => 13044,
                6 => 13045,
                7 => 13046,
                8 => 13047,
                9 => 13048,
                10 => 13049,
                11 => 13050,
                12 => 13051,
                13 => 13052,
                14 => 13053,
                15 => 13054,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13039 => new GrayBannerBlock(Identifier, 0),
            13040 => new GrayBannerBlock(Identifier, 1),
            13041 => new GrayBannerBlock(Identifier, 2),
            13042 => new GrayBannerBlock(Identifier, 3),
            13043 => new GrayBannerBlock(Identifier, 4),
            13044 => new GrayBannerBlock(Identifier, 5),
            13045 => new GrayBannerBlock(Identifier, 6),
            13046 => new GrayBannerBlock(Identifier, 7),
            13047 => new GrayBannerBlock(Identifier, 8),
            13048 => new GrayBannerBlock(Identifier, 9),
            13049 => new GrayBannerBlock(Identifier, 10),
            13050 => new GrayBannerBlock(Identifier, 11),
            13051 => new GrayBannerBlock(Identifier, 12),
            13052 => new GrayBannerBlock(Identifier, 13),
            13053 => new GrayBannerBlock(Identifier, 14),
            13054 => new GrayBannerBlock(Identifier, 15),
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
