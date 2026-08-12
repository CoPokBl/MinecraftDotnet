using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:magenta_banner";
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
    public string TranslationKey => "block.minecraft.magenta_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12959,
                1 => 12960,
                2 => 12961,
                3 => 12962,
                4 => 12963,
                5 => 12964,
                6 => 12965,
                7 => 12966,
                8 => 12967,
                9 => 12968,
                10 => 12969,
                11 => 12970,
                12 => 12971,
                13 => 12972,
                14 => 12973,
                15 => 12974,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12959 => new MagentaBannerBlock(Identifier, 0),
            12960 => new MagentaBannerBlock(Identifier, 1),
            12961 => new MagentaBannerBlock(Identifier, 2),
            12962 => new MagentaBannerBlock(Identifier, 3),
            12963 => new MagentaBannerBlock(Identifier, 4),
            12964 => new MagentaBannerBlock(Identifier, 5),
            12965 => new MagentaBannerBlock(Identifier, 6),
            12966 => new MagentaBannerBlock(Identifier, 7),
            12967 => new MagentaBannerBlock(Identifier, 8),
            12968 => new MagentaBannerBlock(Identifier, 9),
            12969 => new MagentaBannerBlock(Identifier, 10),
            12970 => new MagentaBannerBlock(Identifier, 11),
            12971 => new MagentaBannerBlock(Identifier, 12),
            12972 => new MagentaBannerBlock(Identifier, 13),
            12973 => new MagentaBannerBlock(Identifier, 14),
            12974 => new MagentaBannerBlock(Identifier, 15),
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
