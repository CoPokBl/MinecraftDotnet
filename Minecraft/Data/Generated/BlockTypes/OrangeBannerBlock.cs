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
                0 => 11664,
                1 => 11665,
                2 => 11666,
                3 => 11667,
                4 => 11668,
                5 => 11669,
                6 => 11670,
                7 => 11671,
                8 => 11672,
                9 => 11673,
                10 => 11674,
                11 => 11675,
                12 => 11676,
                13 => 11677,
                14 => 11678,
                15 => 11679,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11664 => new OrangeBannerBlock(Identifier, 0),
            11665 => new OrangeBannerBlock(Identifier, 1),
            11666 => new OrangeBannerBlock(Identifier, 2),
            11667 => new OrangeBannerBlock(Identifier, 3),
            11668 => new OrangeBannerBlock(Identifier, 4),
            11669 => new OrangeBannerBlock(Identifier, 5),
            11670 => new OrangeBannerBlock(Identifier, 6),
            11671 => new OrangeBannerBlock(Identifier, 7),
            11672 => new OrangeBannerBlock(Identifier, 8),
            11673 => new OrangeBannerBlock(Identifier, 9),
            11674 => new OrangeBannerBlock(Identifier, 10),
            11675 => new OrangeBannerBlock(Identifier, 11),
            11676 => new OrangeBannerBlock(Identifier, 12),
            11677 => new OrangeBannerBlock(Identifier, 13),
            11678 => new OrangeBannerBlock(Identifier, 14),
            11679 => new OrangeBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
        };
    }
    
}
