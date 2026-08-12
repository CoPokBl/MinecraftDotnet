using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceSlabBlock(Identifier Identifier, SlabType Type, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:slab", "block.minecraft.spruce_slab", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:spruce_slab", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, null, "minecraft:water", BlockShapes.S86, BlockShapes.S86, BlockShapes.S1, BlockShapes.S86, BlockShapes.S86);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { ValidSpawnFor = [], BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, OcclusionShape = BlockShapes.S87, VisualShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, ValidSpawnFor = [], Fluid = null, BlockShape = BlockShapes.S87, CollisionShape = BlockShapes.S87, OcclusionShape = BlockShapes.S87, VisualShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I4 = I0 with { LightDampening = 15, RedstoneConductor = true, Suffocating = true, ViewBlocking = true, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, OcclusionShape = BlockShapes.S77, VisualShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 15, Flammable = true, RedstoneConductor = true, Suffocating = true, ViewBlocking = true, Fluid = null, BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, OcclusionShape = BlockShapes.S77, VisualShape = BlockShapes.S77 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 13336];

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
                    true => 13336,
                    false => 13337,
                },
                SlabType.Bottom => Waterlogged switch {
                    true => 13338,
                    false => 13339,
                },
                SlabType.Double => Waterlogged switch {
                    true => 13340,
                    false => 13341,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13336 => new SpruceSlabBlock(Identifier, SlabType.Top, true),
            13337 => new SpruceSlabBlock(Identifier, SlabType.Top, false),
            13338 => new SpruceSlabBlock(Identifier, SlabType.Bottom, true),
            13339 => new SpruceSlabBlock(Identifier, SlabType.Bottom, false),
            13340 => new SpruceSlabBlock(Identifier, SlabType.Double, true),
            13341 => new SpruceSlabBlock(Identifier, SlabType.Double, false),
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
