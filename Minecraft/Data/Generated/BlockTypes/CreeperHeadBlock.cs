using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CreeperHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:skull";
    public int ProtocolId => 459;
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
    public Identifier? Item => "minecraft:creeper_head";
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
    public string TranslationKey => "block.minecraft.creeper_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10873,
                    1 => 10874,
                    2 => 10875,
                    3 => 10876,
                    4 => 10877,
                    5 => 10878,
                    6 => 10879,
                    7 => 10880,
                    8 => 10881,
                    9 => 10882,
                    10 => 10883,
                    11 => 10884,
                    12 => 10885,
                    13 => 10886,
                    14 => 10887,
                    15 => 10888,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10889,
                    1 => 10890,
                    2 => 10891,
                    3 => 10892,
                    4 => 10893,
                    5 => 10894,
                    6 => 10895,
                    7 => 10896,
                    8 => 10897,
                    9 => 10898,
                    10 => 10899,
                    11 => 10900,
                    12 => 10901,
                    13 => 10902,
                    14 => 10903,
                    15 => 10904,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10873 => new CreeperHeadBlock(Identifier, true, 0),
            10874 => new CreeperHeadBlock(Identifier, true, 1),
            10875 => new CreeperHeadBlock(Identifier, true, 2),
            10876 => new CreeperHeadBlock(Identifier, true, 3),
            10877 => new CreeperHeadBlock(Identifier, true, 4),
            10878 => new CreeperHeadBlock(Identifier, true, 5),
            10879 => new CreeperHeadBlock(Identifier, true, 6),
            10880 => new CreeperHeadBlock(Identifier, true, 7),
            10881 => new CreeperHeadBlock(Identifier, true, 8),
            10882 => new CreeperHeadBlock(Identifier, true, 9),
            10883 => new CreeperHeadBlock(Identifier, true, 10),
            10884 => new CreeperHeadBlock(Identifier, true, 11),
            10885 => new CreeperHeadBlock(Identifier, true, 12),
            10886 => new CreeperHeadBlock(Identifier, true, 13),
            10887 => new CreeperHeadBlock(Identifier, true, 14),
            10888 => new CreeperHeadBlock(Identifier, true, 15),
            10889 => new CreeperHeadBlock(Identifier, false, 0),
            10890 => new CreeperHeadBlock(Identifier, false, 1),
            10891 => new CreeperHeadBlock(Identifier, false, 2),
            10892 => new CreeperHeadBlock(Identifier, false, 3),
            10893 => new CreeperHeadBlock(Identifier, false, 4),
            10894 => new CreeperHeadBlock(Identifier, false, 5),
            10895 => new CreeperHeadBlock(Identifier, false, 6),
            10896 => new CreeperHeadBlock(Identifier, false, 7),
            10897 => new CreeperHeadBlock(Identifier, false, 8),
            10898 => new CreeperHeadBlock(Identifier, false, 9),
            10899 => new CreeperHeadBlock(Identifier, false, 10),
            10900 => new CreeperHeadBlock(Identifier, false, 11),
            10901 => new CreeperHeadBlock(Identifier, false, 12),
            10902 => new CreeperHeadBlock(Identifier, false, 13),
            10903 => new CreeperHeadBlock(Identifier, false, 14),
            10904 => new CreeperHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString())
        );
    }
    
}
