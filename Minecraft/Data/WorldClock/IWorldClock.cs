using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.WorldClock;

/// <summary>
/// A clock the world's time can be attached to. Vanilla's <c>WorldClock</c> is an empty record —
/// the entry exists purely so that dimensions and
/// <see cref="Minecraft.Packets.Play.ClientBound.ClientBoundUpdateTimePacket"/> have something to
/// point at — so there's nothing to carry beyond the identifier.
/// </summary>
public interface IWorldClock : IProtocolType {
    public INbtTag ToNbt() {
        return new CompoundTag();
    }

    public static IWorldClock FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleWorldClock(ident);
    }
}
