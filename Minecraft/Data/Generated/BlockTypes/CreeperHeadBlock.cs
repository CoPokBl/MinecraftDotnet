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
                    0 => 11075,
                    1 => 11076,
                    2 => 11077,
                    3 => 11078,
                    4 => 11079,
                    5 => 11080,
                    6 => 11081,
                    7 => 11082,
                    8 => 11083,
                    9 => 11084,
                    10 => 11085,
                    11 => 11086,
                    12 => 11087,
                    13 => 11088,
                    14 => 11089,
                    15 => 11090,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11091,
                    1 => 11092,
                    2 => 11093,
                    3 => 11094,
                    4 => 11095,
                    5 => 11096,
                    6 => 11097,
                    7 => 11098,
                    8 => 11099,
                    9 => 11100,
                    10 => 11101,
                    11 => 11102,
                    12 => 11103,
                    13 => 11104,
                    14 => 11105,
                    15 => 11106,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11075 => new CreeperHeadBlock(Identifier, true, 0),
            11076 => new CreeperHeadBlock(Identifier, true, 1),
            11077 => new CreeperHeadBlock(Identifier, true, 2),
            11078 => new CreeperHeadBlock(Identifier, true, 3),
            11079 => new CreeperHeadBlock(Identifier, true, 4),
            11080 => new CreeperHeadBlock(Identifier, true, 5),
            11081 => new CreeperHeadBlock(Identifier, true, 6),
            11082 => new CreeperHeadBlock(Identifier, true, 7),
            11083 => new CreeperHeadBlock(Identifier, true, 8),
            11084 => new CreeperHeadBlock(Identifier, true, 9),
            11085 => new CreeperHeadBlock(Identifier, true, 10),
            11086 => new CreeperHeadBlock(Identifier, true, 11),
            11087 => new CreeperHeadBlock(Identifier, true, 12),
            11088 => new CreeperHeadBlock(Identifier, true, 13),
            11089 => new CreeperHeadBlock(Identifier, true, 14),
            11090 => new CreeperHeadBlock(Identifier, true, 15),
            11091 => new CreeperHeadBlock(Identifier, false, 0),
            11092 => new CreeperHeadBlock(Identifier, false, 1),
            11093 => new CreeperHeadBlock(Identifier, false, 2),
            11094 => new CreeperHeadBlock(Identifier, false, 3),
            11095 => new CreeperHeadBlock(Identifier, false, 4),
            11096 => new CreeperHeadBlock(Identifier, false, 5),
            11097 => new CreeperHeadBlock(Identifier, false, 6),
            11098 => new CreeperHeadBlock(Identifier, false, 7),
            11099 => new CreeperHeadBlock(Identifier, false, 8),
            11100 => new CreeperHeadBlock(Identifier, false, 9),
            11101 => new CreeperHeadBlock(Identifier, false, 10),
            11102 => new CreeperHeadBlock(Identifier, false, 11),
            11103 => new CreeperHeadBlock(Identifier, false, 12),
            11104 => new CreeperHeadBlock(Identifier, false, 13),
            11105 => new CreeperHeadBlock(Identifier, false, 14),
            11106 => new CreeperHeadBlock(Identifier, false, 15),
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
