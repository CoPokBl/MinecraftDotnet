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
    public int ProtocolId => 540;
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
                0 => 11792,
                1 => 11793,
                2 => 11794,
                3 => 11795,
                4 => 11796,
                5 => 11797,
                6 => 11798,
                7 => 11799,
                8 => 11800,
                9 => 11801,
                10 => 11802,
                11 => 11803,
                12 => 11804,
                13 => 11805,
                14 => 11806,
                15 => 11807,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11792 => new CyanBannerBlock(Identifier, 0),
            11793 => new CyanBannerBlock(Identifier, 1),
            11794 => new CyanBannerBlock(Identifier, 2),
            11795 => new CyanBannerBlock(Identifier, 3),
            11796 => new CyanBannerBlock(Identifier, 4),
            11797 => new CyanBannerBlock(Identifier, 5),
            11798 => new CyanBannerBlock(Identifier, 6),
            11799 => new CyanBannerBlock(Identifier, 7),
            11800 => new CyanBannerBlock(Identifier, 8),
            11801 => new CyanBannerBlock(Identifier, 9),
            11802 => new CyanBannerBlock(Identifier, 10),
            11803 => new CyanBannerBlock(Identifier, 11),
            11804 => new CyanBannerBlock(Identifier, 12),
            11805 => new CyanBannerBlock(Identifier, 13),
            11806 => new CyanBannerBlock(Identifier, 14),
            11807 => new CyanBannerBlock(Identifier, 15),
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
