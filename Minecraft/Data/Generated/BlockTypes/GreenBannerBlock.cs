using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:green_banner";
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
    public string TranslationKey => "block.minecraft.green_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13135,
                1 => 13136,
                2 => 13137,
                3 => 13138,
                4 => 13139,
                5 => 13140,
                6 => 13141,
                7 => 13142,
                8 => 13143,
                9 => 13144,
                10 => 13145,
                11 => 13146,
                12 => 13147,
                13 => 13148,
                14 => 13149,
                15 => 13150,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13135 => new GreenBannerBlock(Identifier, 0),
            13136 => new GreenBannerBlock(Identifier, 1),
            13137 => new GreenBannerBlock(Identifier, 2),
            13138 => new GreenBannerBlock(Identifier, 3),
            13139 => new GreenBannerBlock(Identifier, 4),
            13140 => new GreenBannerBlock(Identifier, 5),
            13141 => new GreenBannerBlock(Identifier, 6),
            13142 => new GreenBannerBlock(Identifier, 7),
            13143 => new GreenBannerBlock(Identifier, 8),
            13144 => new GreenBannerBlock(Identifier, 9),
            13145 => new GreenBannerBlock(Identifier, 10),
            13146 => new GreenBannerBlock(Identifier, 11),
            13147 => new GreenBannerBlock(Identifier, 12),
            13148 => new GreenBannerBlock(Identifier, 13),
            13149 => new GreenBannerBlock(Identifier, 14),
            13150 => new GreenBannerBlock(Identifier, 15),
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
