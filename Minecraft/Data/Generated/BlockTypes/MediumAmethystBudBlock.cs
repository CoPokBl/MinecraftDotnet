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
public record MediumAmethystBudBlock(Identifier Identifier, Cardinal Facing, bool Waterlogged) : IBlock, IDirectional, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.medium_amethyst_bud", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:medium_amethyst_bud", BlockInfo.VanillaOnly, "minecraft:blocks/medium_amethyst_bud");
    private static readonly BlockStateInfo I0 = new(1.5f, 2, 1, PushReaction.Popped, 24, "large_amethyst_bud", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S644, BlockShapes.S644, BlockShapes.S1, BlockShapes.S1, BlockShapes.S644, BlockShapes.S644);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S645, CollisionShape = BlockShapes.S645, VisualShape = BlockShapes.S645, SupportShape = BlockShapes.S645 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S645, CollisionShape = BlockShapes.S645, VisualShape = BlockShapes.S645, SupportShape = BlockShapes.S645 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S646, CollisionShape = BlockShapes.S646, VisualShape = BlockShapes.S646, SupportShape = BlockShapes.S646 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S646, CollisionShape = BlockShapes.S646, VisualShape = BlockShapes.S646, SupportShape = BlockShapes.S646 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S647, CollisionShape = BlockShapes.S647, VisualShape = BlockShapes.S647, SupportShape = BlockShapes.S647 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S647, CollisionShape = BlockShapes.S647, VisualShape = BlockShapes.S647, SupportShape = BlockShapes.S647 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S648, CollisionShape = BlockShapes.S648, VisualShape = BlockShapes.S648, SupportShape = BlockShapes.S648 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S648, CollisionShape = BlockShapes.S648, VisualShape = BlockShapes.S648, SupportShape = BlockShapes.S648 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S649, CollisionShape = BlockShapes.S649, VisualShape = BlockShapes.S649, SupportShape = BlockShapes.S649 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S649, CollisionShape = BlockShapes.S649, VisualShape = BlockShapes.S649, SupportShape = BlockShapes.S649 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 26785];

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
                    true => 26785,
                    false => 26786,
                },
                Cardinal.East => Waterlogged switch {
                    true => 26787,
                    false => 26788,
                },
                Cardinal.South => Waterlogged switch {
                    true => 26789,
                    false => 26790,
                },
                Cardinal.West => Waterlogged switch {
                    true => 26791,
                    false => 26792,
                },
                Cardinal.Up => Waterlogged switch {
                    true => 26793,
                    false => 26794,
                },
                Cardinal.Down => Waterlogged switch {
                    true => 26795,
                    false => 26796,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26785 => new MediumAmethystBudBlock(Identifier, Cardinal.North, true),
            26786 => new MediumAmethystBudBlock(Identifier, Cardinal.North, false),
            26787 => new MediumAmethystBudBlock(Identifier, Cardinal.East, true),
            26788 => new MediumAmethystBudBlock(Identifier, Cardinal.East, false),
            26789 => new MediumAmethystBudBlock(Identifier, Cardinal.South, true),
            26790 => new MediumAmethystBudBlock(Identifier, Cardinal.South, false),
            26791 => new MediumAmethystBudBlock(Identifier, Cardinal.West, true),
            26792 => new MediumAmethystBudBlock(Identifier, Cardinal.West, false),
            26793 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, true),
            26794 => new MediumAmethystBudBlock(Identifier, Cardinal.Up, false),
            26795 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, true),
            26796 => new MediumAmethystBudBlock(Identifier, Cardinal.Down, false),
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
