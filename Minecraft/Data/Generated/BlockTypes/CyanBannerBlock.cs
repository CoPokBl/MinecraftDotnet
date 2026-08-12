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
                0 => 13071,
                1 => 13072,
                2 => 13073,
                3 => 13074,
                4 => 13075,
                5 => 13076,
                6 => 13077,
                7 => 13078,
                8 => 13079,
                9 => 13080,
                10 => 13081,
                11 => 13082,
                12 => 13083,
                13 => 13084,
                14 => 13085,
                15 => 13086,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13071 => new CyanBannerBlock(Identifier, 0),
            13072 => new CyanBannerBlock(Identifier, 1),
            13073 => new CyanBannerBlock(Identifier, 2),
            13074 => new CyanBannerBlock(Identifier, 3),
            13075 => new CyanBannerBlock(Identifier, 4),
            13076 => new CyanBannerBlock(Identifier, 5),
            13077 => new CyanBannerBlock(Identifier, 6),
            13078 => new CyanBannerBlock(Identifier, 7),
            13079 => new CyanBannerBlock(Identifier, 8),
            13080 => new CyanBannerBlock(Identifier, 9),
            13081 => new CyanBannerBlock(Identifier, 10),
            13082 => new CyanBannerBlock(Identifier, 11),
            13083 => new CyanBannerBlock(Identifier, 12),
            13084 => new CyanBannerBlock(Identifier, 13),
            13085 => new CyanBannerBlock(Identifier, 14),
            13086 => new CyanBannerBlock(Identifier, 15),
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
