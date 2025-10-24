using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 570;
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
    public Identifier? Item => "minecraft:cyan_banner";
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
    public string TranslationKey => "block.minecraft.cyan_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12869,
                1 => 12870,
                2 => 12871,
                3 => 12872,
                4 => 12873,
                5 => 12874,
                6 => 12875,
                7 => 12876,
                8 => 12877,
                9 => 12878,
                10 => 12879,
                11 => 12880,
                12 => 12881,
                13 => 12882,
                14 => 12883,
                15 => 12884,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12869 => new CyanBannerBlock(Identifier, 0),
            12870 => new CyanBannerBlock(Identifier, 1),
            12871 => new CyanBannerBlock(Identifier, 2),
            12872 => new CyanBannerBlock(Identifier, 3),
            12873 => new CyanBannerBlock(Identifier, 4),
            12874 => new CyanBannerBlock(Identifier, 5),
            12875 => new CyanBannerBlock(Identifier, 6),
            12876 => new CyanBannerBlock(Identifier, 7),
            12877 => new CyanBannerBlock(Identifier, 8),
            12878 => new CyanBannerBlock(Identifier, 9),
            12879 => new CyanBannerBlock(Identifier, 10),
            12880 => new CyanBannerBlock(Identifier, 11),
            12881 => new CyanBannerBlock(Identifier, 12),
            12882 => new CyanBannerBlock(Identifier, 13),
            12883 => new CyanBannerBlock(Identifier, 14),
            12884 => new CyanBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString())
        );
    }
    
}
