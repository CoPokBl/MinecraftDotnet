using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TargetBlock(Identifier Identifier, int Power) : IBlock {
    public Identifier Category => "minecraft:target";
    public int ProtocolId => 908;
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
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:target";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => true;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.target";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Power switch {
                0 => 21550,
                1 => 21551,
                2 => 21552,
                3 => 21553,
                4 => 21554,
                5 => 21555,
                6 => 21556,
                7 => 21557,
                8 => 21558,
                9 => 21559,
                10 => 21560,
                11 => 21561,
                12 => 21562,
                13 => 21563,
                14 => 21564,
                15 => 21565,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21550 => new TargetBlock(Identifier, 0),
            21551 => new TargetBlock(Identifier, 1),
            21552 => new TargetBlock(Identifier, 2),
            21553 => new TargetBlock(Identifier, 3),
            21554 => new TargetBlock(Identifier, 4),
            21555 => new TargetBlock(Identifier, 5),
            21556 => new TargetBlock(Identifier, 6),
            21557 => new TargetBlock(Identifier, 7),
            21558 => new TargetBlock(Identifier, 8),
            21559 => new TargetBlock(Identifier, 9),
            21560 => new TargetBlock(Identifier, 10),
            21561 => new TargetBlock(Identifier, 11),
            21562 => new TargetBlock(Identifier, 12),
            21563 => new TargetBlock(Identifier, 13),
            21564 => new TargetBlock(Identifier, 14),
            21565 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.ChildrenMap.ContainsKey("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("power", Power.ToString())
        );
    }
    
}
