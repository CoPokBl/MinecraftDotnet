using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:lime_banner";
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
    public string TranslationKey => "block.minecraft.lime_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13007,
                1 => 13008,
                2 => 13009,
                3 => 13010,
                4 => 13011,
                5 => 13012,
                6 => 13013,
                7 => 13014,
                8 => 13015,
                9 => 13016,
                10 => 13017,
                11 => 13018,
                12 => 13019,
                13 => 13020,
                14 => 13021,
                15 => 13022,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13007 => new LimeBannerBlock(Identifier, 0),
            13008 => new LimeBannerBlock(Identifier, 1),
            13009 => new LimeBannerBlock(Identifier, 2),
            13010 => new LimeBannerBlock(Identifier, 3),
            13011 => new LimeBannerBlock(Identifier, 4),
            13012 => new LimeBannerBlock(Identifier, 5),
            13013 => new LimeBannerBlock(Identifier, 6),
            13014 => new LimeBannerBlock(Identifier, 7),
            13015 => new LimeBannerBlock(Identifier, 8),
            13016 => new LimeBannerBlock(Identifier, 9),
            13017 => new LimeBannerBlock(Identifier, 10),
            13018 => new LimeBannerBlock(Identifier, 11),
            13019 => new LimeBannerBlock(Identifier, 12),
            13020 => new LimeBannerBlock(Identifier, 13),
            13021 => new LimeBannerBlock(Identifier, 14),
            13022 => new LimeBannerBlock(Identifier, 15),
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
