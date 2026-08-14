using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WitherSkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("minecraft:wither_skull", "block.minecraft.wither_skeleton_skull", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:wither_skeleton_skull", BlockInfo.VanillaOnly, "minecraft:blocks/wither_skeleton_skull");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.WitherSkeleton, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
    public ICollisionBox SupportShape => StateInfo.SupportShape;
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
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };


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
