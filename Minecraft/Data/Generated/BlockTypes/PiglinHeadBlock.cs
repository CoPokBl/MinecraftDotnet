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
    public int ProtocolId => 463;
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
                    0 => 10953,
                    1 => 10954,
                    2 => 10955,
                    3 => 10956,
                    4 => 10957,
                    5 => 10958,
                    6 => 10959,
                    7 => 10960,
                    8 => 10961,
                    9 => 10962,
                    10 => 10963,
                    11 => 10964,
                    12 => 10965,
                    13 => 10966,
                    14 => 10967,
                    15 => 10968,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10969,
                    1 => 10970,
                    2 => 10971,
                    3 => 10972,
                    4 => 10973,
                    5 => 10974,
                    6 => 10975,
                    7 => 10976,
                    8 => 10977,
                    9 => 10978,
                    10 => 10979,
                    11 => 10980,
                    12 => 10981,
                    13 => 10982,
                    14 => 10983,
                    15 => 10984,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10953 => new PiglinHeadBlock(Identifier, true, 0),
            10954 => new PiglinHeadBlock(Identifier, true, 1),
            10955 => new PiglinHeadBlock(Identifier, true, 2),
            10956 => new PiglinHeadBlock(Identifier, true, 3),
            10957 => new PiglinHeadBlock(Identifier, true, 4),
            10958 => new PiglinHeadBlock(Identifier, true, 5),
            10959 => new PiglinHeadBlock(Identifier, true, 6),
            10960 => new PiglinHeadBlock(Identifier, true, 7),
            10961 => new PiglinHeadBlock(Identifier, true, 8),
            10962 => new PiglinHeadBlock(Identifier, true, 9),
            10963 => new PiglinHeadBlock(Identifier, true, 10),
            10964 => new PiglinHeadBlock(Identifier, true, 11),
            10965 => new PiglinHeadBlock(Identifier, true, 12),
            10966 => new PiglinHeadBlock(Identifier, true, 13),
            10967 => new PiglinHeadBlock(Identifier, true, 14),
            10968 => new PiglinHeadBlock(Identifier, true, 15),
            10969 => new PiglinHeadBlock(Identifier, false, 0),
            10970 => new PiglinHeadBlock(Identifier, false, 1),
            10971 => new PiglinHeadBlock(Identifier, false, 2),
            10972 => new PiglinHeadBlock(Identifier, false, 3),
            10973 => new PiglinHeadBlock(Identifier, false, 4),
            10974 => new PiglinHeadBlock(Identifier, false, 5),
            10975 => new PiglinHeadBlock(Identifier, false, 6),
            10976 => new PiglinHeadBlock(Identifier, false, 7),
            10977 => new PiglinHeadBlock(Identifier, false, 8),
            10978 => new PiglinHeadBlock(Identifier, false, 9),
            10979 => new PiglinHeadBlock(Identifier, false, 10),
            10980 => new PiglinHeadBlock(Identifier, false, 11),
            10981 => new PiglinHeadBlock(Identifier, false, 12),
            10982 => new PiglinHeadBlock(Identifier, false, 13),
            10983 => new PiglinHeadBlock(Identifier, false, 14),
            10984 => new PiglinHeadBlock(Identifier, false, 15),
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
