using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Timelines;

public interface ITimeline : IProtocolType {
    public CompoundTag Data { get; }

    public INbtTag ToNbt() {
        return Data.WithName(null);
    }

    public static ITimeline FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleTimeline(ident, tag);
    }
}
