using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 574;
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
    public Identifier? Item => "minecraft:green_banner";
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
    public string TranslationKey => "block.minecraft.green_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12933,
                1 => 12934,
                2 => 12935,
                3 => 12936,
                4 => 12937,
                5 => 12938,
                6 => 12939,
                7 => 12940,
                8 => 12941,
                9 => 12942,
                10 => 12943,
                11 => 12944,
                12 => 12945,
                13 => 12946,
                14 => 12947,
                15 => 12948,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12933 => new GreenBannerBlock(Identifier, 0),
            12934 => new GreenBannerBlock(Identifier, 1),
            12935 => new GreenBannerBlock(Identifier, 2),
            12936 => new GreenBannerBlock(Identifier, 3),
            12937 => new GreenBannerBlock(Identifier, 4),
            12938 => new GreenBannerBlock(Identifier, 5),
            12939 => new GreenBannerBlock(Identifier, 6),
            12940 => new GreenBannerBlock(Identifier, 7),
            12941 => new GreenBannerBlock(Identifier, 8),
            12942 => new GreenBannerBlock(Identifier, 9),
            12943 => new GreenBannerBlock(Identifier, 10),
            12944 => new GreenBannerBlock(Identifier, 11),
            12945 => new GreenBannerBlock(Identifier, 12),
            12946 => new GreenBannerBlock(Identifier, 13),
            12947 => new GreenBannerBlock(Identifier, 14),
            12948 => new GreenBannerBlock(Identifier, 15),
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
