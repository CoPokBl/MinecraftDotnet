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
    public int ProtocolId => 563;
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
                0 => 12757,
                1 => 12758,
                2 => 12759,
                3 => 12760,
                4 => 12761,
                5 => 12762,
                6 => 12763,
                7 => 12764,
                8 => 12765,
                9 => 12766,
                10 => 12767,
                11 => 12768,
                12 => 12769,
                13 => 12770,
                14 => 12771,
                15 => 12772,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12757 => new MagentaBannerBlock(Identifier, 0),
            12758 => new MagentaBannerBlock(Identifier, 1),
            12759 => new MagentaBannerBlock(Identifier, 2),
            12760 => new MagentaBannerBlock(Identifier, 3),
            12761 => new MagentaBannerBlock(Identifier, 4),
            12762 => new MagentaBannerBlock(Identifier, 5),
            12763 => new MagentaBannerBlock(Identifier, 6),
            12764 => new MagentaBannerBlock(Identifier, 7),
            12765 => new MagentaBannerBlock(Identifier, 8),
            12766 => new MagentaBannerBlock(Identifier, 9),
            12767 => new MagentaBannerBlock(Identifier, 10),
            12768 => new MagentaBannerBlock(Identifier, 11),
            12769 => new MagentaBannerBlock(Identifier, 12),
            12770 => new MagentaBannerBlock(Identifier, 13),
            12771 => new MagentaBannerBlock(Identifier, 14),
            12772 => new MagentaBannerBlock(Identifier, 15),
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
