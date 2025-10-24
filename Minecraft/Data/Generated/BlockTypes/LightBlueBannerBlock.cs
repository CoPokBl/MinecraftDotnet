using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 564;
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
    public Identifier? Item => "minecraft:light_blue_banner";
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
    public string TranslationKey => "block.minecraft.light_blue_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 12773,
                1 => 12774,
                2 => 12775,
                3 => 12776,
                4 => 12777,
                5 => 12778,
                6 => 12779,
                7 => 12780,
                8 => 12781,
                9 => 12782,
                10 => 12783,
                11 => 12784,
                12 => 12785,
                13 => 12786,
                14 => 12787,
                15 => 12788,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12773 => new LightBlueBannerBlock(Identifier, 0),
            12774 => new LightBlueBannerBlock(Identifier, 1),
            12775 => new LightBlueBannerBlock(Identifier, 2),
            12776 => new LightBlueBannerBlock(Identifier, 3),
            12777 => new LightBlueBannerBlock(Identifier, 4),
            12778 => new LightBlueBannerBlock(Identifier, 5),
            12779 => new LightBlueBannerBlock(Identifier, 6),
            12780 => new LightBlueBannerBlock(Identifier, 7),
            12781 => new LightBlueBannerBlock(Identifier, 8),
            12782 => new LightBlueBannerBlock(Identifier, 9),
            12783 => new LightBlueBannerBlock(Identifier, 10),
            12784 => new LightBlueBannerBlock(Identifier, 11),
            12785 => new LightBlueBannerBlock(Identifier, 12),
            12786 => new LightBlueBannerBlock(Identifier, 13),
            12787 => new LightBlueBannerBlock(Identifier, 14),
            12788 => new LightBlueBannerBlock(Identifier, 15),
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
