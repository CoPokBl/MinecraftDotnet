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
    public int ProtocolId => 567;
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
                0 => 12821,
                1 => 12822,
                2 => 12823,
                3 => 12824,
                4 => 12825,
                5 => 12826,
                6 => 12827,
                7 => 12828,
                8 => 12829,
                9 => 12830,
                10 => 12831,
                11 => 12832,
                12 => 12833,
                13 => 12834,
                14 => 12835,
                15 => 12836,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12821 => new PinkBannerBlock(Identifier, 0),
            12822 => new PinkBannerBlock(Identifier, 1),
            12823 => new PinkBannerBlock(Identifier, 2),
            12824 => new PinkBannerBlock(Identifier, 3),
            12825 => new PinkBannerBlock(Identifier, 4),
            12826 => new PinkBannerBlock(Identifier, 5),
            12827 => new PinkBannerBlock(Identifier, 6),
            12828 => new PinkBannerBlock(Identifier, 7),
            12829 => new PinkBannerBlock(Identifier, 8),
            12830 => new PinkBannerBlock(Identifier, 9),
            12831 => new PinkBannerBlock(Identifier, 10),
            12832 => new PinkBannerBlock(Identifier, 11),
            12833 => new PinkBannerBlock(Identifier, 12),
            12834 => new PinkBannerBlock(Identifier, 13),
            12835 => new PinkBannerBlock(Identifier, 14),
            12836 => new PinkBannerBlock(Identifier, 15),
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
