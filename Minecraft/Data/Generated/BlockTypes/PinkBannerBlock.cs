using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:pink_banner";
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
    public string TranslationKey => "block.minecraft.pink_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13023,
                1 => 13024,
                2 => 13025,
                3 => 13026,
                4 => 13027,
                5 => 13028,
                6 => 13029,
                7 => 13030,
                8 => 13031,
                9 => 13032,
                10 => 13033,
                11 => 13034,
                12 => 13035,
                13 => 13036,
                14 => 13037,
                15 => 13038,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13023 => new PinkBannerBlock(Identifier, 0),
            13024 => new PinkBannerBlock(Identifier, 1),
            13025 => new PinkBannerBlock(Identifier, 2),
            13026 => new PinkBannerBlock(Identifier, 3),
            13027 => new PinkBannerBlock(Identifier, 4),
            13028 => new PinkBannerBlock(Identifier, 5),
            13029 => new PinkBannerBlock(Identifier, 6),
            13030 => new PinkBannerBlock(Identifier, 7),
            13031 => new PinkBannerBlock(Identifier, 8),
            13032 => new PinkBannerBlock(Identifier, 9),
            13033 => new PinkBannerBlock(Identifier, 10),
            13034 => new PinkBannerBlock(Identifier, 11),
            13035 => new PinkBannerBlock(Identifier, 12),
            13036 => new PinkBannerBlock(Identifier, 13),
            13037 => new PinkBannerBlock(Identifier, 14),
            13038 => new PinkBannerBlock(Identifier, 15),
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
