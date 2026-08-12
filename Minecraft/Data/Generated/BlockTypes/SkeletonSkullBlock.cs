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
    private static readonly BlockInfo Data = new("minecraft:skull", "block.minecraft.skeleton_skull", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:skeleton_skull", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Skeleton, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], null, BlockShapes.S513, BlockShapes.S513, BlockShapes.S1, BlockShapes.S1, BlockShapes.S513);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


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
