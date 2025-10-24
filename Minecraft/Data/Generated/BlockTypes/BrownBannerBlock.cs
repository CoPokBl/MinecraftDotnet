using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 573;
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
    public Identifier? Item => "minecraft:brown_banner";
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
    public string TranslationKey => "block.minecraft.brown_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12917,
                1 => 12918,
                2 => 12919,
                3 => 12920,
                4 => 12921,
                5 => 12922,
                6 => 12923,
                7 => 12924,
                8 => 12925,
                9 => 12926,
                10 => 12927,
                11 => 12928,
                12 => 12929,
                13 => 12930,
                14 => 12931,
                15 => 12932,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12917 => new BrownBannerBlock(Identifier, 0),
            12918 => new BrownBannerBlock(Identifier, 1),
            12919 => new BrownBannerBlock(Identifier, 2),
            12920 => new BrownBannerBlock(Identifier, 3),
            12921 => new BrownBannerBlock(Identifier, 4),
            12922 => new BrownBannerBlock(Identifier, 5),
            12923 => new BrownBannerBlock(Identifier, 6),
            12924 => new BrownBannerBlock(Identifier, 7),
            12925 => new BrownBannerBlock(Identifier, 8),
            12926 => new BrownBannerBlock(Identifier, 9),
            12927 => new BrownBannerBlock(Identifier, 10),
            12928 => new BrownBannerBlock(Identifier, 11),
            12929 => new BrownBannerBlock(Identifier, 12),
            12930 => new BrownBannerBlock(Identifier, 13),
            12931 => new BrownBannerBlock(Identifier, 14),
            12932 => new BrownBannerBlock(Identifier, 15),
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
