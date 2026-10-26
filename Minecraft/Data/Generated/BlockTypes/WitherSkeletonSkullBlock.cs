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
    private static readonly BlockInfo Data = new("block.minecraft.wither_skeleton_skull", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:wither_skeleton_skull", BlockInfo.VanillaOnly, "minecraft:blocks/wither_skeleton_skull");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.WitherSkeleton, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
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
                    0 => 12722,
                    1 => 12723,
                    2 => 12724,
                    3 => 12725,
                    4 => 12726,
                    5 => 12727,
                    6 => 12728,
                    7 => 12729,
                    8 => 12730,
                    9 => 12731,
                    10 => 12732,
                    11 => 12733,
                    12 => 12734,
                    13 => 12735,
                    14 => 12736,
                    15 => 12737,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12738,
                    1 => 12739,
                    2 => 12740,
                    3 => 12741,
                    4 => 12742,
                    5 => 12743,
                    6 => 12744,
                    7 => 12745,
                    8 => 12746,
                    9 => 12747,
                    10 => 12748,
                    11 => 12749,
                    12 => 12750,
                    13 => 12751,
                    14 => 12752,
                    15 => 12753,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12722 => new WitherSkeletonSkullBlock(Identifier, true, 0),
            12723 => new WitherSkeletonSkullBlock(Identifier, true, 1),
            12724 => new WitherSkeletonSkullBlock(Identifier, true, 2),
            12725 => new WitherSkeletonSkullBlock(Identifier, true, 3),
            12726 => new WitherSkeletonSkullBlock(Identifier, true, 4),
            12727 => new WitherSkeletonSkullBlock(Identifier, true, 5),
            12728 => new WitherSkeletonSkullBlock(Identifier, true, 6),
            12729 => new WitherSkeletonSkullBlock(Identifier, true, 7),
            12730 => new WitherSkeletonSkullBlock(Identifier, true, 8),
            12731 => new WitherSkeletonSkullBlock(Identifier, true, 9),
            12732 => new WitherSkeletonSkullBlock(Identifier, true, 10),
            12733 => new WitherSkeletonSkullBlock(Identifier, true, 11),
            12734 => new WitherSkeletonSkullBlock(Identifier, true, 12),
            12735 => new WitherSkeletonSkullBlock(Identifier, true, 13),
            12736 => new WitherSkeletonSkullBlock(Identifier, true, 14),
            12737 => new WitherSkeletonSkullBlock(Identifier, true, 15),
            12738 => new WitherSkeletonSkullBlock(Identifier, false, 0),
            12739 => new WitherSkeletonSkullBlock(Identifier, false, 1),
            12740 => new WitherSkeletonSkullBlock(Identifier, false, 2),
            12741 => new WitherSkeletonSkullBlock(Identifier, false, 3),
            12742 => new WitherSkeletonSkullBlock(Identifier, false, 4),
            12743 => new WitherSkeletonSkullBlock(Identifier, false, 5),
            12744 => new WitherSkeletonSkullBlock(Identifier, false, 6),
            12745 => new WitherSkeletonSkullBlock(Identifier, false, 7),
            12746 => new WitherSkeletonSkullBlock(Identifier, false, 8),
            12747 => new WitherSkeletonSkullBlock(Identifier, false, 9),
            12748 => new WitherSkeletonSkullBlock(Identifier, false, 10),
            12749 => new WitherSkeletonSkullBlock(Identifier, false, 11),
            12750 => new WitherSkeletonSkullBlock(Identifier, false, 12),
            12751 => new WitherSkeletonSkullBlock(Identifier, false, 13),
            12752 => new WitherSkeletonSkullBlock(Identifier, false, 14),
            12753 => new WitherSkeletonSkullBlock(Identifier, false, 15),
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
