using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ResinBrickSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:slab", "block.minecraft.resin_brick_slab", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:resin_brick_slab", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 1, PushReaction.Normal, 37, "resin_bricks", NoteBlockInstrument.Basedrum, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S86, BlockShapes.S86, BlockShapes.S1, BlockShapes.S86, BlockShapes.S86);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, OcclusionShape = BlockShapes.S87, VisualShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, OcclusionShape = BlockShapes.S87, VisualShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 15, RedstoneConductor = true, Suffocating = true, ViewBlocking = true, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, OcclusionShape = BlockShapes.S77, VisualShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 15, RedstoneConductor = true, Suffocating = true, ViewBlocking = true, Fluid = null, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, OcclusionShape = BlockShapes.S77, VisualShape = BlockShapes.S77 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 9003];

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
            return Type switch {
                SlabType.Top => Waterlogged switch {
                    true => 9003,
                    false => 9004,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 9005,
                    false => 9006,
                },
                SlabType.Double => Waterlogged switch {
                    true => 9007,
                    false => 9008,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9003 => new ResinBrickSlabBlock(Identifier, SlabType.Top, true),
            9004 => new ResinBrickSlabBlock(Identifier, SlabType.Top, false),
            9005 => new ResinBrickSlabBlock(Identifier, SlabType.Bottom, true),
            9006 => new ResinBrickSlabBlock(Identifier, SlabType.Bottom, false),
            9007 => new ResinBrickSlabBlock(Identifier, SlabType.Double, true),
            9008 => new ResinBrickSlabBlock(Identifier, SlabType.Double, false),
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
