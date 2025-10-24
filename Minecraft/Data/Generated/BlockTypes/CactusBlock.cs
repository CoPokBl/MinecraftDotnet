using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CactusBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:cactus";
    public int ProtocolId => 278;
    public double Hardness => 0.4;
    public double ExplosionResistance => 0.4;
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
    public Identifier? Item => "minecraft:cactus";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.9375, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.9375, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.cactus";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Age switch {
                0 => 6728,
                1 => 6729,
                2 => 6730,
                3 => 6731,
                4 => 6732,
                5 => 6733,
                6 => 6734,
                7 => 6735,
                8 => 6736,
                9 => 6737,
                10 => 6738,
                11 => 6739,
                12 => 6740,
                13 => 6741,
                14 => 6742,
                15 => 6743,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6728 => new CactusBlock(Identifier, 0),
            6729 => new CactusBlock(Identifier, 1),
            6730 => new CactusBlock(Identifier, 2),
            6731 => new CactusBlock(Identifier, 3),
            6732 => new CactusBlock(Identifier, 4),
            6733 => new CactusBlock(Identifier, 5),
            6734 => new CactusBlock(Identifier, 6),
            6735 => new CactusBlock(Identifier, 7),
            6736 => new CactusBlock(Identifier, 8),
            6737 => new CactusBlock(Identifier, 9),
            6738 => new CactusBlock(Identifier, 10),
            6739 => new CactusBlock(Identifier, 11),
            6740 => new CactusBlock(Identifier, 12),
            6741 => new CactusBlock(Identifier, 13),
            6742 => new CactusBlock(Identifier, 14),
            6743 => new CactusBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.ChildrenMap.ContainsKey("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("age", Age.ToString())
        );
    }
    
}
