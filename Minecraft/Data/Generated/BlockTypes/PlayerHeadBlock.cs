using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PlayerHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:player_head";
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:skull";
    public Identifier? Item => "minecraft:player_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 0.5, 0.75]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.player_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 11035,
                    1 => 11036,
                    2 => 11037,
                    3 => 11038,
                    4 => 11039,
                    5 => 11040,
                    6 => 11041,
                    7 => 11042,
                    8 => 11043,
                    9 => 11044,
                    10 => 11045,
                    11 => 11046,
                    12 => 11047,
                    13 => 11048,
                    14 => 11049,
                    15 => 11050,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11051,
                    1 => 11052,
                    2 => 11053,
                    3 => 11054,
                    4 => 11055,
                    5 => 11056,
                    6 => 11057,
                    7 => 11058,
                    8 => 11059,
                    9 => 11060,
                    10 => 11061,
                    11 => 11062,
                    12 => 11063,
                    13 => 11064,
                    14 => 11065,
                    15 => 11066,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11035 => new PlayerHeadBlock(Identifier, true, 0),
            11036 => new PlayerHeadBlock(Identifier, true, 1),
            11037 => new PlayerHeadBlock(Identifier, true, 2),
            11038 => new PlayerHeadBlock(Identifier, true, 3),
            11039 => new PlayerHeadBlock(Identifier, true, 4),
            11040 => new PlayerHeadBlock(Identifier, true, 5),
            11041 => new PlayerHeadBlock(Identifier, true, 6),
            11042 => new PlayerHeadBlock(Identifier, true, 7),
            11043 => new PlayerHeadBlock(Identifier, true, 8),
            11044 => new PlayerHeadBlock(Identifier, true, 9),
            11045 => new PlayerHeadBlock(Identifier, true, 10),
            11046 => new PlayerHeadBlock(Identifier, true, 11),
            11047 => new PlayerHeadBlock(Identifier, true, 12),
            11048 => new PlayerHeadBlock(Identifier, true, 13),
            11049 => new PlayerHeadBlock(Identifier, true, 14),
            11050 => new PlayerHeadBlock(Identifier, true, 15),
            11051 => new PlayerHeadBlock(Identifier, false, 0),
            11052 => new PlayerHeadBlock(Identifier, false, 1),
            11053 => new PlayerHeadBlock(Identifier, false, 2),
            11054 => new PlayerHeadBlock(Identifier, false, 3),
            11055 => new PlayerHeadBlock(Identifier, false, 4),
            11056 => new PlayerHeadBlock(Identifier, false, 5),
            11057 => new PlayerHeadBlock(Identifier, false, 6),
            11058 => new PlayerHeadBlock(Identifier, false, 7),
            11059 => new PlayerHeadBlock(Identifier, false, 8),
            11060 => new PlayerHeadBlock(Identifier, false, 9),
            11061 => new PlayerHeadBlock(Identifier, false, 10),
            11062 => new PlayerHeadBlock(Identifier, false, 11),
            11063 => new PlayerHeadBlock(Identifier, false, 12),
            11064 => new PlayerHeadBlock(Identifier, false, 13),
            11065 => new PlayerHeadBlock(Identifier, false, 14),
            11066 => new PlayerHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString()))
        );
    }
    
}
