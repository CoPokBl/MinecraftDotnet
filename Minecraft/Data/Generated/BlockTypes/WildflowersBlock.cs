using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WildflowersBlock(Identifier Identifier, Direction Facing, int FlowerAmount) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:flower_bed", "block.minecraft.wildflowers", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:wildflowers", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 7, "pink_petals", NoteBlockInstrument.Harp, true, false, false, false, true, false, false, false, false, false, false, false, false, false, true, [], null, BlockShapes.S792, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S793 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S113 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S794 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S795 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S796 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S797 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S798 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S799 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I2, I3, I4, I2, I2, I5, I6, I2, I2, I7, I8, I2, I2
    ];

    public BlockStateInfo StateInfo => States[StateId - 30323];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => FlowerAmount switch {
                    1 => 30323,
                    2 => 30324,
                    3 => 30325,
                    4 => 30326,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.South => FlowerAmount switch {
                    1 => 30327,
                    2 => 30328,
                    3 => 30329,
                    4 => 30330,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.West => FlowerAmount switch {
                    1 => 30331,
                    2 => 30332,
                    3 => 30333,
                    4 => 30334,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                Direction.East => FlowerAmount switch {
                    1 => 30335,
                    2 => 30336,
                    3 => 30337,
                    4 => 30338,
                    _ => throw new ArgumentOutOfRangeException(nameof(FlowerAmount), FlowerAmount, "Unknown value for property flower_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30323 => new WildflowersBlock(Identifier, Direction.North, 1),
            30324 => new WildflowersBlock(Identifier, Direction.North, 2),
            30325 => new WildflowersBlock(Identifier, Direction.North, 3),
            30326 => new WildflowersBlock(Identifier, Direction.North, 4),
            30327 => new WildflowersBlock(Identifier, Direction.South, 1),
            30328 => new WildflowersBlock(Identifier, Direction.South, 2),
            30329 => new WildflowersBlock(Identifier, Direction.South, 3),
            30330 => new WildflowersBlock(Identifier, Direction.South, 4),
            30331 => new WildflowersBlock(Identifier, Direction.West, 1),
            30332 => new WildflowersBlock(Identifier, Direction.West, 2),
            30333 => new WildflowersBlock(Identifier, Direction.West, 3),
            30334 => new WildflowersBlock(Identifier, Direction.West, 4),
            30335 => new WildflowersBlock(Identifier, Direction.East, 1),
            30336 => new WildflowersBlock(Identifier, Direction.East, 2),
            30337 => new WildflowersBlock(Identifier, Direction.East, 3),
            30338 => new WildflowersBlock(Identifier, Direction.East, 4),
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
