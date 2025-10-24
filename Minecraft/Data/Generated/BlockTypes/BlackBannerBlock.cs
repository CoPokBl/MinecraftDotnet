using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 576;
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
    public Identifier? Item => "minecraft:black_banner";
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
    public string TranslationKey => "block.minecraft.black_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12965,
                1 => 12966,
                2 => 12967,
                3 => 12968,
                4 => 12969,
                5 => 12970,
                6 => 12971,
                7 => 12972,
                8 => 12973,
                9 => 12974,
                10 => 12975,
                11 => 12976,
                12 => 12977,
                13 => 12978,
                14 => 12979,
                15 => 12980,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12965 => new BlackBannerBlock(Identifier, 0),
            12966 => new BlackBannerBlock(Identifier, 1),
            12967 => new BlackBannerBlock(Identifier, 2),
            12968 => new BlackBannerBlock(Identifier, 3),
            12969 => new BlackBannerBlock(Identifier, 4),
            12970 => new BlackBannerBlock(Identifier, 5),
            12971 => new BlackBannerBlock(Identifier, 6),
            12972 => new BlackBannerBlock(Identifier, 7),
            12973 => new BlackBannerBlock(Identifier, 8),
            12974 => new BlackBannerBlock(Identifier, 9),
            12975 => new BlackBannerBlock(Identifier, 10),
            12976 => new BlackBannerBlock(Identifier, 11),
            12977 => new BlackBannerBlock(Identifier, 12),
            12978 => new BlackBannerBlock(Identifier, 13),
            12979 => new BlackBannerBlock(Identifier, 14),
            12980 => new BlackBannerBlock(Identifier, 15),
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
