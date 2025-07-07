using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public record SimpleBlock(Identifier Identifier, uint StateId, 
    double Hardness, double ExplosionResistance, double Friction, double SpeedFactor, double JumpFactor, bool Solid, 
    bool Liquid, bool Occludes, bool RequiresTool, int LightEmission, bool Replaceable, string SoundType, 
    Identifier? BlockEntity, Identifier? Item, ICollisionBox CollisionShape, ICollisionBox OcclusionShape, 
    ICollisionBox BlockShape, ICollisionBox InteractionShape, ICollisionBox VisualShape, bool RedstoneConductor, 
    bool SignalSource,  bool Flammable, PushReaction PushReaction, int MapColorId, string TranslationKey, bool CanRespawnIn) : IBlock {

    public IBlock WithState(uint state) {
        if (state != StateId) {
            throw new ArgumentOutOfRangeException(nameof(state), state, "Invalid state ID.");
        }
        return this;
    }

    public IBlock WithState(CompoundTag properties) {
        return this;
    }
}
