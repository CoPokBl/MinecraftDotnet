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
    public int ProtocolId => 442;
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
                    0 => 10000,
                    1 => 10001,
                    2 => 10002,
                    3 => 10003,
                    4 => 10004,
                    5 => 10005,
                    6 => 10006,
                    7 => 10007,
                    8 => 10008,
                    9 => 10009,
                    10 => 10010,
                    11 => 10011,
                    12 => 10012,
                    13 => 10013,
                    14 => 10014,
                    15 => 10015,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                false => Power switch {
                    0 => 10016,
                    1 => 10017,
                    2 => 10018,
                    3 => 10019,
                    4 => 10020,
                    5 => 10021,
                    6 => 10022,
                    7 => 10023,
                    8 => 10024,
                    9 => 10025,
                    10 => 10026,
                    11 => 10027,
                    12 => 10028,
                    13 => 10029,
                    14 => 10030,
                    15 => 10031,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10000 => new DaylightDetectorBlock(Identifier, true, 0),
            10001 => new DaylightDetectorBlock(Identifier, true, 1),
            10002 => new DaylightDetectorBlock(Identifier, true, 2),
            10003 => new DaylightDetectorBlock(Identifier, true, 3),
            10004 => new DaylightDetectorBlock(Identifier, true, 4),
            10005 => new DaylightDetectorBlock(Identifier, true, 5),
            10006 => new DaylightDetectorBlock(Identifier, true, 6),
            10007 => new DaylightDetectorBlock(Identifier, true, 7),
            10008 => new DaylightDetectorBlock(Identifier, true, 8),
            10009 => new DaylightDetectorBlock(Identifier, true, 9),
            10010 => new DaylightDetectorBlock(Identifier, true, 10),
            10011 => new DaylightDetectorBlock(Identifier, true, 11),
            10012 => new DaylightDetectorBlock(Identifier, true, 12),
            10013 => new DaylightDetectorBlock(Identifier, true, 13),
            10014 => new DaylightDetectorBlock(Identifier, true, 14),
            10015 => new DaylightDetectorBlock(Identifier, true, 15),
            10016 => new DaylightDetectorBlock(Identifier, false, 0),
            10017 => new DaylightDetectorBlock(Identifier, false, 1),
            10018 => new DaylightDetectorBlock(Identifier, false, 2),
            10019 => new DaylightDetectorBlock(Identifier, false, 3),
            10020 => new DaylightDetectorBlock(Identifier, false, 4),
            10021 => new DaylightDetectorBlock(Identifier, false, 5),
            10022 => new DaylightDetectorBlock(Identifier, false, 6),
            10023 => new DaylightDetectorBlock(Identifier, false, 7),
            10024 => new DaylightDetectorBlock(Identifier, false, 8),
            10025 => new DaylightDetectorBlock(Identifier, false, 9),
            10026 => new DaylightDetectorBlock(Identifier, false, 10),
            10027 => new DaylightDetectorBlock(Identifier, false, 11),
            10028 => new DaylightDetectorBlock(Identifier, false, 12),
            10029 => new DaylightDetectorBlock(Identifier, false, 13),
            10030 => new DaylightDetectorBlock(Identifier, false, 14),
            10031 => new DaylightDetectorBlock(Identifier, false, 15),
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
