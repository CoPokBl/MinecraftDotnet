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
public record RedstoneWallTorchBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock, IHorizontalFacing, ILit {
    private static readonly BlockInfo Data = new("block.minecraft.redstone_torch", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:redstone_torch", BlockInfo.VanillaOnly, "minecraft:blocks/redstone_torch");
    private static readonly BlockStateInfo I0 = new(0f, 7, 0, PushReaction.Popped, 0, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S511, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S512 };
    private static readonly BlockStateInfo I3 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S512 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S513 };
    private static readonly BlockStateInfo I5 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S513 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S514 };
    private static readonly BlockStateInfo I7 = I0 with { LightEmission = 0, BlockShape = BlockShapes.S514 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 8557];

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

    public IBlock WithLit(bool lit) => this with { Lit = lit };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 8557,
                    false => 8558,
                },
                Direction.South => Lit switch {
                    true => 8559,
                    false => 8560,
                },
                Direction.West => Lit switch {
                    true => 8561,
                    false => 8562,
                },
                Direction.East => Lit switch {
                    true => 8563,
                    false => 8564,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8557 => new RedstoneWallTorchBlock(Identifier, Direction.North, true),
            8558 => new RedstoneWallTorchBlock(Identifier, Direction.North, false),
            8559 => new RedstoneWallTorchBlock(Identifier, Direction.South, true),
            8560 => new RedstoneWallTorchBlock(Identifier, Direction.South, false),
            8561 => new RedstoneWallTorchBlock(Identifier, Direction.West, true),
            8562 => new RedstoneWallTorchBlock(Identifier, Direction.West, false),
            8563 => new RedstoneWallTorchBlock(Identifier, Direction.East, true),
            8564 => new RedstoneWallTorchBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("lit", new StringTag(Lit.ToString().ToLower()))
        );
    }
    
}
