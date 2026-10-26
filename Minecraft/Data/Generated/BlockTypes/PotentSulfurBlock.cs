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
public record PotentSulfurBlock(Identifier Identifier, PotentSulfurState PotentSulfurState) : IBlock, IPotentSulfured {
    private static readonly BlockInfo Data = new("block.minecraft.potent_sulfur", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:potent_sulfur", "minecraft:potent_sulfur", BlockInfo.VanillaOnly, "minecraft:blocks/potent_sulfur");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 15, PushReaction.PushPull, 30, "potent_sulfur", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

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

    public IBlock WithPotentSulfurState(PotentSulfurState potentSulfurState) => this with { PotentSulfurState = potentSulfurState };


    public uint StateId {
        get {
            return PotentSulfurState switch {
                PotentSulfurState.Dry => 28045,
                PotentSulfurState.Wet => 28046,
                PotentSulfurState.Dormant => 28047,
                PotentSulfurState.Erupting => 28048,
                PotentSulfurState.Continuous => 28049,
                _ => throw new ArgumentOutOfRangeException(nameof(PotentSulfurState), PotentSulfurState, "Unknown value for property potent_sulfur_state.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            28045 => new PotentSulfurBlock(Identifier, PotentSulfurState.Dry),
            28046 => new PotentSulfurBlock(Identifier, PotentSulfurState.Wet),
            28047 => new PotentSulfurBlock(Identifier, PotentSulfurState.Dormant),
            28048 => new PotentSulfurBlock(Identifier, PotentSulfurState.Erupting),
            28049 => new PotentSulfurBlock(Identifier, PotentSulfurState.Continuous),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            PotentSulfurState = properties.Contains("potent_sulfur_state") ? PotentSulfurStateExtensions.FromString(properties["potent_sulfur_state"].GetString()) : PotentSulfurState,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("potent_sulfur_state", new StringTag(PotentSulfurState.ToName()))
        );
    }
    
}
