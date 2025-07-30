using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public record WaterloggableBlock(Identifier Identifier, int ProtocolId, uint StateIdAirLogged, uint StateIdWaterlogged, bool Waterlogged, Identifier Category,
    double Hardness, double ExplosionResistance, double Friction, double SpeedFactor, double JumpFactor, bool Solid, 
    bool Liquid, bool Occludes, bool RequiresTool, int LightEmission, bool Replaceable, string SoundType, 
    Identifier? BlockEntity, Identifier? Item, ICollisionBox CollisionShape, ICollisionBox OcclusionShape, 
    ICollisionBox BlockShape, ICollisionBox InteractionShape, ICollisionBox VisualShape, bool RedstoneConductor, 
    bool SignalSource,  bool Flammable, PushReaction PushReaction, int MapColorId, string TranslationKey, bool CanRespawnIn) : IBlock {
    
    public uint StateId => Waterlogged ? StateIdWaterlogged : StateIdAirLogged;

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
        return new CompoundTag(null, 
            new StringTag("waterlogged", Waterlogged.ToString().ToLower()));
    }
}
