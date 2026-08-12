using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ZombieHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:skull";
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
    public Identifier? Item => "minecraft:zombie_head";
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
    public string TranslationKey => "block.minecraft.zombie_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10995,
                    1 => 10996,
                    2 => 10997,
                    3 => 10998,
                    4 => 10999,
                    5 => 11000,
                    6 => 11001,
                    7 => 11002,
                    8 => 11003,
                    9 => 11004,
                    10 => 11005,
                    11 => 11006,
                    12 => 11007,
                    13 => 11008,
                    14 => 11009,
                    15 => 11010,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11011,
                    1 => 11012,
                    2 => 11013,
                    3 => 11014,
                    4 => 11015,
                    5 => 11016,
                    6 => 11017,
                    7 => 11018,
                    8 => 11019,
                    9 => 11020,
                    10 => 11021,
                    11 => 11022,
                    12 => 11023,
                    13 => 11024,
                    14 => 11025,
                    15 => 11026,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10995 => new ZombieHeadBlock(Identifier, true, 0),
            10996 => new ZombieHeadBlock(Identifier, true, 1),
            10997 => new ZombieHeadBlock(Identifier, true, 2),
            10998 => new ZombieHeadBlock(Identifier, true, 3),
            10999 => new ZombieHeadBlock(Identifier, true, 4),
            11000 => new ZombieHeadBlock(Identifier, true, 5),
            11001 => new ZombieHeadBlock(Identifier, true, 6),
            11002 => new ZombieHeadBlock(Identifier, true, 7),
            11003 => new ZombieHeadBlock(Identifier, true, 8),
            11004 => new ZombieHeadBlock(Identifier, true, 9),
            11005 => new ZombieHeadBlock(Identifier, true, 10),
            11006 => new ZombieHeadBlock(Identifier, true, 11),
            11007 => new ZombieHeadBlock(Identifier, true, 12),
            11008 => new ZombieHeadBlock(Identifier, true, 13),
            11009 => new ZombieHeadBlock(Identifier, true, 14),
            11010 => new ZombieHeadBlock(Identifier, true, 15),
            11011 => new ZombieHeadBlock(Identifier, false, 0),
            11012 => new ZombieHeadBlock(Identifier, false, 1),
            11013 => new ZombieHeadBlock(Identifier, false, 2),
            11014 => new ZombieHeadBlock(Identifier, false, 3),
            11015 => new ZombieHeadBlock(Identifier, false, 4),
            11016 => new ZombieHeadBlock(Identifier, false, 5),
            11017 => new ZombieHeadBlock(Identifier, false, 6),
            11018 => new ZombieHeadBlock(Identifier, false, 7),
            11019 => new ZombieHeadBlock(Identifier, false, 8),
            11020 => new ZombieHeadBlock(Identifier, false, 9),
            11021 => new ZombieHeadBlock(Identifier, false, 10),
            11022 => new ZombieHeadBlock(Identifier, false, 11),
            11023 => new ZombieHeadBlock(Identifier, false, 12),
            11024 => new ZombieHeadBlock(Identifier, false, 13),
            11025 => new ZombieHeadBlock(Identifier, false, 14),
            11026 => new ZombieHeadBlock(Identifier, false, 15),
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
