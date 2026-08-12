using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PiglinHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:piglin_head";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.5, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.piglin_head";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 11155,
                    1 => 11156,
                    2 => 11157,
                    3 => 11158,
                    4 => 11159,
                    5 => 11160,
                    6 => 11161,
                    7 => 11162,
                    8 => 11163,
                    9 => 11164,
                    10 => 11165,
                    11 => 11166,
                    12 => 11167,
                    13 => 11168,
                    14 => 11169,
                    15 => 11170,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11171,
                    1 => 11172,
                    2 => 11173,
                    3 => 11174,
                    4 => 11175,
                    5 => 11176,
                    6 => 11177,
                    7 => 11178,
                    8 => 11179,
                    9 => 11180,
                    10 => 11181,
                    11 => 11182,
                    12 => 11183,
                    13 => 11184,
                    14 => 11185,
                    15 => 11186,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11155 => new PiglinHeadBlock(Identifier, true, 0),
            11156 => new PiglinHeadBlock(Identifier, true, 1),
            11157 => new PiglinHeadBlock(Identifier, true, 2),
            11158 => new PiglinHeadBlock(Identifier, true, 3),
            11159 => new PiglinHeadBlock(Identifier, true, 4),
            11160 => new PiglinHeadBlock(Identifier, true, 5),
            11161 => new PiglinHeadBlock(Identifier, true, 6),
            11162 => new PiglinHeadBlock(Identifier, true, 7),
            11163 => new PiglinHeadBlock(Identifier, true, 8),
            11164 => new PiglinHeadBlock(Identifier, true, 9),
            11165 => new PiglinHeadBlock(Identifier, true, 10),
            11166 => new PiglinHeadBlock(Identifier, true, 11),
            11167 => new PiglinHeadBlock(Identifier, true, 12),
            11168 => new PiglinHeadBlock(Identifier, true, 13),
            11169 => new PiglinHeadBlock(Identifier, true, 14),
            11170 => new PiglinHeadBlock(Identifier, true, 15),
            11171 => new PiglinHeadBlock(Identifier, false, 0),
            11172 => new PiglinHeadBlock(Identifier, false, 1),
            11173 => new PiglinHeadBlock(Identifier, false, 2),
            11174 => new PiglinHeadBlock(Identifier, false, 3),
            11175 => new PiglinHeadBlock(Identifier, false, 4),
            11176 => new PiglinHeadBlock(Identifier, false, 5),
            11177 => new PiglinHeadBlock(Identifier, false, 6),
            11178 => new PiglinHeadBlock(Identifier, false, 7),
            11179 => new PiglinHeadBlock(Identifier, false, 8),
            11180 => new PiglinHeadBlock(Identifier, false, 9),
            11181 => new PiglinHeadBlock(Identifier, false, 10),
            11182 => new PiglinHeadBlock(Identifier, false, 11),
            11183 => new PiglinHeadBlock(Identifier, false, 12),
            11184 => new PiglinHeadBlock(Identifier, false, 13),
            11185 => new PiglinHeadBlock(Identifier, false, 14),
            11186 => new PiglinHeadBlock(Identifier, false, 15),
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
