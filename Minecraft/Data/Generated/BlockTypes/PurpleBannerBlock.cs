using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 571;
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
    public Identifier? Item => "minecraft:purple_banner";
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
    public string TranslationKey => "block.minecraft.purple_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12885,
                1 => 12886,
                2 => 12887,
                3 => 12888,
                4 => 12889,
                5 => 12890,
                6 => 12891,
                7 => 12892,
                8 => 12893,
                9 => 12894,
                10 => 12895,
                11 => 12896,
                12 => 12897,
                13 => 12898,
                14 => 12899,
                15 => 12900,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12885 => new PurpleBannerBlock(Identifier, 0),
            12886 => new PurpleBannerBlock(Identifier, 1),
            12887 => new PurpleBannerBlock(Identifier, 2),
            12888 => new PurpleBannerBlock(Identifier, 3),
            12889 => new PurpleBannerBlock(Identifier, 4),
            12890 => new PurpleBannerBlock(Identifier, 5),
            12891 => new PurpleBannerBlock(Identifier, 6),
            12892 => new PurpleBannerBlock(Identifier, 7),
            12893 => new PurpleBannerBlock(Identifier, 8),
            12894 => new PurpleBannerBlock(Identifier, 9),
            12895 => new PurpleBannerBlock(Identifier, 10),
            12896 => new PurpleBannerBlock(Identifier, 11),
            12897 => new PurpleBannerBlock(Identifier, 12),
            12898 => new PurpleBannerBlock(Identifier, 13),
            12899 => new PurpleBannerBlock(Identifier, 14),
            12900 => new PurpleBannerBlock(Identifier, 15),
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
