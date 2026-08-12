using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WitherSkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
    public Identifier Category => "minecraft:wither_skull";
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
    public Identifier? Item => "minecraft:wither_skeleton_skull";
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
    public string TranslationKey => "block.minecraft.wither_skeleton_skull";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10955,
                    1 => 10956,
                    2 => 10957,
                    3 => 10958,
                    4 => 10959,
                    5 => 10960,
                    6 => 10961,
                    7 => 10962,
                    8 => 10963,
                    9 => 10964,
                    10 => 10965,
                    11 => 10966,
                    12 => 10967,
                    13 => 10968,
                    14 => 10969,
                    15 => 10970,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10971,
                    1 => 10972,
                    2 => 10973,
                    3 => 10974,
                    4 => 10975,
                    5 => 10976,
                    6 => 10977,
                    7 => 10978,
                    8 => 10979,
                    9 => 10980,
                    10 => 10981,
                    11 => 10982,
                    12 => 10983,
                    13 => 10984,
                    14 => 10985,
                    15 => 10986,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10955 => new WitherSkeletonSkullBlock(Identifier, true, 0),
            10956 => new WitherSkeletonSkullBlock(Identifier, true, 1),
            10957 => new WitherSkeletonSkullBlock(Identifier, true, 2),
            10958 => new WitherSkeletonSkullBlock(Identifier, true, 3),
            10959 => new WitherSkeletonSkullBlock(Identifier, true, 4),
            10960 => new WitherSkeletonSkullBlock(Identifier, true, 5),
            10961 => new WitherSkeletonSkullBlock(Identifier, true, 6),
            10962 => new WitherSkeletonSkullBlock(Identifier, true, 7),
            10963 => new WitherSkeletonSkullBlock(Identifier, true, 8),
            10964 => new WitherSkeletonSkullBlock(Identifier, true, 9),
            10965 => new WitherSkeletonSkullBlock(Identifier, true, 10),
            10966 => new WitherSkeletonSkullBlock(Identifier, true, 11),
            10967 => new WitherSkeletonSkullBlock(Identifier, true, 12),
            10968 => new WitherSkeletonSkullBlock(Identifier, true, 13),
            10969 => new WitherSkeletonSkullBlock(Identifier, true, 14),
            10970 => new WitherSkeletonSkullBlock(Identifier, true, 15),
            10971 => new WitherSkeletonSkullBlock(Identifier, false, 0),
            10972 => new WitherSkeletonSkullBlock(Identifier, false, 1),
            10973 => new WitherSkeletonSkullBlock(Identifier, false, 2),
            10974 => new WitherSkeletonSkullBlock(Identifier, false, 3),
            10975 => new WitherSkeletonSkullBlock(Identifier, false, 4),
            10976 => new WitherSkeletonSkullBlock(Identifier, false, 5),
            10977 => new WitherSkeletonSkullBlock(Identifier, false, 6),
            10978 => new WitherSkeletonSkullBlock(Identifier, false, 7),
            10979 => new WitherSkeletonSkullBlock(Identifier, false, 8),
            10980 => new WitherSkeletonSkullBlock(Identifier, false, 9),
            10981 => new WitherSkeletonSkullBlock(Identifier, false, 10),
            10982 => new WitherSkeletonSkullBlock(Identifier, false, 11),
            10983 => new WitherSkeletonSkullBlock(Identifier, false, 12),
            10984 => new WitherSkeletonSkullBlock(Identifier, false, 13),
            10985 => new WitherSkeletonSkullBlock(Identifier, false, 14),
            10986 => new WitherSkeletonSkullBlock(Identifier, false, 15),
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
