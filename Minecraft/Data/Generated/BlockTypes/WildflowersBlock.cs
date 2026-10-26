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
public record WildflowersBlock(Identifier Identifier, Direction Facing, int FlowerAmount) : IBlock, IHorizontalFacing, IStackable {
    private static readonly BlockInfo Data = new("block.minecraft.wildflowers", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:wildflowers", BlockInfo.VanillaOnly, "minecraft:blocks/wildflowers");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 7, "pink_petals", NoteBlockInstrument.Harp, true, false, false, true, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S795, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S796 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S115 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S797 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S798 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S799 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S800 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S801 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S802 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I3, I4, I2, I2, I5, I6, I2, I2, I7, I8, I2, I2
    ];

    public BlockStateInfo StateInfo => States[StateId - 33680];

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

    public int Count => FlowerAmount;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { FlowerAmount = count };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => FlowerAmount switch {
                    1 => 33680,
                    2 => 33681,
                    3 => 33682,
                    4 => 33683,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 33684,
                    2 => 33685,
                    3 => 33686,
                    4 => 33687,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 33688,
                    2 => 33689,
                    3 => 33690,
                    4 => 33691,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 33692,
                    2 => 33693,
                    3 => 33694,
                    4 => 33695,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33680 => new WildflowersBlock(Identifier, Direction.North, 1),
            33681 => new WildflowersBlock(Identifier, Direction.North, 2),
            33682 => new WildflowersBlock(Identifier, Direction.North, 3),
            33683 => new WildflowersBlock(Identifier, Direction.North, 4),
            33684 => new WildflowersBlock(Identifier, Direction.South, 1),
            33685 => new WildflowersBlock(Identifier, Direction.South, 2),
            33686 => new WildflowersBlock(Identifier, Direction.South, 3),
            33687 => new WildflowersBlock(Identifier, Direction.South, 4),
            33688 => new WildflowersBlock(Identifier, Direction.West, 1),
            33689 => new WildflowersBlock(Identifier, Direction.West, 2),
            33690 => new WildflowersBlock(Identifier, Direction.West, 3),
            33691 => new WildflowersBlock(Identifier, Direction.West, 4),
            33692 => new WildflowersBlock(Identifier, Direction.East, 1),
            33693 => new WildflowersBlock(Identifier, Direction.East, 2),
            33694 => new WildflowersBlock(Identifier, Direction.East, 3),
            33695 => new WildflowersBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            FlowerAmount = properties.Contains("flower_amount") ? int.Parse(properties["flower_amount"].GetString()) : FlowerAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("flower_amount", new StringTag(FlowerAmount.ToString()))
        );
    }
    
}
