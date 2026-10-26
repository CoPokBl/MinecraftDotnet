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
public record BeeNestBlock(Identifier Identifier, Direction Facing, int HoneyLevel) : IBlock, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.bee_nest", 0.3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:beehive", "minecraft:bee_nest", BlockInfo.VanillaOnly, "minecraft:blocks/bee_nest");
    private static readonly BlockStateInfo I0 = new(0.3f, 0, 15, PushReaction.PushPull, 18, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HoneyLevel switch {
                    0 => 25125,
                    1 => 25126,
                    2 => 25127,
                    3 => 25128,
                    4 => 25129,
                    5 => 25130,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 25131,
                    1 => 25132,
                    2 => 25133,
                    3 => 25134,
                    4 => 25135,
                    5 => 25136,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 25137,
                    1 => 25138,
                    2 => 25139,
                    3 => 25140,
                    4 => 25141,
                    5 => 25142,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 25143,
                    1 => 25144,
                    2 => 25145,
                    3 => 25146,
                    4 => 25147,
                    5 => 25148,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25125 => new BeeNestBlock(Identifier, Direction.North, 0),
            25126 => new BeeNestBlock(Identifier, Direction.North, 1),
            25127 => new BeeNestBlock(Identifier, Direction.North, 2),
            25128 => new BeeNestBlock(Identifier, Direction.North, 3),
            25129 => new BeeNestBlock(Identifier, Direction.North, 4),
            25130 => new BeeNestBlock(Identifier, Direction.North, 5),
            25131 => new BeeNestBlock(Identifier, Direction.South, 0),
            25132 => new BeeNestBlock(Identifier, Direction.South, 1),
            25133 => new BeeNestBlock(Identifier, Direction.South, 2),
            25134 => new BeeNestBlock(Identifier, Direction.South, 3),
            25135 => new BeeNestBlock(Identifier, Direction.South, 4),
            25136 => new BeeNestBlock(Identifier, Direction.South, 5),
            25137 => new BeeNestBlock(Identifier, Direction.West, 0),
            25138 => new BeeNestBlock(Identifier, Direction.West, 1),
            25139 => new BeeNestBlock(Identifier, Direction.West, 2),
            25140 => new BeeNestBlock(Identifier, Direction.West, 3),
            25141 => new BeeNestBlock(Identifier, Direction.West, 4),
            25142 => new BeeNestBlock(Identifier, Direction.West, 5),
            25143 => new BeeNestBlock(Identifier, Direction.East, 0),
            25144 => new BeeNestBlock(Identifier, Direction.East, 1),
            25145 => new BeeNestBlock(Identifier, Direction.East, 2),
            25146 => new BeeNestBlock(Identifier, Direction.East, 3),
            25147 => new BeeNestBlock(Identifier, Direction.East, 4),
            25148 => new BeeNestBlock(Identifier, Direction.East, 5),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            HoneyLevel = properties.Contains("honey_level") ? int.Parse(properties["honey_level"].GetString()) : HoneyLevel,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("honey_level", new StringTag(HoneyLevel.ToString()))
        );
    }
    
}
