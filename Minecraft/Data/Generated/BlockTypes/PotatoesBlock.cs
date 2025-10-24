using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PotatoesBlock(Identifier Identifier, int Age) : IBlock {
    public Identifier Category => "minecraft:potato";
    public int ProtocolId => 440;
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "crop";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:potato";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.potatoes";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Age switch {
                0 => 10465,
                1 => 10466,
                2 => 10467,
                3 => 10468,
                4 => 10469,
                5 => 10470,
                6 => 10471,
                7 => 10472,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10465 => new PotatoesBlock(Identifier, 0),
            10466 => new PotatoesBlock(Identifier, 1),
            10467 => new PotatoesBlock(Identifier, 2),
            10468 => new PotatoesBlock(Identifier, 3),
            10469 => new PotatoesBlock(Identifier, 4),
            10470 => new PotatoesBlock(Identifier, 5),
            10471 => new PotatoesBlock(Identifier, 6),
            10472 => new PotatoesBlock(Identifier, 7),
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
