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
    public int ProtocolId => 572;
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
                0 => 12901,
                1 => 12902,
                2 => 12903,
                3 => 12904,
                4 => 12905,
                5 => 12906,
                6 => 12907,
                7 => 12908,
                8 => 12909,
                9 => 12910,
                10 => 12911,
                11 => 12912,
                12 => 12913,
                13 => 12914,
                14 => 12915,
                15 => 12916,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12901 => new BlueBannerBlock(Identifier, 0),
            12902 => new BlueBannerBlock(Identifier, 1),
            12903 => new BlueBannerBlock(Identifier, 2),
            12904 => new BlueBannerBlock(Identifier, 3),
            12905 => new BlueBannerBlock(Identifier, 4),
            12906 => new BlueBannerBlock(Identifier, 5),
            12907 => new BlueBannerBlock(Identifier, 6),
            12908 => new BlueBannerBlock(Identifier, 7),
            12909 => new BlueBannerBlock(Identifier, 8),
            12910 => new BlueBannerBlock(Identifier, 9),
            12911 => new BlueBannerBlock(Identifier, 10),
            12912 => new BlueBannerBlock(Identifier, 11),
            12913 => new BlueBannerBlock(Identifier, 12),
            12914 => new BlueBannerBlock(Identifier, 13),
            12915 => new BlueBannerBlock(Identifier, 14),
            12916 => new BlueBannerBlock(Identifier, 15),
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
