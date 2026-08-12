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
                0 => 11231,
                1 => 11232,
                2 => 11233,
                3 => 11234,
                4 => 11235,
                5 => 11236,
                6 => 11237,
                7 => 11238,
                8 => 11239,
                9 => 11240,
                10 => 11241,
                11 => 11242,
                12 => 11243,
                13 => 11244,
                14 => 11245,
                15 => 11246,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11231 => new LightWeightedPressurePlateBlock(Identifier, 0),
            11232 => new LightWeightedPressurePlateBlock(Identifier, 1),
            11233 => new LightWeightedPressurePlateBlock(Identifier, 2),
            11234 => new LightWeightedPressurePlateBlock(Identifier, 3),
            11235 => new LightWeightedPressurePlateBlock(Identifier, 4),
            11236 => new LightWeightedPressurePlateBlock(Identifier, 5),
            11237 => new LightWeightedPressurePlateBlock(Identifier, 6),
            11238 => new LightWeightedPressurePlateBlock(Identifier, 7),
            11239 => new LightWeightedPressurePlateBlock(Identifier, 8),
            11240 => new LightWeightedPressurePlateBlock(Identifier, 9),
            11241 => new LightWeightedPressurePlateBlock(Identifier, 10),
            11242 => new LightWeightedPressurePlateBlock(Identifier, 11),
            11243 => new LightWeightedPressurePlateBlock(Identifier, 12),
            11244 => new LightWeightedPressurePlateBlock(Identifier, 13),
            11245 => new LightWeightedPressurePlateBlock(Identifier, 14),
            11246 => new LightWeightedPressurePlateBlock(Identifier, 15),
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
