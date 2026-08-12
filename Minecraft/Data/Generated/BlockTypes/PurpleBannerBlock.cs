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
                0 => 13087,
                1 => 13088,
                2 => 13089,
                3 => 13090,
                4 => 13091,
                5 => 13092,
                6 => 13093,
                7 => 13094,
                8 => 13095,
                9 => 13096,
                10 => 13097,
                11 => 13098,
                12 => 13099,
                13 => 13100,
                14 => 13101,
                15 => 13102,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13087 => new PurpleBannerBlock(Identifier, 0),
            13088 => new PurpleBannerBlock(Identifier, 1),
            13089 => new PurpleBannerBlock(Identifier, 2),
            13090 => new PurpleBannerBlock(Identifier, 3),
            13091 => new PurpleBannerBlock(Identifier, 4),
            13092 => new PurpleBannerBlock(Identifier, 5),
            13093 => new PurpleBannerBlock(Identifier, 6),
            13094 => new PurpleBannerBlock(Identifier, 7),
            13095 => new PurpleBannerBlock(Identifier, 8),
            13096 => new PurpleBannerBlock(Identifier, 9),
            13097 => new PurpleBannerBlock(Identifier, 10),
            13098 => new PurpleBannerBlock(Identifier, 11),
            13099 => new PurpleBannerBlock(Identifier, 12),
            13100 => new PurpleBannerBlock(Identifier, 13),
            13101 => new PurpleBannerBlock(Identifier, 14),
            13102 => new PurpleBannerBlock(Identifier, 15),
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
