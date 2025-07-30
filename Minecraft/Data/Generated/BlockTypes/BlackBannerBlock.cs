using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 546;
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
    public Identifier? Item => "minecraft:black_banner";
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
    public string TranslationKey => "block.minecraft.black_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11888,
                1 => 11889,
                2 => 11890,
                3 => 11891,
                4 => 11892,
                5 => 11893,
                6 => 11894,
                7 => 11895,
                8 => 11896,
                9 => 11897,
                10 => 11898,
                11 => 11899,
                12 => 11900,
                13 => 11901,
                14 => 11902,
                15 => 11903,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11888 => new BlackBannerBlock(Identifier, 0),
            11889 => new BlackBannerBlock(Identifier, 1),
            11890 => new BlackBannerBlock(Identifier, 2),
            11891 => new BlackBannerBlock(Identifier, 3),
            11892 => new BlackBannerBlock(Identifier, 4),
            11893 => new BlackBannerBlock(Identifier, 5),
            11894 => new BlackBannerBlock(Identifier, 6),
            11895 => new BlackBannerBlock(Identifier, 7),
            11896 => new BlackBannerBlock(Identifier, 8),
            11897 => new BlackBannerBlock(Identifier, 9),
            11898 => new BlackBannerBlock(Identifier, 10),
            11899 => new BlackBannerBlock(Identifier, 11),
            11900 => new BlackBannerBlock(Identifier, 12),
            11901 => new BlackBannerBlock(Identifier, 13),
            11902 => new BlackBannerBlock(Identifier, 14),
            11903 => new BlackBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("rotation", Rotation.ToString())
        );
    }
    
}
