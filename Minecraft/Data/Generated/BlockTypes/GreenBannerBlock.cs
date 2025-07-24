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
    public int ProtocolId => 544;
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
                0 => 11856,
                1 => 11857,
                2 => 11858,
                3 => 11859,
                4 => 11860,
                5 => 11861,
                6 => 11862,
                7 => 11863,
                8 => 11864,
                9 => 11865,
                10 => 11866,
                11 => 11867,
                12 => 11868,
                13 => 11869,
                14 => 11870,
                15 => 11871,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11856 => new GreenBannerBlock(Identifier, 0),
            11857 => new GreenBannerBlock(Identifier, 1),
            11858 => new GreenBannerBlock(Identifier, 2),
            11859 => new GreenBannerBlock(Identifier, 3),
            11860 => new GreenBannerBlock(Identifier, 4),
            11861 => new GreenBannerBlock(Identifier, 5),
            11862 => new GreenBannerBlock(Identifier, 6),
            11863 => new GreenBannerBlock(Identifier, 7),
            11864 => new GreenBannerBlock(Identifier, 8),
            11865 => new GreenBannerBlock(Identifier, 9),
            11866 => new GreenBannerBlock(Identifier, 10),
            11867 => new GreenBannerBlock(Identifier, 11),
            11868 => new GreenBannerBlock(Identifier, 12),
            11869 => new GreenBannerBlock(Identifier, 13),
            11870 => new GreenBannerBlock(Identifier, 14),
            11871 => new GreenBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
