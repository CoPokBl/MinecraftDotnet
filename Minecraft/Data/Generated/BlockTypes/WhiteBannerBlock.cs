using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:white_banner";
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
    public string TranslationKey => "block.minecraft.white_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12927,
                1 => 12928,
                2 => 12929,
                3 => 12930,
                4 => 12931,
                5 => 12932,
                6 => 12933,
                7 => 12934,
                8 => 12935,
                9 => 12936,
                10 => 12937,
                11 => 12938,
                12 => 12939,
                13 => 12940,
                14 => 12941,
                15 => 12942,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12927 => new WhiteBannerBlock(Identifier, 0),
            12928 => new WhiteBannerBlock(Identifier, 1),
            12929 => new WhiteBannerBlock(Identifier, 2),
            12930 => new WhiteBannerBlock(Identifier, 3),
            12931 => new WhiteBannerBlock(Identifier, 4),
            12932 => new WhiteBannerBlock(Identifier, 5),
            12933 => new WhiteBannerBlock(Identifier, 6),
            12934 => new WhiteBannerBlock(Identifier, 7),
            12935 => new WhiteBannerBlock(Identifier, 8),
            12936 => new WhiteBannerBlock(Identifier, 9),
            12937 => new WhiteBannerBlock(Identifier, 10),
            12938 => new WhiteBannerBlock(Identifier, 11),
            12939 => new WhiteBannerBlock(Identifier, 12),
            12940 => new WhiteBannerBlock(Identifier, 13),
            12941 => new WhiteBannerBlock(Identifier, 14),
            12942 => new WhiteBannerBlock(Identifier, 15),
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
