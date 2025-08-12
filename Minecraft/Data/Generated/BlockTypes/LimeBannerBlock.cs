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
    public int ProtocolId => 536;
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
                0 => 11728,
                1 => 11729,
                2 => 11730,
                3 => 11731,
                4 => 11732,
                5 => 11733,
                6 => 11734,
                7 => 11735,
                8 => 11736,
                9 => 11737,
                10 => 11738,
                11 => 11739,
                12 => 11740,
                13 => 11741,
                14 => 11742,
                15 => 11743,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11728 => new LimeBannerBlock(Identifier, 0),
            11729 => new LimeBannerBlock(Identifier, 1),
            11730 => new LimeBannerBlock(Identifier, 2),
            11731 => new LimeBannerBlock(Identifier, 3),
            11732 => new LimeBannerBlock(Identifier, 4),
            11733 => new LimeBannerBlock(Identifier, 5),
            11734 => new LimeBannerBlock(Identifier, 6),
            11735 => new LimeBannerBlock(Identifier, 7),
            11736 => new LimeBannerBlock(Identifier, 8),
            11737 => new LimeBannerBlock(Identifier, 9),
            11738 => new LimeBannerBlock(Identifier, 10),
            11739 => new LimeBannerBlock(Identifier, 11),
            11740 => new LimeBannerBlock(Identifier, 12),
            11741 => new LimeBannerBlock(Identifier, 13),
            11742 => new LimeBannerBlock(Identifier, 14),
            11743 => new LimeBannerBlock(Identifier, 15),
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
