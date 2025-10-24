using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 565;
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
    public Identifier? Item => "minecraft:yellow_banner";
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
    public string TranslationKey => "block.minecraft.yellow_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12789,
                1 => 12790,
                2 => 12791,
                3 => 12792,
                4 => 12793,
                5 => 12794,
                6 => 12795,
                7 => 12796,
                8 => 12797,
                9 => 12798,
                10 => 12799,
                11 => 12800,
                12 => 12801,
                13 => 12802,
                14 => 12803,
                15 => 12804,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12789 => new YellowBannerBlock(Identifier, 0),
            12790 => new YellowBannerBlock(Identifier, 1),
            12791 => new YellowBannerBlock(Identifier, 2),
            12792 => new YellowBannerBlock(Identifier, 3),
            12793 => new YellowBannerBlock(Identifier, 4),
            12794 => new YellowBannerBlock(Identifier, 5),
            12795 => new YellowBannerBlock(Identifier, 6),
            12796 => new YellowBannerBlock(Identifier, 7),
            12797 => new YellowBannerBlock(Identifier, 8),
            12798 => new YellowBannerBlock(Identifier, 9),
            12799 => new YellowBannerBlock(Identifier, 10),
            12800 => new YellowBannerBlock(Identifier, 11),
            12801 => new YellowBannerBlock(Identifier, 12),
            12802 => new YellowBannerBlock(Identifier, 13),
            12803 => new YellowBannerBlock(Identifier, 14),
            12804 => new YellowBannerBlock(Identifier, 15),
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
