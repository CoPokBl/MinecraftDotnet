using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Shapes;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

/// <summary>
/// A block whose only property is whether it is waterlogged. The two states get their own
/// <see cref="BlockStateInfo"/> because waterlogging changes how much light the block takes.
/// </summary>
public record WaterloggableBlock(Identifier Identifier, uint StateIdAirLogged, uint StateIdWaterlogged,
    bool Waterlogged, BlockInfo Info, BlockStateInfo AirLoggedInfo, BlockStateInfo WaterloggedInfo)
    : IBlock, IWaterlogged {

    public uint StateId => Waterlogged ? StateIdWaterlogged : StateIdAirLogged;
    public BlockStateInfo StateInfo => Waterlogged ? WaterloggedInfo : AirLoggedInfo;

    public float ExplosionResistance => Info.ExplosionResistance;
    public float Friction => Info.Friction;
    public float SpeedFactor => Info.SpeedFactor;
    public float JumpFactor => Info.JumpFactor;
    public float BounceRestitution => Info.BounceRestitution;
    public float FallDistanceReduction => Info.FallDistanceReduction;
    public bool Gravity => Info.Gravity;
    public string TranslationKey => Info.TranslationKey;
    public Identifier? BlockEntity => Info.BlockEntity;
    public Identifier? Item => Info.Item;
    public Identifier? LootTable => Info.LootTable;
    public (int Min, int Max)? Experience => Info.Experience;

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

    public IBlock WithState(uint state) {
        if (state == StateIdWaterlogged) {
            return this with {
                Waterlogged = true
            };
        }
        if (state == StateIdAirLogged) {
            return this with {
                Waterlogged = false
            };
        }
        throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state ID.");
    }

    public IBlock WithState(CompoundTag properties) {
        return this with {
            Waterlogged = properties["waterlogged"].GetString() == "true"
        };
    }

    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower())));
    }

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };
}
