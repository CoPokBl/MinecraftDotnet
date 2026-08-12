using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:red_banner";
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
    public string TranslationKey => "block.minecraft.red_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13151,
                1 => 13152,
                2 => 13153,
                3 => 13154,
                4 => 13155,
                5 => 13156,
                6 => 13157,
                7 => 13158,
                8 => 13159,
                9 => 13160,
                10 => 13161,
                11 => 13162,
                12 => 13163,
                13 => 13164,
                14 => 13165,
                15 => 13166,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13151 => new RedBannerBlock(Identifier, 0),
            13152 => new RedBannerBlock(Identifier, 1),
            13153 => new RedBannerBlock(Identifier, 2),
            13154 => new RedBannerBlock(Identifier, 3),
            13155 => new RedBannerBlock(Identifier, 4),
            13156 => new RedBannerBlock(Identifier, 5),
            13157 => new RedBannerBlock(Identifier, 6),
            13158 => new RedBannerBlock(Identifier, 7),
            13159 => new RedBannerBlock(Identifier, 8),
            13160 => new RedBannerBlock(Identifier, 9),
            13161 => new RedBannerBlock(Identifier, 10),
            13162 => new RedBannerBlock(Identifier, 11),
            13163 => new RedBannerBlock(Identifier, 12),
            13164 => new RedBannerBlock(Identifier, 13),
            13165 => new RedBannerBlock(Identifier, 14),
            13166 => new RedBannerBlock(Identifier, 15),
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
