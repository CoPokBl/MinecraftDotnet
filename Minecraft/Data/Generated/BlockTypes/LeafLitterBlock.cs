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
    private static readonly BlockInfo Data = new("minecraft:leaf_litter", "block.minecraft.leaf_litter", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:leaf_litter", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 26, "leaf_litter", NoteBlockInstrument.Harp, true, false, false, false, true, false, false, true, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S617, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S618 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S371 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S619 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S620 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S621 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S622 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S623 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S624 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I3, I4, I2, I2, I5, I6, I2, I2, I7, I8, I2, I2
    ];

    public BlockStateInfo StateInfo => States[StateId - 30339];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public int Count => SegmentAmount;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { SegmentAmount = count };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => SegmentAmount switch {
                    1 => 30339,
                    2 => 30340,
                    3 => 30341,
                    4 => 30342,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 30343,
                    2 => 30344,
                    3 => 30345,
                    4 => 30346,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 30347,
                    2 => 30348,
                    3 => 30349,
                    4 => 30350,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 30351,
                    2 => 30352,
                    3 => 30353,
                    4 => 30354,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30339 => new LeafLitterBlock(Identifier, Direction.North, 1),
            30340 => new LeafLitterBlock(Identifier, Direction.North, 2),
            30341 => new LeafLitterBlock(Identifier, Direction.North, 3),
            30342 => new LeafLitterBlock(Identifier, Direction.North, 4),
            30343 => new LeafLitterBlock(Identifier, Direction.South, 1),
            30344 => new LeafLitterBlock(Identifier, Direction.South, 2),
            30345 => new LeafLitterBlock(Identifier, Direction.South, 3),
            30346 => new LeafLitterBlock(Identifier, Direction.South, 4),
            30347 => new LeafLitterBlock(Identifier, Direction.West, 1),
            30348 => new LeafLitterBlock(Identifier, Direction.West, 2),
            30349 => new LeafLitterBlock(Identifier, Direction.West, 3),
            30350 => new LeafLitterBlock(Identifier, Direction.West, 4),
            30351 => new LeafLitterBlock(Identifier, Direction.East, 1),
            30352 => new LeafLitterBlock(Identifier, Direction.East, 2),
            30353 => new LeafLitterBlock(Identifier, Direction.East, 3),
            30354 => new LeafLitterBlock(Identifier, Direction.East, 4),
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
