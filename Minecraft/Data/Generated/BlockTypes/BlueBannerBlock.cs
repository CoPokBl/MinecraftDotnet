using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 542;
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
    public Identifier? Item => "minecraft:blue_banner";
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
    public string TranslationKey => "block.minecraft.blue_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11824,
                1 => 11825,
                2 => 11826,
                3 => 11827,
                4 => 11828,
                5 => 11829,
                6 => 11830,
                7 => 11831,
                8 => 11832,
                9 => 11833,
                10 => 11834,
                11 => 11835,
                12 => 11836,
                13 => 11837,
                14 => 11838,
                15 => 11839,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11824 => new BlueBannerBlock(Identifier, 0),
            11825 => new BlueBannerBlock(Identifier, 1),
            11826 => new BlueBannerBlock(Identifier, 2),
            11827 => new BlueBannerBlock(Identifier, 3),
            11828 => new BlueBannerBlock(Identifier, 4),
            11829 => new BlueBannerBlock(Identifier, 5),
            11830 => new BlueBannerBlock(Identifier, 6),
            11831 => new BlueBannerBlock(Identifier, 7),
            11832 => new BlueBannerBlock(Identifier, 8),
            11833 => new BlueBannerBlock(Identifier, 9),
            11834 => new BlueBannerBlock(Identifier, 10),
            11835 => new BlueBannerBlock(Identifier, 11),
            11836 => new BlueBannerBlock(Identifier, 12),
            11837 => new BlueBannerBlock(Identifier, 13),
            11838 => new BlueBannerBlock(Identifier, 14),
            11839 => new BlueBannerBlock(Identifier, 15),
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
