using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CakeBlock(Identifier Identifier, int Bites) : IBlock {
    public Identifier Category => "minecraft:cake";
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wool";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cake";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.5, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.cake";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Bites switch {
                0 => 7027,
                1 => 7028,
                2 => 7029,
                3 => 7030,
                4 => 7031,
                5 => 7032,
                6 => 7033,
                _ => throw new ArgumentOutOfRangeException(nameof(Bites), Bites, "Unknown value for property bites.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7027 => new CakeBlock(Identifier, 0),
            7028 => new CakeBlock(Identifier, 1),
            7029 => new CakeBlock(Identifier, 2),
            7030 => new CakeBlock(Identifier, 3),
            7031 => new CakeBlock(Identifier, 4),
            7032 => new CakeBlock(Identifier, 5),
            7033 => new CakeBlock(Identifier, 6),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bites = properties.Contains("bites") ? int.Parse(properties["bites"].GetString()) : Bites,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bites", new StringTag(Bites.ToString()))
        );
    }
    
}
