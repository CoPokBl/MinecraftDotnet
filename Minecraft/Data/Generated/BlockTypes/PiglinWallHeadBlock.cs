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
public record PiglinWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.piglin_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:piglin_head", BlockInfo.VanillaOnly, "minecraft:blocks/piglin_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S791, BlockShapes.S791, BlockShapes.S1, BlockShapes.S791, BlockShapes.S791, BlockShapes.S791);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S792, CollisionShape = BlockShapes.S792, OcclusionShape = BlockShapes.S792, VisualShape = BlockShapes.S792, SupportShape = BlockShapes.S792 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S793, CollisionShape = BlockShapes.S793, OcclusionShape = BlockShapes.S793, VisualShape = BlockShapes.S793, SupportShape = BlockShapes.S793 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S794, CollisionShape = BlockShapes.S794, OcclusionShape = BlockShapes.S794, VisualShape = BlockShapes.S794, SupportShape = BlockShapes.S794 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 12954];

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 12954,
                    false => 12955,
                },
                Direction.South => Powered switch {
                    true => 12956,
                    false => 12957,
                },
                Direction.West => Powered switch {
                    true => 12958,
                    false => 12959,
                },
                Direction.East => Powered switch {
                    true => 12960,
                    false => 12961,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12954 => new PiglinWallHeadBlock(Identifier, Direction.North, true),
            12955 => new PiglinWallHeadBlock(Identifier, Direction.North, false),
            12956 => new PiglinWallHeadBlock(Identifier, Direction.South, true),
            12957 => new PiglinWallHeadBlock(Identifier, Direction.South, false),
            12958 => new PiglinWallHeadBlock(Identifier, Direction.West, true),
            12959 => new PiglinWallHeadBlock(Identifier, Direction.West, false),
            12960 => new PiglinWallHeadBlock(Identifier, Direction.East, true),
            12961 => new PiglinWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
