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
public record WaxedOxidizedCopperChainBlock(Identifier Identifier, Axis Axis, bool Waterlogged) : IBlock, IAxisAligned, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_oxidized_copper_chain", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_oxidized_copper_chain", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_oxidized_copper_chain");
    private static readonly BlockStateInfo I0 = new(5f, 0, 1, PushReaction.PushPull, 0, "chain", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S505, BlockShapes.S505, BlockShapes.S1, BlockShapes.S1, BlockShapes.S505, BlockShapes.S505);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S331, CollisionShape = BlockShapes.S331, VisualShape = BlockShapes.S331, SupportShape = BlockShapes.S331 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S331, CollisionShape = BlockShapes.S331, VisualShape = BlockShapes.S331, SupportShape = BlockShapes.S331 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S506, CollisionShape = BlockShapes.S506, VisualShape = BlockShapes.S506, SupportShape = BlockShapes.S506 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S506, CollisionShape = BlockShapes.S506, VisualShape = BlockShapes.S506, SupportShape = BlockShapes.S506 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 10028];

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

    public IBlock WithAxis(Axis axis) => this with { Axis = axis };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => Waterlogged switch {
                    true => 10028,
                    false => 10029,
                },
                Axis.Y => Waterlogged switch {
                    true => 10030,
                    false => 10031,
                },
                Axis.Z => Waterlogged switch {
                    true => 10032,
                    false => 10033,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10028 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.X, true),
            10029 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.X, false),
            10030 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Y, true),
            10031 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Y, false),
            10032 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Z, true),
            10033 => new WaxedOxidizedCopperChainBlock(Identifier, Axis.Z, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.Contains("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("axis", new StringTag(Axis.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
