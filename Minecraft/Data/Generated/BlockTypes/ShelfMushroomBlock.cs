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
public record ShelfMushroomBlock(Identifier Identifier, int Age, Direction Facing) : IBlock, IAged, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.shelf_mushroom", 0f, 0.6f, 1f, 1f, 0.75f, 0.5f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:shelf_mushroom", BlockInfo.VanillaOnly, "minecraft:blocks/shelf_mushroom");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 40, "shelf_mushroom", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S916, BlockShapes.S916, BlockShapes.S1, BlockShapes.S1, BlockShapes.S916, BlockShapes.S916);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S917, CollisionShape = BlockShapes.S917, VisualShape = BlockShapes.S917, SupportShape = BlockShapes.S917 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S918, CollisionShape = BlockShapes.S918, VisualShape = BlockShapes.S918, SupportShape = BlockShapes.S918 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S919, CollisionShape = BlockShapes.S919, VisualShape = BlockShapes.S919, SupportShape = BlockShapes.S919 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S920, CollisionShape = BlockShapes.S920, VisualShape = BlockShapes.S920, SupportShape = BlockShapes.S920 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S921, CollisionShape = BlockShapes.S921, VisualShape = BlockShapes.S921, SupportShape = BlockShapes.S921 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S922, CollisionShape = BlockShapes.S922, VisualShape = BlockShapes.S922, SupportShape = BlockShapes.S922 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S923, CollisionShape = BlockShapes.S923, VisualShape = BlockShapes.S923, SupportShape = BlockShapes.S923 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 11227];

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

    public IBlock WithAge(int age) => this with { Age = age };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Age switch {
                0 => Facing switch {
                    Direction.North => 11227,
                    Direction.South => 11228,
                    Direction.West => 11229,
                    Direction.East => 11230,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                1 => Facing switch {
                    Direction.North => 11231,
                    Direction.South => 11232,
                    Direction.West => 11233,
                    Direction.East => 11234,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11227 => new ShelfMushroomBlock(Identifier, 0, Direction.North),
            11228 => new ShelfMushroomBlock(Identifier, 0, Direction.South),
            11229 => new ShelfMushroomBlock(Identifier, 0, Direction.West),
            11230 => new ShelfMushroomBlock(Identifier, 0, Direction.East),
            11231 => new ShelfMushroomBlock(Identifier, 1, Direction.North),
            11232 => new ShelfMushroomBlock(Identifier, 1, Direction.South),
            11233 => new ShelfMushroomBlock(Identifier, 1, Direction.West),
            11234 => new ShelfMushroomBlock(Identifier, 1, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
