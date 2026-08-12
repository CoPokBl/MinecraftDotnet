using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:blue_banner";
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
    public string TranslationKey => "block.minecraft.blue_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13103,
                1 => 13104,
                2 => 13105,
                3 => 13106,
                4 => 13107,
                5 => 13108,
                6 => 13109,
                7 => 13110,
                8 => 13111,
                9 => 13112,
                10 => 13113,
                11 => 13114,
                12 => 13115,
                13 => 13116,
                14 => 13117,
                15 => 13118,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13103 => new BlueBannerBlock(Identifier, 0),
            13104 => new BlueBannerBlock(Identifier, 1),
            13105 => new BlueBannerBlock(Identifier, 2),
            13106 => new BlueBannerBlock(Identifier, 3),
            13107 => new BlueBannerBlock(Identifier, 4),
            13108 => new BlueBannerBlock(Identifier, 5),
            13109 => new BlueBannerBlock(Identifier, 6),
            13110 => new BlueBannerBlock(Identifier, 7),
            13111 => new BlueBannerBlock(Identifier, 8),
            13112 => new BlueBannerBlock(Identifier, 9),
            13113 => new BlueBannerBlock(Identifier, 10),
            13114 => new BlueBannerBlock(Identifier, 11),
            13115 => new BlueBannerBlock(Identifier, 12),
            13116 => new BlueBannerBlock(Identifier, 13),
            13117 => new BlueBannerBlock(Identifier, 14),
            13118 => new BlueBannerBlock(Identifier, 15),
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
