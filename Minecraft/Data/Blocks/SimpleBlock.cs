using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Shapes;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

/// <summary>A block with exactly one state, which is most of them.</summary>
public record SimpleBlock(Identifier Identifier, uint StateId, BlockInfo Info, BlockStateInfo StateInfo) : IBlock {
    public Identifier Category => Info.Category;
    public float ExplosionResistance => Info.ExplosionResistance;
    public float Friction => Info.Friction;
    public float SpeedFactor => Info.SpeedFactor;
    public float JumpFactor => Info.JumpFactor;
    public float BounceRestitution => Info.BounceRestitution;
    public bool Gravity => Info.Gravity;
    public string TranslationKey => Info.TranslationKey;
    public Identifier? BlockEntity => Info.BlockEntity;
    public Identifier? Item => Info.Item;

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

    public IBlock WithState(uint state) {
        if (state != StateId) {
            throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state ID.");
        }
        return this;
    }

    public IBlock WithState(CompoundTag properties) {
        return this;
    }

    public CompoundTag ToStateNbt() {
        return new CompoundTag();
    }
}
