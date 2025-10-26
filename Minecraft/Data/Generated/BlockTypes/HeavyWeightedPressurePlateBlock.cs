using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record HeavyWeightedPressurePlateBlock(Identifier Identifier, int Power) : IBlock {
    public Identifier Category => "minecraft:weighted_pressure_plate";
    public int ProtocolId => 470;
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
    public string SoundType => "iron";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:heavy_weighted_pressure_plate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.0625, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.heavy_weighted_pressure_plate";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Power switch {
                0 => 11045,
                1 => 11046,
                2 => 11047,
                3 => 11048,
                4 => 11049,
                5 => 11050,
                6 => 11051,
                7 => 11052,
                8 => 11053,
                9 => 11054,
                10 => 11055,
                11 => 11056,
                12 => 11057,
                13 => 11058,
                14 => 11059,
                15 => 11060,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11045 => new HeavyWeightedPressurePlateBlock(Identifier, 0),
            11046 => new HeavyWeightedPressurePlateBlock(Identifier, 1),
            11047 => new HeavyWeightedPressurePlateBlock(Identifier, 2),
            11048 => new HeavyWeightedPressurePlateBlock(Identifier, 3),
            11049 => new HeavyWeightedPressurePlateBlock(Identifier, 4),
            11050 => new HeavyWeightedPressurePlateBlock(Identifier, 5),
            11051 => new HeavyWeightedPressurePlateBlock(Identifier, 6),
            11052 => new HeavyWeightedPressurePlateBlock(Identifier, 7),
            11053 => new HeavyWeightedPressurePlateBlock(Identifier, 8),
            11054 => new HeavyWeightedPressurePlateBlock(Identifier, 9),
            11055 => new HeavyWeightedPressurePlateBlock(Identifier, 10),
            11056 => new HeavyWeightedPressurePlateBlock(Identifier, 11),
            11057 => new HeavyWeightedPressurePlateBlock(Identifier, 12),
            11058 => new HeavyWeightedPressurePlateBlock(Identifier, 13),
            11059 => new HeavyWeightedPressurePlateBlock(Identifier, 14),
            11060 => new HeavyWeightedPressurePlateBlock(Identifier, 15),
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
