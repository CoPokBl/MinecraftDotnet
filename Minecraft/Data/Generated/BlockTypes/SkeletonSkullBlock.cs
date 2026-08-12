using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock {
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
    public Identifier? Item => "minecraft:skeleton_skull";
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
    public string TranslationKey => "block.minecraft.skeleton_skull";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10915,
                    1 => 10916,
                    2 => 10917,
                    3 => 10918,
                    4 => 10919,
                    5 => 10920,
                    6 => 10921,
                    7 => 10922,
                    8 => 10923,
                    9 => 10924,
                    10 => 10925,
                    11 => 10926,
                    12 => 10927,
                    13 => 10928,
                    14 => 10929,
                    15 => 10930,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 10931,
                    1 => 10932,
                    2 => 10933,
                    3 => 10934,
                    4 => 10935,
                    5 => 10936,
                    6 => 10937,
                    7 => 10938,
                    8 => 10939,
                    9 => 10940,
                    10 => 10941,
                    11 => 10942,
                    12 => 10943,
                    13 => 10944,
                    14 => 10945,
                    15 => 10946,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10915 => new SkeletonSkullBlock(Identifier, true, 0),
            10916 => new SkeletonSkullBlock(Identifier, true, 1),
            10917 => new SkeletonSkullBlock(Identifier, true, 2),
            10918 => new SkeletonSkullBlock(Identifier, true, 3),
            10919 => new SkeletonSkullBlock(Identifier, true, 4),
            10920 => new SkeletonSkullBlock(Identifier, true, 5),
            10921 => new SkeletonSkullBlock(Identifier, true, 6),
            10922 => new SkeletonSkullBlock(Identifier, true, 7),
            10923 => new SkeletonSkullBlock(Identifier, true, 8),
            10924 => new SkeletonSkullBlock(Identifier, true, 9),
            10925 => new SkeletonSkullBlock(Identifier, true, 10),
            10926 => new SkeletonSkullBlock(Identifier, true, 11),
            10927 => new SkeletonSkullBlock(Identifier, true, 12),
            10928 => new SkeletonSkullBlock(Identifier, true, 13),
            10929 => new SkeletonSkullBlock(Identifier, true, 14),
            10930 => new SkeletonSkullBlock(Identifier, true, 15),
            10931 => new SkeletonSkullBlock(Identifier, false, 0),
            10932 => new SkeletonSkullBlock(Identifier, false, 1),
            10933 => new SkeletonSkullBlock(Identifier, false, 2),
            10934 => new SkeletonSkullBlock(Identifier, false, 3),
            10935 => new SkeletonSkullBlock(Identifier, false, 4),
            10936 => new SkeletonSkullBlock(Identifier, false, 5),
            10937 => new SkeletonSkullBlock(Identifier, false, 6),
            10938 => new SkeletonSkullBlock(Identifier, false, 7),
            10939 => new SkeletonSkullBlock(Identifier, false, 8),
            10940 => new SkeletonSkullBlock(Identifier, false, 9),
            10941 => new SkeletonSkullBlock(Identifier, false, 10),
            10942 => new SkeletonSkullBlock(Identifier, false, 11),
            10943 => new SkeletonSkullBlock(Identifier, false, 12),
            10944 => new SkeletonSkullBlock(Identifier, false, 13),
            10945 => new SkeletonSkullBlock(Identifier, false, 14),
            10946 => new SkeletonSkullBlock(Identifier, false, 15),
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
