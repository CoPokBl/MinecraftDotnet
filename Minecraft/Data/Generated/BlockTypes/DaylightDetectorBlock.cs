using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DaylightDetectorBlock(Identifier Identifier, bool Inverted, int Power) : IBlock {
    public Identifier Category => "minecraft:daylight_detector";
    public int ProtocolId => 472;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:daylight_detector";
    public Identifier? Item => "minecraft:daylight_detector";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.375, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.375, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.375, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.375, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 13;
    public string TranslationKey => "block.minecraft.daylight_detector";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Inverted switch {
                true => Power switch {
                    0 => 11077,
                    1 => 11078,
                    2 => 11079,
                    3 => 11080,
                    4 => 11081,
                    5 => 11082,
                    6 => 11083,
                    7 => 11084,
                    8 => 11085,
                    9 => 11086,
                    10 => 11087,
                    11 => 11088,
                    12 => 11089,
                    13 => 11090,
                    14 => 11091,
                    15 => 11092,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                false => Power switch {
                    0 => 11093,
                    1 => 11094,
                    2 => 11095,
                    3 => 11096,
                    4 => 11097,
                    5 => 11098,
                    6 => 11099,
                    7 => 11100,
                    8 => 11101,
                    9 => 11102,
                    10 => 11103,
                    11 => 11104,
                    12 => 11105,
                    13 => 11106,
                    14 => 11107,
                    15 => 11108,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11077 => new DaylightDetectorBlock(Identifier, true, 0),
            11078 => new DaylightDetectorBlock(Identifier, true, 1),
            11079 => new DaylightDetectorBlock(Identifier, true, 2),
            11080 => new DaylightDetectorBlock(Identifier, true, 3),
            11081 => new DaylightDetectorBlock(Identifier, true, 4),
            11082 => new DaylightDetectorBlock(Identifier, true, 5),
            11083 => new DaylightDetectorBlock(Identifier, true, 6),
            11084 => new DaylightDetectorBlock(Identifier, true, 7),
            11085 => new DaylightDetectorBlock(Identifier, true, 8),
            11086 => new DaylightDetectorBlock(Identifier, true, 9),
            11087 => new DaylightDetectorBlock(Identifier, true, 10),
            11088 => new DaylightDetectorBlock(Identifier, true, 11),
            11089 => new DaylightDetectorBlock(Identifier, true, 12),
            11090 => new DaylightDetectorBlock(Identifier, true, 13),
            11091 => new DaylightDetectorBlock(Identifier, true, 14),
            11092 => new DaylightDetectorBlock(Identifier, true, 15),
            11093 => new DaylightDetectorBlock(Identifier, false, 0),
            11094 => new DaylightDetectorBlock(Identifier, false, 1),
            11095 => new DaylightDetectorBlock(Identifier, false, 2),
            11096 => new DaylightDetectorBlock(Identifier, false, 3),
            11097 => new DaylightDetectorBlock(Identifier, false, 4),
            11098 => new DaylightDetectorBlock(Identifier, false, 5),
            11099 => new DaylightDetectorBlock(Identifier, false, 6),
            11100 => new DaylightDetectorBlock(Identifier, false, 7),
            11101 => new DaylightDetectorBlock(Identifier, false, 8),
            11102 => new DaylightDetectorBlock(Identifier, false, 9),
            11103 => new DaylightDetectorBlock(Identifier, false, 10),
            11104 => new DaylightDetectorBlock(Identifier, false, 11),
            11105 => new DaylightDetectorBlock(Identifier, false, 12),
            11106 => new DaylightDetectorBlock(Identifier, false, 13),
            11107 => new DaylightDetectorBlock(Identifier, false, 14),
            11108 => new DaylightDetectorBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Inverted = properties.ChildrenMap.ContainsKey("inverted") ? properties["inverted"].GetString() == "true" : Inverted,
            Power = properties.ChildrenMap.ContainsKey("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("inverted", Inverted.ToString().ToLower()),
            new StringTag("power", Power.ToString())
        );
    }
    
}
