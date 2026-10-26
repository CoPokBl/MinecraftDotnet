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
public record LargeAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock, IDirectional, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.large_amethyst_bud", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:large_amethyst_bud", BlockInfo.VanillaOnly, "minecraft:blocks/large_amethyst_bud");
    private static readonly BlockStateInfo I0 = new(1.5f, 4, 1, PushReaction.Popped, 24, "medium_amethyst_bud", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S612, BlockShapes.S612, BlockShapes.S1, BlockShapes.S1, BlockShapes.S612, BlockShapes.S612);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S613, CollisionShape = BlockShapes.S613, VisualShape = BlockShapes.S613, SupportShape = BlockShapes.S613 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S613, CollisionShape = BlockShapes.S613, VisualShape = BlockShapes.S613, SupportShape = BlockShapes.S613 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S614, CollisionShape = BlockShapes.S614, VisualShape = BlockShapes.S614, SupportShape = BlockShapes.S614 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S614, CollisionShape = BlockShapes.S614, VisualShape = BlockShapes.S614, SupportShape = BlockShapes.S614 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S615, CollisionShape = BlockShapes.S615, VisualShape = BlockShapes.S615, SupportShape = BlockShapes.S615 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S615, CollisionShape = BlockShapes.S615, VisualShape = BlockShapes.S615, SupportShape = BlockShapes.S615 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S616, CollisionShape = BlockShapes.S616, VisualShape = BlockShapes.S616, SupportShape = BlockShapes.S616 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S616, CollisionShape = BlockShapes.S616, VisualShape = BlockShapes.S616, SupportShape = BlockShapes.S616 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S617, CollisionShape = BlockShapes.S617, VisualShape = BlockShapes.S617, SupportShape = BlockShapes.S617 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S617, CollisionShape = BlockShapes.S617, VisualShape = BlockShapes.S617, SupportShape = BlockShapes.S617 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 26773];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Waterlogged switch {
                    true => 26773,
                    false => 26774,
                },
                Cardinal.East => Waterlogged switch {
                    true => 26775,
                    false => 26776,
                },
                Cardinal.South => Waterlogged switch {
                    true => 26777,
                    false => 26778,
                },
                Cardinal.West => Waterlogged switch {
                    true => 26779,
                    false => 26780,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 26781,
                    false => 26782,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 26783,
                    false => 26784,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26773 => new LargeAmethystBudBlock(Identifier, Cardinal.North, true),
            26774 => new LargeAmethystBudBlock(Identifier, Cardinal.North, false),
            26775 => new LargeAmethystBudBlock(Identifier, Cardinal.East, true),
            26776 => new LargeAmethystBudBlock(Identifier, Cardinal.East, false),
            26777 => new LargeAmethystBudBlock(Identifier, Cardinal.South, true),
            26778 => new LargeAmethystBudBlock(Identifier, Cardinal.South, false),
            26779 => new LargeAmethystBudBlock(Identifier, Cardinal.West, true),
            26780 => new LargeAmethystBudBlock(Identifier, Cardinal.West, false),
            26781 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, true),
            26782 => new LargeAmethystBudBlock(Identifier, Cardinal.Up, false),
            26783 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, true),
            26784 => new LargeAmethystBudBlock(Identifier, Cardinal.Down, false),
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
