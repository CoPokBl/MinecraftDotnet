using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 575;
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
    public Identifier? Item => "minecraft:red_banner";
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
    public string TranslationKey => "block.minecraft.red_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12949,
                1 => 12950,
                2 => 12951,
                3 => 12952,
                4 => 12953,
                5 => 12954,
                6 => 12955,
                7 => 12956,
                8 => 12957,
                9 => 12958,
                10 => 12959,
                11 => 12960,
                12 => 12961,
                13 => 12962,
                14 => 12963,
                15 => 12964,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12949 => new RedBannerBlock(Identifier, 0),
            12950 => new RedBannerBlock(Identifier, 1),
            12951 => new RedBannerBlock(Identifier, 2),
            12952 => new RedBannerBlock(Identifier, 3),
            12953 => new RedBannerBlock(Identifier, 4),
            12954 => new RedBannerBlock(Identifier, 5),
            12955 => new RedBannerBlock(Identifier, 6),
            12956 => new RedBannerBlock(Identifier, 7),
            12957 => new RedBannerBlock(Identifier, 8),
            12958 => new RedBannerBlock(Identifier, 9),
            12959 => new RedBannerBlock(Identifier, 10),
            12960 => new RedBannerBlock(Identifier, 11),
            12961 => new RedBannerBlock(Identifier, 12),
            12962 => new RedBannerBlock(Identifier, 13),
            12963 => new RedBannerBlock(Identifier, 14),
            12964 => new RedBannerBlock(Identifier, 15),
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
