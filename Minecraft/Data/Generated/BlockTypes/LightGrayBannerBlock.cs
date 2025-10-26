using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 569;
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
    public Identifier? Item => "minecraft:light_gray_banner";
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
    public string TranslationKey => "block.minecraft.light_gray_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12853,
                1 => 12854,
                2 => 12855,
                3 => 12856,
                4 => 12857,
                5 => 12858,
                6 => 12859,
                7 => 12860,
                8 => 12861,
                9 => 12862,
                10 => 12863,
                11 => 12864,
                12 => 12865,
                13 => 12866,
                14 => 12867,
                15 => 12868,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12853 => new LightGrayBannerBlock(Identifier, 0),
            12854 => new LightGrayBannerBlock(Identifier, 1),
            12855 => new LightGrayBannerBlock(Identifier, 2),
            12856 => new LightGrayBannerBlock(Identifier, 3),
            12857 => new LightGrayBannerBlock(Identifier, 4),
            12858 => new LightGrayBannerBlock(Identifier, 5),
            12859 => new LightGrayBannerBlock(Identifier, 6),
            12860 => new LightGrayBannerBlock(Identifier, 7),
            12861 => new LightGrayBannerBlock(Identifier, 8),
            12862 => new LightGrayBannerBlock(Identifier, 9),
            12863 => new LightGrayBannerBlock(Identifier, 10),
            12864 => new LightGrayBannerBlock(Identifier, 11),
            12865 => new LightGrayBannerBlock(Identifier, 12),
            12866 => new LightGrayBannerBlock(Identifier, 13),
            12867 => new LightGrayBannerBlock(Identifier, 14),
            12868 => new LightGrayBannerBlock(Identifier, 15),
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
