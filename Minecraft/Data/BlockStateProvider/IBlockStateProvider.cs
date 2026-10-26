using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.BlockStateProvider;

/// <summary>
/// A named <c>BlockStateProvider</c>, which world generation features and block transformers both
/// refer to.
/// </summary>
/// <remarks>
/// Kept as the tag it arrived as. What a provider means is decided by whatever runs it, world
/// generation on a server or a tool prediction on a client, and the protocol layer only carries it.
/// </remarks>
public interface IBlockStateProvider : IProtocolType {
    public CompoundTag Data { get; }

    public CompoundTag ToNbt() {
        return Data;
    }

    public static IBlockStateProvider FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleBlockStateProvider(ident, tag);
    }
}

public record SimpleBlockStateProvider(Identifier Identifier, CompoundTag Data) : IBlockStateProvider;
