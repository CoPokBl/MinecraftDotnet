using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
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
    public Identifier? Item => "minecraft:orange_banner";
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
    public string TranslationKey => "block.minecraft.orange_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12943,
                1 => 12944,
                2 => 12945,
                3 => 12946,
                4 => 12947,
                5 => 12948,
                6 => 12949,
                7 => 12950,
                8 => 12951,
                9 => 12952,
                10 => 12953,
                11 => 12954,
                12 => 12955,
                13 => 12956,
                14 => 12957,
                15 => 12958,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12943 => new OrangeBannerBlock(Identifier, 0),
            12944 => new OrangeBannerBlock(Identifier, 1),
            12945 => new OrangeBannerBlock(Identifier, 2),
            12946 => new OrangeBannerBlock(Identifier, 3),
            12947 => new OrangeBannerBlock(Identifier, 4),
            12948 => new OrangeBannerBlock(Identifier, 5),
            12949 => new OrangeBannerBlock(Identifier, 6),
            12950 => new OrangeBannerBlock(Identifier, 7),
            12951 => new OrangeBannerBlock(Identifier, 8),
            12952 => new OrangeBannerBlock(Identifier, 9),
            12953 => new OrangeBannerBlock(Identifier, 10),
            12954 => new OrangeBannerBlock(Identifier, 11),
            12955 => new OrangeBannerBlock(Identifier, 12),
            12956 => new OrangeBannerBlock(Identifier, 13),
            12957 => new OrangeBannerBlock(Identifier, 14),
            12958 => new OrangeBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString()))
        );
    }
    
}
