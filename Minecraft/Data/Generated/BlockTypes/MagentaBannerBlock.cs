using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 533;
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
    public Identifier? Item => "minecraft:magenta_banner";
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
    public string TranslationKey => "block.minecraft.magenta_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11680,
                1 => 11681,
                2 => 11682,
                3 => 11683,
                4 => 11684,
                5 => 11685,
                6 => 11686,
                7 => 11687,
                8 => 11688,
                9 => 11689,
                10 => 11690,
                11 => 11691,
                12 => 11692,
                13 => 11693,
                14 => 11694,
                15 => 11695,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11680 => new MagentaBannerBlock(Identifier, 0),
            11681 => new MagentaBannerBlock(Identifier, 1),
            11682 => new MagentaBannerBlock(Identifier, 2),
            11683 => new MagentaBannerBlock(Identifier, 3),
            11684 => new MagentaBannerBlock(Identifier, 4),
            11685 => new MagentaBannerBlock(Identifier, 5),
            11686 => new MagentaBannerBlock(Identifier, 6),
            11687 => new MagentaBannerBlock(Identifier, 7),
            11688 => new MagentaBannerBlock(Identifier, 8),
            11689 => new MagentaBannerBlock(Identifier, 9),
            11690 => new MagentaBannerBlock(Identifier, 10),
            11691 => new MagentaBannerBlock(Identifier, 11),
            11692 => new MagentaBannerBlock(Identifier, 12),
            11693 => new MagentaBannerBlock(Identifier, 13),
            11694 => new MagentaBannerBlock(Identifier, 14),
            11695 => new MagentaBannerBlock(Identifier, 15),
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
