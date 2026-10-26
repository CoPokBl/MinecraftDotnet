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
public record SkeletonSkullBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.skeleton_skull", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:skeleton_skull", BlockInfo.VanillaOnly, "minecraft:blocks/skeleton_skull");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Skeleton, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 12682,
                    1 => 12683,
                    2 => 12684,
                    3 => 12685,
                    4 => 12686,
                    5 => 12687,
                    6 => 12688,
                    7 => 12689,
                    8 => 12690,
                    9 => 12691,
                    10 => 12692,
                    11 => 12693,
                    12 => 12694,
                    13 => 12695,
                    14 => 12696,
                    15 => 12697,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12698,
                    1 => 12699,
                    2 => 12700,
                    3 => 12701,
                    4 => 12702,
                    5 => 12703,
                    6 => 12704,
                    7 => 12705,
                    8 => 12706,
                    9 => 12707,
                    10 => 12708,
                    11 => 12709,
                    12 => 12710,
                    13 => 12711,
                    14 => 12712,
                    15 => 12713,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12682 => new SkeletonSkullBlock(Identifier, true, 0),
            12683 => new SkeletonSkullBlock(Identifier, true, 1),
            12684 => new SkeletonSkullBlock(Identifier, true, 2),
            12685 => new SkeletonSkullBlock(Identifier, true, 3),
            12686 => new SkeletonSkullBlock(Identifier, true, 4),
            12687 => new SkeletonSkullBlock(Identifier, true, 5),
            12688 => new SkeletonSkullBlock(Identifier, true, 6),
            12689 => new SkeletonSkullBlock(Identifier, true, 7),
            12690 => new SkeletonSkullBlock(Identifier, true, 8),
            12691 => new SkeletonSkullBlock(Identifier, true, 9),
            12692 => new SkeletonSkullBlock(Identifier, true, 10),
            12693 => new SkeletonSkullBlock(Identifier, true, 11),
            12694 => new SkeletonSkullBlock(Identifier, true, 12),
            12695 => new SkeletonSkullBlock(Identifier, true, 13),
            12696 => new SkeletonSkullBlock(Identifier, true, 14),
            12697 => new SkeletonSkullBlock(Identifier, true, 15),
            12698 => new SkeletonSkullBlock(Identifier, false, 0),
            12699 => new SkeletonSkullBlock(Identifier, false, 1),
            12700 => new SkeletonSkullBlock(Identifier, false, 2),
            12701 => new SkeletonSkullBlock(Identifier, false, 3),
            12702 => new SkeletonSkullBlock(Identifier, false, 4),
            12703 => new SkeletonSkullBlock(Identifier, false, 5),
            12704 => new SkeletonSkullBlock(Identifier, false, 6),
            12705 => new SkeletonSkullBlock(Identifier, false, 7),
            12706 => new SkeletonSkullBlock(Identifier, false, 8),
            12707 => new SkeletonSkullBlock(Identifier, false, 9),
            12708 => new SkeletonSkullBlock(Identifier, false, 10),
            12709 => new SkeletonSkullBlock(Identifier, false, 11),
            12710 => new SkeletonSkullBlock(Identifier, false, 12),
            12711 => new SkeletonSkullBlock(Identifier, false, 13),
            12712 => new SkeletonSkullBlock(Identifier, false, 14),
            12713 => new SkeletonSkullBlock(Identifier, false, 15),
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
