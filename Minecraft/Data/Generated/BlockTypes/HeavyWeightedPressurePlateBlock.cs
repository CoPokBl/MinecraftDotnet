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
                0 => 11247,
                1 => 11248,
                2 => 11249,
                3 => 11250,
                4 => 11251,
                5 => 11252,
                6 => 11253,
                7 => 11254,
                8 => 11255,
                9 => 11256,
                10 => 11257,
                11 => 11258,
                12 => 11259,
                13 => 11260,
                14 => 11261,
                15 => 11262,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11247 => new HeavyWeightedPressurePlateBlock(Identifier, 0),
            11248 => new HeavyWeightedPressurePlateBlock(Identifier, 1),
            11249 => new HeavyWeightedPressurePlateBlock(Identifier, 2),
            11250 => new HeavyWeightedPressurePlateBlock(Identifier, 3),
            11251 => new HeavyWeightedPressurePlateBlock(Identifier, 4),
            11252 => new HeavyWeightedPressurePlateBlock(Identifier, 5),
            11253 => new HeavyWeightedPressurePlateBlock(Identifier, 6),
            11254 => new HeavyWeightedPressurePlateBlock(Identifier, 7),
            11255 => new HeavyWeightedPressurePlateBlock(Identifier, 8),
            11256 => new HeavyWeightedPressurePlateBlock(Identifier, 9),
            11257 => new HeavyWeightedPressurePlateBlock(Identifier, 10),
            11258 => new HeavyWeightedPressurePlateBlock(Identifier, 11),
            11259 => new HeavyWeightedPressurePlateBlock(Identifier, 12),
            11260 => new HeavyWeightedPressurePlateBlock(Identifier, 13),
            11261 => new HeavyWeightedPressurePlateBlock(Identifier, 14),
            11262 => new HeavyWeightedPressurePlateBlock(Identifier, 15),
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
