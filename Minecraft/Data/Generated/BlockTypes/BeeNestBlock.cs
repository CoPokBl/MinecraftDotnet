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
    private static readonly BlockInfo Data = new("minecraft:beehive", "block.minecraft.bee_nest", 0.3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:beehive", "minecraft:bee_nest", BlockInfo.VanillaOnly, "minecraft:blocks/bee_nest");
    private static readonly BlockStateInfo I0 = new(0.3f, 0, 15, PushReaction.Normal, 18, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => HoneyLevel switch {
                    0 => 21768,
                    1 => 21769,
                    2 => 21770,
                    3 => 21771,
                    4 => 21772,
                    5 => 21773,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.South => HoneyLevel switch {
                    0 => 21774,
                    1 => 21775,
                    2 => 21776,
                    3 => 21777,
                    4 => 21778,
                    5 => 21779,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.West => HoneyLevel switch {
                    0 => 21780,
                    1 => 21781,
                    2 => 21782,
                    3 => 21783,
                    4 => 21784,
                    5 => 21785,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                Direction.East => HoneyLevel switch {
                    0 => 21786,
                    1 => 21787,
                    2 => 21788,
                    3 => 21789,
                    4 => 21790,
                    5 => 21791,
                    _ => throw new ArgumentOutOfRangeException(nameof(HoneyLevel), HoneyLevel, "Unknown value for property honey_level.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21768 => new BeeNestBlock(Identifier, Direction.North, 0),
            21769 => new BeeNestBlock(Identifier, Direction.North, 1),
            21770 => new BeeNestBlock(Identifier, Direction.North, 2),
            21771 => new BeeNestBlock(Identifier, Direction.North, 3),
            21772 => new BeeNestBlock(Identifier, Direction.North, 4),
            21773 => new BeeNestBlock(Identifier, Direction.North, 5),
            21774 => new BeeNestBlock(Identifier, Direction.South, 0),
            21775 => new BeeNestBlock(Identifier, Direction.South, 1),
            21776 => new BeeNestBlock(Identifier, Direction.South, 2),
            21777 => new BeeNestBlock(Identifier, Direction.South, 3),
            21778 => new BeeNestBlock(Identifier, Direction.South, 4),
            21779 => new BeeNestBlock(Identifier, Direction.South, 5),
            21780 => new BeeNestBlock(Identifier, Direction.West, 0),
            21781 => new BeeNestBlock(Identifier, Direction.West, 1),
            21782 => new BeeNestBlock(Identifier, Direction.West, 2),
            21783 => new BeeNestBlock(Identifier, Direction.West, 3),
            21784 => new BeeNestBlock(Identifier, Direction.West, 4),
            21785 => new BeeNestBlock(Identifier, Direction.West, 5),
            21786 => new BeeNestBlock(Identifier, Direction.East, 0),
            21787 => new BeeNestBlock(Identifier, Direction.East, 1),
            21788 => new BeeNestBlock(Identifier, Direction.East, 2),
            21789 => new BeeNestBlock(Identifier, Direction.East, 3),
            21790 => new BeeNestBlock(Identifier, Direction.East, 4),
            21791 => new BeeNestBlock(Identifier, Direction.East, 5),
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
