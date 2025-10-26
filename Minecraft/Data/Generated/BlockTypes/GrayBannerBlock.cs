using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 568;
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
    public Identifier? Item => "minecraft:gray_banner";
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
    public string TranslationKey => "block.minecraft.gray_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12837,
                1 => 12838,
                2 => 12839,
                3 => 12840,
                4 => 12841,
                5 => 12842,
                6 => 12843,
                7 => 12844,
                8 => 12845,
                9 => 12846,
                10 => 12847,
                11 => 12848,
                12 => 12849,
                13 => 12850,
                14 => 12851,
                15 => 12852,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12837 => new GrayBannerBlock(Identifier, 0),
            12838 => new GrayBannerBlock(Identifier, 1),
            12839 => new GrayBannerBlock(Identifier, 2),
            12840 => new GrayBannerBlock(Identifier, 3),
            12841 => new GrayBannerBlock(Identifier, 4),
            12842 => new GrayBannerBlock(Identifier, 5),
            12843 => new GrayBannerBlock(Identifier, 6),
            12844 => new GrayBannerBlock(Identifier, 7),
            12845 => new GrayBannerBlock(Identifier, 8),
            12846 => new GrayBannerBlock(Identifier, 9),
            12847 => new GrayBannerBlock(Identifier, 10),
            12848 => new GrayBannerBlock(Identifier, 11),
            12849 => new GrayBannerBlock(Identifier, 12),
            12850 => new GrayBannerBlock(Identifier, 13),
            12851 => new GrayBannerBlock(Identifier, 14),
            12852 => new GrayBannerBlock(Identifier, 15),
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
