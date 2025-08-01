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
    public int ProtocolId => 440;
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
                0 => 9968,
                1 => 9969,
                2 => 9970,
                3 => 9971,
                4 => 9972,
                5 => 9973,
                6 => 9974,
                7 => 9975,
                8 => 9976,
                9 => 9977,
                10 => 9978,
                11 => 9979,
                12 => 9980,
                13 => 9981,
                14 => 9982,
                15 => 9983,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9968 => new HeavyWeightedPressurePlateBlock(Identifier, 0),
            9969 => new HeavyWeightedPressurePlateBlock(Identifier, 1),
            9970 => new HeavyWeightedPressurePlateBlock(Identifier, 2),
            9971 => new HeavyWeightedPressurePlateBlock(Identifier, 3),
            9972 => new HeavyWeightedPressurePlateBlock(Identifier, 4),
            9973 => new HeavyWeightedPressurePlateBlock(Identifier, 5),
            9974 => new HeavyWeightedPressurePlateBlock(Identifier, 6),
            9975 => new HeavyWeightedPressurePlateBlock(Identifier, 7),
            9976 => new HeavyWeightedPressurePlateBlock(Identifier, 8),
            9977 => new HeavyWeightedPressurePlateBlock(Identifier, 9),
            9978 => new HeavyWeightedPressurePlateBlock(Identifier, 10),
            9979 => new HeavyWeightedPressurePlateBlock(Identifier, 11),
            9980 => new HeavyWeightedPressurePlateBlock(Identifier, 12),
            9981 => new HeavyWeightedPressurePlateBlock(Identifier, 13),
            9982 => new HeavyWeightedPressurePlateBlock(Identifier, 14),
            9983 => new HeavyWeightedPressurePlateBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = int.Parse(properties["power"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("power", Power.ToString())
        );
    }
    
}
