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
public record DarkPrismarineSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock, ISlabTyped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_prismarine_slab", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_prismarine_slab", BlockInfo.VanillaOnly, "minecraft:blocks/dark_prismarine_slab");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.PushPull, 31, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, false, null, "minecraft:water", BlockShapes.S88, BlockShapes.S88, BlockShapes.S1, BlockShapes.S88, BlockShapes.S88, BlockShapes.S88);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89, SupportShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S89, CollisionShape = BlockShapes.S89, OcclusionShape = BlockShapes.S89, VisualShape = BlockShapes.S89, SupportShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 15, RedstoneConductor = true, Suffocating = true, BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S79, OcclusionShape = BlockShapes.S79, VisualShape = BlockShapes.S79, SupportShape = BlockShapes.S79 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 15, RedstoneConductor = true, Suffocating = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S79, OcclusionShape = BlockShapes.S79, VisualShape = BlockShapes.S79, SupportShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 14733];

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

    public IBlock WithType(SlabType type) => this with { Type = type };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 14733,
                    false => 14734,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 14735,
                    false => 14736,
                },
                SlabType.Double => Waterlogged switch {
                    true => 14737,
                    false => 14738,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14733 => new DarkPrismarineSlabBlock(Identifier, SlabType.Top, true),
            14734 => new DarkPrismarineSlabBlock(Identifier, SlabType.Top, false),
            14735 => new DarkPrismarineSlabBlock(Identifier, SlabType.Bottom, true),
            14736 => new DarkPrismarineSlabBlock(Identifier, SlabType.Bottom, false),
            14737 => new DarkPrismarineSlabBlock(Identifier, SlabType.Double, true),
            14738 => new DarkPrismarineSlabBlock(Identifier, SlabType.Double, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Type = properties.Contains("type") ? SlabTypeExtensions.FromString(properties["type"].GetString()) : Type,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(Type.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
