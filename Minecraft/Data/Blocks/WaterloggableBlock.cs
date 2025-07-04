using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Blocks;

public record WaterloggableBlock(Identifier Identifier, uint StateIdAirLogged, uint StateIdWaterlogged, bool Waterlogged) : IBlock {
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
}
