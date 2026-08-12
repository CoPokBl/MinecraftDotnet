using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DragonHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:dragon_head";
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
    public string TranslationKey => "block.minecraft.dragon_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 11115,
                    1 => 11116,
                    2 => 11117,
                    3 => 11118,
                    4 => 11119,
                    5 => 11120,
                    6 => 11121,
                    7 => 11122,
                    8 => 11123,
                    9 => 11124,
                    10 => 11125,
                    11 => 11126,
                    12 => 11127,
                    13 => 11128,
                    14 => 11129,
                    15 => 11130,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11131,
                    1 => 11132,
                    2 => 11133,
                    3 => 11134,
                    4 => 11135,
                    5 => 11136,
                    6 => 11137,
                    7 => 11138,
                    8 => 11139,
                    9 => 11140,
                    10 => 11141,
                    11 => 11142,
                    12 => 11143,
                    13 => 11144,
                    14 => 11145,
                    15 => 11146,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11115 => new DragonHeadBlock(Identifier, true, 0),
            11116 => new DragonHeadBlock(Identifier, true, 1),
            11117 => new DragonHeadBlock(Identifier, true, 2),
            11118 => new DragonHeadBlock(Identifier, true, 3),
            11119 => new DragonHeadBlock(Identifier, true, 4),
            11120 => new DragonHeadBlock(Identifier, true, 5),
            11121 => new DragonHeadBlock(Identifier, true, 6),
            11122 => new DragonHeadBlock(Identifier, true, 7),
            11123 => new DragonHeadBlock(Identifier, true, 8),
            11124 => new DragonHeadBlock(Identifier, true, 9),
            11125 => new DragonHeadBlock(Identifier, true, 10),
            11126 => new DragonHeadBlock(Identifier, true, 11),
            11127 => new DragonHeadBlock(Identifier, true, 12),
            11128 => new DragonHeadBlock(Identifier, true, 13),
            11129 => new DragonHeadBlock(Identifier, true, 14),
            11130 => new DragonHeadBlock(Identifier, true, 15),
            11131 => new DragonHeadBlock(Identifier, false, 0),
            11132 => new DragonHeadBlock(Identifier, false, 1),
            11133 => new DragonHeadBlock(Identifier, false, 2),
            11134 => new DragonHeadBlock(Identifier, false, 3),
            11135 => new DragonHeadBlock(Identifier, false, 4),
            11136 => new DragonHeadBlock(Identifier, false, 5),
            11137 => new DragonHeadBlock(Identifier, false, 6),
            11138 => new DragonHeadBlock(Identifier, false, 7),
            11139 => new DragonHeadBlock(Identifier, false, 8),
            11140 => new DragonHeadBlock(Identifier, false, 9),
            11141 => new DragonHeadBlock(Identifier, false, 10),
            11142 => new DragonHeadBlock(Identifier, false, 11),
            11143 => new DragonHeadBlock(Identifier, false, 12),
            11144 => new DragonHeadBlock(Identifier, false, 13),
            11145 => new DragonHeadBlock(Identifier, false, 14),
            11146 => new DragonHeadBlock(Identifier, false, 15),
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
