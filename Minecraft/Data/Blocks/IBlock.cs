using Minecraft.Data.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public interface IBlock : IProtocolType {
    /// <summary>What the block is regardless of which state it is in.</summary>
    public BlockInfo Info { get; }

    /// <summary>What this particular state is, which is where the shapes live.</summary>
    public BlockStateInfo StateInfo { get; }

    public Identifier Category { get; }
    public float ExplosionResistance { get; }
    public float Friction { get; }
    public float SpeedFactor { get; }
    public float JumpFactor { get; }
    public float BounceRestitution { get; }
    public bool Gravity { get; }
    public string TranslationKey { get; }
    public Identifier? BlockEntity { get; }
    public Identifier? Item { get; }

    public float Hardness { get; }
    public bool Solid { get; }
    public bool Liquid { get; }
    public bool Air { get; }
    public bool Occludes { get; }
    public bool RequiresTool { get; }
    public bool BlocksMotion { get; }
    public int LightEmission { get; }
    public int LightDampening { get; }
    public bool Replaceable { get; }
    public string SoundType { get; }
    public ICollisionBox BlockShape { get; }
    public ICollisionBox CollisionShape { get; }
    public ICollisionBox OcclusionShape { get; }
    public ICollisionBox InteractionShape { get; }
    public ICollisionBox VisualShape { get; }
    public ICollisionBox SupportShape { get; }
    public bool RedstoneConductor { get; }
    public bool SignalSource { get; }
    public bool Flammable { get; }
    public PushReaction PushReaction { get; }
    public int MapColorId { get; }
    public bool CanRespawnIn { get; }
    public bool RandomlyTicking { get; }
    public bool Suffocating { get; }
    public bool ViewBlocking { get; }
    public bool SpawnTerrainParticles { get; }
    public bool PathfindableLand { get; }
    public bool PathfindableWater { get; }
    public bool PathfindableAir { get; }
    public NoteBlockInstrument Instrument { get; }
    public Identifier? Fluid { get; }

    public uint StateId { get; }

    public IBlock WithState(uint state);
    public IBlock WithState(CompoundTag properties);
    public CompoundTag ToStateNbt();

    /// <summary><c>BlockState.isValidSpawn</c>: whether the given entity type can spawn on this state.</summary>
    public bool IsValidSpawn(IEntityType type) {
        return StateInfo.IsValidSpawn(type);
    }

    /// <summary>
    /// How far this block's shapes are moved at <paramref name="position"/>. Bamboo, dripstone and
    /// the plants are placed off centre by a hash of where they sit, and the shapes here are the
    /// ones before that happens.
    /// </summary>
    public Vec3<double> ShapeOffset(Vec3<int> position) {
        return Info.ShapeOffset(position);
    }

    public bool Equals(IBlock? other) {
        return other?.StateId == StateId;
    }

    public static bool Equals(IBlock? b1, IBlock? b2) {
        if (b1 is null && b2 is null) return true;
        if (b1 is null || b2 is null) return false;
        return b1.Equals(b2);
    }

    public static bool SimilarTo(IBlock? b1, IBlock? b2) {
        if (b1 is null && b2 is null) return true;
        if (b1 is null || b2 is null) return false;
        return b1.Identifier == b2.Identifier;
    }

    public string ToString() {
        return $"{Identifier}[{ToStateNbt().ToJsonString()}]";
    }
}
