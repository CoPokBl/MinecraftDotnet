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
                0 => 21752,
                1 => 21753,
                2 => 21754,
                3 => 21755,
                4 => 21756,
                5 => 21757,
                6 => 21758,
                7 => 21759,
                8 => 21760,
                9 => 21761,
                10 => 21762,
                11 => 21763,
                12 => 21764,
                13 => 21765,
                14 => 21766,
                15 => 21767,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21752 => new TargetBlock(Identifier, 0),
            21753 => new TargetBlock(Identifier, 1),
            21754 => new TargetBlock(Identifier, 2),
            21755 => new TargetBlock(Identifier, 3),
            21756 => new TargetBlock(Identifier, 4),
            21757 => new TargetBlock(Identifier, 5),
            21758 => new TargetBlock(Identifier, 6),
            21759 => new TargetBlock(Identifier, 7),
            21760 => new TargetBlock(Identifier, 8),
            21761 => new TargetBlock(Identifier, 9),
            21762 => new TargetBlock(Identifier, 10),
            21763 => new TargetBlock(Identifier, 11),
            21764 => new TargetBlock(Identifier, 12),
            21765 => new TargetBlock(Identifier, 13),
            21766 => new TargetBlock(Identifier, 14),
            21767 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("power", new StringTag(Power.ToString()))
        );
    }
    
}
