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
    public int ProtocolId => 562;
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
                0 => 12741,
                1 => 12742,
                2 => 12743,
                3 => 12744,
                4 => 12745,
                5 => 12746,
                6 => 12747,
                7 => 12748,
                8 => 12749,
                9 => 12750,
                10 => 12751,
                11 => 12752,
                12 => 12753,
                13 => 12754,
                14 => 12755,
                15 => 12756,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12741 => new OrangeBannerBlock(Identifier, 0),
            12742 => new OrangeBannerBlock(Identifier, 1),
            12743 => new OrangeBannerBlock(Identifier, 2),
            12744 => new OrangeBannerBlock(Identifier, 3),
            12745 => new OrangeBannerBlock(Identifier, 4),
            12746 => new OrangeBannerBlock(Identifier, 5),
            12747 => new OrangeBannerBlock(Identifier, 6),
            12748 => new OrangeBannerBlock(Identifier, 7),
            12749 => new OrangeBannerBlock(Identifier, 8),
            12750 => new OrangeBannerBlock(Identifier, 9),
            12751 => new OrangeBannerBlock(Identifier, 10),
            12752 => new OrangeBannerBlock(Identifier, 11),
            12753 => new OrangeBannerBlock(Identifier, 12),
            12754 => new OrangeBannerBlock(Identifier, 13),
            12755 => new OrangeBannerBlock(Identifier, 14),
            12756 => new OrangeBannerBlock(Identifier, 15),
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
