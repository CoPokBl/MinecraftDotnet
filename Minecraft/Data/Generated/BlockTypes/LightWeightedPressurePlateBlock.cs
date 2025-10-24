using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {
    public Identifier Category => "minecraft:weighted_pressure_plate";
    public int ProtocolId => 469;
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "metal";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:light_weighted_pressure_plate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.0625, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 30;
    public string TranslationKey => "block.minecraft.light_weighted_pressure_plate";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Power switch {
                0 => 11029,
                1 => 11030,
                2 => 11031,
                3 => 11032,
                4 => 11033,
                5 => 11034,
                6 => 11035,
                7 => 11036,
                8 => 11037,
                9 => 11038,
                10 => 11039,
                11 => 11040,
                12 => 11041,
                13 => 11042,
                14 => 11043,
                15 => 11044,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11029 => new LightWeightedPressurePlateBlock(Identifier, 0),
            11030 => new LightWeightedPressurePlateBlock(Identifier, 1),
            11031 => new LightWeightedPressurePlateBlock(Identifier, 2),
            11032 => new LightWeightedPressurePlateBlock(Identifier, 3),
            11033 => new LightWeightedPressurePlateBlock(Identifier, 4),
            11034 => new LightWeightedPressurePlateBlock(Identifier, 5),
            11035 => new LightWeightedPressurePlateBlock(Identifier, 6),
            11036 => new LightWeightedPressurePlateBlock(Identifier, 7),
            11037 => new LightWeightedPressurePlateBlock(Identifier, 8),
            11038 => new LightWeightedPressurePlateBlock(Identifier, 9),
            11039 => new LightWeightedPressurePlateBlock(Identifier, 10),
            11040 => new LightWeightedPressurePlateBlock(Identifier, 11),
            11041 => new LightWeightedPressurePlateBlock(Identifier, 12),
            11042 => new LightWeightedPressurePlateBlock(Identifier, 13),
            11043 => new LightWeightedPressurePlateBlock(Identifier, 14),
            11044 => new LightWeightedPressurePlateBlock(Identifier, 15),
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
