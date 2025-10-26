using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 566;
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
    public Identifier? Item => "minecraft:lime_banner";
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
    public string TranslationKey => "block.minecraft.lime_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12805,
                1 => 12806,
                2 => 12807,
                3 => 12808,
                4 => 12809,
                5 => 12810,
                6 => 12811,
                7 => 12812,
                8 => 12813,
                9 => 12814,
                10 => 12815,
                11 => 12816,
                12 => 12817,
                13 => 12818,
                14 => 12819,
                15 => 12820,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12805 => new LimeBannerBlock(Identifier, 0),
            12806 => new LimeBannerBlock(Identifier, 1),
            12807 => new LimeBannerBlock(Identifier, 2),
            12808 => new LimeBannerBlock(Identifier, 3),
            12809 => new LimeBannerBlock(Identifier, 4),
            12810 => new LimeBannerBlock(Identifier, 5),
            12811 => new LimeBannerBlock(Identifier, 6),
            12812 => new LimeBannerBlock(Identifier, 7),
            12813 => new LimeBannerBlock(Identifier, 8),
            12814 => new LimeBannerBlock(Identifier, 9),
            12815 => new LimeBannerBlock(Identifier, 10),
            12816 => new LimeBannerBlock(Identifier, 11),
            12817 => new LimeBannerBlock(Identifier, 12),
            12818 => new LimeBannerBlock(Identifier, 13),
            12819 => new LimeBannerBlock(Identifier, 14),
            12820 => new LimeBannerBlock(Identifier, 15),
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
