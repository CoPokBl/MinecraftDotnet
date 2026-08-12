using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmallAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:amethyst_cluster", "block.minecraft.small_amethyst_bud", 1.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:small_amethyst_bud", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 1, 1, PushReaction.Destroy, 24, "small_amethyst_bud", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S914, BlockShapes.S914, BlockShapes.S1, BlockShapes.S1, BlockShapes.S914);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S915, CollisionShape = BlockShapes.S915, VisualShape = BlockShapes.S915 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S915, CollisionShape = BlockShapes.S915, VisualShape = BlockShapes.S915 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S916, CollisionShape = BlockShapes.S916, VisualShape = BlockShapes.S916 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S916, CollisionShape = BlockShapes.S916, VisualShape = BlockShapes.S916 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S917, CollisionShape = BlockShapes.S917, VisualShape = BlockShapes.S917 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S917, CollisionShape = BlockShapes.S917, VisualShape = BlockShapes.S917 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S918, CollisionShape = BlockShapes.S918, VisualShape = BlockShapes.S918 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S918, CollisionShape = BlockShapes.S918, VisualShape = BlockShapes.S918 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S919, CollisionShape = BlockShapes.S919, VisualShape = BlockShapes.S919 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S919, CollisionShape = BlockShapes.S919, VisualShape = BlockShapes.S919 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 23440];

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
                Cardinal.North => Waterlogged switch {
                    true => 23440,
                    false => 23441,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23442,
                    false => 23443,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23444,
                    false => 23445,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23446,
                    false => 23447,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23448,
                    false => 23449,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23450,
                    false => 23451,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23440 => new SmallAmethystBudBlock(Identifier, Cardinal.North, true),
            23441 => new SmallAmethystBudBlock(Identifier, Cardinal.North, false),
            23442 => new SmallAmethystBudBlock(Identifier, Cardinal.East, true),
            23443 => new SmallAmethystBudBlock(Identifier, Cardinal.East, false),
            23444 => new SmallAmethystBudBlock(Identifier, Cardinal.South, true),
            23445 => new SmallAmethystBudBlock(Identifier, Cardinal.South, false),
            23446 => new SmallAmethystBudBlock(Identifier, Cardinal.West, true),
            23447 => new SmallAmethystBudBlock(Identifier, Cardinal.West, false),
            23448 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, true),
            23449 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, false),
            23450 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, true),
            23451 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
