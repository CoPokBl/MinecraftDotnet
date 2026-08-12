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
                0 => 12975,
                1 => 12976,
                2 => 12977,
                3 => 12978,
                4 => 12979,
                5 => 12980,
                6 => 12981,
                7 => 12982,
                8 => 12983,
                9 => 12984,
                10 => 12985,
                11 => 12986,
                12 => 12987,
                13 => 12988,
                14 => 12989,
                15 => 12990,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12975 => new LightBlueBannerBlock(Identifier, 0),
            12976 => new LightBlueBannerBlock(Identifier, 1),
            12977 => new LightBlueBannerBlock(Identifier, 2),
            12978 => new LightBlueBannerBlock(Identifier, 3),
            12979 => new LightBlueBannerBlock(Identifier, 4),
            12980 => new LightBlueBannerBlock(Identifier, 5),
            12981 => new LightBlueBannerBlock(Identifier, 6),
            12982 => new LightBlueBannerBlock(Identifier, 7),
            12983 => new LightBlueBannerBlock(Identifier, 8),
            12984 => new LightBlueBannerBlock(Identifier, 9),
            12985 => new LightBlueBannerBlock(Identifier, 10),
            12986 => new LightBlueBannerBlock(Identifier, 11),
            12987 => new LightBlueBannerBlock(Identifier, 12),
            12988 => new LightBlueBannerBlock(Identifier, 13),
            12989 => new LightBlueBannerBlock(Identifier, 14),
            12990 => new LightBlueBannerBlock(Identifier, 15),
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
