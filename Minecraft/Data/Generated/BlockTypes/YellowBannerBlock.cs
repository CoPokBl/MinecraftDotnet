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
                0 => 12991,
                1 => 12992,
                2 => 12993,
                3 => 12994,
                4 => 12995,
                5 => 12996,
                6 => 12997,
                7 => 12998,
                8 => 12999,
                9 => 13000,
                10 => 13001,
                11 => 13002,
                12 => 13003,
                13 => 13004,
                14 => 13005,
                15 => 13006,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12991 => new YellowBannerBlock(Identifier, 0),
            12992 => new YellowBannerBlock(Identifier, 1),
            12993 => new YellowBannerBlock(Identifier, 2),
            12994 => new YellowBannerBlock(Identifier, 3),
            12995 => new YellowBannerBlock(Identifier, 4),
            12996 => new YellowBannerBlock(Identifier, 5),
            12997 => new YellowBannerBlock(Identifier, 6),
            12998 => new YellowBannerBlock(Identifier, 7),
            12999 => new YellowBannerBlock(Identifier, 8),
            13000 => new YellowBannerBlock(Identifier, 9),
            13001 => new YellowBannerBlock(Identifier, 10),
            13002 => new YellowBannerBlock(Identifier, 11),
            13003 => new YellowBannerBlock(Identifier, 12),
            13004 => new YellowBannerBlock(Identifier, 13),
            13005 => new YellowBannerBlock(Identifier, 14),
            13006 => new YellowBannerBlock(Identifier, 15),
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
