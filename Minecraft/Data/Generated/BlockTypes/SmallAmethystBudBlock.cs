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
public record SmallAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock, IDirectional, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.small_amethyst_bud", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:small_amethyst_bud", BlockInfo.VanillaOnly, "minecraft:blocks/small_amethyst_bud");
    private static readonly BlockStateInfo I0 = new(1.5f, 1, 1, PushReaction.Popped, 24, "small_amethyst_bud", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S925, BlockShapes.S925, BlockShapes.S1, BlockShapes.S1, BlockShapes.S925, BlockShapes.S925);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S926, CollisionShape = BlockShapes.S926, VisualShape = BlockShapes.S926, SupportShape = BlockShapes.S926 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S926, CollisionShape = BlockShapes.S926, VisualShape = BlockShapes.S926, SupportShape = BlockShapes.S926 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S927, CollisionShape = BlockShapes.S927, VisualShape = BlockShapes.S927, SupportShape = BlockShapes.S927 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S927, CollisionShape = BlockShapes.S927, VisualShape = BlockShapes.S927, SupportShape = BlockShapes.S927 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S928, CollisionShape = BlockShapes.S928, VisualShape = BlockShapes.S928, SupportShape = BlockShapes.S928 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S928, CollisionShape = BlockShapes.S928, VisualShape = BlockShapes.S928, SupportShape = BlockShapes.S928 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S929, CollisionShape = BlockShapes.S929, VisualShape = BlockShapes.S929, SupportShape = BlockShapes.S929 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S929, CollisionShape = BlockShapes.S929, VisualShape = BlockShapes.S929, SupportShape = BlockShapes.S929 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S930, CollisionShape = BlockShapes.S930, VisualShape = BlockShapes.S930, SupportShape = BlockShapes.S930 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S930, CollisionShape = BlockShapes.S930, VisualShape = BlockShapes.S930, SupportShape = BlockShapes.S930 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 26797];

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
                    true => 26797,
                    false => 26798,
                },
                Cardinal.East => Waterlogged switch {
                    true => 26799,
                    false => 26800,
                },
                Cardinal.South => Waterlogged switch {
                    true => 26801,
                    false => 26802,
                },
                Cardinal.West => Waterlogged switch {
                    true => 26803,
                    false => 26804,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 26805,
                    false => 26806,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 26807,
                    false => 26808,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26797 => new SmallAmethystBudBlock(Identifier, Cardinal.North, true),
            26798 => new SmallAmethystBudBlock(Identifier, Cardinal.North, false),
            26799 => new SmallAmethystBudBlock(Identifier, Cardinal.East, true),
            26800 => new SmallAmethystBudBlock(Identifier, Cardinal.East, false),
            26801 => new SmallAmethystBudBlock(Identifier, Cardinal.South, true),
            26802 => new SmallAmethystBudBlock(Identifier, Cardinal.South, false),
            26803 => new SmallAmethystBudBlock(Identifier, Cardinal.West, true),
            26804 => new SmallAmethystBudBlock(Identifier, Cardinal.West, false),
            26805 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, true),
            26806 => new SmallAmethystBudBlock(Identifier, Cardinal.Up, false),
            26807 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, true),
            26808 => new SmallAmethystBudBlock(Identifier, Cardinal.Down, false),
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
