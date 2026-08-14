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
public record AmethystClusterBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock, IDirectional, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:amethyst_cluster", "block.minecraft.amethyst_cluster", 1.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:amethyst_cluster", BlockInfo.VanillaOnly, "minecraft:blocks/amethyst_cluster");
    private static readonly BlockStateInfo I0 = new(1.5f, 5, 1, PushReaction.Destroy, 24, "amethyst_cluster", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S126, BlockShapes.S126, BlockShapes.S1, BlockShapes.S1, BlockShapes.S126, BlockShapes.S126);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S127, CollisionShape = BlockShapes.S127, VisualShape = BlockShapes.S127, SupportShape = BlockShapes.S127 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S127, CollisionShape = BlockShapes.S127, VisualShape = BlockShapes.S127, SupportShape = BlockShapes.S127 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S128, CollisionShape = BlockShapes.S128, VisualShape = BlockShapes.S128, SupportShape = BlockShapes.S128 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S128, CollisionShape = BlockShapes.S128, VisualShape = BlockShapes.S128, SupportShape = BlockShapes.S128 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S129, CollisionShape = BlockShapes.S129, VisualShape = BlockShapes.S129, SupportShape = BlockShapes.S129 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S129, CollisionShape = BlockShapes.S129, VisualShape = BlockShapes.S129, SupportShape = BlockShapes.S129 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S130, CollisionShape = BlockShapes.S130, VisualShape = BlockShapes.S130, SupportShape = BlockShapes.S130 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S130, CollisionShape = BlockShapes.S130, VisualShape = BlockShapes.S130, SupportShape = BlockShapes.S130 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S131, VisualShape = BlockShapes.S131, SupportShape = BlockShapes.S131 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S131, CollisionShape = BlockShapes.S131, VisualShape = BlockShapes.S131, SupportShape = BlockShapes.S131 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 23404];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 23404,
                    false => 23405,
                },
                Cardinal.East => Waterlogged switch {
                    true => 23406,
                    false => 23407,
                },
                Cardinal.South => Waterlogged switch {
                    true => 23408,
                    false => 23409,
                },
                Cardinal.West => Waterlogged switch {
                    true => 23410,
                    false => 23411,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 23412,
                    false => 23413,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 23414,
                    false => 23415,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23404 => new AmethystClusterBlock(Identifier, Cardinal.North, true),
            23405 => new AmethystClusterBlock(Identifier, Cardinal.North, false),
            23406 => new AmethystClusterBlock(Identifier, Cardinal.East, true),
            23407 => new AmethystClusterBlock(Identifier, Cardinal.East, false),
            23408 => new AmethystClusterBlock(Identifier, Cardinal.South, true),
            23409 => new AmethystClusterBlock(Identifier, Cardinal.South, false),
            23410 => new AmethystClusterBlock(Identifier, Cardinal.West, true),
            23411 => new AmethystClusterBlock(Identifier, Cardinal.West, false),
            23412 => new AmethystClusterBlock(Identifier, Cardinal.Up, true),
            23413 => new AmethystClusterBlock(Identifier, Cardinal.Up, false),
            23414 => new AmethystClusterBlock(Identifier, Cardinal.Down, true),
            23415 => new AmethystClusterBlock(Identifier, Cardinal.Down, false),
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
