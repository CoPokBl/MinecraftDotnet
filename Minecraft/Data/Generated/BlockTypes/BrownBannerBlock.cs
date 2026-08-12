using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownBannerBlock(Identifier Identifier, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:brown_banner";
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
    public string TranslationKey => "block.minecraft.brown_banner";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13119,
                1 => 13120,
                2 => 13121,
                3 => 13122,
                4 => 13123,
                5 => 13124,
                6 => 13125,
                7 => 13126,
                8 => 13127,
                9 => 13128,
                10 => 13129,
                11 => 13130,
                12 => 13131,
                13 => 13132,
                14 => 13133,
                15 => 13134,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13119 => new BrownBannerBlock(Identifier, 0),
            13120 => new BrownBannerBlock(Identifier, 1),
            13121 => new BrownBannerBlock(Identifier, 2),
            13122 => new BrownBannerBlock(Identifier, 3),
            13123 => new BrownBannerBlock(Identifier, 4),
            13124 => new BrownBannerBlock(Identifier, 5),
            13125 => new BrownBannerBlock(Identifier, 6),
            13126 => new BrownBannerBlock(Identifier, 7),
            13127 => new BrownBannerBlock(Identifier, 8),
            13128 => new BrownBannerBlock(Identifier, 9),
            13129 => new BrownBannerBlock(Identifier, 10),
            13130 => new BrownBannerBlock(Identifier, 11),
            13131 => new BrownBannerBlock(Identifier, 12),
            13132 => new BrownBannerBlock(Identifier, 13),
            13133 => new BrownBannerBlock(Identifier, 14),
            13134 => new BrownBannerBlock(Identifier, 15),
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
