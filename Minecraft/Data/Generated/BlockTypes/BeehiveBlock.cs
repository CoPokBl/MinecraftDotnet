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
public record BeehiveBlock(Identifier Identifier, Direction Facing, int HoneyLevel) : IBlock, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.beehive", 0.6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:beehive", "minecraft:beehive", BlockInfo.VanillaOnly, "minecraft:blocks/beehive");
    private static readonly BlockStateInfo I0 = new(0.6f, 0, 15, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
                    0 => 25149,
                    1 => 25150,
                    2 => 25151,
                    3 => 25152,
                    4 => 25153,
                    5 => 25154,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 25155,
                    1 => 25156,
                    2 => 25157,
                    3 => 25158,
                    4 => 25159,
                    5 => 25160,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 25161,
                    1 => 25162,
                    2 => 25163,
                    3 => 25164,
                    4 => 25165,
                    5 => 25166,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 25167,
                    1 => 25168,
                    2 => 25169,
                    3 => 25170,
                    4 => 25171,
                    5 => 25172,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25149 => new BeehiveBlock(Identifier, Direction.North, 0),
            25150 => new BeehiveBlock(Identifier, Direction.North, 1),
            25151 => new BeehiveBlock(Identifier, Direction.North, 2),
            25152 => new BeehiveBlock(Identifier, Direction.North, 3),
            25153 => new BeehiveBlock(Identifier, Direction.North, 4),
            25154 => new BeehiveBlock(Identifier, Direction.North, 5),
            25155 => new BeehiveBlock(Identifier, Direction.South, 0),
            25156 => new BeehiveBlock(Identifier, Direction.South, 1),
            25157 => new BeehiveBlock(Identifier, Direction.South, 2),
            25158 => new BeehiveBlock(Identifier, Direction.South, 3),
            25159 => new BeehiveBlock(Identifier, Direction.South, 4),
            25160 => new BeehiveBlock(Identifier, Direction.South, 5),
            25161 => new BeehiveBlock(Identifier, Direction.West, 0),
            25162 => new BeehiveBlock(Identifier, Direction.West, 1),
            25163 => new BeehiveBlock(Identifier, Direction.West, 2),
            25164 => new BeehiveBlock(Identifier, Direction.West, 3),
            25165 => new BeehiveBlock(Identifier, Direction.West, 4),
            25166 => new BeehiveBlock(Identifier, Direction.West, 5),
            25167 => new BeehiveBlock(Identifier, Direction.East, 0),
            25168 => new BeehiveBlock(Identifier, Direction.East, 1),
            25169 => new BeehiveBlock(Identifier, Direction.East, 2),
            25170 => new BeehiveBlock(Identifier, Direction.East, 3),
            25171 => new BeehiveBlock(Identifier, Direction.East, 4),
            25172 => new BeehiveBlock(Identifier, Direction.East, 5),
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
