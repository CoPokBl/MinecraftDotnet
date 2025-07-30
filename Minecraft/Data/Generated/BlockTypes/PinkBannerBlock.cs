using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkBannerBlock(Identifier Identifier, int Rotation) : IBlock {

    public Identifier Category => "minecraft:banner";
    public int ProtocolId => 537;
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
    public Identifier? Item => "minecraft:pink_banner";
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
    public string TranslationKey => "block.minecraft.pink_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 11744,
                1 => 11745,
                2 => 11746,
                3 => 11747,
                4 => 11748,
                5 => 11749,
                6 => 11750,
                7 => 11751,
                8 => 11752,
                9 => 11753,
                10 => 11754,
                11 => 11755,
                12 => 11756,
                13 => 11757,
                14 => 11758,
                15 => 11759,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11744 => new PinkBannerBlock(Identifier, 0),
            11745 => new PinkBannerBlock(Identifier, 1),
            11746 => new PinkBannerBlock(Identifier, 2),
            11747 => new PinkBannerBlock(Identifier, 3),
            11748 => new PinkBannerBlock(Identifier, 4),
            11749 => new PinkBannerBlock(Identifier, 5),
            11750 => new PinkBannerBlock(Identifier, 6),
            11751 => new PinkBannerBlock(Identifier, 7),
            11752 => new PinkBannerBlock(Identifier, 8),
            11753 => new PinkBannerBlock(Identifier, 9),
            11754 => new PinkBannerBlock(Identifier, 10),
            11755 => new PinkBannerBlock(Identifier, 11),
            11756 => new PinkBannerBlock(Identifier, 12),
            11757 => new PinkBannerBlock(Identifier, 13),
            11758 => new PinkBannerBlock(Identifier, 14),
            11759 => new PinkBannerBlock(Identifier, 15),
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
