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
public record LeafLitterBlock(Identifier Identifier, Direction Facing, int SegmentAmount) : IBlock, IHorizontalFacing, IStackable {
    private static readonly BlockInfo Data = new("block.minecraft.leaf_litter", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:leaf_litter", BlockInfo.VanillaOnly, "minecraft:blocks/leaf_litter");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 26, "leaf_litter", NoteBlockInstrument.Harp, true, false, false, true, false, false, true, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S618, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S619 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S620 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S621 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S622 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S623 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S624 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S625 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I3, I4, I2, I2, I5, I6, I2, I2, I7, I8, I2, I2
    ];

    public BlockStateInfo StateInfo => States[StateId - 33696];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public int Count => SegmentAmount;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { SegmentAmount = count };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => SegmentAmount switch {
                    1 => 33696,
                    2 => 33697,
                    3 => 33698,
                    4 => 33699,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 33700,
                    2 => 33701,
                    3 => 33702,
                    4 => 33703,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 33704,
                    2 => 33705,
                    3 => 33706,
                    4 => 33707,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 33708,
                    2 => 33709,
                    3 => 33710,
                    4 => 33711,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33696 => new LeafLitterBlock(Identifier, Direction.North, 1),
            33697 => new LeafLitterBlock(Identifier, Direction.North, 2),
            33698 => new LeafLitterBlock(Identifier, Direction.North, 3),
            33699 => new LeafLitterBlock(Identifier, Direction.North, 4),
            33700 => new LeafLitterBlock(Identifier, Direction.South, 1),
            33701 => new LeafLitterBlock(Identifier, Direction.South, 2),
            33702 => new LeafLitterBlock(Identifier, Direction.South, 3),
            33703 => new LeafLitterBlock(Identifier, Direction.South, 4),
            33704 => new LeafLitterBlock(Identifier, Direction.West, 1),
            33705 => new LeafLitterBlock(Identifier, Direction.West, 2),
            33706 => new LeafLitterBlock(Identifier, Direction.West, 3),
            33707 => new LeafLitterBlock(Identifier, Direction.West, 4),
            33708 => new LeafLitterBlock(Identifier, Direction.East, 1),
            33709 => new LeafLitterBlock(Identifier, Direction.East, 2),
            33710 => new LeafLitterBlock(Identifier, Direction.East, 3),
            33711 => new LeafLitterBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            SegmentAmount = properties.Contains("segment_amount") ? int.Parse(properties["segment_amount"].GetString()) : SegmentAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("segment_amount", new StringTag(SegmentAmount.ToString()))
        );
    }
    
}
