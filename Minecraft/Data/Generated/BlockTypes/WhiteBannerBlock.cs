using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 561;
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
    public Identifier? Item => "minecraft:white_banner";
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
    public string TranslationKey => "block.minecraft.white_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12725,
                1 => 12726,
                2 => 12727,
                3 => 12728,
                4 => 12729,
                5 => 12730,
                6 => 12731,
                7 => 12732,
                8 => 12733,
                9 => 12734,
                10 => 12735,
                11 => 12736,
                12 => 12737,
                13 => 12738,
                14 => 12739,
                15 => 12740,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12725 => new WhiteBannerBlock(Identifier, 0),
            12726 => new WhiteBannerBlock(Identifier, 1),
            12727 => new WhiteBannerBlock(Identifier, 2),
            12728 => new WhiteBannerBlock(Identifier, 3),
            12729 => new WhiteBannerBlock(Identifier, 4),
            12730 => new WhiteBannerBlock(Identifier, 5),
            12731 => new WhiteBannerBlock(Identifier, 6),
            12732 => new WhiteBannerBlock(Identifier, 7),
            12733 => new WhiteBannerBlock(Identifier, 8),
            12734 => new WhiteBannerBlock(Identifier, 9),
            12735 => new WhiteBannerBlock(Identifier, 10),
            12736 => new WhiteBannerBlock(Identifier, 11),
            12737 => new WhiteBannerBlock(Identifier, 12),
            12738 => new WhiteBannerBlock(Identifier, 13),
            12739 => new WhiteBannerBlock(Identifier, 14),
            12740 => new WhiteBannerBlock(Identifier, 15),
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
