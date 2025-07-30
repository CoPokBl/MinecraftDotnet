using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public interface IBlock : IProtocolType {
    public Identifier Category { get; }
    public double Hardness { get; }
    public double ExplosionResistance { get; }
    public double Friction { get; }
    public double SpeedFactor { get; }
    public double JumpFactor { get; }
    public bool Solid { get; }
    public bool Liquid { get; }
    public bool Occludes { get; }
    public bool RequiresTool { get; }
    public int LightEmission { get; }
    public bool Replaceable { get; }
    public string SoundType { get; }
    public Identifier? BlockEntity { get; }
    public Identifier? Item { get; }
    public ICollisionBox BlockShape { get; }
    public ICollisionBox CollisionShape { get; }
    public ICollisionBox OcclusionShape { get; }
    public ICollisionBox InteractionShape { get; }
    public ICollisionBox VisualShape { get; }
    public bool RedstoneConductor { get; }
    public bool SignalSource { get; }
    public bool Flammable { get; }
    public PushReaction PushReaction { get; }
    public int MapColorId { get; }
    public string TranslationKey { get; }
    public bool CanRespawnIn { get; }
    
    public uint StateId { get; }

    public IBlock WithState(uint state);
    public IBlock WithState(CompoundTag properties);
    public CompoundTag ToStateNbt();

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
}
